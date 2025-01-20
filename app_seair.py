import numpy as np
from scipy.integrate import solve_ivp
import matplotlib.pyplot as plt
import pandas as pd
from app_models import Main_model

class seairM(Main_model):
    def __init__(self, beta=0.00009, delta=0.001, gamma=0.32, mu_E=0.12, mu_I=0.1, mu_A=0.3, 
                 p=0.6, S0=8000, E0=1000, A0=100, I0=400, R0=0, t_sim=200):
        # Parámetros
        self.beta = beta     # Tasa de transmisión

        self.delta = delta   # Modificador de transmisión por asintomáticos
        self.mu_E = mu_E     # Tasa de progresión de expuestos a infectados
        self.p = p           # Proporción de expuestos que desarrollan síntomas

        self.mu_I = mu_I     # Tasa de recuperación de infectados
        self.mu_A = mu_A     # Tasa de recuperación de asintomáticos
        self.gamma = gamma   # Agregamos tasa de inmunidad

        # Condiciones iniciales
        self.S0 = S0
        self.E0 = E0
        self.A0 = A0
        self.I0 = I0
        self.R0 = R0
        self.Y0 = [S0, E0, A0, I0, R0]

        # Tiempo de simulación
        self.tspan = (0, t_sim)
        self.t_eval = np.arange(0, t_sim + 1, 1)

    # Solución numérica del modelo SEAIR
    def SEAIR_model(self, t, Y):
        S, E, A, I, R = Y
        dSdt = -self.beta * S * (self.delta * A + I) + self.gamma * R # --> Recuerda que agregaste (gamma*R)
        dEdt = self.beta * S * (self.delta * A + I) - self.mu_E * E
        dAdt = (1 - self.p) * self.mu_E * E - self.mu_A * A
        dIdt = self.p * self.mu_E * E - self.mu_I * I
        dRdt = self.mu_A * A + self.mu_I * I - self.gamma * R         # --> Recuerda que agregaste (gamma*R)
        return [dSdt, dEdt, dAdt, dIdt, dRdt]

    def model_toCsv(self):
        # Resolver el sistema de EDOs
        solution = solve_ivp(self.SEAIR_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)
        S = np.round(solution.y[0]).astype(int)
        E = np.round(solution.y[1]).astype(int)
        A = np.round(solution.y[2]).astype(int)
        I = np.round(solution.y[3]).astype(int)
        R = np.round(solution.y[4]).astype(int)

        # Guardar los resultados en un archivo Excel
        data = pd.DataFrame({
            "Tiempo": t,
            "S": S,
            "E": E,
            "A": A,
            "I": I,
            "R": R
        })
        data.to_excel("SEAIR_ODEs.xlsx", index=False)

    def show_model(self):
        # Resolver el sistema de EDOs
        solution = solve_ivp(self.SEAIR_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)
        S = np.round(solution.y[0]).astype(int)
        E = np.round(solution.y[1]).astype(int)
        A = np.round(solution.y[2]).astype(int)
        I = np.round(solution.y[3]).astype(int)
        R = np.round(solution.y[4]).astype(int)

        # Graficar los resultados
        plt.figure(figsize=(10, 6))
        plt.plot(t, S, 'b', label='Susceptibles (S)', linestyle="-", marker="o", markersize=3)
        plt.plot(t, E, 'orange', label='Expuestos (E)', linestyle="-", marker="o", markersize=3)
        plt.plot(t, A, 'purple', label='Asintomáticos (A)', linestyle="-", marker="o", markersize=3)
        plt.plot(t, I, 'r', label='Infectados (I)', linestyle="-", marker="o", markersize=3)
        plt.plot(t, R, 'g', label='Recuperados (R)', linestyle="-", marker="o", markersize=3)
        plt.legend()
        plt.xlabel('Tiempo')
        plt.ylabel('Población')
        plt.title('Modelo Epidemiológico SEAIR')
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
