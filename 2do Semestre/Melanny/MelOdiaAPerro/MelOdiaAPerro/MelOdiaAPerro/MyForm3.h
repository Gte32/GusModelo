#pragma once
#include "GameLogic.h"
#include <Windows.h>
#include "MyForm4.h"

namespace MelOdiaAPerro {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Resumen de MyForm3
	/// </summary>
	public ref class MyForm3 : public System::Windows::Forms::Form
	{
	public:
		Pokemon* miPokemon;
		Pokemon* enemigo1;
		Pokemon* enemigo2;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::Label^ label6;
	private: System::Windows::Forms::PictureBox^ pictureBox1;
	private: System::Windows::Forms::PictureBox^ pictureBox2;

	private: System::Windows::Forms::Label^ label8;
	private: System::Windows::Forms::Label^ label9;
	private: System::Windows::Forms::Label^ label10;
	private: System::Windows::Forms::Label^ label11;
	private: System::Windows::Forms::PictureBox^ pictureBox3;
	private: System::Windows::Forms::PictureBox^ pictureBox4;
	public:
		Pokemon* enemigo3;


		MyForm3(Pokemon* pkm, Pokemon* e1, Pokemon* e2, Pokemon* e3)
		{
			InitializeComponent();
			miPokemon = pkm;
			enemigo1 = e1;
			enemigo2 = e2;
			enemigo3 = e3;
			//para esto se uso windows
			//para que pueda spamear boton de random y cuente
			srand((unsigned)time(nullptr) ^ GetTickCount());

			//
			//TODO: agregar código de constructor aquí
			//
		}

	protected:
		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		~MyForm3()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ button1;
	protected:
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::Button^ button3;
	private: System::Windows::Forms::Button^ button4;

	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Button^ button5;

	private:
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		System::ComponentModel::Container ^components;
		EntrenadorJugador* jugador = nullptr;
		EntrenadorNPC* npc1 = nullptr;
		EntrenadorNPC* npc2 = nullptr;
		EntrenadorNPC* npc3 = nullptr;
		int numentrenador = 0;
		int vidaog = 0;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox2 = (gcnew System::Windows::Forms::PictureBox());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->pictureBox3 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox4 = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->BeginInit();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(16, 439);
			this->button1->Margin = System::Windows::Forms::Padding(4);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(533, 92);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Ataque1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm3::button1_Click);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(585, 439);
			this->button2->Margin = System::Windows::Forms::Padding(4);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(536, 92);
			this->button2->TabIndex = 1;
			this->button2->Text = L"Ataque2";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm3::button2_Click);
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(16, 539);
			this->button3->Margin = System::Windows::Forms::Padding(4);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(533, 92);
			this->button3->TabIndex = 2;
			this->button3->Text = L"Ataque3";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm3::button3_Click);
			// 
			// button4
			// 
			this->button4->Location = System::Drawing::Point(585, 537);
			this->button4->Margin = System::Windows::Forms::Padding(4);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(536, 92);
			this->button4->TabIndex = 3;
			this->button4->Text = L"Ataque4";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &MyForm3::button4_Click);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(126, 90);
			this->label2->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(95, 16);
			this->label2->TabIndex = 5;
			this->label2->Text = L"Vida Enemigo:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(702, 274);
			this->label3->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(118, 16);
			this->label3->TabIndex = 6;
			this->label3->Text = L"NombrePkmonYo:";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(13, 375);
			this->label4->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(86, 16);
			this->label4->TabIndex = 7;
			this->label4->Text = L"InfoCombate:";
			// 
			// button5
			// 
			this->button5->Location = System::Drawing::Point(1001, 15);
			this->button5->Margin = System::Windows::Forms::Padding(4);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(100, 28);
			this->button5->TabIndex = 8;
			this->button5->Text = L"Salir";
			this->button5->UseVisualStyleBackColor = true;
			this->button5->Click += gcnew System::EventHandler(this, &MyForm3::button5_Click);
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(819, 340);
			this->label5->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(55, 16);
			this->label5->TabIndex = 9;
			this->label5->Text = L"VidaYo:";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(34, 27);
			this->label6->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(110, 16);
			this->label6->TabIndex = 10;
			this->label6->Text = L"NombreEnemigo";
			// 
			// pictureBox1
			// 
			this->pictureBox1->Location = System::Drawing::Point(16, 12);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(369, 119);
			this->pictureBox1->TabIndex = 11;
			this->pictureBox1->TabStop = false;
			// 
			// pictureBox2
			// 
			this->pictureBox2->Location = System::Drawing::Point(680, 259);
			this->pictureBox2->Name = L"pictureBox2";
			this->pictureBox2->Size = System::Drawing::Size(369, 119);
			this->pictureBox2->TabIndex = 12;
			this->pictureBox2->TabStop = false;
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Location = System::Drawing::Point(659, 21);
			this->label8->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(130, 16);
			this->label8->TabIndex = 14;
			this->label8->Text = L"Entrenador Enemigo";
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Location = System::Drawing::Point(18, 232);
			this->label9->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(126, 16);
			this->label9->TabIndex = 15;
			this->label9->Text = L"Entrenador Jugador";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Location = System::Drawing::Point(436, 115);
			this->label10->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(62, 16);
			this->label10->TabIndex = 16;
			this->label10->Text = L"Victorias:\r\n";
			this->label10->TextAlign = System::Drawing::ContentAlignment::TopCenter;
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Location = System::Drawing::Point(13, 401);
			this->label11->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(140, 16);
			this->label11->TabIndex = 17;
			this->label11->Text = L"InfoCombateEnemigo:";
			// 
			// pictureBox3
			// 
			this->pictureBox3->Location = System::Drawing::Point(222, 245);
			this->pictureBox3->Name = L"pictureBox3";
			this->pictureBox3->Size = System::Drawing::Size(149, 111);
			this->pictureBox3->TabIndex = 18;
			this->pictureBox3->TabStop = false;
			// 
			// pictureBox4
			// 
			this->pictureBox4->Location = System::Drawing::Point(811, 90);
			this->pictureBox4->Name = L"pictureBox4";
			this->pictureBox4->Size = System::Drawing::Size(149, 111);
			this->pictureBox4->TabIndex = 19;
			this->pictureBox4->TabStop = false;
			// 
			// MyForm3
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1137, 644);
			this->Controls->Add(this->label11);
			this->Controls->Add(this->label10);
			this->Controls->Add(this->label9);
			this->Controls->Add(this->label8);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->button5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->button4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->pictureBox2);
			this->Controls->Add(this->pictureBox3);
			this->Controls->Add(this->pictureBox4);
			this->Margin = System::Windows::Forms::Padding(4);
			this->Name = L"MyForm3";
			this->Text = L"MyForm3";
			this->Load += gcnew System::EventHandler(this, &MyForm3::MyForm3_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	
	private: System::Void button5_Click(System::Object^ sender, System::EventArgs^ e) {
		//cierra aplicacion
	Application::Exit();;
}

	void SiguienteForm() 
	{
		//pasa al siguiente forms
		MyForm4^ f4 = gcnew MyForm4(numentrenador);  //pasa numentrenador al 4
		f4->Show(); //muestra siguiente
		this->Hide(); //esconde actual
	}

	//funcion de random x para no tener que hacer eso, flojera maxima, y generalizada
	int Randomnum(int rango) {
		int randomnum = rand() % rango;

		return randomnum;
	}

	private: System::Void MyForm3_Load(System::Object^ sender, System::EventArgs^ e)
	{

		//de tus variables globales obtienes nuevo entranado del gamelogic
		jugador = new EntrenadorJugador();

		npc1 = new EntrenadorNPC();
		npc2 = new EntrenadorNPC();
		npc3 = new EntrenadorNPC();

		jugador->pokemon = *miPokemon;
		npc1->pokemon = *enemigo1;
		npc2->pokemon = *enemigo2;
		npc3->pokemon = *enemigo3;

		//rellenamos 
		jugador->nombre = "Jugador";

		npc1->nombre = "Rojo";
		npc2->nombre = "Azul";
		npc3->nombre = "Hoja";

		label3->Text =
			gcnew String(jugador->pokemon.nombre.c_str());

		label10->Text =
			"Entrenadores Vencidos:" + numentrenador.ToString();

		label5->Text =
			"MiVida: " + jugador->pokemon.vida.ToString();

		vidaog = jugador->pokemon.vida;

		label8->Text = 
			"Entrenador: " + gcnew String(npc1->nombre.c_str());

		label9->Text =
			"Entrenador: " + gcnew String(jugador->nombre.c_str());

		label6->Text =
			gcnew String(npc1->pokemon.nombre.c_str());

		label2->Text =
			"EnemigoVida: " + npc1->pokemon.vida.ToString();

		button1->Text =
			gcnew String(jugador->pokemon.ataques[0].nombre.c_str());

		button2->Text =
			gcnew String(jugador->pokemon.ataques[1].nombre.c_str());

		button3->Text =
			gcnew String(jugador->pokemon.ataques[2].nombre.c_str());

		button4->Text =
			gcnew String(jugador->pokemon.ataques[3].nombre.c_str());



		int empieza = Randomnum(2);

		if (empieza == 0) 
		{
			//jugador empieza
			label4->Text =
				"¡Empieza el jugador!";
		}
		else
		{
			//empieza enemigo
			label4->Text =
				"¡Empieza el enemigo!";
			EnemigoTurno(numentrenador);
		}

		//rutas para imaenes

		System::String^ rutaBaseEnemigo = "imagenes/red-blue/";
		System::String^ rutaBaseJugador = "imagenes/red-blue/back/";
		System::String^ extension = ".png";

		// de aqui saca las imagenes para ponerlas en el ui
			System::String^ ruta = rutaBaseJugador + gcnew String(jugador->pokemon.numero.c_str()) + extension;
			if (System::IO::File::Exists(ruta)) {
				pictureBox3->Image = System::Drawing::Image::FromFile(ruta);
				pictureBox3->SizeMode = PictureBoxSizeMode::StretchImage;
			}
	
			
			//llamas cargar enemigo para leer su imagen

		CargarImagenEnemigo();
	}


	void CargarImagenEnemigo() {

		//lit lo mismo que jugador pero pues con enemigo
		System::String^ rutaBaseEnemigo = "imagenes/red-blue/";
		System::String^ extension = ".png";
		EntrenadorNPC* enemigoActual = GetEnemigoActual();
		if (!enemigoActual) return;

			System::String^ ruta = rutaBaseEnemigo + gcnew String(enemigoActual->pokemon.numero.c_str()) + extension;
			if (System::IO::File::Exists(ruta)) {
				pictureBox4->Image = System::Drawing::Image::FromFile(ruta);
				pictureBox4->SizeMode = PictureBoxSizeMode::StretchImage;
			}

	}


	EntrenadorNPC* GetEnemigoActual()
	{
		//con la variable global checa y cambia el npc, lo regresa
		if (numentrenador == 0) return npc1;
		if (numentrenador == 1) return npc2;
		if (numentrenador == 2) return npc3;
		return nullptr;
	}

	void EnemigoAtaque(int indiceAtaque)
	{
		//lo mismo qu ejugador, obtiene enmigo actual, ataca al jugador y si lo derrota lo saca al siguiente form
		EntrenadorNPC* enemigoActual = GetEnemigoActual();
		if (!enemigoActual) return;
		int vidainiciaj = 0;

		if (jugador->pokemon.vida <= 0) return;
		Ataque ataqueUsado = enemigoActual->pokemon.ataques[indiceAtaque];

		vidainiciaj = jugador->pokemon.vida;

		jugador->pokemon.vida -= ataqueUsado.damage;

		if (jugador->pokemon.vida < 0)
			jugador->pokemon.vida = 0;

		if (jugador->pokemon.vida == 0)
		{
			label4->Text = "¡Te han derrotado!";
			label5->Text =
				"MiVida: " + jugador->pokemon.vida.ToString();
			SiguienteForm();
			return;
		}

		
		label11->Text =
			gcnew String(enemigoActual->pokemon.nombre.c_str()) +
			" atacó con " + gcnew String(ataqueUsado.nombre.c_str()) +
			" y de tu vida inicial: " + vidainiciaj.ToString() +
			" te dejó con: " + jugador->pokemon.vida.ToString();

		label5->Text =
			"MiVida: " + jugador->pokemon.vida.ToString();
	}

	void EnemigoTurno(int)
	{
		//para pues obtener primero enemigo actual y el ataque que se va usar, pudo haber ido todo en uno pero por orden
		EntrenadorNPC* enemigoActual = GetEnemigoActual();
		if (!enemigoActual) return;

		int ataquenum = Randomnum(4);
		EnemigoAtaque(ataquenum);
	}

	
	void Cambio(String^ nombreDerrotado)
	{
		//cosa de cambio, si es derrotado un enemigo ocurre
		//si hay ya 3 vencidos pasa al siguiente
		if (numentrenador == 3) 
		{
			SiguienteForm();
		}
		EntrenadorNPC* enemigoActual = GetEnemigoActual();
		if (!enemigoActual) return;

		//actualizas la imagen del enemigo
		CargarImagenEnemigo();

		//se cambian datos visuales
		label10->Text =
			"Entrenadores Vencidos: " + numentrenador.ToString();

		label8->Text =
			"Entrenador: " + gcnew String(enemigoActual->nombre.c_str());

		label6->Text =
			gcnew String(enemigoActual->pokemon.nombre.c_str());

		label2->Text =
			"EnemigoVida: " + enemigoActual->pokemon.vida.ToString();

		label4->Text =
			"Derrotaste a " + nombreDerrotado +
			" y te has curado a tu vida original: " + vidaog;


	}

	void Atacar(int indiceAtaque)
	{
		//ataque
		//obtienes enemigo actual
		EntrenadorNPC* enemigoActual = GetEnemigoActual();
		if (!enemigoActual) return;
		//recuerdas tu vida inicial para printearla
		int vidainicioe = 0;
		//cual ataque usaste recibido por boton
		Ataque ataqueUsado = jugador->pokemon.ataques[indiceAtaque];

		//recuerdas vida enemigo inicial para printear
		vidainicioe = enemigoActual->pokemon.vida;

		//se resta su vida actual
		enemigoActual->pokemon.vida -= ataqueUsado.damage;

		if (enemigoActual->pokemon.vida <= 0)
		{
			//si vences al enemigo no baja al negativo
			enemigoActual->pokemon.vida = 0;

			//
			String^ nombreDerrotado = gcnew String(enemigoActual->nombre.c_str());

			label4->Text =
				"Has vencido a " + nombreDerrotado;

			label2->Text =
				"EnemigoVida: " + enemigoActual->pokemon.vida.ToString();

			numentrenador++;

			label4->Text =
				"Atacaste con " + gcnew String(ataqueUsado.nombre.c_str()) +
				" a " + gcnew String(enemigoActual->pokemon.nombre.c_str()) + " y de su vida inicial: " + vidainicioe + " lo dejaste con: " + enemigoActual->pokemon.vida.ToString();

			Cambio(nombreDerrotado);

			//curas toda tu vida
			jugador->pokemon.vida = vidaog;
			label5->Text = "MiVida: " + jugador->pokemon.vida.ToString();
			label11->Text =
				"Empieza el combate de nuevo";

			return;
		}
		label4->Text =
			"Atacaste con " + gcnew String(ataqueUsado.nombre.c_str()) +
			" a " + gcnew String(enemigoActual->pokemon.nombre.c_str()) + " y de su vida inicial: " + vidainicioe + " lo dejaste con: " + enemigoActual->pokemon.vida.ToString();

		label2->Text =
			"EnemigoVida: " + enemigoActual->pokemon.vida.ToString();

		EnemigoTurno(numentrenador);
	}

private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
	//label4 info combate, label 2 es vida
	//envia el numero de ataque
	Atacar(0);
}
	   //los demas hacen lo mismo con otro ataque
private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {

	Atacar(1);
}
private: System::Void button3_Click(System::Object^ sender, System::EventArgs^ e) {

	Atacar(2);
}
private: System::Void button4_Click(System::Object^ sender, System::EventArgs^ e) {

	Atacar(3);
}
};
}
