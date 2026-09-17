<?php
// ordinario/api/index.php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

include_once 'config/database.php';
include_once 'models/Character.php';

$database = new Database();
$db = $database->getConnection();
$character = new Character($db);
$result = $character->read();

if ($result && $result->num_rows > 0) {
    $characters_arr = array("records" => array());
    while ($row = $result->fetch_assoc()) {
        array_push($characters_arr["records"], $row);
    }
    echo json_encode($characters_arr);
} else {
    echo json_encode(array("message" => "No characters found."));
}
?>
