import pandas as pd
from PyQt5.QtCore import *
from app_main_ui import MainWindowUI
from app_main_model import MainWindowModel
from app_gui_sis import NewWindowSIS
from app_gui_sir import NewWindowSIR
from app_gui_seair import NewWindowSEAIR
from app_gui_vseiqr import NewWindowVSEIQR
from models_data import *
from models_graph import *
from functools import partial

class MainWindowLogic(MainWindowUI, MainWindowModel):
    """Clase que maneja la lógica de la aplicación"""
    timer_finished = pyqtSignal()

    def __init__(self):
        MainWindowUI.__init__(self)
        MainWindowModel.__init__(self)

        # Conectar eventos de la interfaz a métodos
        self.button_group.buttonClicked[int].connect(self.on_checkbox_selected)
        self.button1.clicked.connect(lambda: self.on_button_clicked(1))
        self.button2.clicked.connect(lambda: self.on_button_clicked(2))
        self.button3.clicked.connect(lambda: self.on_button_clicked(3))
        self.button4.clicked.connect(lambda: self.on_button_clicked(4))

    def on_checkbox_selected(self, selected_option):
        self.model_selection_cb = selected_option
        self.model_in_construction = False
        if selected_option == 1:
            model = "SIS"
            self.ode_file = f"{model}_ODEs.xlsx"
            self.expected_columns = {'S', 'I'}
            self.selected_model_instance = self.selected_model_sis
            self.selected_model_instance_visual = sisGraph(self.selected_model_instance)
            self.label1.setText(f"Estatus: Modelo {model} seleccionado.")
        elif selected_option == 2:
            model = "SIR"
            self.ode_file = f"{model}_ODEs.xlsx"
            self.expected_columns = set(model)
            self.selected_model_instance = self.selected_model_sir
            self.selected_model_instance_visual = sirGraph(self.selected_model_instance)
            self.label1.setText(f"Estatus: Modelo {model} seleccionado.")
        elif selected_option == 3:
            model = "SEAIR"
            self.ode_file = f"{model}_ODEs.xlsx"
            self.expected_columns = set(model)
            self.selected_model_instance = self.selected_model_seair
            self.selected_model_instance_visual = seairGraph(self.selected_model_instance)
            self.label1.setText(f"Estatus: Modelo {model} seleccionado.")
        elif selected_option == 4:
            model = "VSEIQR"
            self.ode_file = f"{model}_ODEs.xlsx"
            self.expected_columns = {'S','V','E','Ia','Q','Is','R','M'}
            self.selected_model_instance = self.selected_model_vseiqr
            self.selected_model_instance_visual = vseiqrGraph(self.selected_model_instance)
            self.label1.setText(f"Estatus: Modelo {model} seleccionado.")
        """elif selected_option == 4:
            self.model_in_construction = True  # Modelo en construcción
            self.selected_model_instance = None  # No asignar instancia de modelo
            self.label1.setText(f"Estatus: Modelo en construcción.")"""
        self.selected_model_instance_data = ModelData(self.selected_model_instance)
            
    def on_button_clicked(self, menu):
        # Verificar si un modelo fue seleccionado
        if not hasattr(self, 'selected_model_instance') or self.model_in_construction:
            self.label1.setText("Error: Por favor selecciona un modelo válido primero.")
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
            self.timer_finished.connect(self.selected_model_instance_visual.show_model)
    
        elif menu == 2:
            self.tiempo_espera("Creando archivo")
            #self.timer_finished.connect(self.selected_model_instance_data.save_to_csv(self.ode_file))
            #self.selected_model_instance_data.save_to_csv(self.ode_file)
            self.timer_finished.connect(lambda: self.selected_model_instance_data.save_to_csv(self.ode_file))

        elif menu == 3:
            try:
                self.tiempo_espera("Cargando Archivos")
                simulation_data = self.selected_model_instance_data.load_from_csv()

                # Validación de columnas
                actual_columns = set(simulation_data.columns)
                if actual_columns != self.expected_columns:
                    raise ValueError(f"El archivo 'estadisticas.csv' debe contener únicamente las columnas {self.expected_columns}. "
                                    f"\nColumnas encontradas: {actual_columns}")

                self.timer_finished.connect(lambda: self.selected_model_instance_visual.modelvsSim(self.ode_file))

            except FileNotFoundError as e:
                self.timer_finished.connect(lambda e=e: self.label1.setText(f"Error: No se pudo encontrar el archivo {e.filename}"))

            except pd.errors.EmptyDataError:
                self.timer_finished.connect(lambda: self.label1.setText("Error: El archivo está vacío."))

            except ValueError as e:
                self.timer_finished.connect(lambda e=e: self.label1.setText(f"Error: {e}"))

            except Exception as e:
                self.timer_finished.connect(lambda e=e: self.label1.setText(f"Error inesperado: {str(e)}"))
        
        elif menu == 4:
            if self.model_selection_cb == 1:
                self.open_new_window(NewWindowSIS, self.update_model_sis)
            elif self.model_selection_cb == 2:
                self.open_new_window(NewWindowSIR, self.update_model_sir)
            elif self.model_selection_cb == 3:
                self.open_new_window(NewWindowSEAIR, self.update_model_seair)
            elif self.model_selection_cb == 4:
                self.open_new_window(NewWindowVSEIQR, self.update_model_vseiqr)
            
            """else:
                self.label1.setText("Error: En construcción")"""
    

    def tiempo_espera(self, mensaje="Cargando", puntos=3):
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

    def open_new_window(self, NewWindow, update_model):
        # Crear una nueva ventana
        self.new_window = NewWindow(self)
        self.new_window.model_modified.connect(update_model)
        self.new_window.show()

    