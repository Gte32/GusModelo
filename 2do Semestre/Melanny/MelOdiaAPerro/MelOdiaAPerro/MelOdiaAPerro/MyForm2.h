#pragma once
#include "MyForm3.h"  
#include "GameLogic.h"


namespace MelOdiaAPerro {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::IO;

	/// <summary>
	/// Resumen de MyForm2
	/// </summary>
	public ref class MyForm2 : public System::Windows::Forms::Form
	{
	public:
		MyForm2(void)

		{
			InitializeComponent();
			srand(time(0));
			this->Load += gcnew System::EventHandler(this, &MyForm2::MyForm2_Load);
			//
			//TODO: agregar código de constructor aquí
			//
		}

	protected:
		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		~MyForm2()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ button1;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Button^ button3;
	protected:

	private:
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		System::ComponentModel::Container ^components;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label5;
		   int reintentos = 0;
		   Pokemon* miPokemon = nullptr;
		   Pokemon* enemigo1 = nullptr;
		   Pokemon* enemigo2 = nullptr;


	private: System::Windows::Forms::PictureBox^ pictureBox3;
	private: System::Windows::Forms::PictureBox^ pictureBox4;
	private: System::Windows::Forms::PictureBox^ pictureBox5;
	private: System::Windows::Forms::PictureBox^ pictureBox6;
		   Pokemon* enemigo3 = nullptr;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->pictureBox3 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox4 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox5 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox6 = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox5))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox6))->BeginInit();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(119, 53);
			this->button1->Margin = System::Windows::Forms::Padding(4);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(100, 28);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Confirmar";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm2::button1_Click);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(711, 53);
			this->button2->Margin = System::Windows::Forms::Padding(4);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(100, 28);
			this->button2->TabIndex = 1;
			this->button2->Text = L"Reiniciar";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm2::button2_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(374, 99);
			this->label1->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(71, 16);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Reintentos";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(137, 325);
			this->label2->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(62, 16);
			this->label2->TabIndex = 3;
			this->label2->Text = L"Datos Tu";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(562, 266);
			this->label3->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(76, 16);
			this->label3->TabIndex = 4;
			this->label3->Text = L"Datos Ellos";
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(803, 494);
			this->button3->Margin = System::Windows::Forms::Padding(4);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(100, 28);
			this->button3->TabIndex = 5;
			this->button3->Text = L"Salir";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm2::button3_Click);
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(783, 266);
			this->label4->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(76, 16);
			this->label4->TabIndex = 6;
			this->label4->Text = L"Datos Ellos";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(672, 420);
			this->label5->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(76, 16);
			this->label5->TabIndex = 7;
			this->label5->Text = L"Datos Ellos";
			// 
			// pictureBox3
			// 
			this->pictureBox3->Location = System::Drawing::Point(154, 192);
			this->pictureBox3->Name = L"pictureBox3";
			this->pictureBox3->Size = System::Drawing::Size(119, 90);
			this->pictureBox3->TabIndex = 10;
			this->pictureBox3->TabStop = false;
			// 
			// pictureBox4
			// 
			this->pictureBox4->Location = System::Drawing::Point(582, 136);
			this->pictureBox4->Name = L"pictureBox4";
			this->pictureBox4->Size = System::Drawing::Size(119, 90);
			this->pictureBox4->TabIndex = 11;
			this->pictureBox4->TabStop = false;
			// 
			// pictureBox5
			// 
			this->pictureBox5->Location = System::Drawing::Point(784, 136);
			this->pictureBox5->Name = L"pictureBox5";
			this->pictureBox5->Size = System::Drawing::Size(119, 90);
			this->pictureBox5->TabIndex = 12;
			this->pictureBox5->TabStop = false;
			// 
			// pictureBox6
			// 
			this->pictureBox6->Location = System::Drawing::Point(675, 312);
			this->pictureBox6->Name = L"pictureBox6";
			this->pictureBox6->Size = System::Drawing::Size(119, 90);
			this->pictureBox6->TabIndex = 13;
			this->pictureBox6->TabStop = false;
			// 
			// MyForm2
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(931, 537);
			this->Controls->Add(this->pictureBox6);
			this->Controls->Add(this->pictureBox5);
			this->Controls->Add(this->pictureBox4);
			this->Controls->Add(this->pictureBox3);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Margin = System::Windows::Forms::Padding(4);
			this->Name = L"MyForm2";
			this->Text = L"MyForm2";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox5))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox6))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
	

	MyForm3^ f3 = gcnew MyForm3(miPokemon, enemigo1, enemigo2, enemigo3);
	f3->Show();
	this->Hide();
	
	}
private: System::Void button3_Click(System::Object^ sender, System::EventArgs^ e) {
	Application::Exit();
}

