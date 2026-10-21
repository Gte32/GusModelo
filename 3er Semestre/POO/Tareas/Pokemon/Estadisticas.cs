using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

public struct Estadisticas
{

    public int vidaMax;
    private int vida;

    public int ataque;

    //public int defensa;

    public int curacion;
    public int nivel = 1;

    public Estadisticas(int vida, int ataque, int curacion, int nivel)
    {
        this.vidaMax = vida;
        this.vida = vida;
        this.ataque = ataque;
        this.curacion = curacion;
        this.nivel = nivel;
    }

    public int Vida
    {
        get { return vida; }
        set
        {
            vida = Math.Clamp(value, 0, vidaMax);
        }
    }
    public int Nivel
    {
        get { return nivel; }
        set
        {
            nivel = Math.Clamp(value, nivel, 100);
        }
    }

}