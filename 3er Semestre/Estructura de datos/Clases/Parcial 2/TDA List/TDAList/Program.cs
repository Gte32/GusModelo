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

        public class Student
        {
            public int Id { get; }
            public string Name { get; }
            
            public double Grade { get; }

            public Student(int id, string name, double grade)
            {
                Id = id;
                Name = name;
                Grade = grade;
            }

        }

        static void Main(string[] args)
        {
            //var para INFERIR TIPO


            /*
            var students = new ArrayList<Student>()
            {
                new Student(6001, "Paco", 93.22),
                new Student(6002, "Juan", 78.90),
                new Student(6003, "Andreuz", 100.00),
                new Student(6004, "John", 50.95),
                new Student(6005, "Linux", 87.22),
                new Student(6006, "Awebo", 98.23)
            };

            //students.Sort((x, y) => x.Grade.CompareTo(y.Grade));
            //Esto de abajo no jala, find all devuelve otra lista y esa se ordena lol
            //students.FindAll(s=> s.Grade <= 60).Sort((x, y) => x.Grade.CompareTo(y.Grade));

            students = (ArrayList<Student>)students.FindAll(s => s.Grade >= 60);
            students.Sort((x, y) => x.Grade.CompareTo(y.Grade));


            foreach (var s in students)
            {
                WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
            /*

            /*
            var list = new LinkedList<int>();
            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(-36);

            Write("\n[ ");
            foreach (int e in list)
            {
                Write($"{e} ");
            }
            WriteLine("]");
            */

            
            /*
            var list = new ArrayList<int>(new int[] { 1, 5, 20, 35, -53, 27, 72 });

            list.Sort((x, y) => (x > y ? 1 : (x == y ? 0 : -1)));
            WriteLine();

            // los tipos de datos basico ya tienen comparacion

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