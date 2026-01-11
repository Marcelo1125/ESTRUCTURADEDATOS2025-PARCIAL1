using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosPOO
{
    //-----------------------------------------
    // Ejercicio 1: Asignaturas en una lista
    //-----------------------------------------
    public class Ejercicio1
    {
        public void Ejecutar()
        {
            List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            Console.WriteLine("Asignaturas del curso:");
            foreach (var asignatura in asignaturas)
                Console.WriteLine(asignatura);
        }
    }

    //----------------------------------------------
    // Ejercicio 4: Números ganadores de la lotería
    //-----------------------------------------------
    public class Ejercicio4
    {
        public void Ejecutar()
        {
            List<int> numeros = new List<int>();
            Console.WriteLine("Ingrese los números ganadores de la lotería (6 números):");
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Número {i + 1}: ");
                numeros.Add(int.Parse(Console.ReadLine()));
            }
            numeros.Sort();
            Console.WriteLine("Números ganadores ordenados:");
            Console.WriteLine(string.Join(", ", numeros));
        }
    }

    //------------------------------------------------------
    // Ejercicio 5: Números del 1 al 100 en orden inverso
    //------------------------------------------------------
    public class Ejercicio5
    {
        public void Ejecutar()
        {
            List<int> numeros = Enumerable.Range(1, 100).ToList();
            numeros.Reverse();
            Console.WriteLine("Números del 1 al 100 en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros));
        }
    }

    //----------------------------------------------------------------
    // Ejercicio 7: Abecedario eliminando posiciones múltiplos de 3
    //-----------------------------------------------------------------
    public class Ejercicio7
    {
        public void Ejecutar()
        {
            List<char> abecedario = Enumerable.Range('A', 26).Select(x => (char)x).ToList();
            // Eliminamos posiciones múltiplos de 3 (índice +1)
            var resultado = abecedario.Where((letra, index) => (index + 1) % 3 != 0).ToList();

            Console.WriteLine("Abecedario sin posiciones múltiplos de 3:");
            Console.WriteLine(string.Join(", ", resultado));
        }
    }

    //--------------------------------------------
    // Ejercicio 9: Contar vocales en una palabra
    //--------------------------------------------
    public class Ejercicio9
    {
        public void Ejecutar()
        {
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();

            Dictionary<char, int> conteoVocales = new Dictionary<char, int>
            {
                { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 }
            };

            foreach (char c in palabra)
            {
                if (conteoVocales.ContainsKey(c))
                    conteoVocales[c]++;
            }

            Console.WriteLine("Número de veces que aparece cada vocal:");
            foreach (var kvp in conteoVocales)
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
    //------------------------------
    // Programa principal con menú
    //------------------------------
    class Program
    {
        static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nSeleccione el ejercicio a ejecutar:");
                Console.WriteLine("1. Asignaturas");
                Console.WriteLine("4. Lotería");
                Console.WriteLine("5. Números inversos");
                Console.WriteLine("7. Abecedario");
                Console.WriteLine("9. Contar vocales");
                Console.WriteLine("0. Salir");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: new Ejercicio1().Ejecutar(); break;
                    case 4: new Ejercicio4().Ejecutar(); break;
                    case 5: new Ejercicio5().Ejecutar(); break;
                    case 7: new Ejercicio7().Ejecutar(); break;
                    case 9: new Ejercicio9().Ejecutar(); break;
                    case 0: Console.WriteLine("Saliendo..."); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            } while (opcion != 0);
        }
    }
}


