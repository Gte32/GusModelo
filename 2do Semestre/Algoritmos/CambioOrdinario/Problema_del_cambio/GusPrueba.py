#------------------------------------------
#--------- DOCUMENTACIÓN PREVIA -----------
#------------------------------------------

#---------- Algoritmos a realizar ---------------

# Algoritmo VORAZ
# Programación DINÁMICA/backtracking

#--------------- Info de las monedas ---------------
# En file json (coin-exchange.json)

# Denominación de las monedas/billetes
# Cantidad disponible de cada una

#--------------- Que debe hacer el file "Proyecto_5.py" ---------------

# 1. Leer "coin-change.json" - LISTO
# 2. Guardar la info del json en un diccionario u otra variable - LISTO
# 3. Solicitar al usuario la cantidad de cambio a proporcionar - LISTO

# 4. Comprobaciones

#   a. Que el saldo en el json sea superior a 0 - LISTO
#   b. Que el cambio solicitado sea mayor a 0 - LISTO
#   c. Comprobar que el cambio no supere al saldo total en el json - LISTO 

# 5. Ejecutar ambos algoritmos (voraz y dinamico) - no listo T-T

# LEOCOMENTARIO: Toda la guía de como hacer las partes fue hecha con claude, para este punto leo ya tenía mucho sueño
# entonces de lo que había en sus notas y en el pdf lo razono claude y puso que se debe de hacer para el voraz y el de backtrackeo con memoria
# son las 10:48 y ya me dio sueño hace rato T-T

#---------- VORAZ ----------

# V1. Ordenar las denominaciones de mayor a menor
# V2. Para cada denominación (de mayor a menor):
#   - Calcular cuántas monedas de esa denominación caben en el cambio restante
#   - No exceder la cantidad disponible en el JSON
#   - Restar al cambio restante lo que se pudo cubrir
# V3. Si al final el cambio restante es 0 -> solución encontrada
#   - Si no -> el algoritmo voraz no pudo dar el cambio exacto
# V4. Retornar las monedas usadas

#---------- DINÁMICO ----------

# D1. Tomar todas las denominaciones del JSON y ordenarlas de menor a mayor
# D2. Crear matriz numpy (num_denominaciones x cambio_solicitado)
# D3. Llenar primera fila:
#       - Si col < denominacion -> infinito (no se puede dar ese cambio)
#       - Si col >= denominacion -> 1 + celda[misma_fila][col - denominacion]
#       - Caso especial col == denominacion -> da 1 automáticamente con la fórmula anterior
# D4. Llenar filas siguientes:
#       - celdas antes de la diagonal -> copiar fila anterior
#       - celda diagonal -> 1
#       - celdas después -> min(fila_anterior[col], 1 + celda[fila_actual][col - denominacion])
# D5. Imprimir la tabla generada

#---------- Backtracking ----------

# B1. Partir de celda [ultima_fila][cambio_solicitado]
# B2. Intentar usar denominacion de fila actual:
#       - Verificar que haya cantidad disponible en JSON
#       - Si si -> restar denominacion al cambio restante, moverse a [fila_actual][col - denominacion]
#       - Si no -> subir a fila anterior, misma columna, imprimir por qué falló
# B3. Repetir hasta que cambio restante == 0
# B4. Retornar lista de monedas usadas

#---------- Backtracking con memoria (DP) ----------

# M1. Igual que backtracking pero añadir hasattr para contador y memoria
# M2. Antes de calcular revisar si (fila, columna) ya está en mem
# M3. Si está -> retornar valor memorizado directamente
# M4. Si no está -> calcular, guardar en mem, retornar
# M5. Al final comparar coin_change_bt.counter vs coin_change_dp.counter

# 6. Mostrar las soluciones generadas por cada uno de ellos - no listo T-T

#------------------------------------------
#---------- EJECUCIÓN DEL CÓDIGO ----------
#------------------------------------------

#---------- Librerías ----------

