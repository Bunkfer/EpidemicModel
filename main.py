from PyQt5.QtWidgets import QApplication
from app_gui import MainWindow

app = QApplication([])
window = MainWindow()
window.show()
app.exec()
