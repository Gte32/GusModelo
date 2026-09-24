public class LocalGaming
{
    public string NombreLocal;
    public List<Equipo> Inventario;

    public LocalGaming(string nombre)
    {
        NombreLocal = nombre;
        this.Inventario = new List<Equipo>();
    }


    public void RentarEquipo(Gamer cliente, Equipo pc, int horas)
    {
        double precio = pc.PrecioPorHora * horas;
        /*
        if (precio > cliente.Saldo)
        {
            Console.WriteLine($"El saldo disponible es {cliente.Saldo} y el precio a pagar es {precio}");
            Console.WriteLine("No es posible pagar el saldo del cliente, favor de agregar mas");
            return;
        }
        */
        double aux = cliente.Saldo;
        cliente.Saldo = cliente.Saldo - precio;

        Console.WriteLine($"{cliente.Nickname} ha pagado con su saldo inicial de: {aux}, el saldo que debe de: {precio}, su saldo restante es de {cliente.Saldo}");
    }

    public void AgregarEquipo(Equipo equipoAgregado) 
    {
        this.Inventario.Add(equipoAgregado);
    }
}