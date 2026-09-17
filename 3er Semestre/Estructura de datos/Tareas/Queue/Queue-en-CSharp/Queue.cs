using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace  Queuedev
{
    internal interface IQueue<T>
    {
        
        int Head {get;}
        int Tail {get;}
        int Size {get;}
        bool Empty {get;}
        bool Full {get;}

        void Enqueue(T e);
        T Dequeue();


        #if DEBUG
        //string DataPeek();

        #endif
    }
}