using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ListsDev
{
    internal class ArrayList<T> : IList<T>
    {
        // ----- CONSTANTES ----- //
        public const int INITIAL_CAPACITY = 10;

        // ----- VARIABLES ----- // 
        private T[] data;
        private int index;

        // ----- PROPIEDADES ----- // 
        public int Capacity { get; private set; }
        public int Size => index + 1;
        public bool Empty => index == -1;

        // ----- CONSTRUCTORES ----- //

        // Constructor que recibe un capacity
        public ArrayList(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACITY ? INITIAL_CAPACITY : capacity;
            data = new T[Capacity];
            index = -1;
        }

        /* Constructor sin parámetros //
        Enlazado de constructores, es decirle a un constructor, se va a apoyar en otro para hacer su trabajo
        Hacemos que un constructor que tiene la mayoría del código comun para referenciarlo en los constructores donde queremos usarlo
        Lo que dice es, si yo quiero crear un ArrayList() entonces manda a llamar el constructor que recibe un capacity con INITIAL_CAPACITY */
        public ArrayList() : this(INITIAL_CAPACITY) { }

        // Constructor basado en construir una lista basado en un enumerable
        // Llamamos al constructor vacío, que llama al constructor con parámetros
        public ArrayList(IEnumerable<T> elements) : this()
        {
            foreach (var e in elements)
            {
                Add(e);
            }
        }

        // ----- MÉTODOS ----- //        

        // Indexador
        public T this[int index]
        {
            get => data[index]; 
            set => data[index] = value; 
        }

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

        public T Get(int index) => data[index];

        public void Set(int index, T element) => data[index] = element;

        public void Add(T element)
        {
            if (Size == Capacity)
            {
                Capacity *= 2;
                // Resize crea un arreglo nuevo basandose en la referncia del arreglo original
                // con el tamaño de capacity, copiando los elementos del arreglo original
                Array.Resize(ref data, Capacity);
            }

            data[++index] = element; // con el ++index primero incrementa el indice y luego accede a él
        }

        // Concepto de params
        public void AddAll(T first, params T[] elements)
        {
            // Se pasa el first, por que es un elemento T
            Add(first);

            // Esto se hace para evitar que compile el AddAll() con un arreglo vacío, suponiendo que no incluyamos de parámetro el T first

            // Luego se pasan todo el arreglo de params extra
            foreach (T e in elements)
            {
                Add(e);
            }
        }

        public void Insert(int index, T element)
        {
            // Prevenimos que el índice sea menor a 0 o mayor al tamaño de la lista
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("index");
            }

            // Si el tamaño actual es la capacidad, entonces crecemos el arreglo
            if (Size == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref data, Capacity);
            }

            int indexToCopy = this.index + 1;
            while (indexToCopy > index)
            {
                data[indexToCopy] = data[indexToCopy - 1];
                indexToCopy--;
            }

            data[index] = element;
            this.index++; // Le avisamos a la lista que añadimos un elemento
        }

        public void RemoveAt(int index)
        {
            // Prevenimos que el índice sea menor a 0 o mayor al tamaño de la lista
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("index");
            }

            // Si el tamaño de nuestro arreglo es igual a un quinto de la capacidad
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
            Capacity = INITIAL_CAPACITY;
            data = new T[INITIAL_CAPACITY];
            index = -1;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Size; i++)
            {
                if (object.Equals(element, data[i]))
                {
                    return true;
                }
            }
            return false;
        }

        // Aquí quiero pasar un método que recibe un elemento de tipo T, y ese método hace algo que no devuelve un valor
        // Simplemente hace algo, la lambda decide que es lo que debe de hacer.
        // El metodo "action" recibe un elemento t y no devuelve nada

        // POV del creador de la lista "Pasame una función que me permita aplicar esa función a cada uno de los elementos de la lista"
        // POV del usuario "Le paso una función que toma un elemento de parámetro y luego la instrucción"
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Size; i++)
            {
                action(data[i]);
            }
        }

        // Predicate es un tipo de lambda que recibe un elemento de la lista y devuelve un booleano
        // Condition es la función o método tipo predicate

        // Esta función sirve para ver si todos los elementos cumplen una condición
        // Llama a este método si quieres saber si todos los elementos de la lista cumplen con una condición
        // Solamente devuelve verdadero si todos los elementos de la lista cumplen la condición
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

        // Método que devuelve verdadero si hay algún elemento que cumpla la condición
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

        // Método que cuenta la cantidad de elementos que cumpla una condición
        public int Count(Predicate<T> condition)
        {
            int count = 0;
            for (int i = 0; i<Size; i++)
            {
                if (condition(data[i]))
                {
                    count++;
                }
            }
            return count;
        }

        // 
        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < Size; i++)
            {
                if (match(data[i]))
                {
                    return data[i];
                }
            }
            // Devuelve un nulo si no lo encuentra
            return default(T);
        }

        public IList<T> FindAll(Predicate<T> match)
        {
            var newlist = new ArrayList<T>(); 

            for (int i = 0; i < Size; i++)
            {
                if (match(data[i]))
                {
                    newlist.Add(data[i]);
                }
            }
            return newlist;
        }
    }
}
