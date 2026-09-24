using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

class Mochila
{
    private int numeroDePociones;

    public Mochila()
    {
        numeroDePociones = 5;
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"En el inventario hay {numeroDePociones} pociones");
    }
}