<?php
include "dbConection.php";

if (!isset($_POST['UserName']) || !isset($_POST['Pass'])) {
    http_response_code(400);
    echo json_encode(array('done' => false, 'message' => 'Faltan datos'));
    exit();
}

$UserName = $_POST['UserName'];
$Pass     = hash("sha256", $_POST['Pass']);

// Consulta preparada para evitar inyección SQL
$sql = "SELECT UserName FROM usuarios WHERE UserName = ? AND Password = ?";
$stmt = $pdo->prepare($sql);
$stmt->execute([$UserName, $Pass]);

if ($stmt->rowCount() > 0) {
    header('Content-Type: application/json');
    echo json_encode(array('done' => true, 'message' => "Bienvenido $UserName"));
    exit();
} else {
    header('Content-Type: application/json');
    echo json_encode(array('done' => false, 'message' => "Usuario o contraseña incorrectos"));
    exit();
}
