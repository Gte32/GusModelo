using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TDAList
{
    internal class ArrayList<T> : IList<T>
    {
        //NUEVOS

        public const int INITIAL_CAPACITY = 10;

        private T[] data;
        private int index;

        public int Capacity { get; private set; }

        public int Size => index + 1;

        public bool Empty => index == -1;


        //CONSTRUCTORES
        public ArrayList(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACITY ? INITIAL_CAPACITY : capacity;
            data = new T[Capacity];
            index = -1;

        }

        public ArrayList() : this(INITIAL_CAPACITY) { }


        public T this[int index] 
        {
            get => data[index];
            set => data[index] = value ;
        }

        public void Add(T element)
        {
            if (Size == Capacity)
            {
                Capacity *= 2;
                //funcion de c# copia el arreglo original y usa la capacidad a crear
                Array.Resize(ref data, Capacity);
            }

            data[++index] = element;
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();


        //ENUMERADORES

        //Dedicamos 2 clases mas o menos comprender como es que funciona un enumerador. Este NO crea un index, si no que va recorriendo
        //y solo asi devuelve el valor
        // la manera de guardar el camino que toamamos es mediante el yield return, que guarda por donde vino 


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //misma funcionalidad que el indexador
        public T Get(int index) => data[index];

        public T Set(int index, T element) => data[index] = element;

        public void AddAll(T first, params T[] elements)
        {
            Add(first);
            foreach (T e in elements)
            {
                Add(e);
            }

        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException("Index");
            }

            if (Size == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref data, Capacity);
            }

            int indexToCopy = this.index + 1;

            while (indexToCopy > index + 1)
            {
                data[indexToCopy] = data[indexToCopy - 1];
                indexToCopy--;
            }

            data[index] = element; 
        }


        // IMPLEMENTAR
        //validar indice, remover elemento y ajustar tamaño
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            index = -1;
            Capacity = INITIAL_CAPACITY;
            data = new T[INITIAL_CAPACITY];
            Array.Resize(ref data, Capacity);
        }



        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

       

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
