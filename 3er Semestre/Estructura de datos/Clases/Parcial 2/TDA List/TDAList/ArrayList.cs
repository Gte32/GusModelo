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

        

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
