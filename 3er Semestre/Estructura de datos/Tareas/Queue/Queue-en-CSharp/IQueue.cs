using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Queuedev
{
    
    internal class Queue<T> : IQueue<T>
    {

        //El data, es el arreglo que vamos a estar trabajando.
        public T[] data; 

        //El size, es aquel que vamos a estar siguiendo el tamaño del arreglo
        private int size;

        //primera parte del queue (cabeza)
        //siempre empieza en 0, pues es el primero
        private int head = 0;

        //ultima parte del queue (cola)
        //la cola debe empezar en -1, pues al inicio no hay NADA, entonces al moverse avanzara 1
        private int tail = -1;

        //un arreglo no tiene sentido de 2, demosle un valor minimo siempre, sirve igual para limitar su reduccion
        private int initialCapacity = 4;


        //Constructor de las variables
        //El dato Head es el primero, el dato es Tail es el ultimo, y el dato Size es el tamaño del arreglo
        //saca head de la plantilla
        public int Head => head;
        //size valor importante, a diferencia de Lenght, que nos recorrera y sabra todo el valor del arreglo, size nos dice cuantos HAY adentro, idenpendientemente del tamaño
        public int Size => size;
        //forma simplificada de length, literal por mame, que no se ve escribi length mal por un buen rato
        public int Length => data.Length;

        //tail, el valor de la plantilla de tail
        public int Tail => tail;
        //valores conservado del Istack, empty, si no hay nada, como sabemos esto, si size es 0
        public bool Empty => size == 0;
        //lo mismo, esta lleno si size llega a llegar a alcanzar a length
        public bool Full => size == Length;

        //funcion de crear queue, lo unico a destacar es que no puede ser menor que el initialSize hardocodeado

        public Queue()
        {
            //crear uno de base con 4
            data = new T[initialCapacity];
            size = 0;

        }
        public Queue(int capacity)
        {
            //crear uno con capacidad definida
            if(capacity < initialCapacity) 
            {
                capacity = initialCapacity;
            }

            data = new T[capacity];
            size = 0;
        }

        public Queue(IQueue<T> original)
        {
            //crear de una copia
            if(original is Queue<T>)
            {
                //mas facil es el mismo, copia
                Queue<T> copia = original as Queue<T>;
                data = new T[copia.Length];
                head = copia.head;
                tail = copia.tail;
                size = copia.size;
            }
            else
            {
                //es de la plantilla mas no es el mismo
                int originalSize = original.Size;
                //separamos, capacity es que esta adentro
                int capacity = originalSize;

                if (originalSize< initialCapacity)
                {
                    //solo cambia capacity, por loas cosas
                    capacity = initialCapacity;
                }
                data = new T[capacity];
                head = 0;
                if (originalSize >0)
                {
                    tail = originalSize -1;
                }
                else
                {
                    tail = -1;
                }

                size = originalSize;
                
                //el for checa solo los objetos
                for (int i = 0; i < capacity; i++)
                {
                    //dequeue te devuelve el dato que sacarias sacas
                    data[i] = original.Dequeue();
                    //metes al nuevo
                    original.Enqueue(data[i]);
                }

            }
        }
        //funcion importante, privada, porque no queremos acceder a ella en program, basicamente toma una nueva longitud y pasa los valores de data
        //manteniendo el orden, luego devuelve una lista T[] para reemplazar el data original
        //reseteea los valores de head y tail, puesto esto es como un soft reset
        private T[] DataSort(int newLength)
        {
            T[] newData = new T[newLength];

            for (int i = 0; i < size; i++)
            {
                //head + i, recorre data dentro del limite de lenght
                newData[i] = data[(head + i) % Length];
            }

            head = 0;
            //literal el -1 inicial, recordemos solo loopea, entonces no puede salirse del rango de variables
            tail = size -1; 

            return newData;
        }
        //funcion de enqueue, mete un valor y mueve indices
        public void Enqueue(T e)
        {  
            //si alguna vez llega a llenarse, se duplica su capcidad y se rellenan sus datos
            if (Full)
            {
                int moreLenght = Length*2;
                data = DataSort(moreLenght);
            }

            //INICIA AUTISMO
            //como funciona el modulo length:
            //tail tiene valores de 0-length, nunca mas, porque se resetea, aunque funcionaria de todas maneras, si length es siempre la longitud
            //aqui aprovecharemos una propiedad matemática que afirma n = qL + r: n= dividiendo, L= divisor, q=cociente, r=residuo o resto
            //por ejemplo en 7, donde lenght es 10. 
            // 7 = 0(10) + 7. => 7 = 0 +7, 7=7
            //con uno mayor tipo 17,  17 = 1(10) + 7, 17= 10 +7, 7=7, aqui se aprecia mejor, basicamente el multiplicando es el numero de vueltas, y el residuo es el numero por asi decir

            //si repetimos infinitamente el proceso, veremos como cuando llegue a un multiplo del lenght, sera 0 y se repetira de nuevo a una distancia del length
            //entonces un length 10, iria con modulo, 0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,...
            //permitiendonos un loop perfecto para nuestros usos
            //TERMINA AUTISMO

            //movemos tail y constringimos al loop
            tail = (tail + 1) % Length;
            //al ser el ultimo dato, lo metemos ahi, empieza en -1, entonces 0, etc.
            data[tail] = e;
            //aumentamos size, detectando valores metidos unicamente
            size++;

        }

        public T Dequeue()
        {
            if (Empty)
            {
                //si no hay nada no puedes quitar nada, tremendo perdedor
                throw new IndexOutOfRangeException("index");
            }

            //como vamos a estar reemplazando
            //guardamos el auxiliar, simplemente no olvidamos data
            T aux = data[head];
            //ok aqui toca defenderme y entender, default(t), realmente toma el valor sea int,bool y pone un "default", es decir, 0 si espera un int, 0.00 si espera un double es 0.0
            //ahora, mas relevantemente, importa?
            //realmente vale burguer, pq con head y tail definimos rango dentro de esto que nos importa, y con size cuanto hay
            //entonces esa cosa podria ser cualquiera, y seria ignorada, la cosa es q nuestra logica la ignore
            data[head] = default(T);
            //misma logica que tail, pero aqui con tail, recordemos head se quita en queue, entonces aumentamos head con nuestro modular, y ya, igual el tamaño es irrelevante
            //pq crece dinamicamente, entonces aqui se mantiene
            head = (head + 1) % Length;
            //quitamos uno en size, o sea si esta, pero no nos importa
            size--;
            
            
            //se encoge si tiene 1/5 libre, Y si es mayor a su initial size, asi no se encoje super chiquito
            if (size<= Length * 4/5 && Length > initialCapacity)
            {
                int lessLength = Length - (Length/5);
                
                //recuerdan como la confirmacion de arriba se supone protege de esto, si, yo igual, pero esto me protege del hombre malo (edson)
                if (lessLength< initialCapacity)
                {
                    lessLength = initialCapacity;
                }
                
                //reordenar con el data sort y resetear
                data = DataSort(lessLength);
            }

            //devuelves el numero quitado, creo era para ver en consola, se quedo del istack
            return aux;


        }

        #if DEBUG
        public string DataPeek()
        {

            //version cambiada del data peek para recorrer de head a tail, literal es para poder imprimir y ya
            //edson no me mates porfa
            string aux = "[";

            for (int i = 0; i < Size; i++)
            {
                //loopea, simplemente sumas la posicion que quiera y divides entre lenght
                int pos = (Head + i) % Length;
                aux += $"{data[pos]}, ";
            }

            aux += "]";

            return aux;

        } 

        #endif
        
    }


}