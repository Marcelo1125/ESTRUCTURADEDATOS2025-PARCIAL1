using System;

// ================================================================
// PROGRAMA 7: Registro de vehículos en el estacionamiento
// Área de Ingeniería de Sistemas - Universidad
// ================================================================
class Vehiculo
{
    public string Placa;
    public string Marca;
    public string Modelo;
    public int Anio;
    public double Precio;
    public Vehiculo Siguiente; // enlace al siguiente nodo
}

class ListaVehiculos
{
    private Vehiculo cabeza;

    // a) Agregar vehículo
    public void Agregar(string placa, string marca, string modelo, int anio, double precio)
    {
        Vehiculo nuevo = new Vehiculo()
        {
            Placa = placa,
            Marca = marca,
            Modelo = modelo,
            Anio = anio,
            Precio = precio,
            Siguiente = cabeza
        };
        cabeza = nuevo;
    }

    // b) Buscar vehículo por placa
    public Vehiculo BuscarPorPlaca(string placa)
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            if (actual.Placa == placa)
                return actual;
            actual = actual.Siguiente;
        }
        return null;
    }

    // c) Ver vehículos por año
    public void VerPorAnio(int anio)
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            if (actual.Anio == anio)
                Console.WriteLine($"{actual.Placa} - {actual.Marca} {actual.Modelo} ({actual.Anio}) Precio: {actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    // d) Ver todos los vehículos registrados
    public void VerTodos()
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"{actual.Placa} - {actual.Marca} {actual.Modelo} ({actual.Anio}) Precio: {actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    // e) Eliminar carro registrado
    public void Eliminar(string placa)
    {
        Vehiculo actual = cabeza;
        Vehiculo anterior = null;

        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                if (anterior == null)
                    cabeza = actual.Siguiente;
                else
                    anterior.Siguiente = actual.Siguiente;

                Console.WriteLine($"Vehículo con placa {placa} eliminado.");
                return;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Vehículo con placa {placa} no encontrado.");
    }
}

class ProgramaVehiculos
{
    public static void Ejecutar()
    {
        ListaVehiculos lista = new ListaVehiculos();
        lista.Agregar("ABC123", "Toyota", "Corolla", 2020, 15000);
        lista.Agregar("XYZ789", "Chevrolet", "Spark", 2018, 8000);
        lista.Agregar("LMN456", "Ford", "Focus", 2020, 12000);

        Console.WriteLine("=== Todos los vehículos registrados ===");
        lista.VerTodos();

        Console.WriteLine("\n=== Buscar por placa ===");
        var v = lista.BuscarPorPlaca("XYZ789");
        if (v != null)
            Console.WriteLine($"Encontrado: {v.Placa} - {v.Marca} {v.Modelo}");

        Console.WriteLine("\n=== Vehículos del año 2020 ===");
        lista.VerPorAnio(2020);

        Console.WriteLine("\n=== Eliminar vehículo ===");
        lista.Eliminar("LMN456");
        lista.VerTodos();
    }
}

// ================================================================
// PROGRAMA 8: Manejo de lista de datos reales y promedio
// ================================================================
class Nodo
{
    public double Valor;
    public Nodo Siguiente;
}

class ListaReales
{
    private Nodo cabeza;

    public void Agregar(double valor)
    {
        Nodo nuevo = new Nodo() { Valor = valor, Siguiente = cabeza };
        cabeza = nuevo;
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    public double Promedio()
    {
        double suma = 0;
        int contador = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            suma += actual.Valor;
            contador++;
            actual = actual.Siguiente;
        }
        return contador > 0 ? suma / contador : 0;
    }

    public void Clasificar(double promedio, ListaReales menoresIguales, ListaReales mayores)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor <= promedio)
                menoresIguales.Agregar(actual.Valor);
            else
                mayores.Agregar(actual.Valor);
            actual = actual.Siguiente;
        }
    }
}

class ProgramaReales
{
    public static void Ejecutar()
    {
        ListaReales listaPrincipal = new ListaReales();
        listaPrincipal.Agregar(10);
        listaPrincipal.Agregar(20);
        listaPrincipal.Agregar(30);
        listaPrincipal.Agregar(40);

        Console.WriteLine("=== Lista principal ===");
        listaPrincipal.Mostrar();

        double promedio = listaPrincipal.Promedio();
        Console.WriteLine($"Promedio: {promedio}");

        ListaReales menoresIguales = new ListaReales();
        ListaReales mayores = new ListaReales();

        listaPrincipal.Clasificar(promedio, menoresIguales, mayores);

        Console.WriteLine("=== Menores o iguales al promedio ===");
        menoresIguales.Mostrar();

        Console.WriteLine("=== Mayores al promedio ===");
        mayores.Mostrar();
    }
}

// ================================================================
// PROGRAMA PRINCIPAL: Selección de ejecución
// ================================================================
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seleccione el programa a ejecutar:");
        Console.WriteLine("1. Registro de Vehículos");
        Console.WriteLine("2. Lista de Datos Reales y Promedio");
        Console.Write("Opción: ");
        string opcion = Console.ReadLine();

        if (opcion == "1")
            ProgramaVehiculos.Ejecutar();
        else if (opcion == "2")
            ProgramaReales.Ejecutar();
        else
            Console.WriteLine("Opción inválida.");
    }
}

