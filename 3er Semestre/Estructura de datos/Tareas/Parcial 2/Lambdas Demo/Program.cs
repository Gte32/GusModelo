using System.Text;
using System.Threading.Tasks;  
using static System.Console;

namespace LambdasDemo
{
    internal class Program
    {
        //simplifica lo que voy a escribir es un tipo de funcion
        //delegate simplifica, lo que escribo es un tipo int y recibo un double
        delegate double Operation(int a, int b);

        // suma y resta son del mismo tipo
        static double Suma(int a, int b)
        {
            return a + b;
        }
        static double Resta(int a, int b)
        {
            return a - b;
        }


        //tras declarar delegados, declarar metodos compatible, y finalmente este es para usar al 
        static double DoOperation(int a, int b, Operation op)
        {
            return op(a, b);
        }


        static void Main(string[] args)
        {
            int m = 10;
            int n = 43;

            //esto es como un tipo de variable como n, creamos una plantilla que recibe x, devuelve y.
            //y la asignamos a una varible que coincida como Suma, que sirve

            //es tener llamadas GENERICAS

            //donde esta el potencial de esto
            //si yo puedo asignar funciones a variables, puedo pasar funciones como parametros a otras funciones
            //es decir, puedes mandar otras funciones como parametros
            Operation op = Suma;
            WriteLine($"m + n:  {DoOperation(m, n, op)}");

            op = Resta;
            WriteLine($"m - n:  {DoOperation(m, n, op)}");

            //pero CUAL ES EL OBJETIVO DE LA FUNCION LAMBDA
            //Es la forma mas breve de escribir una funcion
            //no quiero hacer la funcion Suma ni Resta quiero hacerlo directamente

            //la manera de indicar si es lambda es con el simbolo =>, la flecha
            //aqui el op YA es la plantilla, es decir, no hay necesidad de ponerle double ni ints, ni nada

            //el a y b no es obligatorio es puramente formato
            WriteLine($"m + n:  {DoOperation(m, n, (a, b) => a + b)}");
            WriteLine($"m - n:  {DoOperation(m, n, (a, b) => a - b)}");
            WriteLine($"m * n:  {DoOperation(m, n, (a, b) => a * b)}");
        }
    }

}