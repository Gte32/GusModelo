using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TDAList
{

    //sin la linkedlistdev.ilist, se aplicaba la generica de C#
    internal class LinkedList<T> : IList<T>
    {


        //clase de Nodo, dentro de nuestra LinkedList, el complejo de Nodos
        public class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element)
            {
                Element = element;
                Next = null;
            }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }


        }

        //VARIABLES

        //esta es la referencia, el primer nodo de todos
        private Node first;
        


        //PROPIEDADES
        //el tamaño de esta
        public int Size { get; set; }


        //lambada, si no hay nada en primero es null
        public bool Empty => first == null;

        //CONSTRUCTORES

        //constructor general, se crea, pone el first en nada, y inicia el size
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


        //MÉTODOS

        //HECHO EN CLASE
        //estamos usando toda la funcion, es decir el complejo de Nodos aquí con cada funcion
        public void Add(T element)
        {
            if (Empty)
            {
                first = new Node(element);
            }
            else 
            {
                Node lastNode = first;

                //actualiza lastnode, es decir, del ultimo nodo, se mueve al siguiente,
                while(lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }


                lastNode.Next = new Node(element);
            }

            Size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Size > 0)
            {
                // cuando tienes elementos
                //saca el actualy lo mantiene como primero
                Node current = first;
                do
                {
                    // el primero nodo regresa el primero elemento, y termina el codigo 
                    yield return current.Element;

                    //si lo vuelves a invocar cae y se mueve al siguiente y te lo devuelve arriba
                    current = current.Next;
                }
                //cuando se salga y no haya mas se volvera nulo y parara
                while (current != null);

            }

        }

        //extra para hacer funcionar el get enumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        // A PARTIR DE AQUI TODOS HECHOS POR EL ALUMNO
        //AREGAGAR EL FOREACH DE ESTA LISTA
        //PROYECTO ACABAR EL LINKEDLIST AQUI A FINAL


        //Hay que hacer el sort, para hacer el sort, necesitamos hacer un index primero
        //seria hacer este y luego hacer sort


        //llama a get y set, para hacer por individuo, este (this), recibe index y hace tal, para set necesita value
        public T this[int index]
        {
            //puesto con lambdas
            get => Get(index);
            set => Set(index, value);
        }

        //un get debe devolver el dato actual donde se encuentre el linked list
        //este recibe el index (donde quiere estar) y debe tirar si hay o no hay
        public T Get(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new NotImplementedException("index out of range");
            }

            Node LastNode = first;

            //recorre todo hasta que llega a index, y te lo devuelve su elemento

            for (int i = 0; i < index; i++)
            {
                LastNode = LastNode.Next;
            }

            return LastNode.Element;


        }


        //obtiene index y element, recorre todos los elementos, hasta el index, y lo vuelve el elemento de ese
        public void Set(int index, T element)
        {
            if (index < 0 || index >= Size)
            {
                throw new NotImplementedException("index out of range");
            }

            Node LastNode = first;

            for (int i = 0; i < index; i++)
            {
                LastNode = LastNode.Next;
            }

            LastNode.Element = element;

        }

        //el primero lo manda a add, y si hay mas, los agrega igual con add
        public void AddAll(T first, params T[] elements)
        {
            Add(first);

            foreach (T e in elements)
            {
                Add(e);
            }
        }


        //clears the board, literal reinicia los valores iniciales
        public void Clear()
        {
            Size = 0;
            first = null;
        }

        //checa un elemento contains, es decir, checa si alguno lo tiene
        public bool Contains(T element)
        {
            Node LastNode = first;
            for ( int i = 0; i< Size; i++)
            {
                if (object.Equals(LastNode.Element, element) )
                {
                    return true;
                }
                LastNode = LastNode.Next;
            }

            return false;
        }

        //checa que todos lo tenga, si uno no cumple falso
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

        //si alguno cumple la condicion
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

        //contar los elemntos que tienen la condicion
        public int CountIf(Predicate<T> condition)
        {
            Node LastNode = first;
            int count = 0;
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

        //matchear alguno, ver si coincide uno
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

            return default(T);
        }


        //hacer una lista de nodos y devolver todos que cumplan una condicion
        public IList<T> FindAll(Predicate<T> match)
        {
            Node LastNode = first;
            var Found = new LinkedList<T>();

            for (int i = 0; i < Size; i++)
            {
                if (match(LastNode.Element))
                {
                    Found.Add(LastNode.Element);
                }
                LastNode = LastNode.Next;
            }

            return Found;
        }

        //hacer una accion a cada elementp
        public void ForEach(Action<T> action)
        {
            Node LastNode = first;

            for (int i = 0; i < Size; i++)
            {
                action(LastNode.Element);
                LastNode = LastNode.Next;
            }
        }

        //insertar en un lugar, luego linkear al siguiente nodo que iria
        //si es primero solo se ajusta acordemente
        public void Insert(int index, T item)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException("Index");
            }

            Node LastNode = first;
            Size++; // se crea el esapcio para el nuevo
            if (index == 0)
            {
                first = new Node(item, LastNode); // lastNode se vuelve su siguiente, se mueve
                return;

            }


            //llegamos al valor a agregar, menos 1
            for (int i = 0; i< index-1; i++)
            {
                LastNode = LastNode.Next;
            }

            //nuevo nodo a ingresar, linkea al siguiente
            Node NewNode = new Node(item, LastNode.Next);

            //estamos todavia 1 antes, solo linkeamos al que hicimos, y ya
            LastNode.Next = NewNode;
        }


        //simplemente se cambia la referencia al que seguiria y asi se "elimina"
        //si es primero pues el siguiente y ya
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



        //metodo que agrego edson luego
        public void Sort(Comparison<T> comparison)
        {
            throw new NotImplementedException();
        }

        //leo metodo de print
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
