using System;
using System.Collections.Generic;

namespace EjerciciosConPilas
{
    class Program
    {
        static void Main(string[] args)
        {
            // ==============================
            // EJERCICIO 1: Verificación de paréntesis balanceados
            // ==============================
            Console.WriteLine("=== Verificación de paréntesis balanceados ===");
            string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
            Console.WriteLine("Expresión: " + expresion);

            if (EsBalanceada(expresion))
                Console.WriteLine("Salida: Fórmula balanceada.\n");
            else
                Console.WriteLine("Salida: Fórmula NO balanceada.\n");

            // ==============================
            // EJERCICIO 2: Torres de Hanoi con pilas
            // ==============================
            Console.WriteLine("=== Torres de Hanoi con Pilas ===");
            int numeroDiscos = 3; // Puedes cambiar el número de discos
            ResolverTorresDeHanoi(numeroDiscos);
        }

        // ---------------------------------------------------
        // Método para verificar si una expresión está balanceada
        // ---------------------------------------------------
        static bool EsBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expresion)
            {
                // Si es un símbolo de apertura, lo apilamos
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Si es un símbolo de cierre, verificamos correspondencia
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0) return false; // No hay apertura previa

                    char tope = pila.Pop();
                    if ((c == ')' && tope != '(') ||
                        (c == '}' && tope != '{') ||
                        (c == ']' && tope != '['))
                    {
                        return false; // No coincide el tipo de símbolo
                    }
                }
            }

            // Si al final la pila está vacía, está balanceada
            return pila.Count == 0;
        }

        // ---------------------------------------------------
        // Torres de Hanoi utilizando pilas
        // ---------------------------------------------------
        static void ResolverTorresDeHanoi(int n)
        {
            // Creamos tres pilas que representan las torres
            Stack<int> torreA = new Stack<int>();
            Stack<int> torreB = new Stack<int>();
            Stack<int> torreC = new Stack<int>();

            // Inicializamos la torre A con los discos (mayor abajo, menor arriba)
            for (int i = n; i >= 1; i--)
            {
                torreA.Push(i);
            }

            // Llamamos al método recursivo para resolver
            MoverDiscos(n, torreA, torreC, torreB, "A", "C", "B");
        }

        // Método recursivo para mover discos entre torres
        static void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                                string nombreOrigen, string nombreDestino, string nombreAuxiliar)
        {
            if (n == 1)
            {
                // Caso base: mover un solo disco
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            }
            else
            {
                // Paso 1: mover n-1 discos de origen a auxiliar
                MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

                // Paso 2: mover el disco restante de origen a destino
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");

                // Paso 3: mover los n-1 discos de auxiliar a destino
                MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
            }
        }
    }
}

