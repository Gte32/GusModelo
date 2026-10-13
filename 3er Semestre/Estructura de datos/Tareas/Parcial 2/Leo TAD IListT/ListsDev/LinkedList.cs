using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListsDev
{
    internal class LinkedList<T> : IList<T>
    {
        // ----- CLASES ----- // 

        private class Node
        {
            // El elemento es de tipo T
            public T Element { get; set; }
            // Tengo una referencia al siguiente nodo
            public Node Next { get; set; }

            // Nodo sin referencia
            public Node(T element) : this(element, null) { }

            // Nodo con referencia
            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
        }

        // ----- VARIABLES ----- // 

        private Node first;

        // ----- PROPIEDADES ----- // 

        public int Size { get; private set; }
        public bool Empty => first == null;

        // ----- CONSTRUCTORES ----- // 

        // Cuando creamos una lista vacía nuestro primer nodo es null
        public LinkedList()
        {
            first = null;
            Size = 0;
        }

        public LinkedList(IEnumerable<T> elements) : this()
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
            get { return Get(index); }
            set { Set(index, value); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                yield return LastNode.Element;
                LastNode = LastNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Get(int index)
        {
            // Prevenimos que el índice sea menor a 0 o mayor al tamaño de la lista
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("index");
            }

            // Recorremos toda la lista hasta encontrar la posición "index"

            Node LastNode = first;

            for (int i = 0; i < index; i++)
            {
                LastNode = LastNode.Next;
            }

            return LastNode.Element;
        }

        public void Set(int index, T element)
        {
            // Prevenimos que el índice sea menor a 0 o mayor al tamaño de la lista
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("index");
            }

            // Recorremos toda la lista hasta encontrar la posición "index"

            Node LastNode = first;

            for (int i = 0; i < index; i++)
            {
                LastNode = LastNode.Next;
            }

            LastNode.Element = element;
        }

        public void Add(T element)
        {
            if (Empty)
            {
                first = new Node(element);
                Size++;
            }
            else
            {
                // Asumimos que la lista al no estar vacía tiene un first
                Node lastNode = first;
                // Recorremos toda la lista
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                // Apuntamos al siguiente nodo de la lista
                lastNode.Next = new Node(element);
                Size++;
            }
        }

        public void AddAll(T first, params T[] elements)
        {
            Add(first);

            foreach(T e in elements)
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

            Node LastNode = first;
            Size++;

            // Si el nodo a insertar va al inicio de la lista
            if (index == 0)
            {
                first = new Node(element, LastNode);
                return;
            }

            // Recorremos la lista hasta llegar al índice previo de donde insertar el dato
            for (int i = 0; i < index - 1; i++)
            {
                LastNode = LastNode.Next;
            }

            // Creamos nuestro nuevo nodo, que apuntará al siguiente nodo del nodo actual
            Node NewNode = new Node(element, LastNode.Next);

            // Apuntamos del nodo actual hacia el nuevo nodo
            LastNode.Next = NewNode;
        }

        public void RemoveAt(int index)
        {
            // Prevenimos que el índice sea menor a 0 o mayor al tamaño de la lista
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("index");
            }

            Node LastNode = first;
            Size--;

            // Si el nodo a eliminar está en el inicio de la lista
            if (index == 0)
            {
                first = first.Next;
                return;
            }

            // Recorremos la lista hasta llegar al índice previo de donde insertar el dato
            for (int i = 0; i < index - 1; i++)
            {
                LastNode = LastNode.Next;
            }

            LastNode.Next = LastNode.Next.Next;
        }

        public void Clear()
        {
            first = null;
            Size = 0;
        }

        public bool Contains(T element)
        {
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                if (object.Equals(element, LastNode.Element))
                {
                    return true;
                }
                LastNode = LastNode.Next;
            }
            return false;
        }

        public void ForEach(Action<T> action)
        {
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                action(LastNode.Element);
                LastNode = LastNode.Next;
            }   
        }

        public bool All(Predicate<T> condition)
        {
            Node LastNode = first;
            
            for (int i = 0; i < Size; i++)
            {
                if (!condition(LastNode.Element))
                {
                    return false;
                }
                LastNode = LastNode.Next;
            }
            return true;
        }

        public bool Any(Predicate<T> condition)
        {
            Node LastNode = first;
            for (int i = 0; i < Size; i++)
            {
                if (condition(LastNode.Element))
                {
                    return true;
                }
                LastNode = LastNode.Next;
            }
            return false;
        }

        public int Count(Predicate<T> condition)
        {
            int count = 0;
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                if (condition(LastNode.Element))
                {
                    count++;
                }
                LastNode = LastNode.Next;
            }
            return count;
        }

        public T Find(Predicate<T> match)
        {
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                if (match(LastNode.Element))
                {
                    return LastNode.Element;
                }
                LastNode = LastNode.Next;
            }
            // Devuelve un nulo si no lo encuentra
            return default(T);
        }

        public IList<T> FindAll(Predicate<T> match)
        {
            var newlist = new ArrayList<T>();
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                if (match(LastNode.Element))
                {
                    newlist.Add(LastNode.Element);
                }
                LastNode = LastNode.Next;
            }
            return newlist;
        }

        // LeoMétodos
        // Primer intento de recorrer una lista enlazada utilizando un while, que posteriormente se cambio por un ciclo for
        public void Print()
        {
            Console.Write("[ ");
            if (Empty)
            {
                // No hacemos nada
            }
            else
            {
                // Asumimos que la lista al no estar vacía tiene un first
                Node lastNode = first;
                Console.Write($"{lastNode.Element} ");
                // Recorremos toda la lista
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                    Console.Write($"{lastNode.Element} ");
                }
            }
            Console.Write($"]\n");
        }
    }
}
