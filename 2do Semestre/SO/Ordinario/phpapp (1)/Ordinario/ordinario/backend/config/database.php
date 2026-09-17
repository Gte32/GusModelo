<?php
// backend/config/database.php
// Configuración de la base de datos

class Database {
    private $host = 'db'; // Nombre del servicio en docker-compose
    private $db_name = 'app_db';
    private $username = 'db_user';
    private $password = 'db_pass';
    public $conn;

    // Obtener la conexión a la base de datos
    public function getConnection() {
        $this->conn = null;

        try {
            $this->conn = new mysqli($this->host, $this->username, $this->password, $this->db_name);
            if ($this->conn->connect_error) {
                return null;
            }
            $this->conn->set_charset("utf8mb4");
        } catch (Exception $e) {
            error_log($e->getMessage());
        }

        return $this->conn;
    }
}
?>
