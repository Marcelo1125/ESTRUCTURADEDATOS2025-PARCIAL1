using System;

namespace PrimerParcial
{
    class Estudiante
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            ID = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("\n===== Registro del Estudiante =====");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
            Console.WriteLine("===================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Información ficticia cargada directamente
            int id = 101;
            string nombres = "Juan Carlos";
            string apellidos = "Pérez Gómez";
            string direccion = "Av. Siempre Viva 123, Quito";
            string[] telefonos = { "0991234567", "022345678", "0987654321" };

            // Crear objeto estudiante con datos ficticios
            Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);

            // Mostrar información
            estudiante.MostrarInformacion();

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

