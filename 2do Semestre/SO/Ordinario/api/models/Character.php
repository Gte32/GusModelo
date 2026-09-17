<?php
class Character {
    private $conn;
    private $table_name = 'characters';
    public $id;
    public $name;
    public $category;
    public $description;

    public function __construct($db) {
        $this->conn = $db;
    }

    public function read() {
        $query = 'SELECT id, name, category, description FROM ' . $this->table_name . ' ORDER BY id ASC';
        return $this->conn->query($query);
    }
}
?> 
