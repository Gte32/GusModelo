public class Sala
{
    public int NumeroSala;
    public int CapacidadMaxima;
    public Pelicula PeliculaProyectada;

    private int _asientosOcupados;

  
    public int AsientosOcupados 
    { 
        get { return _asientosOcupados; }
        set
        {
            //basado en como hice lo de pokemon
            _asientosOcupados = Math.Clamp(value,0, CapacidadMaxima);

        }
        
    }

    public int AsientosDisponibles 
    {
        get
        {
            int _asientosDisponibles = CapacidadMaxima - AsientosOcupados;
            return _asientosDisponibles;
        }
    }


    public Sala(int numero, int capacidad, Pelicula pelicula)
    {
        NumeroSala = numero;
        CapacidadMaxima = capacidad;
        PeliculaProyectada = pelicula;
        _asientosOcupados = 0;
    }
}