// GameLogic.h
#pragma once
#include "json.hpp"
#include <cstdlib> 
#include <ctime>   
#include <iostream>
#include <fstream>

using json = nlohmann::json;


inline int GetRandom(int tamano)
{
    int random = rand() % tamano;
    return random;
}

class Ataque {
public:
    std::string nombre;   
    int damage;
    Ataque() {}
    Ataque(std::string n, int d) : nombre(n), damage(d) {}
};

class Pokemon {
public:
    std::string nombre;   
    std::string tipo;
    int vida;
    Ataque ataques[4];
    std::string numero;
    Pokemon() {}
};

inline Pokemon CrearPokemon(json& data)
{
    Pokemon pkm;
    int total_Pokemones = data["Pokemon"].size();
    int Rpkmon = GetRandom(total_Pokemones);
    auto pkmon = data["Pokemon"][Rpkmon];

    pkm.nombre = pkmon["nombre"];
    pkm.tipo = pkmon["tipo"];
    pkm.vida = pkmon["vida"];
    pkm.numero = pkmon.value("numero", "0000");

    std::string tipo = pkmon["tipo"];   
    int total_tipoPedido = data["AtaquesT"][tipo].size();
    int recordar = 0;

    for (int i = 0; i < 2; i++)
    {
        int RataqueT = GetRandom(total_tipoPedido);
        while (recordar == RataqueT)
            RataqueT = GetRandom(total_tipoPedido);
        recordar = RataqueT;
        auto ataqueT = data["AtaquesT"][tipo][RataqueT];
        pkm.ataques[i] = Ataque(ataqueT["nombre"], ataqueT["damage"]);
    }

    int total_Normal = data["AtaquesN"].size();
    recordar = 0;

    for (int i = 2; i < 4; i++)
    {
        int RataqueN = GetRandom(total_Normal);
        while (recordar == RataqueN)
            RataqueN = GetRandom(total_Normal);
        recordar = RataqueN;
        auto ataqueN = data["AtaquesN"][RataqueN];
        pkm.ataques[i] = Ataque(ataqueN["nombre"], ataqueN["damage"]);
    }

    return pkm;
}

class Entrenador {
public:
    std::string nombre;   
};

class EntrenadorJugador : public Entrenador {
public:
    Pokemon pokemon;
};

class EntrenadorNPC : public Entrenador {
public:
    Pokemon pokemon;
};