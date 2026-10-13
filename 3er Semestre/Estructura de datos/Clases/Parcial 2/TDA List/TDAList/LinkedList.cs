using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TDAList
{
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

        //esta es la referencia, el primer nodo de todos
        private Node first;
        

        public int Size { get; set; }


        //lambada, si no hay nada en primero es null
        public bool Empty => first == null;


        public LinkedList()
        {
            first = null;
            Size = 0;   
        }


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

        //AREGAGAR EL FOREACH DE ESTA LISTA
        //PROYECTO ACABAR EL LINKEDLIST AQUI A FINAL


        //Hay que hacer el sort, para hacer el sort, necesitamos hacer un index primero
        //seria hacer este y luego hacer sort
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            if (Size > 0)
            {
                // cuando tienes elementos
                Node current = first;
                do
                {
                    // el primero nodo regresa el primero elemento, y termina el codigo 
                    yield return current.Element;
                    current = current.Next;
                }
                while (current != null);
                
            }

        }

        public LinkedList(IEnumerable<T> elements) : this()
        {
            foreach (var e in elements)
            {
                Add(e);
            }
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
