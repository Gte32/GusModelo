# ***************************************************
print('\n****************************************\n')
# ***************************************************

def factorialI(n):
    #si factorialI no tiene un atributo counter, creamos el atributo
    if not hasattr(factorialI, "counter"):
        factorialI.counter = 0

    #De ahí en adelante vamos a contar
    factorialI.counter += 1

    factor = 1
    for i in range(1, n+1):
        factor *= i
    return factor

for i in range(7):
    print(f'!{i} = {factorialI(i)}')

print(f'\n#Llamadas => {factorialI.counter} veces')

# ***************************************************
print('\n****************************************\n')
# ***************************************************

def factorialR(n):
    if not hasattr(factorialR, "counter"):
        factorialR.counter = 0

    factorialR.counter += 1

    if n == 0:
        return 1
    else:
        return n * factorialR(n-1)
    
for i in range(7):
    print(f'!{i} = {factorialR(i)}')

print(f'\n#Llamadas => {factorialR.counter} veces')

# ***************************************************
print('\n****************************************\n')
# ***************************************************

def fibonacciI(n):
    if not hasattr(fibonacciI, "counter"):
        fibonacciI.counter = 0

    fibonacciI.counter += 1

    if n == 0 or n == 1:
        return 1
        
    f_1 = 1
    f_2 = 1
    for i in range(2, n+1):
    
        f = f_1 + f_2
        f_1 = f_2
        f_2 = f

    return f

for i in range(12):
    print(f'fib({i}) = {fibonacciI(i)}')

print(f'\n#Llamadas => {fibonacciI.counter} veces')

# ***************************************************
print('\n****************************************\n')
# ***************************************************

def fibonacciR(n):
    if not hasattr(fibonacciR, "counter"):
        fibonacciR.counter = 0

    fibonacciR.counter += 1
    
    if n == 0 or n == 1:
        return 1
    
    return fibonacciR(n-1) + fibonacciR(n-2)

for i in range(12):
    print(f'fib({i}) = {fibonacciR(i)}')

print(f'\n#Llamadas => {fibonacciR.counter} veces')

# ***************************************************
print('\n****************************************\n')
# ***************************************************

#Programación Dinámica (Dinamic Programming)

def factorialDP(n):
    if not hasattr(factorialDP, "counter"):
        factorialDP.counter = 0

    factorialDP.counter += 1

    if not hasattr(factorialDP, "mem"):
        factorialDP.mem = {}

    if n == 0:
        return 1
    #luego de revisar si es 0, se revisa si la clave n ya está en la memoria, si si lo es regresa el valor previamente memorizado
    elif n in factorialDP.mem:
        return factorialDP.mem[n]
    #Si no es memorizado entonces lo calcula
    else:
        aux = n * factorialDP(n-1)
        #en la clave n voy a guardar el cálculo del factorial realizado
        factorialDP.mem[n] = aux
        return aux
    
for i in range(7):
    print(f'!{i} = {factorialDP(i)}')

print(f'\n#Llamadas => {factorialDP.counter} veces')

# ***************************************************
print('\n****************************************\n')
# ***************************************************

def fibonacciDP(n):
    if not hasattr(fibonacciDP, "counter"):
        fibonacciDP.counter = 0

    fibonacciDP.counter += 1

    #si fibonacciDP no tiene su memoria se la creamos
    if not hasattr(fibonacciDP, "mem"):
        fibonacciDP.mem = {}
    
    if n == 0 or n == 1:
        return 1
    #Si fibonacci ya fue calculado lo retorna
    elif n in fibonacciDP.mem:
        return fibonacciDP.mem[n]
    
    aux = fibonacciDP(n-1) + fibonacciDP(n-2)
    fibonacciDP.mem[n] = aux
    return aux

for i in range(12):
    print(f'fib({i}) = {fibonacciDP(i)}')

print(f'\n#Llamadas => {fibonacciDP.counter} veces')

# ***************************************************
print('\n****************************************\n')
# ***************************************************   