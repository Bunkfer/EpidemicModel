import pandas as pd

class ModelData:
    def __init__(self, model_data_instance):
        self.data = model_data_instance
        self.data = model_data_instance.results  # Carga automáticamente los datos resueltos

    def save_to_csv(self, filename):
        df = pd.DataFrame(self.data)
        df.to_excel(filename, index=False)

    @staticmethod
    def load_from_excel(filename):
        """Carga datos desde un archivo Excel."""
        return pd.read_excel(filename)

    @staticmethod
    def load_from_csv():
        """Carga datos desde un archivo CSV."""
        return pd.read_csv(r"C:\OnedriveOut\Maestria\Tesis\Proyecto\estadisticas.csv")