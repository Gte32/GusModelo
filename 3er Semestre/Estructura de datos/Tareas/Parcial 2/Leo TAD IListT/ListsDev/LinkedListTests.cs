using System;
using System.Collections.Generic;
using static System.Console;

namespace ListsDev
{
    // ----- Pruebas de casos límite para LinkedList<T>. -----
    // Archivo para hacer unos últimos testeos completos de manera automática de la linked list aparte de los manuales
    // Para poder utilizar este archivo se escribió "LinkedListTests.Run();" dentro del main, como último chequeo previo a la entrega
    internal static class LinkedListTests
    {
        private static int passed;
        private static int failed;

        // ----- HELPERS ----- //

        private static void Check(string name, bool condition)
        {
            if (condition)
            {
                passed++;
            }
            else
            {
                failed++;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"  [FALLO] {name}");
                ResetColor();
            }
        }

        private static void Throws<TEx>(string name, Action action) where TEx : Exception
        {
            try
            {
                action();
                failed++;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"  [FALLO] {name} (no lanzó excepción)");
                ResetColor();
            }
            catch (TEx)
            {
                passed++;
            }
            catch (Exception ex)
            {
                failed++;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"  [FALLO] {name} (lanzó {ex.GetType().Name} en lugar de {typeof(TEx).Name})");
                ResetColor();
            }
        }

        // Compara tamaño, Empty, enumeración e indexador contra lo esperado
        private static bool Same<T>(IList<T> list, params T[] expected)
        {
            var cmp = EqualityComparer<T>.Default;

            if (list.Size != expected.Length) return false;
            if (list.Empty != (expected.Length == 0)) return false;

            int i = 0;
            foreach (T e in list)
            {
                if (i >= expected.Length || !cmp.Equals(e, expected[i])) return false;
                i++;
            }
            if (i != expected.Length) return false;

            for (int j = 0; j < expected.Length; j++)
            {
                if (!cmp.Equals(list[j], expected[j])) return false;
                if (!cmp.Equals(list.Get(j), expected[j])) return false;
            }
            return true;
        }

        private static void Section(string title)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"\n== {title} ==");
            ResetColor();
        }

        // ----- EJECUCIÓN ----- //

        public static void Run()
        {
            passed = 0;
            failed = 0;

            EmptyList();
            AddAndConstructors();
            GetSet();
            AddAllTests();
            InsertTests();
            RemoveAtTests();
            ClearTests();
            ContainsTests();
            PredicateTests();
            NullsAndStrings();
            InterfaceUsage();
            RandomDifferential();

            WriteLine();
            ForegroundColor = failed == 0 ? ConsoleColor.Green : ConsoleColor.Red;
            WriteLine($"Resultado: {passed} pasaron, {failed} fallaron.");
            ResetColor();
        }

        // ----- LISTA VACÍA ----- //

        private static void EmptyList()
        {
            Section("Lista vacía");
            var list = new LinkedList<int>();

            Check("Size == 0", list.Size == 0);
            Check("Empty == true", list.Empty);
            Check("Enumerar no produce elementos", Same(list));

            Throws<IndexOutOfRangeException>("Get(0) en vacía", () => list.Get(0));
            Throws<IndexOutOfRangeException>("Get(-1) en vacía", () => list.Get(-1));
            Throws<IndexOutOfRangeException>("Indexador [0] en vacía", () => { var x = list[0]; });
            Throws<IndexOutOfRangeException>("Set(0, x) en vacía", () => list.Set(0, 1));
            Throws<IndexOutOfRangeException>("RemoveAt(0) en vacía", () => list.RemoveAt(0));
            Throws<IndexOutOfRangeException>("Insert(0, x) en vacía", () => list.Insert(0, 1));

            Check("Después de excepciones sigue vacía", Same(list));

            Check("Contains en vacía == false", !list.Contains(0));
            Check("Find en vacía == default", list.Find(e => true) == 0);
            Check("FindAll en vacía == vacía", Same(list.FindAll(e => true)));
            Check("All en vacía == true (vacuo)", list.All(e => false));
            Check("Any en vacía == false", !list.Any(e => true));
            Check("Count en vacía == 0", list.Count(e => true) == 0);

            int calls = 0;
            list.ForEach(e => calls++);
            Check("ForEach en vacía no llama la acción", calls == 0);

            list.Clear();
            Check("Clear en vacía no rompe nada", Same(list));
        }

        // ----- ADD Y CONSTRUCTORES ----- //

        private static void AddAndConstructors()
        {
            Section("Add y constructores");

            var one = new LinkedList<int>();
            one.Add(7);
            Check("Add a vacía", Same(one, 7));

            one.Add(8);
            one.Add(9);
            Check("Add mantiene el orden", Same(one, 7, 8, 9));

            Check("Constructor con arreglo", Same(new LinkedList<int>(new[] { 1, 2, 3 }), 1, 2, 3));
            Check("Constructor con arreglo vacío", Same(new LinkedList<int>(new int[0])));
            Check("Constructor con List<int>",
                Same(new LinkedList<int>(new List<int> { 5, 4, 3 }), 5, 4, 3));
            Check("Constructor con un solo elemento", Same(new LinkedList<int>(new[] { 42 }), 42));
            Check("Constructor con duplicados",
                Same(new LinkedList<int>(new[] { 1, 1, 1 }), 1, 1, 1));

            // Enumerar dos veces da lo mismo (el enumerador no consume la lista)
            var list = new LinkedList<int>(new[] { 1, 2, 3 });
            int s1 = 0, s2 = 0;
            foreach (var e in list) s1 += e;
            foreach (var e in list) s2 += e;
            Check("Enumerar dos veces da el mismo resultado", s1 == 6 && s2 == 6);
        }

        // ----- GET / SET ----- //

        private static void GetSet()
        {
            Section("Get / Set / Indexador");
            var list = new LinkedList<int>(new[] { 10, 20, 30, 40 });

            Check("Get primero", list.Get(0) == 10);
            Check("Get medio", list.Get(2) == 30);
            Check("Get último", list.Get(3) == 40);

            Throws<IndexOutOfRangeException>("Get(-1)", () => list.Get(-1));
            Throws<IndexOutOfRangeException>("Get(Size)", () => list.Get(list.Size));
            Throws<IndexOutOfRangeException>("Get(Size + 100)", () => list.Get(list.Size + 100));
            Throws<IndexOutOfRangeException>("Set(-1)", () => list.Set(-1, 0));
            Throws<IndexOutOfRangeException>("Set(Size)", () => list.Set(list.Size, 0));

            list.Set(0, -1);
            list.Set(3, -4);
            list.Set(1, -2);
            Check("Set primero, medio y último", Same(list, -1, -2, 30, -4));

            list[2] = 99;
            Check("Indexador set", list[2] == 99);
            Check("Set no cambia el tamaño", list.Size == 4);

            Check("Lista intacta tras excepciones", Same(list, -1, -2, 99, -4));

            var single = new LinkedList<int>(new[] { 5 });
            single.Set(0, 6);
            Check("Set en lista de un elemento", Same(single, 6));
        }

        // ----- ADDALL ----- //

        private static void AddAllTests()
        {
            Section("AddAll");

            var a = new LinkedList<int>();
            a.AddAll(1);
            Check("AddAll solo con first", Same(a, 1));

            a.AddAll(2, 3, 4);
            Check("AddAll con varios", Same(a, 1, 2, 3, 4));

            a.AddAll(5, new int[0]);
            Check("AddAll con params vacío", Same(a, 1, 2, 3, 4, 5));

            a.AddAll(6, new[] { 7, 8 });
            Check("AddAll con arreglo explícito", Same(a, 1, 2, 3, 4, 5, 6, 7, 8));
        }

        // ----- INSERT ----- //

        private static void InsertTests()
        {
            Section("Insert");

            var list = new LinkedList<int>(new[] { 1, 2, 3 });

            list.Insert(0, 0);
            Check("Insert al inicio", Same(list, 0, 1, 2, 3));

            list.Insert(2, 99);
            Check("Insert en medio", Same(list, 0, 1, 99, 2, 3));

            list.Insert(list.Size - 1, 77);
            Check("Insert antes del último", Same(list, 0, 1, 99, 2, 77, 3));

            // Con tu diseño (igual que ArrayList): index >= Size lanza excepción,
            // por lo que Insert no puede añadir al final. Estas pruebas documentan ese comportamiento.
            int sizeBefore = list.Size;
            Throws<IndexOutOfRangeException>("Insert(Size) lanza", () => list.Insert(list.Size, 5));
            Throws<IndexOutOfRangeException>("Insert(-1) lanza", () => list.Insert(-1, 5));
            Throws<IndexOutOfRangeException>("Insert(Size + 10) lanza", () => list.Insert(list.Size + 10, 5));
            Check("Insert fallido no cambia Size ni contenido",
                list.Size == sizeBefore && Same(list, 0, 1, 99, 2, 77, 3));

            var single = new LinkedList<int>(new[] { 5 });
            single.Insert(0, 4);
            Check("Insert(0) en lista de un elemento", Same(single, 4, 5));

            // Después de Insert al inicio, Add sigue llegando al final correcto
            single.Add(6);
            Check("Add después de Insert al inicio", Same(single, 4, 5, 6));

            // Muchos Insert(0) seguidos (invierten el orden)
            var rev = new LinkedList<int>(new[] { 0 });
            for (int i = 1; i <= 5; i++) rev.Insert(0, i);
            Check("Varios Insert(0) seguidos", Same(rev, 5, 4, 3, 2, 1, 0));
        }

        // ----- REMOVEAT ----- //

        private static void RemoveAtTests()
        {
            Section("RemoveAt");

            var list = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

            list.RemoveAt(0);
            Check("RemoveAt primero", Same(list, 2, 3, 4, 5));

            list.RemoveAt(list.Size - 1);
            Check("RemoveAt último", Same(list, 2, 3, 4));

            list.RemoveAt(1);
            Check("RemoveAt medio", Same(list, 2, 4));

            int sizeBefore = list.Size;
            Throws<IndexOutOfRangeException>("RemoveAt(-1)", () => list.RemoveAt(-1));
            Throws<IndexOutOfRangeException>("RemoveAt(Size)", () => list.RemoveAt(list.Size));
            Check("RemoveAt fallido no cambia nada", list.Size == sizeBefore && Same(list, 2, 4));

            // Quitar hasta dejarla vacía
            list.RemoveAt(0);
            list.RemoveAt(0);
            Check("Quedó vacía tras quitar todo", Same(list));
            Throws<IndexOutOfRangeException>("RemoveAt en lista que quedó vacía", () => list.RemoveAt(0));

            // Reutilizar después de vaciarla
            list.Add(10);
            list.Add(20);
            Check("Add después de vaciar con RemoveAt", Same(list, 10, 20));

            // Quitar siempre el último (verifica que Next del nuevo último sea null)
            var b = new LinkedList<int>(new[] { 1, 2, 3, 4 });
            while (!b.Empty) b.RemoveAt(b.Size - 1);
            Check("Vaciar quitando siempre el último", Same(b));
            b.Add(1);
            Check("Add tras vaciar desde atrás", Same(b, 1));

            // Quitar el último y luego agregar: no debe quedar enlace colgante
            var c = new LinkedList<int>(new[] { 1, 2, 3 });
            c.RemoveAt(2);
            c.Add(9);
            Check("RemoveAt último y luego Add", Same(c, 1, 2, 9));

            // Con duplicados quita solo por posición
            var d = new LinkedList<int>(new[] { 3, 3, 3 });
            d.RemoveAt(1);
            Check("RemoveAt con duplicados", Same(d, 3, 3));

            // Un solo elemento
            var e1 = new LinkedList<int>(new[] { 8 });
            e1.RemoveAt(0);
            Check("RemoveAt(0) en lista de un elemento", Same(e1));
        }

        // ----- CLEAR ----- //

        private static void ClearTests()
        {
            Section("Clear");

            var list = new LinkedList<int>(new[] { 1, 2, 3 });
            list.Clear();
            Check("Clear vacía la lista", Same(list));
            Throws<IndexOutOfRangeException>("Get(0) tras Clear", () => list.Get(0));

            list.Add(5);
            list.Insert(0, 4);
            Check("Reutilizar después de Clear", Same(list, 4, 5));

            list.Clear();
            list.Clear();
            Check("Clear doble", Same(list));
        }

        // ----- CONTAINS ----- //

        private static void ContainsTests()
        {
            Section("Contains");

            var list = new LinkedList<int>(new[] { 1, 2, 3, 2 });
            Check("Contains primero", list.Contains(1));
            Check("Contains medio", list.Contains(2));
            Check("Contains último", list.Contains(2) && list.Contains(3));
            Check("Contains inexistente", !list.Contains(99));

            list.RemoveAt(0);
            Check("Contains tras RemoveAt", !list.Contains(1));
        }

        // ----- PREDICADOS ----- //

        private static void PredicateTests()
        {
            Section("All / Any / Count / Find / FindAll / ForEach");

            var list = new LinkedList<int>(new[] { 1, -3, 5, 0, 35, -53, 27, 72, 24, 0, 1 });

            Check("All: todos >= -100", list.All(e => e >= -100));
            Check("All: no todos positivos", !list.All(e => e > 0));
            Check("Any: hay negativo", list.Any(e => e < 0));
            Check("Any: no hay > 100", !list.Any(e => e > 100));
            Check("Count positivos == 7", list.Count(e => e > 0) == 7);
            Check("Count negativos == 2", list.Count(e => e < 0) == 2);
            Check("Count ceros == 2", list.Count(e => e == 0) == 2);
            Check("Count nada == 0", list.Count(e => e > 1000) == 0);
            Check("Count todo == Size", list.Count(e => true) == list.Size);

            Check("Find primero que cumple", list.Find(e => e > 30) == 35);
            Check("Find no encontrado == default", list.Find(e => e > 1000) == 0);
            Check("Find en el último elemento", list.Find(e => e == 1 && true) == 1);

            var pos = list.FindAll(e => e > 0);
            Check("FindAll positivos", Same(pos, 1, 5, 35, 27, 72, 24, 1));
            Check("FindAll ninguno", Same(list.FindAll(e => e > 1000)));
            Check("FindAll todos", Same(list.FindAll(e => true), 1, -3, 5, 0, 35, -53, 27, 72, 24, 0, 1));

            // El resultado de FindAll es independiente de la lista original
            pos.Add(1000);
            pos.Set(0, -1);
            Check("Modificar FindAll no afecta al original", list.Size == 11 && list[0] == 1 && !list.Contains(1000));

            int sum = 0;
            list.ForEach(e => sum += e);
            Check("ForEach suma == 109", sum == 109);

            // Un elemento
            var one = new LinkedList<int>(new[] { 4 });
            Check("Predicados en lista de un elemento",
                one.All(e => e == 4) && one.Any(e => e == 4) && one.Count(e => e == 4) == 1 && one.Find(e => e == 4) == 4);
        }

        // ----- NULOS Y STRINGS ----- //

        private static void NullsAndStrings()
        {
            Section("Tipos de referencia y null");

            var list = new LinkedList<string>();
            list.Add("a");
            list.Add(null);
            list.Add("c");

            Check("Acepta null como elemento", Same(list, "a", null, "c"));
            Check("Contains(null) == true", list.Contains(null));
            Check("Contains de string existente", list.Contains("c"));
            Check("Find no encontrado == null", list.Find(s => s == "zzz") == null);

            list.RemoveAt(1);
            Check("Contains(null) tras quitarlo == false", !list.Contains(null));
            Check("Contenido tras quitar null", Same(list, "a", "c"));

            list.Set(0, null);
            Check("Set con null", Same(list, null, "c"));
        }

        // ----- USO A TRAVÉS DE LA INTERFAZ ----- //

        private static void InterfaceUsage()
        {
            Section("Uso mediante IList<T>");

            IList<int> list = new LinkedList<int>();
            list.AddAll(1, 2, 3);
            list.Insert(0, 0);
            list.RemoveAt(2);
            list[0] = 10;
            Check("Operaciones a través de la interfaz", Same(list, 10, 1, 3));

            // Que ArrayList y LinkedList se comporten igual con la misma secuencia de operaciones
            IList<int> arr = new ArrayList<int>();
            arr.AddAll(1, 2, 3);
            arr.Insert(0, 0);
            arr.RemoveAt(2);
            arr[0] = 10;
            Check("LinkedList y ArrayList dan el mismo resultado", Same(arr, 10, 1, 3) && Same(list, 10, 1, 3));
        }

        // ----- PRUEBA ALEATORIA CONTRA List<int> DE .NET ----- //

        private static void RandomDifferential()
        {
            Section("Prueba aleatoria contra List<int> de .NET");

            var rnd = new Random(12345);
            var mine = new LinkedList<int>();
            var oracle = new List<int>();
            bool ok = true;
            int failIteration = -1;
            string failOp = "";

            for (int it = 0; it < 5000 && ok; it++)
            {
                int op = rnd.Next(5);
                int v = rnd.Next(-100, 100);
                string opName = "";

                try
                {
                    switch (op)
                    {
                        case 0:
                        case 1:
                            opName = $"Add({v})";
                            mine.Add(v);
                            oracle.Add(v);
                            break;
                        case 2:
                            if (oracle.Count > 0)
                            {
                                int i = rnd.Next(oracle.Count);
                                opName = $"Insert({i}, {v})";
                                mine.Insert(i, v);
                                oracle.Insert(i, v);
                            }
                            break;
                        case 3:
                            if (oracle.Count > 0)
                            {
                                int i = rnd.Next(oracle.Count);
                                opName = $"RemoveAt({i})";
                                mine.RemoveAt(i);
                                oracle.RemoveAt(i);
                            }
                            break;
                        case 4:
                            if (oracle.Count > 0)
                            {
                                int i = rnd.Next(oracle.Count);
                                opName = $"Set({i}, {v})";
                                mine.Set(i, v);
                                oracle[i] = v;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ok = false;
                    failIteration = it;
                    failOp = $"{opName} lanzó {ex.GetType().Name}";
                    break;
                }

                // Comparación completa por enumeración en cada iteración
                if (mine.Size != oracle.Count || mine.Empty != (oracle.Count == 0))
                {
                    ok = false;
                }
                else
                {
                    int k = 0;
                    foreach (int e in mine)
                    {
                        if (k >= oracle.Count || e != oracle[k]) { ok = false; break; }
                        k++;
                    }
                    if (k != oracle.Count) ok = false;
                }

                // Comparación por indexador cada 50 iteraciones (es O(n^2))
                if (ok && it % 50 == 0)
                {
                    for (int k = 0; k < oracle.Count; k++)
                    {
                        if (mine[k] != oracle[k]) { ok = false; break; }
                    }
                }

                if (!ok)
                {
                    failIteration = it;
                    failOp = opName;
                }
            }

            Check(ok
                ? "5000 operaciones aleatorias coinciden con List<int>"
                : $"Divergencia en la iteración {failIteration} ({failOp})", ok);

            // Vaciar la lista aleatoriamente hasta el final
            while (ok && oracle.Count > 0)
            {
                int i = rnd.Next(oracle.Count);
                mine.RemoveAt(i);
                oracle.RemoveAt(i);
            }
            Check("Vaciado aleatorio final llega a lista vacía", mine.Empty && mine.Size == 0);
        }
    }
}
