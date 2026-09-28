using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Calculadora_RPN_en_CSharp
{
    class Program
    {
        static bool checkParentheses(string expression)
        {
            //crea un array de char
            ArrayStack<char> stack = new ArrayStack<char>(expression.Length);

            //checa cada char en la expresion, checa por parentesis, si ve uno izquiero pushea, si hay uno derecho popea
            foreach (char c in expression) 
            { 
                if (c == '(')
                {
                    stack.Push(c);
                }     
                    
                if (c == ')')
                {
                    if (stack.Empty)
                    {
                        //si llega a haber uno derecho sin izquierdo (no se pusheo nada) no cumple
                        return false;
                    }
                    stack.Pop();
                }
            
            }
            //si al terminar NO hay NADA en el stack, significa que cumple y estan bien los parentesis
            return stack.Empty;
        }


        static ArrayStack<string> separarEnStrings(string expression, Workspace workspace)
        {
            Symbology<char> symbology = new Symbology<char>();
            ArrayStack<string> stack = new ArrayStack<string>(expression.Length);
            string numero = "";
            string variable = "";
            bool syntax = false;
            //si hay resta, puede ser que sea negativo si esta antes
            //condicion primero a la izquierda
            bool resta = false;

            foreach (char c in expression)
            {
                //sacamos si es simbolo
                bool esSimbolo = false;

                if (c == ' ')
                {
                    //espacio
                    if (numero != "")
                    {
                        //si es espacio y estamos haciendo un numero, entonces hay un espacio entre ellos
                        //ojala sea signo si no leña
                        syntax = true;
                        
                    }
                    continue;

                }

                foreach (var symbol in symbology.symbols)
                {
                    if (c == symbol.Key)
                    {
                        esSimbolo = true;
                        
                        break;
                    }
                }

                //si no es, es digito, se va creando el string de digitos
                if (char.IsDigit(c))
                {
                    
                    //si c es un digito se agrega al string numero
                    if (syntax)
                    {
                        WriteLine("Syntax Error - Numero con esapcios");
                        return null;
                    }
                    resta = true;
                    numero += c;
                }
                else if (char.IsLetter(c))
                {
                    variable += c;
                    resta = true;
                    continue;
                }
                else if (esSimbolo)
                {
                    //si nuestro operador es resta, y NO hemos puesto nada antes, puede ser negativo
                    //es decir, si no hay nada antes podemos permitirnos el poner el negativo antes
                    if (c == '-' && !resta)
                    {
                        numero += c;
                        continue;
                    }

                    //si es simbolo, checa numero, si HAY algo en numero, es decir, no esta vacio, se pushea el numero creado
                    if (numero != "")
                    {
                        stack.Push(numero);
                        //se reinicia numero
                        numero = "";
                    }
                    if (variable != "")
                    {
                        double valor = workspace.Get(variable);   // lanza excepción si no existe
                        stack.Push(valor.ToString());
                        variable = "";
                    }
                    //se pushea el signo como string
                    //si es simbolo se reinicia nuestro syntax
                    syntax = false;
                    stack.Push(c.ToString());

                    //cuando cerramos un parentesis, podemos tener un valor muerto de resta de otras, ya que no lo cambia
                    //sin esto al salir del parentesis trataria el numero como un valor negativo, en lugar de efectuar la resta
                    resta = (c == ')');
                }



            }
            //luego, si la ecuacion acaba en numero, esto signfica es numero, y debe pushearse, debido a que si no, daria la vuelta con el es simbolo
            //Tambien aplica para variable

            if (numero != "")
            {
                
                stack.Push(numero);
            }
            if (variable != "")
            {
                stack.Push(workspace.Get(variable).ToString());
            }

            return stack;
        }



        static string convertToRPN(string expression, Workspace workspace)
        {
            //Usamos el diccionario de simbolos

            Symbology<char> symbology = new Symbology<char>();

            ArrayStack<string> digitos = separarEnStrings(expression, workspace);

            if (digitos == null)
            {
                return expression;
            }


            //creamos stack para numerosE
            ArrayStack<string> ecuation = new ArrayStack<string>(digitos.Size);

            ArrayStack<(char operador, int prioridad)> symbols = new ArrayStack<(char operador, int prioridad)>(expression.Length);


            for (int i = 0; i< digitos.Size; i++)
            {
                string digito = digitos[i];

                if (digito.Length > 1)
                {
                    ecuation.Push(digito);
                    continue;
                }

                //si pasa de aqui ES simbolo
                char c = digito[0];

                (char operador, int prioridad) found = ('\0', 0);
                bool symbolTrue = false;

                foreach (var symbol in symbology.symbols)
                {
                    if (c == symbol.Key)
                    {

                        found = (symbol.Key, symbol.Value);
                        //aqui solia pushear found pero jodia el pop
                        //si es simbolo se activa modo simbolo
                        symbolTrue = true;
                        break;//se sale del foreach
                    }

                }

                if (!symbolTrue)
                {
                    //Si no es simbolo, solo puede ser digito de uno
                    ecuation.Push(digito);
                    continue;
                }

                //si NO es un digito, y NO esta en nuestra simbologia, ha de ser un espacio o un simbolo que no nos importa, ojo al parche con variables
                //cuando hagamos pts extra aqui ANTES poner uno de simbologia pero de variables
                if (!symbolTrue && !char.IsDigit(c))
                {
                    continue;
                }

                //Si es simbolo
                if (symbolTrue)
                {
                    //hubo que reahacer logica con peek porque los parentesis son mierda
                    //si es el de la izquierda se mete como BARRERA, y se salta al sig char
                    if (found.operador == '(')
                    {
                        symbols.Push(found);
                        continue;
                    }

                    //si es el otro parentesis
                    if (found.operador == ')')
                    {
                        //mientras haya cosas que sacar, y mientras el operador no sea el final (
                        while (!symbols.Empty && symbols.Peek().operador != '(')
                        {

                            //saca todo indiferente del valor
                            ecuation.Push(symbols.Pop().operador.ToString());

                        }

                        //si NO esta vacio, significa que es el ultimo (, por ende sacalo y ve al sig char

                        if (!symbols.Empty)
                        {
                            symbols.Pop();
                        }
                        continue;

                    }

                    //condiciones
                    //no esta vacio
                    // la prioridad del anterior NO es de menor valor, popeamos hasta encontrar uno menor
                    //NO puede ser el parentesis izquierdo, porqe la prioridad de estos es maxima
                    while (!symbols.Empty && symbols.Peek().prioridad >= found.prioridad && symbols.Peek().operador != '(') //si no esta vacio y la prioridad no del simbolo encontrado es menor
                    {
                        //pusheas a la ecuacion y popeas en simbolos
                        ecuation.Push(symbols.Pop().operador.ToString());

                    }

                    //si no se cumple NADA anterior, esta vacio o hay uno de mayor valor antes
                    //solo metelo a symbols
                    symbols.Push(found);


                    continue;
                }




            }
            //una vez acabado el foreach

            //inicializa
            string result = "";

            //mientras no este vacio simbolos, agregalo a la ecuacion, por si falto
            while (!symbols.Empty)
            {
                ecuation.Push(symbols.Pop().operador.ToString());
            }

            //se recorre el stack de ecuacion y se agrega al resultado como string
            for (int i = 0; i < ecuation.Size; i++)
            {
                //agregamos espacio para poder distinguir de elementos 
                result += ecuation[i] + " ";
            }

            // devuelve resultado

            return result;
        }


        static List<string> separarListRPN(string expression, char separador)
        {
            List<string> ecuation = new List<string>();
            string digit = "";
            foreach (char c in expression)
            {

                if (c == separador)
                {
                    if (digit != "")
                    {
                        ecuation.Add(digit);
                        digit = "";
                    }
                }
                else
                {
                    digit += c;
                }

            }

            if (digit != "")
            {
                ecuation.Add(digit);
            }


            return ecuation;
        }


        static double EvaluateRPN(List<string> expression)
        {
            ArrayStack<double> numbers = new ArrayStack<double>(expression.Count);
            //recorre la expresion y su lista sacada del convertidor
            //aqui literal esta exacto, el numero de listas es el numero de pasos en una calculadora rpn, al parecer

            //tuve que reescribir toda mi logica intente manejarlo con strings que guardaban 3 datos y enviaban y volvian literal una tonteria
            //toda la llogica esta en el stack

            //aqui literal esta exacto, el numero de listas es el numero de pasos en una calculadora rpn, al parecer
            foreach (string digit in expression)
            {
                //checa si es numero con is digit, si no, tiene que ser a fuerza un simbolo
                //las variables son intercambiadas directamente en convertir a rpn, por lo que ya son numeros

                //is char falla por negativos y nos piden enteros se cambio a parse
                bool esNumero = double.TryParse(digit, out double num); 

                if (esNumero)
                {
                    //si es numero, se paresa a double y se pushea al stack, parseo facil pq sabemos es digito
                    //se sabe directamente que es num ahora sin el es digit
                    numbers.Push(num);
                }
                else
                {
                    //podria checar antes, pero asi es mas facil y si se puede convertir
                    //si es numero simbolo, esta mal y te lo tira
                    if (numbers.Size < 2)
                    {
                        throw new Exception("Syntax Error - Expresión incompleta");
                    }
                    //si falla el digit, entra aqui
                    //ojo aqui NO hemos metido nada, por lo que solo sabemos que el digit en expression es simbolo

                    //sabiendo esto y como funciona el stack, popeas a y b, sabiendo que son numeros, 
                    //sacas con pop y obtienes tus ultimos numeros
                    double b = numbers.Pop();
                    double a = numbers.Pop();
                    double result = 0;
                     switch (digit)
                    {
                        case "+":
                            result = a + b;
                            break;

                        case "-":
                            result = a - b;
                            break;

                        case "*":
                            result = a * b;
                            break;

                        case "/":
                            result = a / b;
                            break;

                        case "^":
                            result = Math.Pow(a, b);
                            break;

                        default:
                            throw new Exception("Syntax Error - Operador no válido");
                    }
                    numbers.Push(result);
                }
            }

            return numbers.Pop();
        }

        static double EvaluarExpresion(string expression, Workspace workspace)
        {
            //esta funcion pasa por todas las funciones hechas para que no haya ningun error
            //si check parenteheses tira falso, algo esta mal de una
            if (!checkParentheses(expression))
            {
                throw new Exception("Syntax Error - Paréntesis no balanceados");
            }

            //si pasa parentesis convierte a rpn
            string rpn = convertToRPN(expression, workspace);
            //luego convierte a a lista para usar en el evaluar
            //el separador de una ecuacion es ' '
            char separador = ' ';
            List<string> tokens = separarListRPN(rpn, separador);
            //tira al evaluar y regresa el resultado
            return EvaluateRPN(tokens);
        }


        static void REPL(Workspace workspace)
        {
            WriteLine("Calculadora RPN - escribe 'salir' para terminar");

            while (true)
            {
                Write("> ");
                string linea = ReadLine();
                //si la linea es null, es decir , uno de los valores devolvio que no tiene nada, se rompe
                //o si pusiste salir, te saca del while
                if (linea == null || linea.Trim().ToLower() == "salir")
                {
                    break;
                }

                if (linea.Trim() == "")
                {
                    //si no pusiste nada solo baja
                    continue;
                }

                try
                {
                    //esto es literal todo lo de las variables
                    if (linea.Contains('='))
                    {
                        char separador = '=';
                        List<string> partes = separarListRPN(linea, separador);
                        string nombreVariable = partes[0];
                        string expresion = partes[1];

                        //se manda a evaluar para optener expresion en double, y que esta sea valor
                        double valor = EvaluarExpresion(expresion, workspace);
                        workspace.Define(nombreVariable, valor);
                        WriteLine($"{nombreVariable} = {valor}");
                    }
                    else
                    {
                        //se pasa por un chequeo de todo, y tira de vuelta tu resultado
                        double resultado = EvaluarExpresion(linea, workspace);
                        WriteLine(resultado);
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {

            Workspace workspace = new Workspace();
            REPL(workspace);

        }
    }
}
