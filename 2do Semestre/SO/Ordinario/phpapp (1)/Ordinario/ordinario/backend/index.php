<?php
// backend/index.php
// Punto de entrada de la API

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

include_once 'config/database.php';
include_once 'models/Character.php';

// Instanciar base de datos y objeto personaje
$database = new Database();
$db = $database->getConnection();

if (!$db) {
    http_response_code(500);
    echo json_encode(array("message" => "Error: No se pudo establecer conexión con la base de datos."));
    exit;
}

$character = new Character($db);

// Leer personajes
$result = $character->read();

if ($result) {
    if ($result->num_rows > 0) {
        $characters_arr = array();
        $characters_arr["records"] = array();

        while ($row = $result->fetch_assoc()) {
            extract($row);
            $character_item = array(
                "id" => $id,
                "name" => $name,
                "caracteristica_1" => $caracteristica_1,
                "caracteristica_2" => $caracteristica_2
            );
            array_push($characters_arr["records"], $character_item);
        }

        http_response_code(200);
        echo json_encode($characters_arr);
    } else {
        http_response_code(200); // Cambiado a 200 para que el frontend pueda procesar el mensaje si se desea
        echo json_encode(array("records" => [], "message" => "La tabla está vacía."));
    }
} else {
    http_response_code(500);
    echo json_encode(array("message" => "Error al ejecutar la consulta: " . $db->error));
}

if ($db) $db->close();
?>
