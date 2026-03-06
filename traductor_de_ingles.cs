using System;
using System.Collections.Generic;

namespace TraductorBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============================================================
            // Diccionario inicial con al menos 10 palabras
            // La clave es la palabra en inglés, el valor es la traducción en español
            // ============================================================
            Dictionary<string, string> diccionario = new Dictionary<string, string>()
            {
                {"hello", "hola"},
                {"world", "mundo"},
                {"computer", "computadora"},
                {"keyboard", "teclado"},
                {"mouse", "ratón"},
                {"screen", "pantalla"},
                {"book", "libro"},
                {"house", "casa"},
                {"car", "auto"},
                {"dog", "perro"}
            };

            int opcion;
            do
            {
                // ============================================================
                // Menú interactivo
                // ============================================================
                Console.WriteLine("==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Leer opción del usuario
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1; // valor inválido
                }

                switch (opcion)
                {
                    case 1:
                        // ============================================================
                        // Opción 1: Traducir una frase
                        // ============================================================
                        Console.Write("Ingrese la frase en inglés: ");
                        string frase = Console.ReadLine().ToLower(); // convertir a minúsculas
                        string[] palabras = frase.Split(' ');

                        Console.WriteLine("Traducción:");
                        foreach (string palabra in palabras)
                        {
                            if (diccionario.ContainsKey(palabra))
                            {
                                Console.Write(diccionario[palabra] + " ");
                            }
                            else
                            {
                                // Si la palabra no está en el diccionario, se deja igual
                                Console.Write(palabra + " ");
                            }
                        }
                        Console.WriteLine("\n");
                        break;

                    case 2:
                        // ============================================================
                        // Opción 2: Agregar palabras al diccionario
                        // ============================================================
                        Console.Write("Ingrese la palabra en inglés: ");
                        string palabraIngles = Console.ReadLine().ToLower();

                        Console.Write("Ingrese la traducción en español: ");
                        string palabraEspanol = Console.ReadLine().ToLower();

                        if (!diccionario.ContainsKey(palabraIngles))
                        {
                            diccionario.Add(palabraIngles, palabraEspanol);
                            Console.WriteLine("Palabra agregada correctamente.\n");
                        }
                        else
                        {
                            Console.WriteLine("La palabra ya existe en el diccionario.\n");
                        }
                        break;

                    case 0:
                        // ============================================================
                        // Opción 0: Salir
                        // ============================================================
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                        break;
                }

            } while (opcion != 0);
        }
    }
}
