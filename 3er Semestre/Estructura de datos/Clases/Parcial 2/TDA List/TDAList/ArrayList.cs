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
        public int Count => Size;

        public bool Empty => index == -1;


        //CONSTRUCTORES
        public ArrayList(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACITY ? INITIAL_CAPACITY : capacity;
            data = new T[Capacity];
            index = -1;

        }

        public ArrayList() : this(INITIAL_CAPACITY) { }

        public ArrayList(IEnumerable<T> elements)
        {
            Capacity = INITIAL_CAPACITY;
            data = new T[Capacity];
            index = -1;

            foreach (T element in elements)
            {
                Add(element);
            }
        }


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
            // Prevenimos que el índice sea menor a 0 o mayor al tamaño de la lista
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("index");
            }

            // Si el tamaño de nuestro arreglo es igual a un quinto de la capacidadç
            // Y tampoco partido a la mitad, va ser menor que initial capacity
            if (Capacity / 2 >= INITIAL_CAPACITY && Size == Capacity / 5)
            {
                Capacity /= 2;
                Array.Resize(ref data, Capacity);
            }

            while (index < Size - 1) // o this.index
            {
                data[index] = data[index + 1];
                index++;
            }
            this.index--;
        }

        public void Clear()
        {
            index = -1;
            Capacity = INITIAL_CAPACITY;
            data = new T[INITIAL_CAPACITY];
            Array.Resize(ref data, Capacity);
        }



        //clase nueva

        //action t es lo mismo que la clase de arriba, que nos permite usarlos
        //recibe el tipo de la lista y les hace un accion

        //pasame una funcion que aplique a cada elemento de la lista, 
        // En esta funcion la paso con main de esta manera, a un elemento cualquiera yo le quiero hacer algo, sea imprimir, sumar,1 etc
        // y esta simplemente dice ah, voy a hacerlo a todo
        public void ForEach(Action<T> action)
        {
            // el foreach no funcionaria, porque la lista tiene espacios vacios de activados ya, cuando crece, decrece o al inicio
            //entonces lo aplica a elementos que NO deben ser afectados
            /*
            foreach(var item in data)
            {
                action(item);
            }
            */

            for (int i = 0; i < Size; i++)
            {
                action(data[i]);
            }
        }

        //si la lissta contiene un elemento que EXISTE con la condicion, devuelve true, sino false
        public bool Contains(T item)
        {
            for (int i = 0; i < Size; i++)
            {
                if (data[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        //contar los elementos que existen segun la condicion
        public int CountIf(Predicate<T> condition)
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                if (condition(data[i]))
                {
                    count++;
                }
            }
            return count;
        }


        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < Size; i++)
            {
                if (match(data[i]))
                {
                    return data[i];
                }
            }
            return default(T);
        }


        //cambiado de Ilist a ArayList para que jale, checar error
        public ArrayList<T> FindAll(Predicate<T> match)
        {
            var Found = new ArrayList<T>();

            for (int i = 0; i<Size; i++)
            {
                if (match(data[i]))
                {
                    Found.Add(data[i]);
                }
            }

            return Found;
        }



        // Llama a este elemento si quieres saber que todos elementos en la lista pueden cumplir con una condicion
        public bool All(Predicate<T> condition)
        {
            for (int i = 0; i < Size; i++)
            {
                if (!condition(data[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Any(Predicate<T> condition)
        {
            for (int i = 0; i < Size; i++)
            {
                if (condition(data[i]))
                {
                    return true;
                }
            }
            return false;
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
