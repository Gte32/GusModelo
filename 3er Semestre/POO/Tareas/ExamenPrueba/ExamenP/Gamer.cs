public class Gamer
{
    public string Nickname;

    private double saldo;
    //inicializaddo generalmente para que siempre se cree
    public Membresia MiMembresia; //= new Membresia();

    public double Saldo
    {
        get { return saldo;}
        set
        {
            saldo = Math.Max(value, 0);
        }
    }

    public Gamer(string nombre, double saldoInicial)
    {
        Nickname = nombre;
        MiMembresia = new Membresia();
        saldo = saldoInicial;

    }

    public Gamer(string nombre)
    {
        Nickname = nombre;
        MiMembresia = new Membresia();
        saldo = 0;


    }




}