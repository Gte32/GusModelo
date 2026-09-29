public class Cine
{
    public string NombreCine;

    public List<Sala> SalasHabilitadas; //= new List<Sala>(); 
    public Cine(string nombre)
    {
        NombreCine = nombre;

        SalasHabilitadas = new List<Sala>();
      
    }

   public void AgregarSala(Sala salaAgregada)
    {
        this.SalasHabilitadas.Add(salaAgregada);
    }

  
    public void VenderBoleto(Espectador cliente, Sala salaCine)
    {
        Console.WriteLine($"\nProcesando venta para {cliente.Nombre} - Película: {salaCine.PeliculaProyectada.Titulo}...");

        bool Permitido = ChequeoSeguridad(cliente, salaCine);

        if (Permitido)
        {
            Console.WriteLine($"Se ha permitido la venta para el usuario");
            Console.WriteLine($"Se ha confirmado la venta para el cliente {cliente.Nombre} en la película - Película: {salaCine.PeliculaProyectada.Titulo}");
            salaCine.AsientosOcupados = salaCine.AsientosOcupados + 1 ;
            Console.WriteLine($"Se ha finalizado la venta");
        }
        else
        {
            Console.WriteLine($"Se ha cancelado la compra");
        }


        
     }

    public bool ChequeoSeguridad(Espectador cliente, Sala salaCine)
    {
        bool pasoChequeo = true;
        //edad = pelicula con edad minima, asociada a una sala
        // PeliculaProyectada de sala
        // EdadMinima de pelicula

        if (salaCine.PeliculaProyectada.EdadMinima > cliente.Edad)
        {
            pasoChequeo = false;
            Console.WriteLine($"El cliente {cliente.Nombre} no tiene la edad requerida para la pelicula");
        }

        if(salaCine.AsientosOcupados >= salaCine.CapacidadMaxima)
        {
            pasoChequeo = false;
            Console.WriteLine($"La sala número {salaCine.NumeroSala} no tiene asientos disponibles");
        }

        return pasoChequeo;

    }
}