private: System::Void MyForm2_Load(System::Object^ sender, System::EventArgs^ e) {
	//lee el json, saca sus datos parseandolo
	std::ifstream archivo("Datos.json");
	json data = json::parse(archivo);
	//creas nuevos pokemones para cadda entrenador
	miPokemon = new Pokemon(CrearPokemon(data));
	enemigo1 = new Pokemon(CrearPokemon(data));
	enemigo2 = new Pokemon(CrearPokemon(data));
	enemigo3 = new Pokemon(CrearPokemon(data));
	
	label1->Text = "Tus reintentos son: " + (3 - reintentos).ToString();

	label2->Text = "Tu nombre es: " + gcnew String(miPokemon->nombre.c_str())
		+ "\nTu vida es: " + miPokemon->vida.ToString()
		+ "\nTu tipo es: " + gcnew String(miPokemon->tipo.c_str());

	label3->Text = "Enemigo: " + gcnew String(enemigo1->nombre.c_str())
		+ "\nVida: " + enemigo1->vida.ToString()
		+ "\nTipo: " + gcnew String(enemigo1->tipo.c_str());

	label4->Text = "Enemigo: " + gcnew String(enemigo2->nombre.c_str())
		+ "\nVida: " + enemigo2->vida.ToString()
		+ "\nTipo: " + gcnew String(enemigo2->tipo.c_str());

	label5->Text = "Enemigo: " + gcnew String(enemigo3->nombre.c_str())
		+ "\nVida: " + enemigo3->vida.ToString()
		+ "\nTipo: " + gcnew String(enemigo3->tipo.c_str());



	System::String^ rutaBase = "imagenes/red-blue/";
	System::String^ extension = ".png";

	// Jugador (pictureBox3)

		System::String^ ruta1 = rutaBase + gcnew String(miPokemon->numero.c_str()) + extension;
		if (System::IO::File::Exists(ruta1)) {
			pictureBox3->Image = System::Drawing::Image::FromFile(ruta1);
			pictureBox3->SizeMode = PictureBoxSizeMode::StretchImage;
		}


	// Enemigo 1 (pictureBox4)

		System::String^ ruta2 = rutaBase + gcnew String(enemigo1->numero.c_str()) + extension;
		if (System::IO::File::Exists(ruta2)) {
			pictureBox4->Image = System::Drawing::Image::FromFile(ruta2);
			pictureBox4->SizeMode = PictureBoxSizeMode::StretchImage;
		}

	// Enemigo 2 (pictureBox5)
	
		System::String^ ruta3 = rutaBase + gcnew String(enemigo2->numero.c_str()) + extension;
		if (System::IO::File::Exists(ruta3)) {
			pictureBox5->Image = System::Drawing::Image::FromFile(ruta3);
			pictureBox5->SizeMode = PictureBoxSizeMode::StretchImage;
		}


	// Enemigo 3 (pictureBox6)

		System::String^ ruta4 = rutaBase + gcnew String(enemigo3->numero.c_str()) + extension;
		if (System::IO::File::Exists(ruta4)) {
			pictureBox6->Image = System::Drawing::Image::FromFile(ruta4);
			pictureBox6->SizeMode = PictureBoxSizeMode::StretchImage;
		}

}



private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {

	//saca el json de nuevo, leelo y parsealo

	std::ifstream archivo("Datos.json");
	json data = json::parse(archivo);

	// si tienes reintentos vuelve a crear un pokemony actualiza
	if (reintentos < 3) {
		reintentos = reintentos + 1;

		delete miPokemon;


		miPokemon = new Pokemon(CrearPokemon(data));


		label1->Text = "Tus reintentos son: " + (3 - reintentos).ToString();

		label2->Text = "Tu nombre es: " + gcnew String(miPokemon->nombre.c_str())
			+ "\nTu vida es: " + miPokemon->vida.ToString()
			+ "\nTu tipo es: " + gcnew String(miPokemon->tipo.c_str());


		System::String^ rutaBase = "imagenes/red-blue/";
		System::String^ extension = ".png";


		try {
			System::String^ ruta = rutaBase + gcnew String(miPokemon->numero.c_str()) + extension;
			if (System::IO::File::Exists(ruta)) {
				pictureBox3->Image = System::Drawing::Image::FromFile(ruta);
				pictureBox3->SizeMode = PictureBoxSizeMode::StretchImage;
			}
			else {
				MessageBox::Show("No se encontró: " + ruta);
			}
		}
		catch (Exception^ ex) {
			MessageBox::Show("Error: " + ex->Message);
		}
	}
	else
	{
		label1->Text = "Ya no hay reintentos";
	}
}
};





}
