using System;
using System.Collections.Generic;
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

        private int head = 0;
        private int tail = -1;


        //Constructor de las variables
        //El dato Head es el primero, el dato es Tail es el ultimo, y el dato Size es el tamaño del arreglo
        public int Head => head;
        public int Size => size;
        public int Lenght => data.Length;

        //Es el último, se suma, y se hace módulo del tamaño del arreglo, para que no se salga del rango
        public int Tail => tail;
        public bool Empty => size == 0;
        public bool Full => size == Lenght;


        public Queue(int capacity)
        {
            data = new T[capacity];
            size = 0;
        }
        public void Enqueue(T e)
        {  
            if (Full)
            {
                T[] newData = new T[Lenght * 2];
                Array.Copy(data, newData, Lenght);
                data = newData;
            }
            //Se suma y con el modulo lenght loop
            tail = (tail + 1) % Lenght;
            data[tail] = e;
            size++;

        }

        public T Dequeue()
        {
            if (Empty)
            {
                throw new IndexOutOfRangeException("index");
            }
            //throw new NotImplementedException();
            T aux = data[head];
            head = (head + 1) % Lenght;
            size--;
            data[head] = default(T);
            return aux;
        }

        #if DEBUG
        public string DataPeek()
        {
            string aux = "[";

            for (int i = 0; i < Size; i++)
            {
                //loopea, simplemente sumas la posicion que quiera y divides entre lenght
                int pos = (Head + i) % Lenght;
                aux += $"{data[pos]}, ";
            }

            aux += "]";

            return aux;

        } 

        #endif
        
    }


}