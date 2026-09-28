using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_RPN_en_CSharp
{
    internal interface ISymbology<T>
    {

        Dictionary<char, int> symbols { get;set;}





    }

    internal interface IStack<T> // Istack<Tipodedato>
    {
        int Size { get; } // Encapsula los datos para que los datos no puedan salir de la clase a menos que lo permitas
        bool Empty { get; }
        bool Full { get; }

        void Push(T e);
        T Pop();
        T Peek();

    }



}