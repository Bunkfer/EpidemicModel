from app_menu import *
from app_sis import sisM
from app_sir import sirM

# Bucle principal del programa
if __name__ == "__main__":
    while True:
        # Mostrar el menú principal
        selected_option = display_menu()

        # Salir si el usuario selecciona "Exit"
        if selected_option is None:
            break

        # Procesar la selección del usuario
        if selected_option == 1:
            model="SIS"
            file =f"{model}_ODEs.xlsx"
            columns = {'S', 'I'}
            display_model(sisM(), model, file, columns)
            print()
        if selected_option == 2:
            model="SIR"
            file =f"{model}_ODEs.xlsx"
            columns = set(model) 
            display_model(sirM(), model, file, columns)
            print()
        elif selected_option in [3]:
            print()
            print("Under Construction")
            print()
