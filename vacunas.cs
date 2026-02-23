using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaniaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============================================================
            // 1. Generar conjunto ficticio de 500 ciudadanos
            // ============================================================
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add("Ciudadano " + i);
            }

            // ============================================================
            // 2. Generar conjunto ficticio de 75 ciudadanos vacunados con Pfizer
            // ============================================================
            HashSet<string> vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add("Ciudadano " + i); // primeros 75
            }

            // ============================================================
            // 3. Generar conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca
            // ============================================================
            HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
            for (int i = 51; i <= 125; i++)
            {
                vacunadosAstraZeneca.Add("Ciudadano " + i); // del 51 al 125
            }

            // ============================================================
            // 4. Operaciones de teoría de conjuntos
            // ============================================================

            // a) Ciudadanos que no se han vacunado
            var noVacunados = ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstraZeneca));

            // b) Ciudadanos que han recibido ambas dosis (Pfizer y AstraZeneca)
            var ambasDosis = vacunadosPfizer.Intersect(vacunadosAstraZeneca);

            // c) Ciudadanos que solo han recibido Pfizer
            var soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca);

            // d) Ciudadanos que solo han recibido AstraZeneca
            var soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer);

            // ============================================================
            // 5. Mostrar resultados
            // ============================================================

            Console.WriteLine("=== Ciudadanos que NO se han vacunado ===");
            foreach (var c in noVacunados)
                Console.WriteLine(c);

            Console.WriteLine("\n=== Ciudadanos que han recibido ambas dosis (Pfizer y AstraZeneca) ===");
            foreach (var c in ambasDosis)
                Console.WriteLine(c);

            Console.WriteLine("\n=== Ciudadanos que SOLO han recibido Pfizer ===");
            foreach (var c in soloPfizer)
                Console.WriteLine(c);

            Console.WriteLine("\n=== Ciudadanos que SOLO han recibido AstraZeneca ===");
            foreach (var c in soloAstraZeneca)
                Console.WriteLine(c);
        }
    }
}

