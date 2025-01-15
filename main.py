import pandas as pd
from app_sis import sis

def display_menu():
    while True:
        try:
            print("Welcome to the EpiSolver app. Your options are:")
            print(" 1. SIS model")
            print(" 2. SIR model")
            print(" 3. SEAIR model")
            print()
            print("Enter your selection number (or type Exit to exit the program):")
            
            # Leer la entrada como texto
            user_input = input("Your selection: ").strip()
            
            # Permitir salir si el usuario escribe 'Exit'
            if user_input.lower() == "exit":
                print("Goodbye!")
                return None  # O algún valor especial que indique la salida
            
            # Intentar convertir la entrada a un número
            menu = int(user_input)
            
            # Verificar si el número está en el rango permitido
            if 1 <= menu <= 3:
                return menu  # Regresar el número si es válido
            else:
                print("Invalid selection. Please select a number between 1 and 3.")
        except ValueError:
            # Capturar errores si el usuario no introduce un número válido
            print("Invalid input. Please enter a number or type 'Exit' to quit.")

def display_sis():
    while True:
        try:
            print("Model sis can:")
            print(" 1. Graph model")
            print(" 2. Create numeric solution")
            print(" 3. Compare numeric solution vs simulation")
            print()
            print("Enter your selection number (or type Retrun to return menu):")
            
            # Leer la entrada como texto
            user_input = input("Your selection: ").strip()
            
            # Permitir regresar al menu
            if user_input.lower() == "return":
                break
            
            # Intentar convertir la entrada a un número
            menu = int(user_input)
            
            # Verificar si el número está en el rango permitido
            if 1 <= menu <= 3:
                sismodel = sis()
                if menu == 1:
                    sismodel.show_model()
                if menu == 2:
                    sismodel.model_topdf()
                if menu == 3:
                    try:
                        # Intentar cargar los archivos
                        ode_data = pd.read_excel("SIS_ODEs.xlsx")
                        simulation_data = pd.read_csv(r"C:\OnedriveOut\Maestria\Tesis\Proyecto\estadisticas.csv")

                        # Verificar que el archivo tenga exactamente las columnas esperadas
                        expected_columns = {'S', 'I'}
                        actual_columns = set(simulation_data.columns)

                        if actual_columns != expected_columns:
                            raise ValueError(f"El archivo 'estadisticas.csv' debe contener únicamente las columnas {expected_columns}. "
                                            f"Columnas encontradas: {actual_columns}")

                        # Llamar al método que compara los datos
                        sismodel.modelvsSim(ode_data, simulation_data)

                    except FileNotFoundError as e:
                        # Manejar archivos no encontrados
                        print(f"Error: No se pudo encontrar el archivo {e.filename}. Asegúrate de que el archivo esté cargado antes de ejecutar el programa.")
                    except pd.errors.EmptyDataError as e:
                        # Manejar archivos vacíos
                        print(f"Error: El archivo {e.filename} está vacío. Por favor, verifica el contenido del archivo.")
                    except ValueError as e:
                        # Manejar errores de validación de columnas
                        print(f"Error: {e}")
                    except Exception as e:
                        # Capturar cualquier otro error
                        print(f"Error inesperado: {str(e)}. Por favor, revisa los archivos y vuelve a intentarlo.")
            else:
                print("Invalid selection. Please select a number between 1 and 3.")
        except ValueError:
            # Capturar errores si el usuario no introduce un número válido
            print("Invalid input. Please enter a number or or type 'Retrun' to return menu.")

# Llamar a la función y capturar la opción seleccionada
selected_option = display_menu()

if selected_option == 1:
    display_sis()
    display_menu()
elif selected_option == 2 or selected_option == 3:
    print("Under Construction")

