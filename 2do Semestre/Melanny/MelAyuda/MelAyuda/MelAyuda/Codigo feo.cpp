#include <iostream>
using namespace std;
#include <cstdlib>
#include <ctime>

class pokemones {
private:

	string pokemon, tipo;
	int vida, danio = 0;
	int random = rand() % 151 + 1;
public:
	void elegirpokemon() {
		if (random == 1) {
			pokemon = "Bunolbasaur";
			vida = 30;
			tipo = "pasto";
		}
		else if (random == 2) {
			pokemon = "Ivysaur";
			tipo = "pasto";
			vida = 60;
		}
		else if (random == 3) {
			pokemon = "Venusaur";
			vida = 100;
			tipo = "pasto";
		}
		else if (random == 4) {
			pokemon = "Charmander";
			tipo = "fuego";
			vida = 30;
		}
		else if (random == 5) {
			pokemon = "Charmeleon";
			tipo = "fuego";
			vida = 60;
		}
		else if (random == 6) {
			pokemon = "Charizard";
			tipo = "fuego";
			vida = 100;
		}
		else if (random == 7) {
			pokemon = "Squirtle";
			tipo = "agua";
			vida = 30;
		}
		else if (random == 8) {
			pokemon = "Wartortle";
			tipo = "agua";
			vida = 60;
		}
		else if (random == 9) {
			pokemon = "Blastoise";
			tipo = "agua";
			vida = 100;
		}
		else if (random == 10) {
			pokemon = "Caterpie";
			tipo = "insecto";
			vida = 30;
		}
		else if (random == 11) {
			pokemon = "Metapod";
			tipo = "insecto";
			vida = 60;
		}
		else if (random == 12) {
			pokemon = "Butterfree";
			tipo = "insecto";
			vida = 100;
		}
		else if (random == 13) {
			pokemon = "Weedle";
			tipo = "insecto";
			vida = 30;
		}
		else if (random == 14) {
			pokemon = "Kakuna";
			tipo = "insecto";
			vida = 60;
		}
		else if (random == 15) {
			pokemon = "Beedrill";
			tipo = "insecto";
			vida = 100;
		}
		else if (random == 16) {
			pokemon = "Pidgey";
			tipo = "normal";
			vida = 30;
		}
		else if (random == 17) {
			pokemon = "Pidgeotto";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 18) {
			pokemon = "Pidgeot";
			tipo = "normal";
			vida = 100;
		}
		else if (random == 19) {
			pokemon = "Rattata";
			tipo = "normal";
			vida = 30;
		}
		else if (random == 20) {
			pokemon = "Raticate";
			tipo = "normal";
			vida = 60;
		}
		else if (random == 21) {
			pokemon = "Spearow";
			vida = 30;
			tipo = "normal";
		}
		else if (random == 22) {
			pokemon = "Fearow";
			tipo = "normal";
			vida = 60;
		}
		else if (random == 23) {
			pokemon = "Ekans";
			tipo = "veneno";
			vida = 30;
		}
		else if (random == 24) {
			pokemon = "Arbok";
			tipo = "veneno";
			vida = 60;
		}
		else if (random == 25) {
			pokemon = "Pikachu";
			vida = 30;
			tipo = "electrico";
		}
		else if (random == 26) {
			pokemon = "Raichu";
			tipo = "electrico";
			vida = 60;
		}
		else if (random == 27) {
			pokemon = "Sandshrew	";
			vida = 30;
			tipo = "suelo";
		}
		else if (random == 28) {
			pokemon = "Sandslash";
			tipo = "suelo";
			vida = 60;
		}
		else if (random == 29) {
			pokemon = "Nidoran";
			tipo = "veneno";
			vida = 30;
		}
		else if (random == 30) {
			pokemon = "Nidorina";
			tipo = "veneno";
			vida = 30;
		}
		else if (random == 31) {
			pokemon = "Nidoqueen";
			tipo = "veneno";
			vida = 60;
		}
		else if (random == 32) {
			pokemon = "Nidoran";
			tipo = "veneno";
			vida = 30;
		}
		else if (random == 33) {
			pokemon = "Nidorino";
			tipo = "veneno";
			vida = 30;
		}
		else if (random == 34) {
			pokemon = "Nidoking";
			vida = 60;
			tipo = "veneno";
		}
		else if (random == 35) {
			pokemon = "Clefairy";
			tipo = "hada";
			vida = 30;
		}
		else if (random == 36) {
			pokemon = "Clefable";
			tipo = "hada";
			vida = 60;
		}
		else if (random == 37) {
			pokemon = "Vulpix";
			vida = 30;
			tipo = "fuego";
		}
		else if (random == 38) {
			pokemon = "Ninetales";
			tipo = "fuego";
			vida = 60;
		}
		else if (random == 39) {
			pokemon = "Jigglypuff";
			tipo = "normal";
			vida = 30;
		}
		else if (random == 40) {
			pokemon = "Wigglytuff";
			tipo = "normal";
			vida = 60;
		}
		else if (random == 41) {
			pokemon = "Zubat";
			vida = 30;
			tipo = "veneno";
		}
		else if (random == 42) {
			pokemon = "Golbat";
			tipo = "veneno";
			vida = 60;
		}
		else if (random == 43) {
			pokemon = "Oddish";
			tipo = "pasto";
			vida = 30;
		}
		else if (random == 44) {
			pokemon = "Gloom";
			tipo = "pasto";
			vida = 60;
		}
		else if (random == 45) {
			pokemon = "Vileplume";
			vida = 100;
			tipo = "pasto";
		}
		else if (random == 46) {
			pokemon = "Paras";
			vida = 30;
			tipo = "insecto";
		}
		else if (random == 47) {
			pokemon = "Parasect";
			vida = 60;
			tipo = "insecto";
		}
		else if (random == 48) {
			pokemon = "Venonat";
			vida = 30;
			tipo = "insecto";
		}
		else if (random == 49) {
			pokemon = "Venomoth";
			vida = 60;
			tipo = "insecto";
		}
		else if (random == 50) {
			pokemon = "Diglett";
			vida = 30;
			tipo = "suelo";
		}
		else if (random == 51) {
			pokemon = "Dugtrio";
			vida = 60;
			tipo = "suelo";
		}
		else if (random == 52) {
			pokemon = "Meowth";
			vida = 30;
			tipo = "normal";
		}
		else if (random == 53) {
			pokemon = "Persian";
			tipo = "normal";
			vida = 60;
		}
		else if (random == 54) {
			pokemon = "Psyduck";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 55) {
			pokemon = "Golduck";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 56) {
			pokemon = "Mankey";
			vida = 30;
			tipo = "pelea";
		}
		else if (random == 57) {
			pokemon = "Primeape";
			vida = 60;
			tipo = "pelea";
		}
		else if (random == 58) {
			pokemon = "Growlithe";
			vida = 30;
			tipo = "fuego";
		}
		else if (random == 59) {
			pokemon = "Arcanine";
			vida = 60;
			tipo = "fuego";
		}
		else if (random == 60) {
			pokemon = "Poliwag";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 61) {
			pokemon = "Poliwhirl";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 62) {
			pokemon = "Poliwrath";
			vida = 100;
			tipo = "agua";
		}
		else if (random == 63) {
			pokemon = "Abra";
			vida = 30;
			tipo = "psiquico";
		}
		else if (random == 64) {
			pokemon = "Kadabra";
			vida = 60;
			tipo = "psiquico";
		}
		else if (random == 65) {
			pokemon = "Alakazam";
			vida = 100;
			tipo = "psiquico";
		}
		else if (random == 66) {
			pokemon = "Machop";
			vida = 30;
			tipo = "pelea";
		}
		else if (random == 67) {
			pokemon = "Machoke";
			vida = 60;
			tipo = "pelea";
		}
		else if (random == 68) {
			pokemon = "Machamp";
			vida = 100;
			tipo = "pelea";
		}
		else if (random == 69) {
			pokemon = "Bellsprout";
			vida = 30;
			tipo = "pasto";
		}
		else if (random == 70) {
			pokemon = "Weepinbell";
			vida = 60;
			tipo = "pasto";
		}
		else if (random == 71) {
			pokemon = "Victreebel";
			vida = 100;
			tipo = "pasto";
		}
		else if (random == 72) {
			pokemon = "Tentacool";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 73) {
			pokemon = "Tentacruel";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 74) {
			pokemon = "Geodude";
			vida = 30;
			tipo = "piedra";
		}
		else if (random == 75) {
			pokemon = "Graveler";
			vida = 60;
			tipo = "piedra";
		}
		else if (random == 76) {
			pokemon = "Golem";
			vida = 100;
			tipo = "piedra";
		}
		else if (random == 77) {
			pokemon = "Ponyta";
			vida = 30;
			tipo = "fuego";
		}
		else if (random == 78) {
			pokemon = "Rapidash";
			vida = 60;
			tipo = "fuego";
		}
		else if (random == 79) {
			pokemon = "Slowpoke";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 80) {
			pokemon = "Slowbro";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 81) {
			pokemon = "Magnemite";
			vida = 30;
			tipo = "electrico";
		}
		else if (random == 82) {
			pokemon = "Magneton";
			vida = 60;
			tipo = "electrico";
		}
		else if (random == 83) {
			pokemon = "Farfetch'd";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 84) {
			pokemon = "Doduo";
			vida = 30;
			tipo = "normal";
		}
		else if (random == 85) {
			pokemon = "Dodrio";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 86) {
			pokemon = "Seel";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 87) {
			pokemon = "Dewgong";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 88) {
			pokemon = "Grimer";
			vida = 30;
			tipo = "veneno";
		}
		else if (random == 89) {
			pokemon = "Muk";
			vida = 60;
			tipo = "veneno";
		}
		else if (random == 90) {
			pokemon = "Shellder";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 91) {
			pokemon = "Cloyster";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 92) {
			pokemon = "Gastly";
			vida = 30;
			tipo = "fantasma";
		}
		else if (random == 93) {
			pokemon = "Haunter";
			vida = 60;
			tipo = "fantasma";
		}
		else if (random == 94) {
			pokemon = "Gengar";
			vida = 100;
			tipo = "fantasma";
		}
		else if (random == 95) {
			pokemon = "Onix";
			vida = 60;
			tipo = "roca";
		}
		else if (random == 96) {
			pokemon = "Drowzee";
			vida = 30;
			tipo = "Psiquico";
		}
		else if (random == 97) {
			pokemon = "Hypno";
			vida = 60;
			tipo = "Psiquico";
		}
		else if (random == 98) {
			pokemon = "Krabby";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 99) {
			pokemon = "Kingler";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 100) {
			pokemon = "Voltorb";
			vida = 30;
			tipo = "electrico";
		}
		else if (random == 101) {
			pokemon = "Electrode";
			vida = 60;
			tipo = "electrico";
		}
		else if (random == 102) {
			pokemon = "Exeggcute";
			vida = 30;
			tipo = "hierba";
		}
		else if (random == 103) {
			pokemon = "Exeggutor";
			vida = 60;
			tipo = "hierba";
		}
		else if (random == 104) {
			pokemon = "Cubone";
			vida = 30;
			tipo = "tierra";
		}
		else if (random == 105) {
			pokemon = "Marowak";
			vida = 60;
			tipo = "tierra";
		}
		else if (random == 106) {
			pokemon = "Hitmonlee";
			vida = 30;
			tipo = "pelea";
		}
		else if (random == 107) {
			pokemon = "Hitmonchan";
			vida = 60;
			tipo = "pelea";
		}
		else if (random == 108) {
			pokemon = "Lickitung";
			vida = 100;
			tipo = "normal";
		}
		else if (random == 109) {
			pokemon = "Koffing";
			vida = 30;
			tipo = "veneno";
		}
		else if (random == 110) {
			pokemon = "Weezing";
			vida = 60;
			tipo = "veneno";
		}
		else if (random == 111) {
			pokemon = "Rhyhorn";
			vida = 30;
			tipo = "tierra";
		}
		else if (random == 112) {
			pokemon = "Rhydon";
			vida = 60;
			tipo = "tierra";
		}
		else if (random == 113) {
			pokemon = "Chansey";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 114) {
			pokemon = "Tangela";
			vida = 60;
			tipo = "hierba";
		}
		else if (random == 115) {
			pokemon = "Kangaskhan";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 116) {
			pokemon = "Horsea";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 117) {
			pokemon = "Seadra";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 118) {
			pokemon = "Goldeen";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 119) {
			pokemon = "Seaking";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 120) {
			pokemon = "Staryu";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 121) {
			pokemon = "Starmie";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 122) {
			pokemon = "Mr. Mime";
			vida = 60;
			tipo = "Psiquico";
		}
		else if (random == 123) {
			pokemon = "Scyther";
			vida = 60;
			tipo = "bicho";
		}
		else if (random == 124) {
			pokemon = "Jynx";
			vida = 60;
			tipo = "hielo";
		}
		else if (random == 125) {
			pokemon = "Electabuzz";
			vida = 60;
			tipo = "electrico";
		}
		else if (random == 126) {
			pokemon = "Magmar";
			vida = 60;
			tipo = "fuego";
		}
		else if (random == 127) {
			pokemon = "Pinsir";
			vida = 60;
			tipo = "bicho";
		}
		else if (random == 128) {
			pokemon = "Tauros";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 129) {
			pokemon = "Magikarp";
			vida = 30;
			tipo = "agua";
		}
		else if (random == 130) {
			pokemon = "Gyarados";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 131) {
			pokemon = "Lapras";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 132) {
			pokemon = "Ditto";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 133) {
			pokemon = "Eevee";
			vida = 30;
			tipo = "normal";
		}
		else if (random == 134) {
			pokemon = "Vaporeon";
			vida = 60;
			tipo = "agua";
		}
		else if (random == 135) {
			pokemon = "Jolteon";
			vida = 60;
			tipo = "electrico";
		}
		else if (random == 136) {
			pokemon = "Flareon";
			vida = 60;
			tipo = "fuego";
		}
		else if (random == 137) {
			pokemon = "Porygon";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 138) {
			pokemon = "Omanyte";
			vida = 30;
			tipo = "roca";
		}
		else if (random == 139) {
			pokemon = "Omastar";
			vida = 60;
			tipo = "roca";
		}
		else if (random == 140) {
			pokemon = "Kabuto";
			vida = 30;
			tipo = "roca";
		}
		else if (random == 141) {
			pokemon = "Kabutops";
			vida = 60;
			tipo = "roca";
		}
		else if (random == 142) {
			pokemon = "Aerodactyl";
			vida = 60;
			tipo = "roca";
		}
		else if (random == 143) {
			pokemon = "Snorlax";
			vida = 60;
			tipo = "normal";
		}
		else if (random == 144) {
			pokemon = "Articuno";
			vida = 60;
			tipo = "hielo";
		}
		else if (random == 145) {
			pokemon = "Zapdos";
			vida = 60;
			tipo = "electrico";
		}
		else if (random == 146) {
			pokemon = "Moltres";
			vida = 60;
			tipo = "fuego";
		}
		else if (random == 147) {
			pokemon = "Dratini";
			vida = 30;
			tipo = "dragon";
		}
		else if (random == 148) {
			pokemon = "Dragonair";
			vida = 60;
			tipo = "dragon";
		}
		else if (random == 149) {
			pokemon = "Dragonite";
			vida = 100;
			tipo = "dragon";
		}
		else if (random == 150) {
			pokemon = "Mewtwo";
			vida = 60;
			tipo = "Psiquico";
		}
		else if (random == 151) {
			pokemon = "Mew";
			vida = 30;
			tipo = "Psiquico";
		}
	}