import subprocess # para limpiar la pantalla
import json # para poder leer el file json
import copy # para copiar datos
import numpy as np # para tratar con las matrices de numpy

#---------- Funciones ----------

import os

def clear_screen():
    os.system('cls' if os.name == 'nt' else 'clear')

# lee y extrae la información del json, convierte las keys en ints y retorna un diccionario
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

# función que multiplica la denominación de la moneda por la cantidad de esta para saber si hay saldo disponible
def total_balance_exists(coin_change_data):
    total_balance = 0
    for denomination, ammount in coin_change_data.items():
        subtotal = denomination * ammount
        total_balance += subtotal
    if total_balance <= 0:
        clear_screen()
        print("Error: la máquina se ha quedado sin cambio")
        return False
    return True

# lee el input de consola para validar que el dato sea de tipo entero y retorna el dato
def read_input_coin_change():
    while True: # se ejecuta el while
        try: # se intenta convertir a int el input de consola
            change = int(input("Ingrese la cantidad de cambio que desea solicitar: "))
            break # si no hubo ningun error de tipo de datos sale del while
        except ValueError: # si hubo error de tipo de datos muestra un comentario
            clear_screen()
            print("Error: el dato ingresado no es un número entero válido.")
    return change

# valida que el cambio a pedir sea mayor a 0 
def validate_change(change):
    if change < 1:
        clear_screen()
        print("Error: el cambio debe de ser una cantidad positiva")
        return False
    return True

# función que multiplica la denominación de la moneda por la cantidad de esta para saber si es suficiente para dar el saldo
def validate_total_balance(coin_change_data, change):
    total_balance = 0
    for denomination, amount in coin_change_data.items():
        subtotal = denomination * amount
        total_balance += subtotal
    if total_balance < change:
        clear_screen()
        print("Error: no se cuenta con saldo suficiente para dar el cambio solicitado")
        return False
    return True

# función que resuelve el problema del cambio de monedas desde una perspectiva voraz
def greedy_algorithm(coin_change_data, change, debug = False):
    start = False
    changeDiccionary = copy.deepcopy(coin_change_data)
    for datos in changeDiccionary:
        changeDiccionary[datos] = 0
    
    Ichange = change 
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
            
            
            print("Tu cambio final es de: ")

            for datos in changeDiccionary:
                if changeDiccionary[datos] > 0:
                    if datos <=20: 
                        print(f"{changeDiccionary[datos]} monedas de {datos} pesos")
                    else:
                        print(f"{changeDiccionary[datos]} billetes de {datos} pesos")

            start = True
        else:
            print("No se puede encontrar el cambio, no hay monedas exactas al elegir el mejor caso siempre")
            start = True

# función que genera la tabla coin_table para poder trabajarla recursivamente
def generate_table(data, change):

    denominations = [] # se inicializa la lista de denominaciones validas como vacía

    # se recorren todas las denominaciones para solamente armar la tabla con las válidas
    # por ejemplo si se pide un cambio de 13 no es posible dar el cambio con monedas de 20
    for denomination in data.keys():
        if denomination <= change: # si el cambio pedido es menor a la denominacion, entonces no se añade a la lista
            denominations.append(denomination)
    
    table_rows = len(denominations) # se establece la cantidad de las filas 
    table_cols = change # se establece la cantidad de las columnas

    coin_table = np.zeros((table_rows,table_cols), dtype=int) # quieres un vector le pasas un solo dato, quieres una matriz le pasas una tupla    

    # rellenamos la primera fila como si fuese desde 0 hasta la cantidad de cambio pedido    
    for i in range(table_cols):
        coin_table[0][i] = i+1

    # partir celda nxn, o sea "denominacion"x"columna_cambio", todas las celdas a la izquierda de esta celda nxn serán iguales a la de la fila superior
    # luego, todas las celdas a la derecha de la celda "nxn" serán calculadas por medio de la siguiente lógica
    # el valor la celda donde estás posicionado se obtendrá con el valor de la celda ubicada a "denominacion" posiciones a la izquierda, sumado de 1 

    for row in range(1, table_rows):
        den = denominations[row]

        for col in range(table_cols):
            
            # cols va de (0 a change-1), por esto se le suma 1, que vaya de (1 a change)
            if (col + 1) == den: 
                coin_table[row][col] = 1 # si estamos en la celda nxn ponemos el valor igual a 1
            elif (col+1) < den: 
                coin_table[row][col] = coin_table[row-1][col] # copiamos el valor de la row anterior si la col es menor a la nxn
            else: # si la col es mayor a la nxn
                coin_table[row][col] = 1 + coin_table[row][col - den] # entonces su valor se obtiene sumando el valor de la celda 

    return coin_table

