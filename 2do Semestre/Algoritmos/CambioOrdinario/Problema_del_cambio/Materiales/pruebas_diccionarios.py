import subprocess
import json # Librería para poder leer el archivo json
import numpy as np

def limpiar_pantalla():
    subprocess.run('cls', shell=True) #Limpia la pantalla

limpiar_pantalla()

# "open('coin-change.json', 'r')" abre el archivo con nombre 'coin-change.json' dentro de la carpeta, con el parámetro 'r' que indica solo lectura
# "with" garantiza que el archivo se cierre automáticamente al terminar el bloque de instrucciones
# "as coin_change_json" se le da un nombre al archivo que se acaba de abrir 
# "json.load(coin_change_json)" lee el archivo y convierte su contenido de formato json a una estructura de python, en este caso un diccionario
# finalmente lo convertido lo guarda en "raw_coin_change_data"

raw_coin_change_data = {'1': 47, '2': 23, '5': 38, '10': 1, '20': 0, '50': 2, '100': 0}

print(raw_coin_change_data)

coin_change_data = {}

for element in raw_coin_change_data.keys():
    print(element)

# Solo claves
for k in raw_coin_change_data.keys():
    print(k)

# Solo valores
for v in raw_coin_change_data.values():
    print(v)

# Clave y valor al mismo tiempo
for k, v in raw_coin_change_data.items():
    print(k, v)