using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TDAList
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var list = new LinkedList<int>();
            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(-36);

            WriteLine();


            /*

            var list = new ArrayList<int>(new int[] { 1, 5, 20, 35, -53, 27, 72 });

            Write(("\n[ "));
            list.ForEach(e => Write($"{e} "));
            Write("]");

            int sum = 0;
            list.ForEach(e => sum += e);
            WriteLine($"Promedio = {sum / (double)list.Size} ");

            WriteLine($"Todos son positivos: {list.All(e => e >= 0)}");
            WriteLine($"hay algun  negativo?: {list.Any(e => e < 0)}");
            WriteLine($"hay algun  cero?: {list.All(e => e == 0)}");

            WriteLine($"\n# positivos: : {list.CountIf(e => e >= 0)}");
            WriteLine($"\n# negativos: : {list.CountIf(e => e < 0)}");
            WriteLine($"\n# ceros: : {list.CountIf(e => e == 0)}");

            WriteLine($"Mayor a 50: : {list.Find(e => e >= 50)}");
            WriteLine($"Menor a 50: : {list.Find(e => e <= 50)}");

            Write(("\n[ "));
            list.FindAll(e => e >0).ForEach(e => Write($"{e} "));
            Write("]");
            */




            /*
            ArrayList<int> list = new ArrayList<int>();
            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(-36);

            list.AddAll(100, 2, 56, 34, 11);

            list[4] = -360;

            Write("\n[ ");
            for (int i = 0; i < list.Size; i++)
            {
                Write($"{list[i]} ");
            }
            WriteLine("]");

            list.Clear();
            //list.Insert(0, -20);
            list.Insert(4, -20);
            //list.Insert(list.Size -1, -20)

            Write("\n[ ");
            for (int i = 0; i < list.Size; i++)
            {
                Write($"{list[i]} ");
            }
            WriteLine("]");
            /*
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