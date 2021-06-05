<?php
$servername = "localhost";
$username = "id14855263_malbasic";
$password = "KristijanMalbasic.1";
$dbname = "id14855263_git_applies";

//if(isset($_POST[""]))
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

//$pls1 = $_POST["emailerino"];
//$pls2 = $_POST["githuberino"];

$sql = "INSERT INTO GitApplicants (Email, GitHub, Age)
VALUES ('{$_POST["emailerino"]}', '{$_POST["githuberino"]}', 'john@example.com')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "
" . $conn->error;
}

$conn->close();
?>


