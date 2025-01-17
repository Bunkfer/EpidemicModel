from PyQt5.QtWidgets import *
from PyQt5.QtCore import *
from app_sir import sirM
from app_sis import sisM
import pandas as pd
from functools import partial

class MainWindow(QMainWindow):
    timer_finished = pyqtSignal()
    def __init__(self):
        super().__init__()
        self.setWindowTitle("EpiSolver")

        #Personalizacion
        self.resize(700, 500)
        self.style()
        
        # Layout principal (vertical)
        main_layout = QVBoxLayout()
        
        # Formas
        self.Check_box(main_layout)
        self.Buttons(main_layout)
        self.Status_label(main_layout)
        
        # Crear el contenedor principal
        container = QWidget()
        container.setLayout(main_layout)
        self.setCentralWidget(container)

    def style(self):
        self.setStyleSheet("""
            QMainWindow {
                background-color: #000000;
            }
            QLabel, QCheckBox, QPushButton {
                color: #FFFFFF;
                font-size: 14px;
            }
            QPushButton {
                background-color: #444444;
                border: 1px solid #FFFFFF;
                border-radius: 5px;
                padding: 5px;
            }
            QPushButton:hover {
                background-color: #555555;
            }
            QPushButton:pressed {
                background-color: #222222;
            }
        """)

    def Check_box(self, main_layout):
        # Layout para los checkboxes (horizontal)
        checkbox_layout = QHBoxLayout()
        
        # Crear 3 checkboxes
        self.checkbox1 = QCheckBox("SIS")
        self.checkbox2 = QCheckBox("SIR")
        self.checkbox3 = QCheckBox("SEAIR")

        # Crear un grupo para hacerlos exclusivos
        button_group = QButtonGroup(self)
        button_group.setExclusive(True)  # Permitir solo uno seleccionado
        
        # Agregar checkboxes al grupo
        button_group.addButton(self.checkbox1, 1)
        button_group.addButton(self.checkbox2, 2)
        button_group.addButton(self.checkbox3, 3)

        # Conectar la señal de selección a un método
        button_group.buttonClicked[int].connect(self.on_checkbox_selected)
            
        # Agregar checkboxes al layout horizontal
        checkbox_layout.addWidget(self.checkbox1)
        checkbox_layout.addWidget(self.checkbox2)
        checkbox_layout.addWidget(self.checkbox3)
        
        # Agregar el layout horizontal al layout principal
        main_layout.addLayout(checkbox_layout)
    
    def Buttons(self, main_layout):
        # Layout para los botones (horizontal)
        button_layout = QHBoxLayout()

        # Crear 3 botones
        self.button1 = QPushButton("Ver grafica")
        self.button2 = QPushButton("Crear solucion\nnumerica")
        self.button3 = QPushButton("Solucion numerica\nvs Simulación")

        # Definir tamaño fijo para los botones
        self.button1.setFixedSize(150, 40)  # Ancho: 150, Alto: 40
        self.button2.setFixedSize(150, 40)
        self.button3.setFixedSize(150, 40)

        # Conectar botones a métodos
        self.button1.clicked.connect(lambda: self.on_button_clicked(1))
        self.button2.clicked.connect(lambda: self.on_button_clicked(2))
        self.button3.clicked.connect(lambda: self.on_button_clicked(3))

        # Agregar botones al layout horizontal
        button_layout.addWidget(self.button1)
        button_layout.addWidget(self.button2)
        button_layout.addWidget(self.button3)

        # Agregar el layout de botones al layout principal
        main_layout.addLayout(button_layout)

    def Status_label(self, main_layout):
        label_layout = QHBoxLayout()
        self.label1 = QLabel("Estatus: Esperando Seleccion del Usuario...")
        self.label1.setAlignment(Qt.AlignCenter)
        label_layout.addWidget(self.label1)
        main_layout.addLayout(label_layout)

    def on_checkbox_selected(self, selected_option):
        if selected_option == 1:
            model = "SIS"
            self.ode_file = f"{model}_ODEs.xlsx"
            self.expected_columns = {'S', 'I'}
            self.selected_model_instance = sisM()
            self.label1.setText(f"Estatus: Modelo {model} seleccionado.")
        elif selected_option == 2:
            model = "SIR"
            self.ode_file = f"{model}_ODEs.xlsx"
            self.expected_columns = set(model)
            self.selected_model_instance = sirM()
            self.label1.setText(f"Estatus: Modelo {model} seleccionado.")
        elif selected_option == 3:
            self.label1.setText(f"Under Construction")
            
    def on_button_clicked(self, menu):
        # Verificar si un modelo fue seleccionado
        if not hasattr(self, 'selected_model_instance'):
            self.label1.setText("Error: Por favor selecciona un modelo primero.")
            return

        # Desconectar conexiones previas de la señal timer_finished
        try:
            self.timer_finished.disconnect()
        except (TypeError, RuntimeError):
            pass

        # Asegurar que el temporizador no esté activo
        if hasattr(self, "timer") and self.timer.isActive():
            self.timer.stop()

        if menu == 1:
            self.tiempo_espera(mensaje="Creando gráfica")
            self.timer_finished.connect(self.selected_model_instance.show_model)
        elif menu == 2:
            self.tiempo_espera("Creando archivo")
            self.timer_finished.connect(self.selected_model_instance.model_toCsv)
        elif menu == 3:
            try:
                self.tiempo_espera("Cargando Archivos")
                # Carga de archivos
                ode_data = pd.read_excel(self.ode_file)
                simulation_data = pd.read_csv(r"C:\OnedriveOut\Maestria\Tesis\Proyecto\estadisticas.csv")

                # Validación de columnas
                actual_columns = set(simulation_data.columns)
                if actual_columns != self.expected_columns:
                    raise ValueError(f"El archivo 'estadisticas.csv' debe contener únicamente las columnas {self.expected_columns}. "
                                    f"\nColumnas encontradas: {actual_columns}")

                self.timer_finished.connect(lambda: self.selected_model_instance.modelvsSim(ode_data, simulation_data))

            except FileNotFoundError as e:
                self.timer_finished.connect(lambda e=e: self.label1.setText(f"Error: No se pudo encontrar el archivo {e.filename}"))

            except pd.errors.EmptyDataError:
                self.timer_finished.connect(lambda: self.label1.setText("Error: El archivo está vacío."))

            except ValueError as e:
                self.timer_finished.connect(lambda e=e: self.label1.setText(f"Error: {e}"))

            except Exception as e:
                self.timer_finished.connect(lambda e=e: self.label1.setText(f"Error inesperado: {str(e)}"))

    def tiempo_espera(self, mensaje="Cargando", puntos=4):
        self.label1.setText(f"Estatus: {mensaje}")  # Mensaje inicial
        self.current_dots = 0  # Contador para los puntos
        self.max_dots = puntos  # Máximo número de puntos

        # Crear un QTimer para actualizar los puntos
        self.timer = QTimer(self)
        self.timer.timeout.connect(partial(self.update_dots, mensaje))   # Conectar al método para actualizar
        self.timer.start(500)  # Actualizar cada 500 ms (0.5 segundos)

    def update_dots(self, mensaje):
        # Agregar un punto al mensaje
        self.current_dots += 1
        self.label1.setText(f"Estatus: {mensaje}{'.' * self.current_dots}")

        # Detener el temporizador una vez alcanzado el número máximo de puntos
        if self.current_dots >= self.max_dots:
            self.timer.stop()
            self.timer_finished.emit()