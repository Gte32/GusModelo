using System.Collections.Generic;
//Gustavo Luis Martínez Ortega DTS 3A

namespace TADS
{
    //RESUMEN NOTAS PDF
    /*
     * Tipo Abstracto de Datos TAD
     * Coleccion de valores y operaciones definidas por una especificacion independiente de su implementacion
     * 
     * Un TAD te dice QUE dato guarda, mas QUE se puede hacer con ellos
     * 
     * PERO -> NO te dice COMO lo hace
     */

    //mayoria de conceptos y notas aqui: https://www.youtube.com/watch?v=PIWAKf26NCk
    //Descripciones y metodos: https://medium.com/@devnurai/comprehensive-guide-to-ilist-in-c-296deea68ab5

    public interface IList<T>
    {
        //HAY CUATRO TIPOS DE TADS QUE OBSERVAREMOS

        //OBSERVADORA NO SELECTORA
        // Devuelven información del estado general de la lista (bool, int, etc.)
        // sin extraer ni devolver elementos internos específicos.

        /// Obtiene la cantidad total de elementos contenidos en la lista.
        int Count { get; }

        /// Indica si la lista es de solo lectura.
        bool IsReadOnly { get; }

        /// Indica si la lista no contiene elementos.
        bool IsEmpty { get; }

        /// Determina si un elemento está en la lista (Observadora No Selectora).
        bool Contains(T item);

        /// Copia todos los elementos de la lista a un arreglo compatible, 
        /// comenzando en el índice especificado del arreglo destino.
        void CopyTo(T[] array, int arrayIndex);

        //OBSERVADORAS SELECTORAS
        //Consultan o devuelven un elemento o posición específica dentro de la lista

        /// Devuelve el índice de la primera aparición de un elemento 
        int IndexOf(T item);

        /// Retorna un enumerador que permite iterar secuencialmente sobre la lista 
        /// Usa la plantilla y lo hereda de Ienumerator, lo necesitamos para el foreach
        /// unica cosa extra NO de la pagina pero si para que funcione su iteracion
        IEnumerator<T> GetEnumerator();

        //CONSTRUCTORA NO GENERADORAS
        // Modifican el contenido de un elemento existente, pero NO alteran 
        // la estructura ni la cantidad/tamaño de elementos de la lista

        /// Permite get o set de elementos en un index especifico usando un indexer
        T this[int index] { get; set; }


        /// Devuelve el ultimo index 
        int LastIndexOf(T item);

        //CONSTRUCTORA GENERADORA
        // Modifican sustancialmente la estructura de la lista, ya sea alterando
        // su tamaño, agregando elementos o eliminándolos

        /// Agrega un elemento al final de la lista.
        void Add(T item);

        /// Inserta un elemento en la lista en el índice especificado.
        void Insert(int index, T item);

        /// Elimina la primera aparición de un elemento específico.
        bool Remove(T item);

        /// Elimina el elemento en el índice especificado.
        void RemoveAt(int index);

        /// Remueve todos los elementos de la lista.
        void Clear();


    }
}