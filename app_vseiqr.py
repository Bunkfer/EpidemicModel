import numpy as np
from scipy.integrate import solve_ivp
import matplotlib.pyplot as plt
import pandas as pd
from app_models import Main_model

class vseiqrM(Main_model):
    def __init__(self, sigma=0.001, alpha=0.02, tau=0.05, omega=0.02, zeta=0.05,
                 epsilon=0.1, delta=0.05, eta=0.1, kappa=0.02, rho=0.05, theta=0.4,
                 iota=0.3, nu=0.02, S0=8500, V0=0, E0=1500,
                 I_A0=0, Q0=0, I_S0=0, R0=0, M0=0, t_sim=200):
        # Parámetros
        self.sigma = sigma          #Tasa de inmunidad adquirida
        self.alpha = alpha          #Tasa de exposicion
        self.tau = tau              #Tasa de perdida de vacunacion
        self.omega = omega          #Tasa de vacunacion
        self.zeta = zeta            #Tasa E-Q
        self.epsilon = epsilon      #Tasa E-Is
        self.delta = delta          #Tasa E-Ia
        self.eta = eta              #Tasa de recuperacion Ia
        self.kappa = kappa          #Tasa Is-Q
        self.rho = rho              #Tasa defuncion Is
        self.theta = theta          #Tasa de recuperacion Is
        self.iota = iota            #Tasa de recuperacion Q
        self.nu = nu                #Tasa defuncion Q

        # Condiciones iniciales
        self.S0 = S0
        self.V0 = V0
        self.E0 = E0
        self.I_A0 = I_A0
        self.Q0 = Q0
        self.I_S0 = I_S0
        self.R0 = R0
        self.M0 = M0
        self.Y0 = [S0, V0, E0, I_A0, Q0, I_S0, R0, M0]

        # Tiempo de simulación
        self.t_sim = t_sim
        self.tspan = (0, self.t_sim)
        self.t_eval = np.arange(0, self.t_sim + 1, 1)

    # Sistema de ecuaciones
    def VSEIQR_model(self, t, Y):
        S, V, E, I_A, Q, I_S, R, M = Y
        dSdt = self.sigma * R - self.alpha * S * E + self.tau * V - self.omega * S
        dVdt = self.omega * S - self.tau * V
        dEdt = self.alpha * S * E - (self.zeta + self.epsilon + self.delta) * E
        dI_Adt = self.delta * E - self.eta * I_A
        dQdt = self.zeta * E + self.kappa * I_S - (self.iota + self.nu) * Q
        dI_Sdt = self.epsilon * E - (self.kappa + self.rho + self.theta) * I_S
        dRdt = self.iota * Q + self.theta * I_S + self.eta * I_A - self.sigma * R
        dMdt = self.nu * Q + self.rho * I_S
        return [dSdt, dVdt, dEdt, dI_Adt, dQdt, dI_Sdt, dRdt, dMdt]

    
    def model_toCsv(self):
        solution = solve_ivp(self.VSEIQR_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)
        S = np.round(solution.y[0]).astype(int)
        V = np.round(solution.y[1]).astype(int)
        E = np.round(solution.y[2]).astype(int)
        I_A = np.round(solution.y[3]).astype(int)
        Q = np.round(solution.y[4]).astype(int)
        I_S = np.round(solution.y[5]).astype(int)
        R = np.round(solution.y[6]).astype(int)
        M = np.round(solution.y[7]).astype(int)

        t = solution.t.astype(int)
        data = pd.DataFrame({
            "Tiempo": t,
            "S (Susceptibles)": S,
            "V (Vacunados)": V,
            "E (Expuestos)": E,
            "I_A (Asintomáticos)": I_A,
            "Q (Cuarentenados)": Q,
            "I_S (Sintomáticos)": I_S,
            "R (Recuperados)": R,
            "M (Muertes)": M
        })
        data.to_excel("VSEIQR_ODEs.xlsx", index=False)

    def show_model(self):
        solution = solve_ivp(self.VSEIQR_model, self.tspan, self.Y0, t_eval=self.t_eval)

        # Extraer los resultados
        t = solution.t.astype(int)
        S = np.round(solution.y[0]).astype(int)
        V = np.round(solution.y[1]).astype(int)
        E = np.round(solution.y[2]).astype(int)
        I_A = np.round(solution.y[3]).astype(int)
        Q = np.round(solution.y[4]).astype(int)
        I_S = np.round(solution.y[5]).astype(int)
        R = np.round(solution.y[6]).astype(int)
        M = np.round(solution.y[7]).astype(int)

        plt.figure(figsize=(12, 8))
        plt.plot(t, S, label="S (Susceptibles)")
        plt.plot(t, V, label="V (Vacunados)")
        plt.plot(t, E, label="E (Expuestos)")
        plt.plot(t, I_A, label="I_A (Asintomáticos)")
        plt.plot(t, Q, label="Q (Cuarentena)")
        plt.plot(t, I_S, label="I_S (Sintomáticos)")
        plt.plot(t, R, label="R (Recuperados)")
        plt.plot(t, M, label="M (Muertes)")
        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.title("Modelo Epidemiológico VSEIQR")
        plt.legend()
        plt.grid()
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
            "ODE_V": ode_data_200["V"],
            "Sim_V": simulation_data_200["V"],
            "Diff_V": abs(ode_data_200["V"] - simulation_data_200["V"]),
            "ODE_E": ode_data_200["E"],
            "Sim_E": simulation_data_200["E"],
            "Diff_E": abs(ode_data_200["E"] - simulation_data_200["E"]),
            "ODE_I_A": ode_data_200["I_A"],
            "Sim_I_A": simulation_data_200["I_A"],
            "Diff_I_A": abs(ode_data_200["I_A"] - simulation_data_200["I_A"]),
            "ODE_Q": ode_data_200["Q"],
            "Sim_Q": simulation_data_200["Q"],
            "Diff_Q": abs(ode_data_200["Q"] - simulation_data_200["Q"]),
            "ODE_I_S": ode_data_200["I_S"],
            "Sim_I_S": simulation_data_200["I_S"],
            "Diff_I_S": abs(ode_data_200["I_S"] - simulation_data_200["I_S"]),
            "ODE_R": ode_data_200["R"],
            "Sim_R": simulation_data_200["R"],
            "Diff_R": abs(ode_data_200["R"] - simulation_data_200["R"]),
            "ODE_M": ode_data_200["M"],
            "Sim_M": simulation_data_200["M"],
            "Diff_M": abs(ode_data_200["M"] - simulation_data_200["M"])
        })

        # Graficar los resultados
        plt.figure(figsize=(12, 8))

        # Graficar susceptibles
        plt.plot(comp["Time"], comp["ODE_S"], label="ODE Susceptibles (S)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_S"], label="Sim Susceptibles (S)", linestyle="--", marker="x", markersize=3)

        # Graficar vacunados
        plt.plot(comp["Time"], comp["ODE_V"], label="ODE Vacunados (V)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_V"], label="Sim Vacunados (V)", linestyle="--", marker="x", markersize=3)

        # Graficar expuestos
        plt.plot(comp["Time"], comp["ODE_E"], label="ODE Expuestos (E)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_E"], label="Sim Expuestos (E)", linestyle="--", marker="x", markersize=3)

        # Graficar asintomáticos
        plt.plot(comp["Time"], comp["ODE_I_A"], label="ODE Asintomáticos (I_A)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_I_A"], label="Sim Asintomáticos (I_A)", linestyle="--", marker="x", markersize=3)

        # Graficar cuarentenados
        plt.plot(comp["Time"], comp["ODE_Q"], label="ODE Cuarentenados (Q)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_Q"], label="Sim Cuarentenados (Q)", linestyle="--", marker="x", markersize=3)

        # Graficar sintomáticos
        plt.plot(comp["Time"], comp["ODE_I_S"], label="ODE Sintomáticos (I_S)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_I_S"], label="Sim Sintomáticos (I_S)", linestyle="--", marker="x", markersize=3)

        # Graficar recuperados
        plt.plot(comp["Time"], comp["ODE_R"], label="ODE Recuperados (R)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_R"], label="Sim Recuperados (R)", linestyle="--", marker="x", markersize=3)

        # Graficar muertes
        plt.plot(comp["Time"], comp["ODE_M"], label="ODE Muertes (M)", linestyle="-", marker="o", markersize=3)
        plt.plot(comp["Time"], comp["Sim_M"], label="Sim Muertes (M)", linestyle="--", marker="x", markersize=3)

        # Configurar el gráfico
        plt.title("Comparación de Resultados: Modelo ODE vs Simulación")
        plt.xlabel("Tiempo (días)")
        plt.ylabel("Población")
        plt.legend()
        plt.grid(True)
        plt.tight_layout()

        # Mostrar la gráfica
        plt.show()


