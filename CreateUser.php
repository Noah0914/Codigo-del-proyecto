<?php
include "dbConection.php";

if (!isset($_POST['UserName']) || !isset($_POST['Email']) || !isset($_POST['Pass'])) {
    http_response_code(400);
    echo json_encode(array('done' => false, 'message' => 'Faltan datos'));
    exit();
}

$UserName = $_POST['UserName'];
$Email    = $_POST['Email'];
$Pass     = hash("sha256", $_POST['Pass']);

$sql = "SELECT UserName FROM usuarios WHERE UserName = ?";
$stmt = $pdo->prepare($sql);
$stmt->execute([$UserName]);

if ($stmt->rowCount() > 0) {
    header('Content-Type: application/json');
    echo json_encode(array('done' => false, 'message' => "Nombre de usuario existente"));
    exit();
}

$sql = "SELECT Email FROM usuarios WHERE Email = ?";
$stmt = $pdo->prepare($sql);
$stmt->execute([$Email]);

if ($stmt->rowCount() > 0) {
    header('Content-Type: application/json');
    echo json_encode(array('done' => false, 'message' => "Email existente"));
    exit();
}

$sql = "INSERT INTO usuarios (UserName, Email, Password) VALUES (?, ?, ?)";
$stmt = $pdo->prepare($sql);
$stmt->execute([$UserName, $Email, $Pass]);

header('Content-Type: application/json');
echo json_encode(array('done' => true, 'message' => "Usuario creado exitosamente"));
exit();
