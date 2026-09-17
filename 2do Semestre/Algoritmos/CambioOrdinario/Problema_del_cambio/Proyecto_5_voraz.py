import json
import copy
def extract_json_data(file):

    # "open(file, 'r')" abre el file con nombre 'coin-change.json' dentro de la carpeta, con el parámetro 'r' que indica solo lectura
    # "with" garantiza que el file se cierre automáticamente al terminar el bloque de instrucciones
    # "as file_json" se le da un nombre al file que se acaba de abrir 
    # "json.load(file_json)" lee el file y convierte su contenido de formato json a una estructura de python, en este caso un diccionario
    # finalmente lo convertido lo guarda en "raw_json_data"

    with open(file, 'r') as file_json:
        raw_json_data = json.load(file_json)

    # se inicializa un nuevo diccionario donde se van a guardar los datos del json a modo de ints
    json_data = {}

    # se recorren tanto las keys como los valores del diccionario al mismo tiempo, utilizando el raw_json_data.items, para poder ver estos dos datos simulateneamente
    for key, value in raw_json_data.items():
        json_data[int(key)] = value # luego en el nuevo diccionario, la nueva key se guarda como un int, manteniendo los mismos datos del diccionario original

    return json_data

##{1: 47, 2: 23, 5: 38, 10: 1, 20: 0, 50: 2, 100: 0}
coin_change_data = extract_json_data('coin-change.json')


def mainCode(debug = False):
    start = False
    changeDiccionary = copy.deepcopy(coin_change_data)
    for datos in changeDiccionary:
        changeDiccionary[datos] = 0


    change = input("Ingrese la cantidad de cambio que desea solicitar: ")

    try: 
        Ichange = int(change)
    except ValueError:
        print("Error: el dato ingresado no es un número entero válido.")
        return
    
    changeToUse = 0
    
    while not start:

        ##DEBUG
        if debug:
            print(f"El cambio actual a restar es: {Ichange}")
        for datos in reversed(coin_change_data):
            if datos <= Ichange and coin_change_data[datos] > 0:
                changeToUse = datos
                break

        ##DEBUG
        if debug:
            print(f"El cambio más grande disponible es: {changeToUse}")
            print(f"La cantidad de monedas disponibles de esa denominación es: {coin_change_data[changeToUse]}")


        coin_change_data[changeToUse] -= 1
        changeDiccionary[changeToUse] += 1
        
        Ichange = Ichange - changeToUse

        

        if Ichange == 0:
            print(f"Pediste un cambio de: {change}")
            print("Tu cambio final es de: ")

            for datos in changeDiccionary:
                if changeDiccionary[datos] > 0:
                    if datos <=20: 
                        print(f"{changeDiccionary[datos]} monedas de {datos} pesos")
                    else:
                        print(f"{changeDiccionary[datos]} billetes de {datos} pesos")

            start = True
        elif Ichange < 0:
            print("no se pudo regresar el cambio exacto")
            start = True


mainCode(False)

                
            
    