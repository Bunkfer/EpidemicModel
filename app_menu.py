import time
import sys
import pandas as pd

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
                return None  # Indica que el usuario quiere salir
            
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


def tiempo_espera(mensaje="Cargando"):
    print(mensaje, end="", flush=True)
    for _ in range(3):
        time.sleep(0.5)
        print(".", end="", flush=True)
    print()


def display_model(model_class, model_name, ode_file, expected_columns):
    """
    Función genérica para manejar los modelos epidemiologicos.
    
    Parámetros:
    - model_class: Clase del modelo (ej. sisM o sirM).
    - model_name: Nombre del modelo (ej. "SIS" o "SIR").
    - ode_file: Nombre del archivo ODE (ej. "SIS_ODEs.xlsx").
    - expected_columns: Columnas esperadas en la simulación (conjunto de strings).
    """
    while True:
        try:
            print(f"Model {model_name} can:")
            print(" 1. Graph model")
            print(" 2. Create numeric solution")
            print(" 3. Compare numeric solution vs simulation")
            print()
            print(f"Enter your selection number (or type Return to return to the main menu):")
            
            # Leer la entrada como texto
            user_input = input("Your selection: ").strip()
            
            # Permitir regresar al menú principal
            if user_input.lower() == "return":
                return  # Termina esta función y regresa al menú principal
            
            # Intentar convertir la entrada a un número
            menu = int(user_input)
            
            # Verificar si el número está en el rango permitido
            if 1 <= menu <= 3:
                model_instance = model_class
                if menu == 1:
                    tiempo_espera("Creando gráfica")
                    model_instance.show_model()
                elif menu == 2:
                    tiempo_espera("Creando archivo")
                    model_instance.model_topdf()
                elif menu == 3:
                    tiempo_espera()
                    try:
                        # Intentar cargar los archivos
                        ode_data = pd.read_excel(ode_file)
                        simulation_data = pd.read_csv(r"C:\OnedriveOut\Maestria\Tesis\Proyecto\estadisticas.csv")

                        # Verificar que el archivo tenga exactamente las columnas esperadas
                        actual_columns = set(simulation_data.columns)

                        if actual_columns != expected_columns:
                            raise ValueError(f"El archivo 'estadisticas.csv' debe contener únicamente las columnas {expected_columns}. "
                                            f"Columnas encontradas: {actual_columns}")

                        # Llamar al método que compara los datos
                        print("Archivos Cargados")
                        tiempo_espera("Creando Comparación")
                        model_instance.modelvsSim(ode_data, simulation_data)

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
            print("Invalid input. Please enter a number or type 'Return' to return to the main menu.")

