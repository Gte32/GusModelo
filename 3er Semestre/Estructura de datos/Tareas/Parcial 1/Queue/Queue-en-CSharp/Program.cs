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
            //PRUEBAS
            //Probar crecimiento
            //Probar decrecimiento
            //probar se mueva como rangos


            //Crecimiento
            queue.Enqueue(-5);
            queue.Enqueue(10);
            queue.Enqueue(15);
            queue.Enqueue(20);
            //son 4 de 4, esta full
            PrintQueueStatus(queue);

            queue.Enqueue(25);
            //son 5, y ya no es full, es decir, se aumento su tamaño, puede crecer
            PrintQueueStatus(queue);
            
            queue.Dequeue();
            
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            PrintQueueStatus(queue);

            queue.Enqueue(30);
            queue.Enqueue(35);
            queue.Enqueue(40);
            //aqui volvio el tamaño a full, entonces, el tamaño volvio a su limite de 4, ergo, puede decrecer
            PrintQueueStatus(queue);

        }

    } 
}