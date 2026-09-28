using Calculadora_RPN_en_CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_RPN_en_CSharp
{
    internal class ArrayStack<T> : IStack<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] data;
        private int index;

        public int Capacity { get; private set; } // con private set solo podemos modificar la propiedad desde dentro de la clase.

        public int Size => index + 1;

        public bool Empty => index == -1;

        public bool Full => index == data.Length - 1;

        public int Index => index;



        public ArrayStack()
        {
            Capacity = INITIAL_CAPACITY; // Te permite ignorar la propiedad de solo lectura, ya que una vez creado el objeto no se puede modificar
            data = new T[Capacity];
            index = -1;
        }

        // jjcnjdsnsj
        public ArrayStack(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACITY ? INITIAL_CAPACITY : capacity; // un if, "condicion ? si se cumple : si no se cumple"
            data = new T[Capacity];
            index = -1;
        }

        //indexador, para acceder a data sin tenerlo publico, simplemente para ver y comparar
        public T this[int i]
        {
            get { return data[i]; }
        }

        public void Push(T e)
        {
            if (Full)
            {
                T[] newData = new T[Capacity * 2];
                Array.Copy(data, newData, Capacity);

                Capacity *= 2;
                data = newData; // Estamos cambiando referencias
            }

            data[++index] = e;
        }

        public T Pop()
        {
            if (Empty)
            {
                throw new IndexOutOfRangeException("index");
            }

            if (Capacity / 2 >= INITIAL_CAPACITY && index == Capacity / 5)
            {
                T[] newData = new T[Capacity / 2];
                Array.Copy(data, newData, Size);

                Capacity /= 2;
                data = newData;
            }

            return data[index--];
        }

        public T Peek()
        {
            if (Empty)
            {
                throw new IndexOutOfRangeException("index");
            }

            return data[index];
        }


    }


    public class Symbology<T> : ISymbology<T>
    {
        public Dictionary <char, int> symbols { get; set; }

        public Symbology()
        {
            symbols = new Dictionary<char, int>()
            {
                { '+', 1 },
                { '-', 1 },
                { '*', 2 },
                { '/', 2 },
                { '^', 3 },
                { '(', 4 },
                { ')', 4 }
            };
        }
    }


    public class Workspace
    {
        private Dictionary<string, double> variables;

        public Workspace()
        {
            variables = new Dictionary<string, double>();
        }

        public void Define(string nombre, double valor) 
        {
            variables[nombre] = valor;
        }
        public double Get(string nombre) 
        {
            if (!variables.ContainsKey(nombre))
            {
                throw new Exception($"Error - variable '{nombre}' no definida");
            }
            return variables[nombre];
        }
        public bool Exists(string nombre) 
        {
            return variables.ContainsKey(nombre);
        }

    }

}
