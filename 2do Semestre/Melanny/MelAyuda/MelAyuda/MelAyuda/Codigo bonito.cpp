#include "json.hpp"
#include <cstdlib> 
#include <ctime>   
#include <iostream>
#include <fstream>

using json = nlohmann::json;
using namespace std;




int GetRandom(int tamano)
{
    int random = rand() % tamano;
    return random;
}

class Ataque {
public:
    string nombre = "";
    int damage = 0;

    Ataque() {}
    Ataque(string n, int d) : nombre(n), damage(d) {}
};


class Pokemon {
public:
    string nombre = "";
    string tipo = "";
    int vida = 0;

    Ataque ataques[4];

    
};

Pokemon CrearPokemon(json& data)
{
    Pokemon pkm;

    //Tamano de los pokemones en el json
    int total_Pokemones = data["Pokemon"].size();

    ///Haces el random y eliges un pokemon
    int Rpkmon = GetRandom(total_Pokemones);

    ///Sacas el pkmon de la lista Pokemones, segun tu random
    auto pkmon = data["Pokemon"][Rpkmon];

    //Vamos a rellenar pokemon
    pkm.nombre = pkmon["nombre"];
    pkm.tipo = pkmon["tipo"];
    pkm.vida = pkmon["vida"];


    //FALTAN LOS ATAQUES
    //Sacas el tipo del pkmon
    string tipo = pkmon["tipo"];
    //Sacas el random del tipo pedido
    int total_tipoPedido = data["AtaquesT"][tipo].size();
    int recordar = 0;
    for (int i = 0; i < 2; i++)
    {
        //Random de los ataques de tu tipo 
        int RataqueT = GetRandom(total_tipoPedido);

        while (recordar == RataqueT)
        {
            RataqueT = GetRandom(total_tipoPedido);
        }
        recordar = RataqueT;
        //Eliges el ataque, segun tipo, segun el numero
        auto ataqueT = data["AtaquesT"][tipo][RataqueT];

        pkm.ataques[i] = Ataque(ataqueT["nombre"], ataqueT["damage"]);

    }

    int total_Normal = data["AtaquesN"].size();

    recordar = 0;
    for (int i = 2; i < 4; i++)
    {
        //Random de los ataques de tu normales 
        int RataqueN = GetRandom(total_Normal);
        while (recordar == RataqueN)
        {
            RataqueN = GetRandom(total_Normal);
        }
        recordar = RataqueN;
        //Eliges el ataque, segun tipo, segun el numero
        auto ataqueN = data["AtaquesN"][RataqueN];

        pkm.ataques[i] = Ataque(ataqueN["nombre"], ataqueN["damage"]);

    }


    return pkm;

}


class Entrenador {
public:
    string nombre;

};

class EntrenadorNPC : public Entrenador {

public:
    Pokemon equipo[3];


};

class EntrenadorJugador : public Entrenador{

public:
    Pokemon equipo[3];


};


Pokemon ElegirPokemon(json& data)
{
    Pokemon eleccion1 = CrearPokemon(data);
    Pokemon eleccion2 = CrearPokemon(data);
    Pokemon eleccion3 = CrearPokemon(data);

    //De aqui en la aplicacion crear un boton elegir


}






int main()
{
    //Se habre el json
    ifstream file("Datos.json");
    //A fuerza se inicia la semilla aqui, asi se corre y si hay random deberas
    srand(time(0));
    if (!file)
    {
        cout << "No se pudo abrir" << endl;
        return -1;
    }

    int eleccion = 0;
    json data;
    file >> data;

















    cout << "---BIENVENIDO A POKEMON---" << endl;
    cout << "Apreta ``enter`` para iniciar" << endl;
    cout << "--Seleccionar pokemon (1)- Iniciar Batalla (2)- Salir (3)--" << endl;
    cin >> eleccion;

    if (eleccion == 3)
    {
        cout << "Gracias, bye" << endl;
        return 0;
    }

    if ((eleccion == 1) || (eleccion == 2))
    {

        Pokemon jugador = CrearPokemon(data);
        Pokemon enemigo = CrearPokemon(data);

        cout << jugador.nombre << endl;
        cout << jugador.tipo << endl;
        cout << jugador.vida << endl;


        for (int i = 0; i < 4; i++) {
            cout << jugador.ataques[i].nombre
                << " (" << jugador.ataques[i].damage << ")\n";
        }

        cout << "-INICIANDO BATALLA-" << endl;
        cout << " " << endl;

        cout << "-El Pokemon de tu rival es " << enemigo.nombre << endl;
        cout << "-De Tipo: " << enemigo.tipo << endl;
        cout << "-Vida: " << enemigo.vida << " pts." << endl;
        cout << "Tiene como ataque: " << enemigo.ataques[0].nombre << " con danio de " << enemigo.ataques[0].damage << "pts." << endl;
        cout << "Tiene como ataque: " << enemigo.ataques[1].nombre << " con danio de " << enemigo.ataques[1].damage << "pts." << endl;
        cout << "Tiene como ataque: " << enemigo.ataques[2].nombre << " con danio de " << enemigo.ataques[2].damage << "pts." << endl;
        cout << "Tiene como ataque: " << enemigo.ataques[3].nombre << " con danio de " << enemigo.ataques[3].damage << "pts." << endl;

        cout << " " << endl;

        cout << "-Tu Pokemon es " << jugador.nombre << endl;
        cout << "-Tipo: " << jugador.tipo << endl;
        cout << "-Vida: " << jugador.vida << " pts." << endl;
        cout << "Tiene como ataque: " << jugador.ataques[0].nombre << " con danio de " << jugador.ataques[0].damage << "pts." << endl;
        cout << "Tiene como ataque: " << jugador.ataques[1].nombre << " con danio de " << jugador.ataques[1].damage << "pts." << endl;
        cout << "Tiene como ataque: " << jugador.ataques[2].nombre << " con danio de " << jugador.ataques[2].damage << "pts." << endl;
        cout << "Tiene como ataque: " << jugador.ataques[3].nombre << " con danio de " << jugador.ataques[3].damage << "pts." << endl;

    }


    return 0;



}