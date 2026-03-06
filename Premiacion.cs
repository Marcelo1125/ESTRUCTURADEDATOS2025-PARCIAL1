using System;
using System.Collections.Generic;
using System.Linq;

namespace PremiacionDeportistas
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============================================================
            // 1. Estructuras principales: Diccionarios y Conjuntos
            // Diccionario: disciplina -> conjunto de deportistas
            // ============================================================
            Dictionary<string, HashSet<string>> disciplinas = new Dictionary<string, HashSet<string>>()
            {
                {"Futbol", new HashSet<string>() {"Juan", "Pedro", "Luis", "Carlos"}},
                {"Basket", new HashSet<string>() {"Ana", "Pedro", "Maria", "Luis"}},
                {"Natacion", new HashSet<string>() {"Sofia", "Juan", "Maria"}}
            };

            int opcion;
            do
            {
                Console.WriteLine("==================== MENÚ ====================");
                Console.WriteLine("1. Ver deportistas por disciplina");
                Console.WriteLine("2. Ver deportistas en varias disciplinas");
                Console.WriteLine("3. Ver deportistas exclusivos de una disciplina");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1;
                }

                switch (opcion)
                {
                    case 1:
                        // ============================================================
                        // Reportería: visualizar deportistas por disciplina
                        // ============================================================
                        foreach (var d in disciplinas)
                        {
                            Console.WriteLine($"\nDisciplina: {d.Key}");
                            foreach (var deportista in d.Value)
                            {
                                Console.WriteLine($"- {deportista}");
                            }
                        }
                        break;

                    case 2:
                        // ============================================================
                        // Deportistas que participan en varias disciplinas
                        // Usamos Intersección de conjuntos
                        // ============================================================
                        var interseccion = disciplinas["Futbol"]
                            .Intersect(disciplinas["Basket"])
                            .Union(disciplinas["Futbol"].Intersect(disciplinas["Natacion"]))
                            .Union(disciplinas["Basket"].Intersect(disciplinas["Natacion"]));

                        Console.WriteLine("\n=== Deportistas en varias disciplinas ===");
                        foreach (var d in interseccion)
                        {
                            Console.WriteLine(d);
                        }
                        break;

                    case 3:
                        // ============================================================
                        // Deportistas exclusivos de una disciplina
                        // Usamos Diferencia de conjuntos
                        // ============================================================
                        var todos = disciplinas["Futbol"]
                            .Union(disciplinas["Basket"])
                            .Union(disciplinas["Natacion"]);

                        foreach (var d in disciplinas)
                        {
                            var exclusivos = d.Value.Except(todos.Except(d.Value));
                            Console.WriteLine($"\nExclusivos de {d.Key}:");
                            foreach (var deportista in exclusivos)
                            {
                                Console.WriteLine(d);
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.\n");
                        break;
                }

            } while (opcion != 0);
        }
    }
}

