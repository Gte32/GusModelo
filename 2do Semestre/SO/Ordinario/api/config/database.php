<?php
class Database {
    private $host = 'db';
    private $db_name = 'db_personajes';
    private $username = 'db_user';
    private $password = 'db_pass';
    public $conn;

    public function getConnection() {
        $this->conn = null;
        try {
            $this->conn = new mysqli($this->host, $this->username, $this->password, $this->db_name);
        } catch (Exception $e) {
            error_log($e->getMessage());
        }
        return $this->conn;
    }
}
?> 
