using System;
using System.Collections.Generic;

class Ingrediente
{
    public string Nombre { get; }
    public int Cantidad { get; }
    public decimal Precio { get; }

    public Ingrediente(string nombre, int cantidad, decimal precio)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }
}

class Pastel
{
    public string Nombre { get; }
    public string Tamaño { get; }
    private List<Ingrediente> ingredientes;

    public Pastel(string nombre, string tamaño)
    {
        Nombre = nombre;
        Tamaño = tamaño;
        ingredientes = new List<Ingrediente>();
    }

    public void AgregarIngrediente(Ingrediente ingrediente)
    {
        ingredientes.Add(ingrediente);
    }

    public int CantidadIngredientes()
    {
        return ingredientes.Count;
    }

    public string ListarIngredientes()
    {
        string lista = "";
        foreach (Ingrediente ingrediente in ingredientes)
        {
            lista += $"- {ingrediente.Nombre} ({ingrediente.Cantidad})\n";
        }
        return lista;
    }

    public decimal CalcularCosto()
    {
        decimal costoTotal = 0;
        foreach (Ingrediente ingrediente in ingredientes)
        {
            costoTotal += ingrediente.Precio;
        }
        return costoTotal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el nombre del pastel:");
        string nombrePastel = Console.ReadLine();

        Console.WriteLine("Ingrese el tamaño del pastel:");
        string tamañoPastel = Console.ReadLine();

        Pastel pastel = new Pastel(nombrePastel, tamañoPastel);

        bool agregarIngredientes = true;
        while (agregarIngredientes)
        {
            Console.WriteLine("Ingrese el nombre del ingrediente:");
            string nombreIngrediente = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad del ingrediente:");
            int cantidadIngrediente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el precio del ingrediente:");
            decimal precioIngrediente = decimal.Parse(Console.ReadLine());

            Ingrediente ingrediente = new Ingrediente(nombreIngrediente, cantidadIngrediente, precioIngrediente);
            pastel.AgregarIngrediente(ingrediente);

            Console.WriteLine("¿Desea agregar otro ingrediente? (s/n)");
            string respuesta = Console.ReadLine();
            agregarIngredientes = (respuesta.ToLower() == "s");
        }

        Console.WriteLine("\nResumen del pastel:");
        Console.WriteLine($"Nombre: {pastel.Nombre}");
        Console.WriteLine($"Tamaño: {pastel.Tamaño}");
        Console.WriteLine($"Cantidad de ingredientes: {pastel.CantidadIngredientes()}");
        Console.WriteLine("Ingredientes:");
        Console.WriteLine(pastel.ListarIngredientes());
        Console.WriteLine($"Costo total: {pastel.CalcularCosto()}");

        Console.ReadLine();
    }
}
