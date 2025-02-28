import numpy as np
from scipy.integrate import solve_ivp
import matplotlib.pyplot as plt
import pandas as pd
from app_models import Main_model

class sisM(Main_model):
    def __init__(self, alpha = 0.0001, beta = 0.4, S0 = 8500, I0 = 1500, t_sim = 200):
        # Parámetros
        self.alpha = alpha  # Tasa de transmisión
        self.beta = beta    # Tasa de recuperación

        # Condiciones iniciales
        self.S0 = S0      # No. Susceptibles iniciales
        self.I0 = I0         # No. Infectados iniciales
        self.Y0 = [S0, I0]

        # Tiempo de simulación (valores enteros de 0 a 200)
        self.t_sim = t_sim
        self.tspan = (0, self.t_sim)
        self.t_eval = np.arange(0, self.t_sim+1, 1) 

    # Solución numérica del modelo SIS
    def SIS_model(self, t, Y):
        S, I = Y
        dSdt = -self.alpha * S * I + self.beta * I
        dIdt = self.alpha * S * I - self.beta * I
        return [dSdt, dIdt]

    def model_toCsv(self):
        # Resolver el sistema de EDOs
        solution = solve_ivp(self.SIS_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)  # Tiempos enteros
        S = np.round(solution.y[0]).astype(int)  # Población Susceptible entera
        I = np.round(solution.y[1]).astype(int)  # Población Infectada entera

        # Guardar los resultados en un archivo Excel
        data = pd.DataFrame({
            "Tiempo": t,
            "S": S,
            "I": I
        })
        data.to_excel("SIS_ODEs.xlsx", index=False)

    def show_model(self):
        # Resolver el sistema de EDOs
        solution = solve_ivp(self.SIS_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)  # Tiempos enteros
        S = np.round(solution.y[0]).astype(int)  # Población Susceptible entera
        I = np.round(solution.y[1]).astype(int)  # Población Infectada entera

        # Graficar los resultados
        plt.figure(figsize=(10, 6))
        plt.plot(t, S, 'b', label='Susceptible',linestyle="-", marker="o", markersize=3)
        plt.plot(t, I, 'r', label='Infectious',linestyle="-", marker="o", markersize=3)
        plt.legend()
        plt.xlabel('Time')
        plt.ylabel('Population')
        plt.title('SIS Epidemic Model')
        plt.grid(True)
        plt.tight_layout()
        plt.show()
    
    def modelvsSim(self,ode_data, simulation_data):
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
            "Diff_I": abs(ode_data_200["I"] - simulation_data_200["I"])
        })

        # Graficar los resultados
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