# función para debuggear e imprimir la tabla en consola
def print_table(coin_table, data):
    # se tomala forma de la tabla generada
    change = coin_table.shape[1]
    
    # se toman las denominaciones a imprimir de la tabla
    denominations = []
    for denomination in data.keys():
        if denomination <= change:
            denominations.append(denomination)
    
    # se genera el encabezado superior con los valores de cambio del 1 hasta el cambio solicitado
    # ":4" reserva 4 espacios por número para que las columnas queden alineadas
    header = "     " + "".join(f"{col+1:4}" for col in range(coin_table.shape[1]))
    print(header)
    
    # se recorre cada fila de la tabla junto con su índice usando enumerate
    # se imprime la denominación a la izquierda y luego cada valor de la fila
    for i, row in enumerate(coin_table):
        row_str = f"{denominations[i]:4} " + "".join(f"{val:4}" for val in row)
        print(row_str)

# función para imprimir el balance total inicial en máquina como la cantidad de cada denominación
def print_original_data(coin_change_data):
    total_balance = 0
    for denomination, amount in coin_change_data.items():
        subtotal = denomination * amount
        total_balance += subtotal
    print(f"- Pediste un cambio de: ${change}")
    print(f'- El saldo total en máquina es de: ${total_balance}') 
    print(f'- Las monedas y billetes disponibles en la máquina son los siguientes:\n')
    for denomination, amount in coin_change_data.items():
        print(f'${denomination:<3} = {amount:<5}')
        
#---------- Ejecución ----------

clear_screen()

# se extrae el diccionario del json
coin_change_data = extract_json_data('coin-change.json')

# si hay 0 balance en el json termina la ejecución tempranamente
if not total_balance_exists(coin_change_data):
    exit()

# obtiene el cambio del usuario
change = read_input_coin_change()

# valida que el cambio sea válido y que el balance total sea mayor que el cambio solicitado, si no pide que ingrese un cambio diferente
# mientras una de las dos validaciones de False, el and dará False, por ende el not lo invierte a True y se ejecuta el ciclo
while not (validate_change(change) and validate_total_balance(coin_change_data, change)):
    change = read_input_coin_change()

clear_screen()

# *******************************************************
print('\n************* Datos iniciales **************\n')
# *******************************************************

print_original_data(coin_change_data)

# *******************************************************
print('\n************* Algoritmo  voraz *************\n')
# *******************************************************

# --- Algoritmo  voraz ---

greedy_algorithm(coin_change_data, change, False)

# --- Programacion dinamico con backtracing---

# *******************************************************
print('\n********** Programación dinamica ***********\n')
# *******************************************************

# genera la tabla de monedas como una matriz de np
coin_table = generate_table(coin_change_data, change)

print_table(coin_table, coin_change_data)

# falta ir recorriendo la tabla generada con backtracking e incorporar la memoria al algoritmo



#.shape[0] -> filas
#.shape[1] -> columnas

##lógica para el backtracking con memoria
##Encontrar el numero en la tabla, restarle lo apropiado, recordar valores para el backt

coin_change_data = extract_json_data('coin-change.json')

# *******************************************************
print('\n*********** Algoritmo  Recursivo ***********\n')
# *******************************************************

