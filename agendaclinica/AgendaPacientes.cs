using System;

// Estructura ligera para guardar datos del paciente
public struct Paciente {
    public string Nombre;
    public string Cedula;
    public int Edad;
    public string Telefono;
}

// Clase Turno: combina paciente con fecha, hora y especialidad
public class Turno {
    public Paciente paciente;
    public string Especialidad;
    public string Fecha;
    public string Hora;

    // Constructor: inicializa el turno con datos
    public Turno(Paciente p, string especialidad, string fecha, string hora) {
        paciente = p;
        Especialidad = especialidad;
        Fecha = fecha;
        Hora = hora;
    }

    // Método para mostrar datos del turno
    public void MostrarTurno() {
        Console.WriteLine($"Paciente: {paciente.Nombre}, Cédula: {paciente.Cedula}, " +
                          $"Especialidad: {Especialidad}, Fecha: {Fecha}, Hora: {Hora}");
    }
}

// Clase Agenda: administra un vector de turnos
public class Agenda {
    private Turno[] turnos; // Vector de turnos
    private int contador;   // Número de turnos registrados

    public Agenda(int capacidad) {
        turnos = new Turno[capacidad]; // Se define el tamaño máximo
        contador = 0;
    }

    // Agregar un turno al vector
    public void AgregarTurno(Turno t) {
        if (contador < turnos.Length) {
            turnos[contador] = t;
            contador++;
        } else {
            Console.WriteLine("Agenda llena, no se pueden agregar más turnos.");
        }
    }

    // Mostrar todos los turnos registrados
    public void MostrarAgenda() {
        Console.WriteLine("Agenda de Turnos:");
        for (int i = 0; i < contador; i++) {
            turnos[i].MostrarTurno();
        }
    }

    // Consultar turnos por cédula
    public void ConsultarPorCedula(string cedula) {
        Console.WriteLine($"Turnos del paciente con cédula {cedula}:");
        for (int i = 0; i < contador; i++) {
            if (turnos[i].paciente.Cedula == cedula) {
                turnos[i].MostrarTurno();
            }
        }
    }
}

// Clase principal con el método Main (punto de entrada del programa)
public class Program {
    public static void Main(string[] args) {
        // Crear algunos pacientes de ejemplo
        Paciente p1 = new Paciente { Nombre = "Ana Pérez", Cedula = "0102030405", Edad = 30, Telefono = "099111222" };
        Paciente p2 = new Paciente { Nombre = "Luis Gómez", Cedula = "1112131415", Edad = 45, Telefono = "098333444" };

        // Crear la agenda con capacidad para 5 turnos
        Agenda agenda = new Agenda(5);

        // Agregar turnos de ejemplo
        agenda.AgregarTurno(new Turno(p1, "Medicina General", "2025-12-29", "09:00"));
        agenda.AgregarTurno(new Turno(p2, "Odontología", "2025-12-29", "10:30"));

        // Mostrar toda la agenda
        agenda.MostrarAgenda();

        // Consultar turnos por cédula
        agenda.ConsultarPorCedula("0102030405");
    }
}


