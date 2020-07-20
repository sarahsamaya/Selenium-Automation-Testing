

<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "car";

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);
// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}

$sql = "INSERT INTO cardetails (SellerName, Address, City, Phone, Email, VehicleMake, Model, Year)
VALUES ('$_POST[firstname]', '$_POST[address]', '$_POST[city]', '$_POST[number]', '$_POST[email]', '$_POST[Vehiclemake]','$_POST[Model]','$_POST[Year]')";



if (mysqli_query($conn, $sql)) {
    echo "New record created successfully";
    header('location:Display.php');
} else {
    echo "Error: " . $sql . "<br>" . mysqli_error($conn);
}


mysqli_close($conn);
?>