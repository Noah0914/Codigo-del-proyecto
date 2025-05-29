<?php

$host = "localhost";
$dbname = "dimensionstem";
$user = "Noah";
$pass = "DayanaSofia123";

try {
    $pdo = new PDO("mysql:host=$host;dbname=$dbname;charset=utf8", $user, $pass);
} catch (PDOException $e) {
    die("Error en la conexión: " . $e->getMessage());
    exit();
}

?>