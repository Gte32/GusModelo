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