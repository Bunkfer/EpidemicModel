import matplotlib.pyplot as plt
from models_data import *
from models_super import *

class sisGraph(Main_graph):
    def __init__(self, sis_instance):
        self.t = sis_instance.results["Tiempo"]
        self.S = sis_instance.results["S"]
        self.I = sis_instance.results["I"]

    def show_model(self):
        plt.figure(figsize=(10, 6))
        plt.plot(self.t, self.S, 'b', label='Susceptible', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.I, 'r', label='Infectious', linestyle="-", marker="o", markersize=3)
        plt.legend()
        plt.xlabel('Time')
        plt.ylabel('Population')
        plt.title('SIS Epidemic Model')
        plt.grid(True)
        plt.tight_layout()
        plt.show()

    def modelvsSim(self, ode_file):
        # Cargar datos de los archivos
        ode_data = ModelData.load_from_excel(ode_file)
        simulation_data = ModelData.load_from_csv()

        # Limitar los datos a los primeros 200 puntos
        ode_data_200 = ode_data.head(200)
        simulation_data_200 = simulation_data.head(200)

        # Comparación de datos
        comp = pd.DataFrame({
            "Time": range(200),
            "ODE_S": ode_data_200["S"],
            "Sim_S": simulation_data_200["S"],
            "Diff_S": abs(ode_data_200["S"] - simulation_data_200["S"]),
            "ODE_I": ode_data_200["I"],
            "Sim_I": simulation_data_200["I"],
            "Diff_I": abs(ode_data_200["I"] - simulation_data_200["I"])
        })

        # Graficar la comparación
        plt.figure(figsize=(10, 6))

        # Graficar susceptibles
        plt.plot(comp["Time"], comp["ODE_S"], label="ODE Susceptible", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_S"], label="Sim Susceptible", linestyle="--", marker="x", markersize=3)

        # Graficar infectados
        plt.plot(comp["Time"], comp["ODE_I"], label="ODE Infectious", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_I"], label="Sim Infectious", linestyle="--", marker="x", markersize=3)

        # Configurar el gráfico
        plt.title("Comparación de Resultados: Modelo ODE vs Simulación C#")
        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.legend()
        plt.grid(True)
        plt.tight_layout()

        # Mostrar la gráfica
        plt.show()

class sirGraph(Main_graph):
    def __init__(self, sir_instance):
        self.t = sir_instance.results["Tiempo"]
        self.S = sir_instance.results["S"]
        self.I = sir_instance.results["I"]
        self.R = sir_instance.results["R"]

    def show_model(self):
        # Graficar los resultados
        plt.figure(figsize=(10, 6))
        plt.plot(self.t, self.S, 'b', label='Susceptibles (S)', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.I, 'r', label='Infectados (I)', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.R, 'g', label='Recuperados (R)', linestyle="-", marker="o", markersize=3)
        plt.legend()
        plt.xlabel('Tiempo')
        plt.ylabel('Población')
        plt.title('Modelo Epidemiológico SIR')
        plt.grid(True)
        plt.tight_layout()
        plt.show()

    def modelvsSim(self, ode_file):
        # Cargar datos de los archivos
        ode_data = ModelData.load_from_excel(ode_file)
        simulation_data = ModelData.load_from_csv()

        # Limitar los datos a los primeros 200 puntos
        ode_data_200 = ode_data.head(200)
        simulation_data_200 = simulation_data.head(200)

        # Crear una nueva columna que calcule la diferencia absoluta entre los modelos
        comp = pd.DataFrame({
            "Time": range(200),
            "ODE_S": ode_data_200["S"],
            "Sim_S": simulation_data_200["S"],
            "Diff_S": abs(ode_data_200["S"] - simulation_data_200["S"]),
            "ODE_I": ode_data_200["I"],
            "Sim_I": simulation_data_200["I"],
            "Diff_I": abs(ode_data_200["I"] - simulation_data_200["I"]),
            "ODE_R": ode_data_200["R"],
            "Sim_R": simulation_data_200["R"],
            "Diff_R": abs(ode_data_200["R"] - simulation_data_200["R"])
        })

        # Graficar los resultados
        plt.figure(figsize=(10, 6))

        # Graficar susceptibles
        plt.plot(comp["Time"], comp["ODE_S"], label="ODE Susceptible", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_S"], label="Sim Susceptible", linestyle="--", marker="x", markersize=3)

        # Graficar infectados
        plt.plot(comp["Time"], comp["ODE_I"], label="ODE Infectious", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_I"], label="Sim Infectious", linestyle="--", marker="x", markersize=3)

        # Graficar recuperados
        plt.plot(comp["Time"], comp["ODE_R"], label="ODE Recovered", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_R"], label="Sim Recovered", linestyle="--", marker="x", markersize=3)

        # Configurar el gráfico
        plt.title("Comparación de Resultados: Modelo ODE vs Simulación")
        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.legend()
        plt.grid(True)
        plt.tight_layout()

        # Mostrar la gráfica
        plt.show()

class seairGraph(Main_graph):
    def __init__(self, seair_instance):
        self.t = seair_instance.results["Tiempo"]
        self.S = seair_instance.results["S"]
        self.E = seair_instance.results["E"]
        self.A = seair_instance.results["A"]
        self.I = seair_instance.results["I"]
        self.R = seair_instance.results["R"]

    def show_model(self):
        # Graficar los resultados
        plt.figure(figsize=(10, 6))
        plt.plot(self.t, self.S, 'b', label='Susceptibles (S)', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.E, 'orange', label='Expuestos (E)', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.A, 'purple', label='Asintomáticos (A)', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.I, 'r', label='Infectados (I)', linestyle="-", marker="o", markersize=3)
        plt.plot(self.t, self.R, 'g', label='Recuperados (R)', linestyle="-", marker="o", markersize=3)
        plt.legend()
        plt.xlabel('Tiempo')
        plt.ylabel('Población')
        plt.title('Modelo Epidemiológico SEAIR')
        plt.grid(True)
        plt.tight_layout()
        plt.show()

    def modelvsSim(self, ode_file):
        # Cargar datos de los archivos
        ode_data = ModelData.load_from_excel(ode_file)
        simulation_data = ModelData.load_from_csv()

        # Limitar los datos a los primeros 200 puntos
        ode_data_200 = ode_data.head(200)
        simulation_data_200 = simulation_data.head(200)

        # Crear una nueva columna que calcule la diferencia absoluta entre los modelos
        comp = pd.DataFrame({
            "Time": range(200),
            "ODE_S": ode_data_200["S"],
            "Sim_S": simulation_data_200["S"],
            "Diff_S": abs(ode_data_200["S"] - simulation_data_200["S"]),
            "ODE_E": ode_data_200["E"],
            "Sim_E": simulation_data_200["E"],
            "Diff_E": abs(ode_data_200["E"] - simulation_data_200["E"]),
            "ODE_A": ode_data_200["A"],
            "Sim_A": simulation_data_200["A"],
            "Diff_A": abs(ode_data_200["A"] - simulation_data_200["A"]),
            "ODE_I": ode_data_200["I"],
            "Sim_I": simulation_data_200["I"],
            "Diff_I": abs(ode_data_200["I"] - simulation_data_200["I"]),
            "ODE_R": ode_data_200["R"],
            "Sim_R": simulation_data_200["R"],
            "Diff_R": abs(ode_data_200["R"] - simulation_data_200["R"])
        })

        # Graficar los resultados
        plt.figure(figsize=(10, 6))

        # Graficar susceptibles
        plt.plot(comp["Time"], comp["ODE_S"], label="ODE Susceptible", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_S"], label="Sim Susceptible", linestyle="--", marker="x", markersize=3)

        # Graficar expuestos
        plt.plot(comp["Time"], comp["ODE_E"], label="ODE Exposed", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_E"], label="Sim Exposed", linestyle="--", marker="x", markersize=3)

        # Graficar asintomáticos
        plt.plot(comp["Time"], comp["ODE_A"], label="ODE Asymptomatic", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_A"], label="Sim Asymptomatic", linestyle="--", marker="x", markersize=3)

        # Graficar infectados
        plt.plot(comp["Time"], comp["ODE_I"], label="ODE Infectious", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_I"], label="Sim Infectious", linestyle="--", marker="x", markersize=3)

        # Graficar recuperados
        plt.plot(comp["Time"], comp["ODE_R"], label="ODE Recovered", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_R"], label="Sim Recovered", linestyle="--", marker="x", markersize=3)

        # Configurar el gráfico
        plt.title("Comparación de Resultados: Modelo ODE vs Simulación")
        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.legend()
        plt.grid(True)
        plt.tight_layout()

        # Mostrar la gráfica
        plt.show()

class vseiqrGraph(Main_graph):
    def __init__(self, vseiqr_instance):
        self.t = vseiqr_instance.results["Tiempo"]
        self.S = vseiqr_instance.results["S"]
        self.V = vseiqr_instance.results["V"]
        self.E = vseiqr_instance.results["E"]
        self.I_A = vseiqr_instance.results["Ia"]
        self.Q = vseiqr_instance.results["Q"]
        self.I_S = vseiqr_instance.results["Is"]
        self.R = vseiqr_instance.results["R"]
        self.M = vseiqr_instance.results["M"]

    def show_model(self):
        # Crear figura con dos gráficos en columnas
        fig, axes = plt.subplots(nrows=1, ncols=2, figsize=(12, 6))

        # Colores diferentes para cada gráfico
        colors1 = ['#1f77b4', '#2ca02c', '#ff7f0e']  # Azul, Verde, Naranja para S, V, R
        colors2 = ['#d62728', '#9467bd', '#8c564b', '#56B4E9', '#7f7f7f']  # Rojo, Morado, Marrón, Celeste, Gris para E, I_A, Q, I_S, M

        # Primera gráfica con S, V, R
        axes[0].plot(self.t, self.S, label="S (Susceptibles)", color=colors1[0])
        axes[0].plot(self.t,self.V, label="V (Vacunados)", color=colors1[1])
        axes[0].plot(self.t, self.R, label="R (Recuperados)", color=colors1[2])
        axes[0].set_xlabel("Tiempo (días)")
        axes[0].set_ylabel("Población")
        axes[0].set_title("Estados S, V y R")
        axes[0].legend()
        axes[0].grid()

        # Segunda gráfica con E, I_A, Q, I_S, M
        axes[1].plot(self.t, self.E, label="E (Expuestos)", color=colors2[0])
        axes[1].plot(self.t, self.I_A, label="Ia (Asintomáticos)", color=colors2[1])
        axes[1].plot(self.t, self.Q, label="Q (Cuarentena)", color=colors2[2])
        axes[1].plot(self.t, self.I_S, label="Is (Sintomáticos)", color=colors2[3])
        axes[1].plot(self.t, self.M, label="M (Muertes)", color=colors2[4])
        axes[1].set_xlabel("Tiempo (días)")
        axes[1].set_ylabel("Población")
        axes[1].set_title("Estados E, Ia, Q, Is y M")
        axes[1].legend()
        axes[1].grid()

        plt.tight_layout()
        plt.show()

    def modelvsSim(self, ode_file):
        # Cargar datos de los archivos
        ode_data = ModelData.load_from_excel(ode_file)
        simulation_data = ModelData.load_from_csv()

        # Limitar los datos a los primeros 200 puntos
        ode_data_200 = ode_data.head(200)
        simulation_data_200 = simulation_data.head(200)

        # Crear DataFrame de comparación
        comp = pd.DataFrame({"Time": range(200)})
        variables = ["S", "V", "E", "Ia", "Q", "Is", "R", "M"]

        for var in variables:
            comp[f"ODE_{var}"] = ode_data_200[var]
            comp[f"Sim_{var}"] = simulation_data_200[var]

        # Crear la figura con dos gráficos
        fig, axes = plt.subplots(nrows=1, ncols=2, figsize=(14, 6))

        # Definir colores para cada grupo de estados
        colors1 = ['#1f77b4', '#2ca02c', '#ff7f0e']  # Azul, Verde, Naranja (S, V, R)
        colors2 = ['#d62728', '#9467bd', '#8c564b', '#56B4E9', '#7f7f7f']  # Rojo, Morado, Marrón, Celeste, Gris (E, I_A, Q, I_S, M)

        # Definir los grupos de estados
        group1 = ["S", "V", "R"]
        group2 = ["E", "Ia", "Q", "Is", "M"]

        # Gráfico 1: S, V, R
        for i, var in enumerate(group1):
            axes[0].plot(comp["Time"], comp[f"ODE_{var}"], label=f"ODE {var}", linestyle="-", marker="o", markersize=3, color=colors1[i])
            axes[0].plot(comp["Time"], comp[f"Sim_{var}"], label=f"Sim {var}", linestyle="--", marker="x", markersize=3, color=colors1[i])

        axes[0].set_xlabel("Tiempo (días)")
        axes[0].set_ylabel("Población")
        axes[0].set_title("Comparación de S, V y R")
        axes[0].legend()
        axes[0].grid()

        # Gráfico 2: E, I_A, Q, I_S, M
        for i, var in enumerate(group2):
            axes[1].plot(comp["Time"], comp[f"ODE_{var}"], label=f"ODE {var}", linestyle="-", marker="o", markersize=3, color=colors2[i])
            axes[1].plot(comp["Time"], comp[f"Sim_{var}"], label=f"Sim {var}", linestyle="--", marker="x", markersize=3, color=colors2[i])

        axes[1].set_xlabel("Tiempo (días)")
        axes[1].set_ylabel("Población")
        axes[1].set_title("Comparación de E, Ia, Q, Is y M")
        axes[1].legend()
        axes[1].grid()

        plt.tight_layout()
        plt.show()

"""class EpidemicGraph:
    def __init__(self, model_instance):
        self.data = model_instance.results  # Diccionario con datos del modelo
        self.t = self.data["Tiempo"]
        
        # Extraer las variables automáticamente sin importar el modelo
        self.variables = {key: self.data[key] for key in self.data if key != "Tiempo"}

    def show_model(self):
        plt.figure(figsize=(10, 6))

        for var_name, values in self.variables.items():
            plt.plot(self.t, values, label=var_name, linestyle="-", marker="o", markersize=3)

        plt.legend()
        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.title("Evolución del Modelo Epidemiológico")
        plt.grid(True)
        plt.tight_layout()
        plt.show()

    def modelvsSim(self, ode_file, sim_file):
        # Cargar datos desde archivos
        ode_data = ModelData.load_from_excel(ode_file)
        simulation_data = ModelData.load_from_csv(sim_file)

        # Limitar a los primeros 200 datos
        ode_data_200 = ode_data.head(200)
        simulation_data_200 = simulation_data.head(200)

        # Comparar automáticamente todas las variables
        comp = pd.DataFrame({"Time": range(200)})
        for var in self.variables.keys():
            if var in ode_data_200.columns and var in simulation_data_200.columns:
                comp[f"ODE_{var}"] = ode_data_200[var]
                comp[f"Sim_{var}"] = simulation_data_200[var]
                comp[f"Diff_{var}"] = abs(ode_data_200[var] - simulation_data_200[var])

        # Graficar comparación
        plt.figure(figsize=(10, 6))
        for var in self.variables.keys():
            if f"ODE_{var}" in comp.columns and f"Sim_{var}" in comp.columns:
                plt.plot(comp["Time"], comp[f"ODE_{var}"], label=f"ODE {var}", linestyle="-", marker="o", markersize=3)
                plt.plot(comp["Time"], comp[f"Sim_{var}"], label=f"Sim {var}", linestyle="--", marker="x", markersize=3)

        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.title("Comparación de Resultados: Modelo ODE vs Simulación")
        plt.legend()
        plt.grid(True)
        plt.tight_layout()
        plt.show()"""