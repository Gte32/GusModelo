using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TDAList
{
    internal class ArrayQueue<T> : IQueue<T>
    {
        // ---------- VARIABLES ----------

        private const int INITIAL_CAPACITY = 5; //al ser constante no se modifica
        private T[] data;
        private int i; // índice del principio del queue
        private int j; // índice del final de la queue
        private int counter; // contador de elementos en la queue (cuantos elementos tiene)

        // ---------- PROPIEDADES ----------

        public int Capacity { get; private set; }

        // La condición sirve para evitar que se intente acceder a un elemento de un queue vacío
        public T Head => !Empty ? data[i] : throw new IndexOutOfRangeException("index"); // Retorna el primer elemento del queue, sin removerlo

        public T Tail => !Empty ? data[j] : throw new IndexOutOfRangeException("index"); // Retorna el último elemento del queue, sin removerlo

        public int Size => counter; // Retorna el número de elementos en el queue

        public bool Empty => counter == 0; // Retorna true si el queue está vacío

        public bool Full => counter == Capacity; // Retorna true si el queue está lleno

        // ---------- CONSTRUCTORES ----------

        // a) Constructor sin parámetros
        public ArrayQueue()
        {
            Capacity = INITIAL_CAPACITY;
            data = new T[Capacity];
            i = 0;
            j = -1;
            counter = 0;
        }

        // b) Constructor con capacity inicial

        public ArrayQueue(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACITY ? INITIAL_CAPACITY : capacity;
            data = new T[Capacity];
            i = 0;
            j = -1;
            counter = 0;
        }

        // c) Constructor por copia
        public ArrayQueue(IQueue<T> originQueue)
        {
            if (originQueue is ArrayQueue<T>) // Si el queue es de la misma clase que el array queue ...
            {
                ArrayQueue<T> aqueue = originQueue as ArrayQueue<T>; // Lo quiero observar momentaneamente como un ArrayStack
                Capacity = aqueue.Capacity;
                data = new T[Capacity];

                i = aqueue.i;
                j = aqueue.j;
                counter = aqueue.counter;
                Array.Copy(aqueue.data, data, Capacity);
            }

            // se puede utilzar un else if para cada tipo diferente de clase queue que fuese a ser creada

            else // Si se desconoce el tipo de queue que es ...
            {
                int originSize = originQueue.Size;
                // Asignamos la capacidad inicial solo si el queue a copiar desconocido tiene capacity menor al límite
                Capacity = originSize < INITIAL_CAPACITY ? INITIAL_CAPACITY : originSize;
                data = new T[Capacity];
                i = 0;
                j = originSize > 0 ? originSize - 1 : -1; // Si hay 0 elementos, iniciamos j en -1, si no en la originSize - 1 
                counter = originSize; // El contador se toma como el tamaño del queue original (la cantidad de elementos que tenía)

                for (int a = 0; a < originSize; a++)
                {
                    data[a] = originQueue.Dequeue();
                    originQueue.Enqueue(data[a]);
                }
            }
        }

        // Constructor para cualquier IEnumerable
        public ArrayQueue(IEnumerable<T> elements) : this()
        {
            foreach (var element in elements)
            {
                Enqueue(element);
            }
        }

        // --------- MÉTODOS ----------

        public void Enqueue(T e)
        {
            if (Full)
            {
                Expand();
            }

            // Incrementamos el índice de forma circular
            j = (j + 1) % Capacity;
            counter++;
            data[j] = e;
        }

        private void Expand()
        {
            T[] newData = new T[Capacity * 2];
            int sizeCounter = 0; // Contador de elementos copiados al nuevo array
            int a = i; // Variable para iterar el ciclo while

            while (sizeCounter < Size)
            {
                newData[sizeCounter] = data[a];
                a = (a + 1) % Capacity;
                sizeCounter++;
            }

            i = 0; // Reiniciamos el índice del principio del queue
            j = sizeCounter - 1; // Adaptamos el índice del final del queue al nuevo tamaño

            Capacity *= 2;
            data = newData; // cambiamos referencias
        }

        public T Dequeue()
        {
            if (Empty)
            {
                throw new IndexOutOfRangeException("index");
            }

            // Trabajar aqui
            if (Capacity / 2 >= INITIAL_CAPACITY && Size == Capacity / 5)
            {
                Shrink();
            }

            // Retornamos el valor actual de i y luego incrementamos i de forma circular
            T e = data[i];
            i = (i + 1) % Capacity;
            counter--;
            return e;
        }

        private void Shrink()
        {
            T[] newData = new T[Capacity / 2];

            int sizeCounter = 0; // Contador de elementos copiados al nuevo array
            int a = i; // Variable para iterar el ciclo while

            while (sizeCounter < Size)
            {
                newData[sizeCounter] = data[a];
                a = (a + 1) % Capacity;
                sizeCounter++;
            }

            i = 0; // Reiniciamos el índice del principio del queue
            j = sizeCounter - 1; // Adaptamos el índice del final del queue al nuevo tamaño

            Capacity /= 2;
            data = newData;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = i;
            int size = Size;

            for (int count = 0; count < size; count++)
            {
                yield return data[index];
                index = (index + 1) % Capacity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        // Funcion para imprimir la queue FALTA REVISAR Y DEBBUGEAR
#if DEBUG
        public string QueuePrint()
        {
            string aux = "[";
            int sizeCounter = 0;
            int a = i;

            while (sizeCounter < Size)
            {
                if (a == Capacity)
                {
                    a = 0;
                    continue;
                }

                aux += $" {data[a]}";
                sizeCounter++;
                a++;
            }

            aux += " ]";

            return aux;
        }
        public string DataPrint()
        {
            string aux = "[";

            for (int idx = 0; idx < Capacity; idx++)
            {
                aux += $" {data[idx]}";
            }

            aux += " ]";

            return aux;
        }


#endif
    }
}