def logic_change_constructor(coin_table, changeNumber, coin_change_data):
    # reconstruir la lista de denominaciones válidas, igual que en generate_table
    ##aunque aparezcane en la tabla, no existen la primera columna y fila
    change_given = coin_change_data.copy()

    for datos in change_given:
        change_given[datos] = 0

    unvalid_paths =[]
    denominations = []
    raiz = []
    for denomination in coin_change_data.keys():
        if denomination <= changeNumber: # si el cambio pedido es menor a la denominacion, entonces no se añade a la lista
            denominations.append(denomination)
    
    if  logic_changeimp(coin_table, unvalid_paths , changeNumber, coin_change_data, change_given, denominations,raiz):
        print(f"La raíz que lo consiguio es la raiz {raiz}")
        print(f"El cambio recibido es de:")
        for datos in change_given:
                if change_given[datos] > 0:
                    if datos <=20: 
                        print(f"{change_given[datos]} monedas de {datos} pesos")
                    else:
                        print(f"{change_given[datos]} billetes de {datos} pesos")

    else:
        print("No se puede dar el cambio necesario con las monedas y billetes actuales")
    

def logic_changeimp(coin_table, unvalid_paths , changeNumber, coin_change_data, change_given, denominations,raiz):
    Craiz = copy.deepcopy(raiz)
    col =0
    fail = False
    ChangeNumberOG = changeNumber
    prevRow = None
    prevCol = None
    
    while(not fail):
        row = None
        for i in reversed(range(len(denominations))): ##aqui recorre la tabla
            valor = denominations[i]  # la denominación real de esta fila
            col = changeNumber - 1 # la columna a revisar es el cambio restante -1, porque las columnas van de 0 a change-1
            if valor <= changeNumber and coin_change_data[valor] > 0:
                if CheckMemory(unvalid_paths, i, col):
                    row = i ## i = al número de fila (0,1,2,...), valor = el número que se encuentra en esa fila(1,2,5,10,...)
                    break
        ##Debug
        ##print(f"El cambio en esta vuelta es de {changeNumber}, con la fila = {row}, y la columna = {col}")
        
        if row is None:  ##cuando NO pueda encontrar otra entrada se sale
            fail = True
            break

        ##se guarda la columna anterior, en caso de fallar, esta se va a la memoria de raices usadas y pues ahi muere basicamente
        prevRow = row
        prevCol = col
      
        valor = denominations[row]  # la denominación real de esta fila (valor moneda)
        col = changeNumber - 1 # la columna a revisar es el cambio restante -1, porque las columnas van de 0 a change-1
        raiz.append(valor)
  

        changeNumber = changeNumber - valor

        ##Se agrega al cambio dado(print) y se resta al coin_change_data para actualizar el saldo disponible
        coin_change_data[valor] -= 1
        change_given[valor] += 1

        if changeNumber == 0:
            print("Esta raíz ha encontrado el cambio!")
            print("\n")
            return True
    
    for datos in coin_change_data:
        coin_change_data[datos] = coin_change_data[datos] + change_given[datos] # se regresa el saldo a su estado original, sumando lo que se había restado en el proceso

    for datos in change_given:
        change_given[datos] = 0

    if prevRow is None:
        return False  # no hay ningun camino aqui ya

    unvalid_paths.append((prevRow, prevCol))
    print(f"Se probo y fallo la raiz {raiz}")
    raiz.clear()
    raiz.extend(Craiz)
    
    ##pasa a la siguiente, si es así 
    if logic_changeimp(coin_table, unvalid_paths , ChangeNumberOG, coin_change_data, change_given, denominations,raiz):
        return True
    
    return False
    

def CheckMemory(unvalid_paths, row, col):
    for path in unvalid_paths:
        if path == (row, col):
            return False
    return True


       

logic_change_constructor(coin_table, change, coin_change_data)


# *******************************************************
print('\n************ Fin del programa **************\n')
# *******************************************************