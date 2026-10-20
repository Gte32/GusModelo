using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Structura_de_clases
{
    internal class Program
    {
        public struct Empleado
        {
            public double salarioBase;
            public double comision;

            public Empleado(double salarioBase, double comision)
            {
                this.salarioBase = salarioBase;
                this.comision = comision;
            }

            public override string ToString()
            {
                return $"Salario Base: {salarioBase}, Comision {comision}";
            }

            public void CambiarSalario(Empleado e, double incremento)
            {
                e.salarioBase += incremento;
                e.comision += incremento;
            }

        }


        static void Main(string[] args)
        {
            Empleado empleado1 = new Empleado(1200, 500);
            WriteLine(empleado1.ToString());

        }
        


    }
}