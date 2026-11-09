using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAList
{
    internal interface IQueue<T> : IEnumerable<T>// IQueue<TipoDeDato>
    {
        T Head { get; }
        T Tail { get; }
        int Size { get; }


        //
        //bool Empty { get; }


        bool Full { get; }
        void Enqueue(T e);
        T Dequeue();

#if DEBUG
        string QueuePrint();
        string DataPrint();
#endif
    }
}
