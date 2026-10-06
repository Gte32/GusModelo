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