	pokemones() {
		elegirpokemon();
	}

	string getPokemon() {
		return pokemon;
	}

	int getVida() {
		return vida;
	}

	string getTipo() {
		return tipo;
	}
};

class ataque {
private:
	int random = rand() % 100 + 1, random2 = rand() % 100 + 1, quitavid1 = rand() % 60 + 10, quitavid2 = rand() % 60 + 10;
	string atk1, atk2;
public:
	void primeratk() {
		if (random == 1) {
			atk1 = "Ácido";
		}
		if (random == 2) {
			atk1 = "Aguijón letal";
		}
		if (random == 3) {
			atk1 = "Ala de acero";
		}
		if (random == 4) {
			atk1 = "Alboroto";
		}
		if (random == 5) {
			atk1 = "Amnesia";
		}
		if (random == 6) {
			atk1 = "Anclaje";
		}
		if (random == 7) {
			atk1 = "Arañazo";
		}
		if (random == 8) {
			atk1 = "Ataque arena";
		}
		if (random == 9) {
			atk1 = "Ataque rápido";
		}
		if (random == 10) {
			atk1 = "Aullido";
		}
		if (random == 11) {
			atk1 = "Avalancha";
		}
		if (random == 12) {
			atk1 = "Beso amoroso";
		}
		if (random == 13) {
			atk1 = "Bofetón lodo";
		}
		if (random == 14) {
			atk1 = "Bola hielo";
		}
		if (random == 15) {
			atk1 = "Bola voltio";
		}
		if (random == 16) {
			atk1 = "Bomba ácida";
		}
		if (random == 17) {
			atk1 = "Bola de polen";
		}
		if (random == 18) {
			atk1 = "Bostezo";
		}
		if (random == 19) {
			atk1 = "Caída libre";
		}
		if (random == 20) {
			atk1 = "Campo de hierba";
		}
		if (random == 21) {
			atk1 = "Bola de acido";
		}
		if (random == 22) {
			atk1 = "Campo de niebla";
		}
		if (random == 23) {
			atk1 = "Campo eléctrico";
		}
		if (random == 24) {
			atk1 = "Campo psíquico";
		}
		if (random == 25) {
			atk1 = "Canto";
		}
		if (random == 26) {
			atk1 = "Canto mortal";
		}
		if (random == 27) {
			atk1 = "Canto helado";
		}
		if (random == 28) {
			atk1 = "Cañón floral";
		}
		if (random == 29) {
			atk1 = "Canto floral";
		}
		if (random == 30) {
			atk1 = "Cara susto";
		}
		if (random == 31) {
			atk1 = "Carga";
		}
		if (random == 32) {
			atk1 = "Carga dragón";
		}
		if (random == 33) {
			atk1 = "Carga tóxica";
		}
		if (random == 34) {
			atk1 = "Cascada";
		}
		if (random == 35) {
			atk1 = "Castigo";
		}
		if (random == 36) {
			atk1 = "Chapoteo lodo";
		}
		if (random == 37) {
			atk1 = "Chirrido";
		}
		if (random == 38) {
			atk1 = "Chispa";
		}
		if (random == 39) {
			atk1 = "Cola dragón";
		}
		if (random == 40) {
			atk1 = "Cólera del guardián";
		}
		if (random == 41) {
			atk1 = "Colmillo hielo";
		}
		if (random == 42) {
			atk1 = "Colmillo rayo";
		}
		if (random == 43) {
			atk1 = "Colmillo veneno";
		}
		if (random == 44) {
			atk1 = "Come sueños";
		}
		if (random == 45) {
			atk1 = "Confusión";
		}
		if (random == 46) {
			atk1 = "Conjuro";
		}
		if (random == 47) {
			atk1 = "Contraataque";
		}
		if (random == 48) {
			atk1 = "Cosquillas";
		}
		if (random == 49) {
			atk1 = "Cuchillada";
		}
		if (random == 50) {
			atk1 = "Cuchilla solar";
		}
		if (random == 51) {
			atk1 = "Cuerpo pesado";
		}
		if (random == 52) {
			atk1 = "Danza caos";
		}
		if (random == 53) {
			atk1 = "Danza dragón";
		}
		if (random == 54) {
			atk1 = "Danza espada";
		}
		if (random == 55) {
			atk1 = "Danza llama";
		}
		if (random == 56) {
			atk1 = "Danza lluvia";
		}
		if (random == 57) {
			atk1 = "Danza lunar";
		}
		if (random == 58) {
			atk1 = "Daño secreto";
		}
		if (random == 59) {
			atk1 = "Defensa floral";
		}
		if (random == 60) {
			atk1 = "Desahogo";
		}
		if (random == 61) {
			atk1 = "Destello";
		}
		if (random == 62) {
			atk1 = "Día de pago";
		}
		if (random == 63) {
			atk1 = "Día soleado";
		}
		if (random == 64) {
			atk1 = "Diluvio corrosivo";
		}
		if (random == 65) {
			atk1 = "Doble filo";
		}
		if (random == 66) {
			atk1 = "Doble golpe";
		}
		if (random == 67) {
			atk1 = "Doble patada";
		}
		if (random == 68) {
			atk1 = "Doble rayo";
		}
		if (random == 69) {
			atk1 = "Dracoenergía";
		}
		if (random == 70) {
			atk1 = "Dulce aroma";
		}
		if (random == 71) {
			atk1 = "Dracoaliento devastador";
		}
		if (random == 72) {
			atk1 = "Dragoaliento";
		}
		if (random == 73) {
			atk1 = "Empujón";
		}
		if (random == 74) {
			atk1 = "Enfado";
		}
		if (random == 75) {
			atk1 = "Eructo";
		}
		if (random == 76) {
			atk1 = "Escupir";
		}
		if (random == 77) {
			atk1 = "Espora";
		}
		if (random == 78) {
			atk1 = "Espada santa";
		}
		if (random == 79) {
			atk1 = "Estoicismo";
		}
		if (random == 80) {
			atk1 = "Excavar";
		}
		if (random == 81) {
			atk1 = "Explosión";
		}
		if (random == 82) {
			atk1 = "Finta";
		}
		if (random == 83) {
			atk1 = "Foco resplandor";
		}
		if (random == 84) {
			atk1 = "Frustración";
		}
		if (random == 85) {
			atk1 = "Fuego sagrado";
		}
		if (random == 86) {
			atk1 = "Fuerza bruta";
		}
		if (random == 87) {
			atk1 = "Furia";
		}
		if (random == 88) {
			atk1 = "Furia dragón";
		}
		if (random == 89) {
			atk1 = "Garra brutal";
		}
		if (random == 90) {
			atk1 = "Garra metal";
		}
		if (random == 91) {
			atk1 = "Gas venenoso";
		}
		if (random == 92) {
			atk1 = "Giro rápido";
		}
		if (random == 93) {
			atk1 = "Golpe calor";
		}
		if (random == 94) {
			atk1 = "Golpe cuerpo";
		}
		if (random == 95) {
			atk1 = "Golpe kárate";
		}
		if (random == 96) {
			atk1 = "Golpe fantasma";
		}
		if (random == 97) {
			atk1 = "Golpe oscuro";
		}
		if (random == 98) {
			atk1 = "Gota vital";
		}
		if (random == 99) {
			atk1 = "Hipnosis";
		}
		if (random == 100) {
			atk1 = "Infierno";
		}

	}
	void segundoatk() {
		if (random2 == 1) {
			atk2 = "Ácido";
		}
		if (random2 == 2) {
			atk2 = "Aguijón letal";
		}
		if (random2 == 3) {
			atk2 = "Ala de acero";
		}
		if (random2 == 4) {
			atk2 = "Alboroto";
		}
		if (random2 == 5) {
			atk2 = "Amnesia";
		}
		if (random2 == 6) {
			atk2 = "Anclaje";
		}
		if (random2 == 7) {
			atk2 = "Arañazo";
		}
		if (random2 == 8) {
			atk2 = "Ataque arena";
		}
		if (random2 == 9) {
			atk2 = "Ataque rápido";
		}
		if (random2 == 10) {
			atk2 = "Aullido";
		}
		if (random2 == 11) {
			atk2 = "Avalancha";
		}
		if (random2 == 12) {
			atk2 = "Beso amoroso";
		}
		if (random2 == 13) {
			atk2 = "Bofetón lodo";
		}
		if (random2 == 14) {
			atk2 = "Bola hielo";
		}
		if (random2 == 15) {
			atk2 = "Bola voltio";
		}
		if (random2 == 16) {
			atk2 = "Bomba ácida";
		}
		if (random2 == 17) {
			atk2 = "Bola de polen";
		}
		if (random2 == 18) {
			atk2 = "Bostezo";
		}
		if (random2 == 19) {
			atk2 = "Caída libre";
		}
		if (random2 == 20) {
			atk2 = "Campo de hierba";
		}
		if (random2 == 21) {
			atk2 = "Bola de acido";
		}
		if (random2 == 22) {
			atk2 = "Campo de niebla";
		}
		if (random2 == 23) {
			atk2 = "Campo eléctrico";
		}
		if (random2 == 24) {
			atk2 = "Campo psíquico";
		}
		if (random2 == 25) {
			atk2 = "Canto";
		}
		if (random2 == 26) {
			atk2 = "Canto mortal";
		}
		if (random2 == 27) {
			atk2 = "Canto helado";
		}
		if (random2 == 28) {
			atk2 = "Cañón floral";
		}
		if (random2 == 29) {
			atk2 = "Canto floral";
		}
		if (random2 == 30) {
			atk2 = "Cara susto";
		}
		if (random2 == 31) {
			atk2 = "Carga";
		}
		if (random2 == 32) {
			atk2 = "Carga dragón";
		}
		if (random2 == 33) {
			atk2 = "Carga tóxica";
		}
		if (random2 == 34) {
			atk2 = "Cascada";
		}
		if (random2 == 35) {
			atk2 = "Castigo";
		}
		if (random2 == 36) {
			atk2 = "Chapoteo lodo";
		}
		if (random2 == 37) {
			atk2 = "Chirrido";
		}
		if (random2 == 38) {
			atk2 = "Chispa";
		}
		if (random2 == 39) {
			atk2 = "Cola dragón";
		}
		if (random2 == 40) {
			atk2 = "Cólera del guardián";
		}
		if (random2 == 41) {
			atk2 = "Colmillo hielo";
		}
		if (random2 == 42) {
			atk2 = "Colmillo rayo";
		}
		if (random2 == 43) {
			atk2 = "Colmillo veneno";
		}
		if (random2 == 44) {
			atk2 = "Come sueños";
		}
		if (random2 == 45) {
			atk2 = "Confusión";
		}
		if (random2 == 46) {
			atk2 = "Conjuro";
		}
		if (random2 == 47) {
			atk2 = "Contraataque";
		}
		if (random2 == 48) {
			atk2 = "Cosquillas";
		}
		if (random2 == 49) {
			atk2 = "Cuchillada";
		}
		if (random2 == 50) {
			atk2 = "Cuchilla solar";
		}
		if (random2 == 51) {
			atk2 = "Cuerpo pesado";
		}
		if (random2 == 52) {
			atk2 = "Danza caos";
		}
		if (random2 == 53) {
			atk2 = "Danza dragón";
		}
		if (random2 == 54) {
			atk2 = "Danza espada";
		}
		if (random2 == 55) {
			atk2 = "Danza llama";
		}
		if (random2 == 56) {
			atk2 = "Danza lluvia";
		}
		if (random2 == 57) {
			atk2 = "Danza lunar";
		}
		if (random2 == 58) {
			atk2 = "Daño secreto";
		}
		if (random2 == 59) {
			atk2 = "Defensa floral";
		}
		if (random2 == 60) {
			atk2 = "Desahogo";
		}
		if (random2 == 61) {
			atk2 = "Destello";
		}
		if (random2 == 62) {
			atk2 = "Día de pago";
		}
		if (random2 == 63) {
			atk2 = "Día soleado";
		}
		if (random2 == 64) {
			atk2 = "Diluvio corrosivo";
		}
		if (random2 == 65) {
			atk2 = "Doble filo";
		}
		if (random2 == 66) {
			atk2 = "Doble golpe";
		}
		if (random2 == 67) {
			atk2 = "Doble patada";
		}
		if (random2 == 68) {
			atk2 = "Doble rayo";
		}
		if (random2 == 69) {
			atk2 = "Dracoenergía";
		}
		if (random2 == 70) {
			atk2 = "Dulce aroma";
		}
		if (random2 == 71) {
			atk2 = "Dracoaliento devastador";
		}
		if (random2 == 72) {
			atk2 = "Dragoaliento";
		}
		if (random2 == 73) {
			atk2 = "Empujón";
		}
		if (random2 == 74) {
			atk2 = "Enfado";
		}
		if (random2 == 75) {
			atk2 = "Eructo";
		}
		if (random2 == 76) {
			atk2 = "Escupir";
		}
		if (random2 == 77) {
			atk2 = "Espora";
		}
		if (random2 == 78) {
			atk2 = "Espada santa";
		}
		if (random2 == 79) {
			atk2 = "Estoicismo";
		}
		if (random2 == 80) {
			atk2 = "Excavar";
		}
		if (random2 == 81) {
			atk2 = "Explosión";
		}
		if (random2 == 82) {
			atk2 = "Finta";
		}
		if (random2 == 83) {
			atk2 = "Foco resplandor";
		}
		if (random2 == 84) {
			atk2 = "Frustración";
		}
		if (random2 == 85) {
			atk2 = "Fuego sagrado";
		}
		if (random2 == 86) {
			atk2 = "Fuerza bruta";
		}
		if (random2 == 87) {
			atk2 = "Furia";
		}
		if (random2 == 88) {
			atk2 = "Furia dragón";
		}
		if (random2 == 89) {
			atk2 = "Garra brutal";
		}
		if (random2 == 90) {
			atk2 = "Garra metal";
		}
		if (random2 == 91) {
			atk2 = "Gas venenoso";
		}
		if (random2 == 92) {
			atk2 = "Giro rápido";
		}
		if (random2 == 93) {
			atk2 = "Golpe calor";
		}
		if (random2 == 94) {
			atk2 = "Golpe cuerpo";
		}
		if (random2 == 95) {
			atk2 = "Golpe kárate";
		}
		if (random2 == 96) {
			atk2 = "Golpe fantasma";
		}
		if (random2 == 97) {
			atk2 = "Golpe oscuro";
		}
		if (random2 == 98) {
			atk2 = "Gota vital";
		}
		if (random2 == 99) {
			atk2 = "Hipnosis";
		}
		if (random2 == 100) {
			atk2 = "Infierno";
		}
	}
	void compararig() {
		if (atk1 == atk2) {
			atk2 = "Pataleta";
		}
	}

