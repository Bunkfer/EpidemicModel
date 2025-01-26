import numpy as np
from scipy.integrate import solve_ivp
import matplotlib.pyplot as plt
import pandas as pd
from app_models import Main_model

class sirM(Main_model):
    def __init__(self, alpha=0.0001, beta=0.12, gamma=0.08, S0=8500, I0=1500, R0=0, t_sim=200):
        # Parámetros
        self.alpha = alpha  # Tasa de transmisión
        self.beta = beta    # Tasa de recuperación
        self.gamma = gamma  # Tasa de pérdida de inmunidad

        # Condiciones iniciales
        self.S0 = S0
        self.I0 = I0
        self.R0 = R0
        self.Y0 = [S0, I0, R0]

        # Tiempo de simulación (valores enteros de 0 a 200)
        self.t_sim = t_sim
        self.tspan = (0, self.t_sim)
        self.t_eval = np.arange(0, self.t_sim + 1, 1)

    # Solución numérica del modelo SIR
    def SIR_model(self, t, Y):
        S, I, R = Y
        dSdt = -self.alpha * S * I + self.gamma * R
        dIdt = self.alpha * S * I - self.beta * I
        dRdt = self.beta * I - self.gamma * R
        return [dSdt, dIdt, dRdt]

    def model_toCsv(self):
        # Resolver el sistema de EDOs
        solution = solve_ivp(self.SIR_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)  # Tiempos enteros
        S = np.round(solution.y[0]).astype(int)  # Población Susceptible entera
        I = np.round(solution.y[1]).astype(int)  # Población Infectada entera
        R = np.round(solution.y[2]).astype(int)  # Población Recuperada entera

        # Guardar los resultados en un archivo Excel
        data = pd.DataFrame({
            "Tiempo": t,
            "S": S,
            "I": I,
            "R": R
        })
        data.to_excel("SIR_ODEs.xlsx", index=False)

    def show_model(self):
        # Resolver el sistema de EDOs
        solution = solve_ivp(self.SIR_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)  # Tiempos enteros
        S = np.round(solution.y[0]).astype(int)  # Población Susceptible entera
        I = np.round(solution.y[1]).astype(int)  # Población Infectada entera
        R = np.round(solution.y[2]).astype(int)  # Población Recuperada entera

        # Graficar los resultados
        plt.figure(figsize=(10, 6))
        plt.plot(t, S, 'b', label='Susceptibles (S)', linestyle="-", marker="o", markersize=3)
        plt.plot(t, I, 'r', label='Infectados (I)', linestyle="-", marker="o", markersize=3)
        plt.plot(t, R, 'g', label='Recuperados (R)', linestyle="-", marker="o", markersize=3)
        plt.legend()
        plt.xlabel('Tiempo')
        plt.ylabel('Población')
        plt.title('Modelo Epidemiológico SIR')
        plt.grid(True)
        plt.tight_layout()
        plt.show()

    def modelvsSim(self, ode_data, simulation_data):
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
