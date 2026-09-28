using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Queuedev
{
    
    internal class Program
    {
        static void PrintQueueStatus<T>(Queue<T> queue)
        {
            #if DEBUG
            WriteLine(queue.DataPeek());
            #endif
            
            WriteLine($"Size: {queue.Size}, E:{queue.Empty}, F:{queue.Full}");

            
        }

        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(4);
            //queue.Enqueue(-5);
            //queue.Enqueue(10);
            //queue.Enqueue(15);
            PrintQueueStatus(queue);
        

        }

    } 
}