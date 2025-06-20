import pandas as pd

class ModelData:
    def __init__(self, model_data_instance):
        self.data = model_data_instance
        self.data = model_data_instance.results  # Carga automáticamente los datos resueltos

    def save_to_csv(self, filename):
        df = pd.DataFrame(self.data)
        df.to_excel(f"./models/{filename}", index=False)

    @staticmethod
    def load_from_excel(filename):
        return pd.read_excel(f"./models/{filename}")

    @staticmethod
    def load_from_csv():
        return pd.read_csv(f"./models/Sim_Result.csv")