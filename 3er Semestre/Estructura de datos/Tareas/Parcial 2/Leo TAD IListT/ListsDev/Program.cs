using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ListsDev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var list = new LinkedList<int>();

            //list.Add(10);
            //list.Add(-4);
            //list.Add(5);
            //list.Add(27);
            //list.Add(40);

            var list = new ArrayList<int>(
                new int[] { 1, -3, 5, 0, 35, -53, 27, 72, 24, 0, 1 });

            
            // El método ForEach de la clase donde se le pasa una lambda

            Write("\n[ ");
            list.ForEach(e => Write($"{e} "));
            WriteLine("]");

            WriteLine($"La lista contiene un 35: {list.Contains(35)}");

            int sum = 0;
            list.ForEach(e => sum += e);
            WriteLine($"Promedio = {sum/(double)list.Size}");

            WriteLine($"Todos son positivos: {list.All(e => e >= 0)}");
            
            WriteLine($"Hay algún negativo?: {list.Any(e => e < 0)}");

            WriteLine($"Hay algún cero?: {list.Any(e => e == 0)}");
            
            WriteLine($"\n# positivos: {list.Count(e => e > 0)}");
            WriteLine($"# negativos: {list.Count(e => e < 0)}");
            WriteLine($"# ceros: {list.Count(e => e == 0)}");

            WriteLine($"Mayor a 50: {list.Find(e => e >= 50)}");
            WriteLine($"Mayor a 50 (magnitud): {list.Find(e => e >= 50 || e < -50)}");

            Write("\n[ ");
            list.FindAll(e => e > 0).ForEach(e => Write($"{e} "));
            WriteLine("]");

            /*
            Write("\n[ ");
            foreach (int e in list)
            {
                Write($"{e} ");
            }
            WriteLine("]");


            /*
            ArrayList<int> list = new ArrayList<int>();
            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(-36);

            list.AddAll(100, 2, 56, 34, -11);

            list[4] = -360;

            Write("\n[ ");
            for (int i = 0; i < list.Size; i++)
            {
                Write($"{list[i]} ");
            }
            WriteLine("]");

            //list.Clear();
            //list.Insert(0, -20);
            list.Insert(4, -20);
            //list.Insert(list.Size - 1, -20);

            Write("\n[ ");
            foreach (int e in list)
            {
                Write($"{e} ");
            }
            WriteLine("]");

            //list.Clear();
            //list.RemoveAt(0);
            list.RemoveAt(2);
            //list.RemoveAt(10);

            Write("\n[ ");
            foreach (int e in list)
            {
                Write($"{e} ");
            }
            WriteLine("]");
            */
        }
    }
}
