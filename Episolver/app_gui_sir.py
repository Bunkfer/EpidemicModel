from PyQt5.QtWidgets import *
from PyQt5.QtCore import *
from PyQt5.QtGui import QPixmap

class NewWindowSIR(QWidget):
    model_modified = pyqtSignal()
    def __init__(self, main_window):
        super().__init__()
        self.main_window = main_window
        self.setWindowTitle("Modificar modelo SIR")
        self.setGeometry(150, 150, 400, 400)
        self.style()

        # Etiqueta en la nueva ventana
        label = QLabel("Introduce los nuevos valores", self)
        label.move(20, 15)

        # Cajas de texto (QLineEdit) para ingresar los parámetros
        self.alpha_input = QLineEdit(self)
        self.alpha_input.setPlaceholderText(f"Transmision alpha = {self.main_window.selected_model_sir.alpha }")
        self.alpha_input.move(20, 50)
        self.alpha_input.resize(170, 25)

        self.beta_input = QLineEdit(self)
        self.beta_input.setPlaceholderText(f"Infectados beta = {self.main_window.selected_model_sir.beta}")
        self.beta_input.move(210, 50)
        self.beta_input.resize(170, 25)

        self.gamma_input = QLineEdit(self)
        self.gamma_input.setPlaceholderText(f"Inmunidad gamma = {self.main_window.selected_model_sir.gamma}")
        self.gamma_input.move(20,80)
        self.gamma_input.resize(170, 25)

        self.s0_input = QLineEdit(self)
        self.s0_input.setPlaceholderText(f"Suceptibles S0 = {self.main_window.selected_model_sir.S0}")
        self.s0_input.move(210, 80)
        self.s0_input.resize(170, 25)
        
        self.i0_input = QLineEdit(self)
        self.i0_input.setPlaceholderText(f"Infectados I0 = {self.main_window.selected_model_sir.I0}")
        self.i0_input.move(20, 110)
        self.i0_input.resize(170, 25)

        self.r0_input = QLineEdit(self)
        self.r0_input.setPlaceholderText(f"Recuperados R0 = {self.main_window.selected_model_sir.R0}")
        self.r0_input.move(210, 110)
        self.r0_input.resize(170, 25)

        self.t_sim_input = QLineEdit(self)
        self.t_sim_input.setPlaceholderText(f"Tiempo t_sim = {self.main_window.selected_model_sir.t_sim}")
        self.t_sim_input.move(20, 140)
        self.t_sim_input.resize(170, 25)

        # Imagen
        image_label = QLabel(self)
        pixmap = QPixmap("./img/SIR.png")  # Reemplaza con la ruta de tu imagen
        image_label.setPixmap(pixmap)
        image_label.setScaledContents(True)  # Ajusta la imagen al tamaño del QLabel
        image_label.setGeometry(85, 170, 225, 160)  # Ajusta las dimensiones según sea necesario

        save_button = QPushButton("Guardar", self)
        save_button.move(75, 340)
        save_button.setFixedSize(250, 30) 
        save_button.clicked.connect(self.mod)
    
    def style(self):
        self.setStyleSheet("""
            NewWindowSIR {
                background-color: #000000;
            }
            QLabel, QCheckBox, QPushButton{
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

    def mod(self):
        # Verificar y actualizar alpha
        if not self.rev_TextBox(self.alpha_input, 'alpha'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.beta_input, 'beta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.gamma_input, 'gamma'):
            return  # Si hay un error, no seguir
        
        # Verificar y actualizar S0
        if not self.rev_TextBox(self.s0_input, 'S0'):
            return  # Si hay un error, no seguir

        # Verificar y actualizar I0
        if not self.rev_TextBox(self.i0_input, 'I0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.r0_input, 'R0'):
            return  # Si hay un error, no seguir

        if not self.rev_TextBox(self.t_sim_input, 't_sim'):
            return  # Si hay un error, no seguir

        # Emitir señal de modificación y cerrar la ventana
        self.model_modified.emit()
        self.main_window.label1.setText(f"Modelo SIR modificado.")
        self.close()
        
    def rev_TextBox(self, TB_input, output_attribute_name):
        # Verificar si el campo de texto tiene un valor ingresado
        if TB_input.text().strip():  # Si no está vacío
            try:
                # Convertir el valor a float
                value = float(TB_input.text())
                setattr(self.main_window.selected_model_sir, output_attribute_name, value)  # Asignar el valor al atributo del modelo
            except ValueError:
                self.main_window.label1.setText("Error: Por favor ingrese valores numéricos válidos.")
                return False  # Retornar False si ocurre un error
        else:
            # Si el campo está vacío, mantener el valor actual del modelo
            current_value = getattr(self.main_window.selected_model_sir, output_attribute_name)
            setattr(self.main_window.selected_model_sir, output_attribute_name, current_value)  # No cambiar el valor

        return True  # Retornar True si la operación fue exitosa

        


