from app_sis import sisM
from app_sir import sirM
from app_seair import seairM
from app_vseiqr import vseiqrM

class MainWindowModel():
    def __init__(self):
        # Inicializar modelos
        self.selected_model_sis = sisM()
        self.selected_model_sir = sirM()
        self.selected_model_seair = seairM()
        self.selected_model_vseiqr = vseiqrM()

    def update_model_sis(self):
        self.selected_model_sis = sisM(alpha = self.selected_model_sis.alpha, 
                                       beta = self.selected_model_sis.beta,
                                       S0 = self.selected_model_sis.S0, 
                                       I0 = self.selected_model_sis.I0,
                                       t_sim = self.selected_model_sis.t_sim
                                       )
        self.selected_model_instance = self.selected_model_sis

    def update_model_sir(self):
        self.selected_model_sir = sirM(alpha = self.selected_model_sir.alpha, 
                                       beta = self.selected_model_sir.beta,
                                       gamma= self.selected_model_sir.gamma,
                                       S0 = self.selected_model_sir.S0, 
                                       I0 = self.selected_model_sir.I0,
                                       R0 = self.selected_model_sir.R0,
                                       t_sim = self.selected_model_sir.t_sim
                                       )
        self.selected_model_instance = self.selected_model_sir

    def update_model_seair(self):
        self.selected_model_seair = seairM(beta = self.selected_model_seair.beta, 
                                           delta = self.selected_model_seair.delta,
                                           gamma = self.selected_model_seair.gamma,
                                           mu_E = self.selected_model_seair.mu_E,
                                           mu_I = self.selected_model_seair.mu_I,
                                           mu_A = self.selected_model_seair.mu_A,
                                           p = self.selected_model_seair.p,
                                           S0 = self.selected_model_seair.S0,
                                           E0 = self.selected_model_seair.E0,
                                           A0 = self.selected_model_seair.A0,
                                           I0 = self.selected_model_seair.I0,
                                           R0 = self.selected_model_seair.R0,
                                           t_sim = self.selected_model_seair.t_sim
                                       )
        self.selected_model_instance = self.selected_model_seair
    
    def update_model_vseiqr(self):
        self.selected_model_vseiqr = vseiqrM(sigma = self.selected_model_vseiqr.sigma,
                                              alpha = self.selected_model_vseiqr.alpha,
                                              tau=self.selected_model_vseiqr.tau,
                                              omega=self.selected_model_vseiqr.omega,
                                              zeta=self.selected_model_vseiqr.zeta,
                                              epsilon=self.selected_model_vseiqr.epsilon,
                                              delta=self.selected_model_vseiqr.delta,
                                              eta=self.selected_model_vseiqr.eta,
                                              kappa=self.selected_model_vseiqr.kappa,
                                              rho=self.selected_model_vseiqr.rho,
                                              theta=self.selected_model_vseiqr.theta,
                                              iota=self.selected_model_vseiqr.iota,
                                              nu=self.selected_model_vseiqr.nu,
                                              S0=self.selected_model_vseiqr.S0,
                                              V0=self.selected_model_vseiqr.V0,
                                              E0=self.selected_model_vseiqr.E0,
                                              I_A0=self.selected_model_vseiqr.I_A0,
                                              Q0=self.selected_model_vseiqr.Q0,
                                              I_S0=self.selected_model_vseiqr.I_S0,
                                              R0=self.selected_model_vseiqr.R0,
                                              M0=self.selected_model_vseiqr.M0,
                                              t_sim=self.selected_model_vseiqr.t_sim
                                              )
        self.selected_model_instance = self.selected_model_vseiqr