from PyQt5.QtWidgets import *
from PyQt5.QtCore import *
from PyQt5.QtGui import QPixmap

class NewWindowSEAIR(QWidget):
    model_modified = pyqtSignal()
    def __init__(self, main_window):
        super().__init__()
        self.main_window = main_window
        self.setWindowTitle("Modificar modelo SEAIR")
        self.setGeometry(150, 150, 590, 520)
        self.style()

        # Etiqueta en la nueva ventana
        label = QLabel("Introduce los nuevos valores", self)
        label.move(20, 15)

        # Cajas de texto (QLineEdit) para ingresar los parámetros
        self.beta_input = QLineEdit(self)
        self.beta_input.setPlaceholderText(f"Transmision beta = {self.main_window.selected_model_seair.beta }")
        self.beta_input.move(20, 50)
        self.beta_input.resize(170, 25)

        self.delta_input = QLineEdit(self)
        self.delta_input.setPlaceholderText(f"Modificador delta = {self.main_window.selected_model_seair.delta}")
        self.delta_input.move(210, 50)
        self.delta_input.resize(170, 25)

        self.gamma_input = QLineEdit(self)
        self.gamma_input.setPlaceholderText(f"Inmunidad gamma = {self.main_window.selected_model_seair.gamma}")
        self.gamma_input.move(400,50)
        self.gamma_input.resize(170, 25)

        self.mu_E_input = QLineEdit(self)
        self.mu_E_input.setPlaceholderText(f"Progresion-EI mu_E = {self.main_window.selected_model_seair.mu_E}")
        self.mu_E_input.move(20, 80)
        self.mu_E_input.resize(170, 25)
        
        self.mu_I_input = QLineEdit(self)
        self.mu_I_input.setPlaceholderText(f"Recup-IR mu_I = {self.main_window.selected_model_seair.mu_I}")
        self.mu_I_input.move(210, 80)
        self.mu_I_input.resize(170, 25)

        self.mu_A_input = QLineEdit(self)
        self.mu_A_input.setPlaceholderText(f"Recup-AR mu_A = {self.main_window.selected_model_seair.mu_A}")
        self.mu_A_input.move(400, 80)
        self.mu_A_input.resize(170, 25)

        self.p_input = QLineEdit(self)
        self.p_input.setPlaceholderText(f"Proporcion-E-IA p = {self.main_window.selected_model_seair.p}")
        self.p_input.move(20, 110)
        self.p_input.resize(170, 25)

        self.S0_input = QLineEdit(self)
        self.S0_input.setPlaceholderText(f"Suceptibles S0 = {self.main_window.selected_model_seair.S0}")
        self.S0_input.move(210, 110)
        self.S0_input.resize(170, 25)

        self.E0_input = QLineEdit(self)
        self.E0_input.setPlaceholderText(f"Expuestos E0 = {self.main_window.selected_model_seair.E0}")
        self.E0_input.move(400, 110)
        self.E0_input.resize(170, 25)

        self.A0_input = QLineEdit(self)
        self.A0_input.setPlaceholderText(f"Asintomaticos A0 = {self.main_window.selected_model_seair.A0}")
        self.A0_input.move(20, 140)
        self.A0_input.resize(170, 25)

        self.I0_input = QLineEdit(self)
        self.I0_input.setPlaceholderText(f"Infectados I0 = {self.main_window.selected_model_seair.I0}")
        self.I0_input.move(210, 140)
        self.I0_input.resize(170, 25)

        self.R0_input = QLineEdit(self)
        self.R0_input.setPlaceholderText(f"Recuperados R0 = {self.main_window.selected_model_seair.R0}")
        self.R0_input.move(400, 140)
        self.R0_input.resize(170, 25)

        self.t_sim_input = QLineEdit(self)
        self.t_sim_input.setPlaceholderText(f"Tiempo t_sim = {self.main_window.selected_model_seair.t_sim}")
        self.t_sim_input.move(20, 170)
        self.t_sim_input.resize(170, 25)

        # Imagen
        image_label = QLabel(self)
        pixmap = QPixmap("./Imagenes/SEAIR.png")  # Reemplaza con la ruta de tu imagen
        image_label.setPixmap(pixmap)
        image_label.setScaledContents(True)  # Ajusta la imagen al tamaño del QLabel
        image_label.setGeometry(150, 205, 300, 260)

        save_button = QPushButton("Guardar", self)
        save_button.move(175, 475)
        save_button.setFixedSize(250, 30) 
        save_button.clicked.connect(self.mod)
    
    def style(self):
        self.setStyleSheet("""
            NewWindowSEAIR {
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
        if not self.rev_TextBox(self.beta_input, 'beta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.delta_input, 'delta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.gamma_input, 'gamma'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.mu_E_input, 'mu_E'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.mu_I_input, 'mu_I'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.mu_A_input, 'mu_A'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.p_input, 'p'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.S0_input, 'S0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.E0_input, 'E0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.A0_input, 'A0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.I0_input, 'I0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.R0_input, 'R0'):
            return  # Si hay un error, no seguir

        if not self.rev_TextBox(self.t_sim_input, 't_sim'):
            return  # Si hay un error, no seguir

        # Emitir señal de modificación y cerrar la ventana
        self.model_modified.emit()
        self.main_window.label1.setText(f"Modelo SEAIR modificado.")
        self.close()
        
    def rev_TextBox(self, TB_input, output_attribute_name):
        # Verificar si el campo de texto tiene un valor ingresado
        if TB_input.text().strip():  # Si no está vacío
            try:
                # Convertir el valor a float
                value = float(TB_input.text())
                setattr(self.main_window.selected_model_seair, output_attribute_name, value)  # Asignar el valor al atributo del modelo
            except ValueError:
                self.main_window.label1.setText("Error: Por favor ingrese valores numéricos válidos.")
                return False  # Retornar False si ocurre un error
        else:
            # Si el campo está vacío, mantener el valor actual del modelo
            current_value = getattr(self.main_window.selected_model_seair, output_attribute_name)
            setattr(self.main_window.selected_model_seair, output_attribute_name, current_value)  # No cambiar el valor

        return True  # Retornar True si la operación fue exitosa

        


