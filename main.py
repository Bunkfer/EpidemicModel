from app_menu import *

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
            print()
            display_sis()
            print()
        if selected_option == 2:
            print()
            display_sir()
            print()
        elif selected_option in [3]:
            print()
            print("Under Construction")
            print()
