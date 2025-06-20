from PyQt5.QtWidgets import QApplication
from app_main_logic import MainWindowLogic

app = QApplication([])
window = MainWindowLogic()
window.show()
app.exec()
