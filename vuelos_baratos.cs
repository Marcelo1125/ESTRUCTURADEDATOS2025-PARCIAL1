using System;
using System.Collections.Generic;
using System.Linq;

public class Vuelo
{
    public string Origen { get; set; }
    public string Destino { get; set; }
    public DateTime Fecha { get; set; }
    public double Precio { get; set; }
}

class ProgramaVuelos
{
    static void Main(string[] args)
    {
        // Base de datos ficticia de vuelos
        List<Vuelo> vuelos = new List<Vuelo>
        {
            new Vuelo { Origen = "Quito", Destino = "Guayaquil", Fecha = new DateTime(2026, 4, 10), Precio = 80 },
            new Vuelo { Origen = "Quito", Destino = "Cuenca", Fecha = new DateTime(2026, 4, 12), Precio = 65 },
            new Vuelo { Origen = "Quito", Destino = "Bogotá", Fecha = new DateTime(2026, 4, 15), Precio = 150 },
            new Vuelo { Origen = "Guayaquil", Destino = "Quito", Fecha = new DateTime(2026, 4, 20), Precio = 75 },
            new Vuelo { Origen = "Cuenca", Destino = "Quito", Fecha = new DateTime(2026, 4, 22), Precio = 70 }
        };

        Console.WriteLine("=== Sistema de Vuelos Baratos ===");
        Console.WriteLine("1. Mostrar todos los vuelos");
        Console.WriteLine("2. Buscar vuelo más barato");
        Console.WriteLine("Seleccione una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            Console.WriteLine("\n--- Lista de vuelos disponibles ---");
            foreach (var v in vuelos)
            {
                Console.WriteLine($"{v.Origen} → {v.Destino}, Fecha: {v.Fecha.ToShortDateString()}, Precio: ${v.Precio}");
            }
        }
        else if (opcion == 2)
        {
            Console.Write("\nIngrese origen: ");
            string origen = Console.ReadLine();
            Console.Write("Ingrese destino: ");
            string destino = Console.ReadLine();

            var resultado = vuelos
                .Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase)
                         && v.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
                .OrderBy(v => v.Precio)
                .FirstOrDefault();

            if (resultado != null)
            {
                Console.WriteLine($"\nVuelo más barato encontrado:");
                Console.WriteLine($"{resultado.Origen} → {resultado.Destino}, Fecha: {resultado.Fecha.ToShortDateString()}, Precio: ${resultado.Precio}");
            }
            else
            {
                Console.WriteLine("\nNo se encontraron vuelos para esa ruta.");
            }
        }
        else
        {
            Console.WriteLine("Opción inválida.");
        }

        Console.WriteLine("\n--- Análisis ---");
        Console.WriteLine("Estructura utilizada: Lista de objetos Vuelo.");
        Console.WriteLine("Ventajas: fácil implementación, consultas rápidas en memoria.");
        Console.WriteLine("Desventajas: no escala bien para grandes volúmenes de datos (mejor usar una base real).");
    }
}
