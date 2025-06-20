from PyQt5.QtWidgets import *
from PyQt5.QtCore import *

class MainWindowUI(QMainWindow):
    """Clase que define la interfaz gráfica"""
    def __init__(self):
        super().__init__()
        self.setWindowTitle("EpiSolver")
        self.resize(700, 500)
        self.style()

        # Layout principal (vertical)
        self.main_layout = QVBoxLayout()

        # Inicializar elementos de la interfaz
        self.init_checkboxes()
        self.init_buttons()
        self.init_status_label()

        # Crear contenedor principal
        container = QWidget()
        container.setLayout(self.main_layout)
        self.setCentralWidget(container)

    def style(self):
        """Estilo de la aplicación"""
        self.setStyleSheet("""
            QMainWindow {
                background-color: #000000;
            }
            QLabel, QCheckBox, QPushButton {
                color: #FFFFFF;
                font-size: 14px;
                padding: 5px;
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

    def init_checkboxes(self):
        """Inicializa los checkboxes"""
        checkbox_layout = QHBoxLayout()
        self.checkbox1 = QCheckBox("SIS")
        self.checkbox2 = QCheckBox("SIR")
        self.checkbox3 = QCheckBox("SEAIR")
        self.checkbox4 = QCheckBox("VSEIQR")

        # Grupo de botones para exclusividad
        self.button_group = QButtonGroup(self)
        self.button_group.setExclusive(True)
        self.button_group.addButton(self.checkbox1, 1)
        self.button_group.addButton(self.checkbox2, 2)
        self.button_group.addButton(self.checkbox3, 3)
        self.button_group.addButton(self.checkbox4, 4)

        # Agregar checkboxes al layout
        checkbox_layout.addWidget(self.checkbox1)
        checkbox_layout.addWidget(self.checkbox2)
        checkbox_layout.addWidget(self.checkbox3)
        checkbox_layout.addWidget(self.checkbox4)

        # Añadir al layout principal
        self.main_layout.addLayout(checkbox_layout)

    def init_buttons(self):
        """Inicializa los botones"""
        button_layout = QHBoxLayout()
        self.button1 = QPushButton("Ver grafica\nsolucion numerica")
        self.button2 = QPushButton("Crear solucion\nnumerica")
        self.button3 = QPushButton("Solucion numerica\nvs Simulación")
        self.button4 = QPushButton("Modificar modelo\nnumerico")

        # Tamaño fijo
        for button in [self.button1, self.button2, self.button3, self.button4]:
            button.setFixedSize(130, 40)

        # Agregar botones al layout
        button_layout.addWidget(self.button1)
        button_layout.addWidget(self.button2)
        button_layout.addWidget(self.button3)
        button_layout.addWidget(self.button4)

        # Añadir al layout principal
        self.main_layout.addLayout(button_layout)

    def init_status_label(self):
        """Inicializa la etiqueta de estado"""
        label_layout = QHBoxLayout()
        self.label1 = QLabel("Estatus: Esperando Seleccion del Usuario...")
        self.label1.setAlignment(Qt.AlignCenter)
        label_layout.addWidget(self.label1)
        self.main_layout.addLayout(label_layout)
