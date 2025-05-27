from scipy.integrate import solve_ivp
import numpy as np
from models_super import *

class sis(Main_model):
    def __init__(self, alpha=0.0001, beta=0.4, S0=8500, I0=1500, t_sim=200):
        self.alpha = alpha  
        self.beta = beta    
        self.S0 = S0       
        self.I0 = I0        
        self.Y0 = [S0, I0]

        self.t_sim = t_sim
        self.tspan = (0, self.t_sim)
        self.t_eval = np.arange(0, self.t_sim + 1, 1) 

        # Resolver automáticamente al crear la instancia
        self.results = self.solve()

    def SIS_model(self, t, Y):
        S, I = Y
        dSdt = -self.alpha * S * I + self.beta * I
        dIdt = self.alpha * S * I - self.beta * I
        return [dSdt, dIdt]

    def solve(self):
        solution = solve_ivp(self.SIS_model, self.tspan, self.Y0, t_eval=self.t_eval)
        return {
            "Tiempo": solution.t.astype(int),
            "S": np.round(solution.y[0]).astype(int),
            "I": np.round(solution.y[1]).astype(int)
        }
    

class sir(Main_model):
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

        # Resolver automáticamente al crear la instancia
        self.results = self.solve()

    def SIR_model(self, t, Y):
        S, I, R = Y
        dSdt = -self.alpha * S * I + self.gamma * R
        dIdt = self.alpha * S * I - self.beta * I
        dRdt = self.beta * I - self.gamma * R
        return [dSdt, dIdt, dRdt]
    
    def solve(self):
        solution = solve_ivp(self.SIR_model, self.tspan, self.Y0, t_eval=self.t_eval)
        return {
            "Tiempo": solution.t.astype(int),
            "S": np.round(solution.y[0]).astype(int),
            "I": np.round(solution.y[1]).astype(int),
            "R": np.round(solution.y[2]).astype(int),
        }
    
class seair(Main_model):
    def __init__(self, beta=0.0004, delta=0.03, gamma=0.25, mu_E=0.12, mu_I=0.1, mu_A=0.2, 
                 p=0.6, S0=8500, E0=1000, A0=100, I0=400, R0=0, t_sim=200):
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
        self.t_sim = t_sim
        self.tspan = (0, self.t_sim)
        self.t_eval = np.arange(0, self.t_sim + 1, 1)

        # Resolver automáticamente al crear la instancia
        self.results = self.solve()

    # Solución numérica del modelo SEAIR
    def SEAIR_model(self, t, Y):
        S, E, A, I, R = Y
        dSdt = -self.beta * S * (self.delta * A + I) + self.gamma * R 
        dEdt = self.beta * S * (self.delta * A + I) - self.mu_E * E
        dAdt = (1 - self.p) * self.mu_E * E - self.mu_A * A
        dIdt = self.p * self.mu_E * E - self.mu_I * I
        dRdt = self.mu_A * A + self.mu_I * I - self.gamma * R         
        return [dSdt, dEdt, dAdt, dIdt, dRdt]
    
    def solve(self):
        solution = solve_ivp(self.SEAIR_model, self.tspan, self.Y0, t_eval=self.t_eval)
        return {
            "Tiempo": solution.t.astype(int),
            "S": np.round(solution.y[0]).astype(int),
            "E": np.round(solution.y[1]).astype(int),
            "A": np.round(solution.y[2]).astype(int),
            "I": np.round(solution.y[3]).astype(int),
            "R": np.round(solution.y[4]).astype(int)
        }
    
class vseiqr(Main_model):
    """def __init__(self, sigma=0.0668, alpha=0.01, tau=0.0002, omega=0.0032, zeta=0.02798,
                 epsilon=0.0101, delta=1.6728e-5, eta=0.04478, kappa=0.0368, rho=0.004, theta=0.0101,
                 iota=0.0045, nu=3.2084e-4, S0=8500, V0=0, E0=1500,
                 I_A0=0, Q0=0, I_S0=0, R0=0, M0=0, t_sim=200):"""
    def __init__(self, sigma=0.12, alpha=0.0003, tau=0.02, omega=0.05, zeta=0.008,
                 epsilon=0.004, delta=0.12, eta=0.05, kappa=0.001, rho=0.0001, theta=0.0005,
                 iota=0.003, nu=0.001, S0=8500, V0=0, E0=1500,
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

        # Resolver automáticamente al crear la instancia
        self.results = self.solve()

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
    
    def solve(self):
        solution = solve_ivp(self.VSEIQR_model, self.tspan, self.Y0, t_eval=self.t_eval)
        return {
            "Tiempo": solution.t.astype(int),
            "S": np.round(solution.y[0]).astype(int),
            "V": np.round(solution.y[1]).astype(int),
            "E": np.round(solution.y[2]).astype(int),
            "Ia": np.round(solution.y[3]).astype(int),
            "Q": np.round(solution.y[4]).astype(int),
            "Is": np.round(solution.y[5]).astype(int),
            "R": np.round(solution.y[6]).astype(int),
            "M": np.round(solution.y[7]).astype(int)
        }