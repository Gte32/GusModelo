
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TDAList
{
    internal class PriorityQueue<T> : IQueue<T>
    {
        // ---------- VARIABLES ----------

        private const int INITIAL_CAPACITY = 5; //Valor del indice inicial
        private T[] data;


        //obj = objeto almacenado
        // priority = que prioridad tiene
        // index = donde esta en su index
        private (T obj, int priority, int index) head; // Indice de mayor prioridad
        private (T obj, int priority, int index) tail; // Indice de menor prioridad



        private int counter; // contador de elementos en la queue (cuantos elementos tiene)

        // ---------- PROPIEDADES ----------

        public int Capacity { get; private set; }

        // La condición sirve para evitar que se intente acceder a un elemento de un queue vacío
        public T Head => !Empty ? data[head.index] : throw new IndexOutOfRangeException("index"); // Retorna el primer elemento del queue, sin removerlo

        public T Tail => !Empty ? data[tail.index] : throw new IndexOutOfRangeException("index"); // Retorna el último elemento del queue, sin removerlo

        public int Size => counter; // Retorna el número de elementos en el queue



        //Center, para poder saber cual es el elemento del medio
        public int Center => Size / 2;



        public bool Empty => counter == 0; // Retorna true si el queue está vacío

        public bool Full => counter == Capacity; // Retorna true si el queue está lleno



        // ---------- CONSTRUCTORES ----------
        public PriorityQueue()
        {
            Capacity = INITIAL_CAPACITY;
            data = new T[Capacity];
            head = (default(T), 0, 0);
            tail = (default(T), -1, -1);
            counter = 0;
        }

        // b) Constructor con capacity inicial

        public PriorityQueue(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACITY ? INITIAL_CAPACITY : capacity;
            data = new T[Capacity];
            head = (default(T), 0, 0);
            tail = (default(T), -1, -1);
            counter = 0;
        }

        // Constructor para cualquier IEnumerable
        public PriorityQueue(IEnumerable<T> elements) : this()
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

            // Cambiar el meter
            // j = ultima
            // i = primera
            j = (j + 1) % Capacity;
            counter++;
            data[j] = e;
        }

        private void Expand()
        {
            
        }

        public T Dequeue()
        {


            // Implementar dequeue, quitar y devolver
            T e = data[0];


            return e;
        }

        private void Shrink()
        {
           
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = head.index;
            int size = Size;

            for (int count = 0; count < size; count++)
            {
                yield return data[index];
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Arrange()
        {


        }




        // Funcion para imprimir la queue FALTA REVISAR Y DEBBUGEAR -- Adaptado a Lineal
#if DEBUG
        public string QueuePrint()
        {
            string aux = "[";

            for (int index = head.index; index < head.index + Size; index++)
            {
                aux += $" {data[index]}";
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