	ataque() {
		primeratk();
		segundoatk();
		compararig();
	}
	string getAtk1() {
		return atk1;
	}
	string getAtk2() {
		return atk2;
	}
	int getQuitavid1() {
		return quitavid1;
	}
	int getQuitavid2() {
		return quitavid2;
	}
};

int main() {
	srand(time(NULL));
	int eleccion, contador = 0;
	char cambiarPokemon;

	srand(time(0));

	cout << "---BIENVENIDO A POKEMON---" << endl;
	cout << "Apreta ``enter`` para iniciar" << endl;
	cout << "--Seleccionar pokemon (1)- Iniciar Batalla (2)- Salir (3)--" << endl;
	cin >> eleccion;


	pokemones jugador;
	pokemones guerrero;
	ataque jugad;
	ataque guerra;

	if (eleccion == 1 || eleccion == 2) {
		cout << "Puedes seleccionar un pokemon hasta 3 veces" << endl;
		do {
			cout << "-Tu Pokemon es " << jugador.getPokemon() << endl;
			cout << "-Tipo: " << jugador.getTipo() << endl;
			cout << "-Vida: " << jugador.getVida() << " pts." << endl;
			cout << "Quieres cambiar de pokemon? y/n" << endl;
			cin >> cambiarPokemon;

			if (cambiarPokemon = "y" && contador < 2) {
				
				//jugador.getPokemon() = new jugador.getPokemon();
			}
			contador++;
		} while (cambiarPokemon = "y" && contador < 3);

		cout << "-INICIANDO BATALLA-" << endl;

		cout << "-El Pokemon de tu rival es " << guerrero.getPokemon() << endl;
		cout << "-De Tipo: " << guerrero.getTipo() << endl;
		cout << "-Con Vida de: " + guerrero.getVida() << " pts." << endl;
		cout << "Tiene como ataque: " << guerra.getAtk1() << " con danio de " << guerra.getQuitavid1() << "pts." << endl;
		cout << "Tiene como ataque: " << guerra.getAtk2() << " con danio de " << guerra.getQuitavid2() << "pts." << endl;

		cout << "-Tu Pokemon es " << jugador.getPokemon() << endl;
		cout << "-Tipo: " << jugador.getTipo() << endl;
		cout << "-Vida: " << jugador.getVida() << " pts." << endl;
		cout << "Tiene como ataque: " << jugad.getAtk1() << " con danio de " << jugad.getQuitavid1() << "pts." << endl;
		cout << "Tiene como ataque: " << jugad.getAtk2() << " con danio de " << jugad.getQuitavid2() << "pts." << endl;
	}
	if (eleccion == 3) {
		cout << "Gracias, bye" << endl;
	}
	return 0;
}