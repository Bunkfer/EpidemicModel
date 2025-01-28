from PyQt5.QtWidgets import *
from PyQt5.QtCore import *
from PyQt5.QtGui import QPixmap

class NewWindowVSEIQR(QWidget):
    model_modified = pyqtSignal()
    def __init__(self, main_window):
        super().__init__()
        self.main_window = main_window
        self.setWindowTitle("Modificar modelo VSEIQR")
        self.setGeometry(150, 150, 780, 800)
        self.style()

        # Etiqueta en la nueva ventana
        label = QLabel("Introduce los nuevos valores", self)
        label.move(20, 15)

        # Cajas de texto (QLineEdit) para ingresar los parámetros
        self.sigma_input = QLineEdit(self)
        self.sigma_input.setPlaceholderText(f"R-S σ = {self.main_window.selected_model_vseiqr.sigma }")
        self.sigma_input.move(20, 50)
        self.sigma_input.resize(170, 25)

        self.alpha_input = QLineEdit(self)
        self.alpha_input.setPlaceholderText(f"S-E α = {self.main_window.selected_model_vseiqr.alpha }")
        self.alpha_input.move(210, 50)
        self.alpha_input.resize(170, 25)

        self.tau_input = QLineEdit(self)
        self.tau_input.setPlaceholderText(f"V-S τ = {self.main_window.selected_model_vseiqr.tau }")
        self.tau_input.move(400, 50)
        self.tau_input.resize(170, 25)

        self.omega_input = QLineEdit(self)
        self.omega_input.setPlaceholderText(f"S-V ω = {self.main_window.selected_model_vseiqr.omega }")
        self.omega_input.move(590, 50)
        self.omega_input.resize(170, 25)

        self.zeta_input = QLineEdit(self)
        self.zeta_input.setPlaceholderText(f"E-Q ζ = {self.main_window.selected_model_vseiqr.zeta }")
        self.zeta_input.move(20,80)
        self.zeta_input.resize(170, 25)

        self.epsilon_input = QLineEdit(self)
        self.epsilon_input.setPlaceholderText(f"E-Is ϵ = {self.main_window.selected_model_vseiqr.epsilon }")
        self.epsilon_input.move(210,80)
        self.epsilon_input.resize(170, 25)

        self.delta_input = QLineEdit(self)
        self.delta_input.setPlaceholderText(f"E-Ia δ = {self.main_window.selected_model_vseiqr.delta }")
        self.delta_input.move(400,80)
        self.delta_input.resize(170, 25)

        self.eta_input = QLineEdit(self)
        self.eta_input.setPlaceholderText(f"Ia-R η = {self.main_window.selected_model_vseiqr.eta }")
        self.eta_input.move(590,80)
        self.eta_input.resize(170, 25)

        self.kappa_input = QLineEdit(self)
        self.kappa_input.setPlaceholderText(f"Is-Q κ = {self.main_window.selected_model_vseiqr.kappa }")
        self.kappa_input.move(20,110)
        self.kappa_input.resize(170, 25)

        self.rho_input = QLineEdit(self)
        self.rho_input.setPlaceholderText(f"Is-M ρ = {self.main_window.selected_model_vseiqr.rho }")
        self.rho_input.move(210,110)
        self.rho_input.resize(170, 25)

        self.theta_input = QLineEdit(self)
        self.theta_input.setPlaceholderText(f"Is-R θ = {self.main_window.selected_model_vseiqr.theta }")
        self.theta_input.move(400,110)
        self.theta_input.resize(170, 25)

        self.iota_input = QLineEdit(self)
        self.iota_input.setPlaceholderText(f"Q-R ι = {self.main_window.selected_model_vseiqr.iota }")
        self.iota_input.move(590,110)
        self.iota_input.resize(170, 25)

        self.nu_input = QLineEdit(self)
        self.nu_input.setPlaceholderText(f"Q-M ν = {self.main_window.selected_model_vseiqr.nu }")
        self.nu_input.move(20,140)
        self.nu_input.resize(170, 25)

        self.S0_input = QLineEdit(self)
        self.S0_input.setPlaceholderText(f"Suceptibles S0 = {self.main_window.selected_model_vseiqr.S0 }")
        self.S0_input.move(210,140)
        self.S0_input.resize(170, 25)

        self.V0_input = QLineEdit(self)
        self.V0_input.setPlaceholderText(f"Vacunados V0 = {self.main_window.selected_model_vseiqr.V0 }")
        self.V0_input.move(400,140)
        self.V0_input.resize(170, 25)

        self.E0_input = QLineEdit(self)
        self.E0_input.setPlaceholderText(f"Expuestos E0 = {self.main_window.selected_model_vseiqr.E0 }")
        self.E0_input.move(590,140)
        self.E0_input.resize(170, 25)

        self.I_A0_input = QLineEdit(self)
        self.I_A0_input.setPlaceholderText(f"Asintomaticos I_A0 = {self.main_window.selected_model_vseiqr.I_A0 }")
        self.I_A0_input.move(20,170)
        self.I_A0_input.resize(170, 25)

        self.Q0_input = QLineEdit(self)
        self.Q0_input.setPlaceholderText(f"Cuarentena Q0 = {self.main_window.selected_model_vseiqr.Q0 }")
        self.Q0_input.move(210,170)
        self.Q0_input.resize(170, 25)

        self.I_S0_input = QLineEdit(self)
        self.I_S0_input.setPlaceholderText(f"Sintomaticos I_S0 = {self.main_window.selected_model_vseiqr.I_S0 }")
        self.I_S0_input.move(400,170)
        self.I_S0_input.resize(170, 25)

        self.R0_input = QLineEdit(self)
        self.R0_input.setPlaceholderText(f"Recuperados R0 = {self.main_window.selected_model_vseiqr.R0 }")
        self.R0_input.move(590,170)
        self.R0_input.resize(170, 25)

        self.M0_input = QLineEdit(self)
        self.M0_input.setPlaceholderText(f"Muertos M0 = {self.main_window.selected_model_vseiqr.M0 }")
        self.M0_input.move(20,200)
        self.M0_input.resize(170, 25)

        self.t_sim_input = QLineEdit(self)
        self.t_sim_input.setPlaceholderText(f"Tiempo t_sim = {self.main_window.selected_model_vseiqr.t_sim }")
        self.t_sim_input.move(210,200)
        self.t_sim_input.resize(170, 25)

        # Imagen
        image_label = QLabel(self)
        pixmap = QPixmap("./Imagenes/VSEIQR.png")  # Reemplaza con la ruta de tu imagen
        image_label.setPixmap(pixmap)
        image_label.setScaledContents(True)  # Ajusta la imagen al tamaño del QLabel
        #image_label.setGeometry(150, 205, 300, 260)
        image_label.setGeometry(180, 245, 410, 495)

        save_button = QPushButton("Guardar", self)
        save_button.move(265, 755)  # Ajustado a múltiplos de 5.
        save_button.setFixedSize(250, 30) 
        save_button.clicked.connect(self.mod)
    
    def style(self):
        self.setStyleSheet("""
            NewWindowVSEIQR {
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
        if not self.rev_TextBox(self.sigma_input, 'sigma'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.alpha_input, 'alpha'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.tau_input, 'tau'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.omega_input, 'omega'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.zeta_input, 'zeta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.epsilon_input, 'epsilon'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.delta_input, 'delta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.eta_input, 'eta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.kappa_input, 'kappa'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.rho_input, 'rho'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.theta_input, 'theta'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.iota_input, 'iota'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.nu_input, 'nu'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.S0_input, 'S0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.V0_input, 'V0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.E0_input, 'E0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.I_A0_input, 'I_A0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.Q0_input, 'Q0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.I_S0_input, 'I_S0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.R0_input, 'R0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.M0_input, 'M0'):
            return  # Si hay un error, no seguir
        
        if not self.rev_TextBox(self.t_sim_input, 't_sim'):
            return  # Si hay un error, no seguir

        # Emitir señal de modificación y cerrar la ventana
        self.model_modified.emit()
        self.main_window.label1.setText(f"Modelo VSEIQR modificado.")
        self.close()
        
    def rev_TextBox(self, TB_input, output_attribute_name):
        # Verificar si el campo de texto tiene un valor ingresado
        if TB_input.text().strip():  # Si no está vacío
            try:
                # Convertir el valor a float
                value = float(TB_input.text())
                setattr(self.main_window.selected_model_vseiqr, output_attribute_name, value)  # Asignar el valor al atributo del modelo
            except ValueError:
                self.main_window.label1.setText("Error: Por favor ingrese valores numéricos válidos.")
                return False  # Retornar False si ocurre un error
        else:
            # Si el campo está vacío, mantener el valor actual del modelo
            current_value = getattr(self.main_window.selected_model_vseiqr, output_attribute_name)
            setattr(self.main_window.selected_model_vseiqr, output_attribute_name, current_value)  # No cambiar el valor

        return True  # Retornar True si la operación fue exitosa

        


