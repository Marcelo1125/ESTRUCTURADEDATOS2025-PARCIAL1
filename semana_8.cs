using System;                     // Importa librerías básicas de C#
using System.Collections.Generic; // Permite usar la clase Queue (Cola)

class CongresoAuditorio
{
    static void Main()
    {
        // Se crea una cola para almacenar los asistentes
        Queue<string> colaAuditorio = new Queue<string>();

        int capacidad = 100;   // Número máximo de asientos en el auditorio
        int asiento = 1;       // Contador para asignar asientos

        // Simulación de registro por dos personas (registradores A y B)
        for (int i = 1; i <= capacidad; i++)
        {
            // Si el número es par, lo registra la persona A
            if (i % 2 == 0)
                colaAuditorio.Enqueue("Registrador A -> Asistente " + i);
            // Si es impar, lo registra la persona B
            else
                colaAuditorio.Enqueue("Registrador B -> Asistente " + i);
        }

        // Reporte inicial de asignación
        Console.WriteLine("=== Reporte de Asignación de Asientos ===");

        // Mientras haya asistentes en la cola y asientos disponibles
        while (colaAuditorio.Count > 0 && asiento <= capacidad)
        {
            // Se desencola al primer asistente (FIFO)
            string persona = colaAuditorio.Dequeue();

            // Se asigna un asiento en orden de llegada
            Console.WriteLine($"{persona} -> Asiento {asiento}");

            asiento++; // Se incrementa el número de asiento
        }

        // Reporte final con resumen
        Console.WriteLine("\n=== Resumen ===");
        Console.WriteLine($"Total de asistentes registrados: {capacidad}");
        Console.WriteLine($"Total de asientos asignados: {asiento - 1}");
        Console.WriteLine($"Asientos disponibles: {capacidad - (asiento - 1)}");
    }
}
