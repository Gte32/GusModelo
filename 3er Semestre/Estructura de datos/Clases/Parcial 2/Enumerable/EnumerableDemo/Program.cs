using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableDemo 
{
    // se conocen en otros lenguajes como iteradores

    // cuando uno es ENUMERABLE, tiene la capacidad de devolverte un objeto enumerador
    //el enumerador es el que tiene la capacidad de recorrer la colección
    class Demo<T> : IEnumerable<T>
    {

        class DemoEnumerator<T> : IEnumerator<T>
        {
            private Demo<T> demoRef;
            private int index;

            public DemoEnumerator(Demo<T> demo)
            {
                demoRef = demo;
                index = -1;
            }


            //Un enumerator, para que SEA enmuertaor tiene que implementar estos 3 metodos
            //Current, MoveNext y Reset

            /*
            public T Current => throw new NotImplementedException();
            
            */

            public T Current
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return demoRef.x;
                        case 1:
                            return demoRef.y;
                        case 2:
                            return demoRef.z;
                        default:
                            throw new InvalidOperationException();
                    }
                }

            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
               if (index < 2)
                {
                    index++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }

        private T x; // 0
        private T y; // 1
        private T z; // 2

        public IEnumerator<T> GetEnumerator()
        {
            return new DemoEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Demo(int x, int y, int z)
        {
            this.x = (T)(object)x;
            this.y = (T)(object)y;
            this.z = (T)(object)z;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Demo<int> demo = new Demo<int>(10, 25, -64);
            
            foreach (int e in demo)
            {
                Console.WriteLine(e);
            }


            /*
             IEnumerable<int> enumerable = demo.GetEnumerator();

            while (enumerable.MoveNext())
            {
                int e = enumerable.Current;
                Console.WriteLine(e);
            }
            */


        }
    }

}