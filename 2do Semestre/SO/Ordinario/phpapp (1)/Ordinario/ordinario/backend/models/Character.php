<?php
// backend/models/Character.php
// Modelo para los personajes de la aplicación

class Character {
    private $conn;
    private $table_name = "characters";

    public $id;
    public $name;
    public $caracteristica_1;
    public $caracteristica_2;

    public function __construct($db) {
        $this->conn = $db;
    }

    // Leer todos los personajes
    public function read() {
        $query = "SELECT id, name, caracteristica_1, caracteristica_2 FROM " . $this->table_name . " ORDER BY name ASC";
        $result = $this->conn->query($query);
        return $result;
    }
}
?>
