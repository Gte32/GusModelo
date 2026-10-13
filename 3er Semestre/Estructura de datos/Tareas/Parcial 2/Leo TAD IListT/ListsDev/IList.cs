using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsDev
{
    public interface IList<T> : IEnumerable<T>
    {
        int Size { get; } 
        bool Empty { get; }

        // Es un indexador, es permitir que un objeto reconozca los corchetes, o sea lista1[i]
        T this[int index] { get; set; }

        // Si yo quiero leer el objeto en la posición 10 puedo hacerlo con el objeto[indice] u objeto.Get(indice)
        T Get(int index);

        // De misma manera se puede poner el set
        void Set(int index, T element);

        // Método para agregar un elemento
        void Add(T element);

        // Params sirve para poner un número variable de elementos por ejemplo list.Add(10, 20, 50, -5);
        void AddAll(T first, params T[] elements);
        void Insert(int index, T element);
        void RemoveAt(int index);
        void Clear();

        // Determines whether a sequence contains a specified element by using
        // the default equality comparer.
        bool Contains(T element);

        // Determines whether all elements of a list satisfy a condition.
        bool All(Predicate<T> condition);
        // Determines whether any element of a sequence satisfies a condition.
        bool Any(Predicate<T> condition);
        // Returns a number that represents how many elements in the list
        // satisfy a condition.
        int Count(Predicate<T> condition);
        // Searches for an element that matches the conditions defined
        // by the specified predicate, and returns the first occurrence.
        T Find(Predicate<T> match);
        // Retrieves all the elements that match the conditions defined
        // by the specified predicate.
        IList<T> FindAll(Predicate<T> match);
        // Performs the specified action on each element of the list.
        void ForEach(Action<T> action);
    }
}
