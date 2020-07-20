

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

$sql = "select * from cardetails ORDER BY Sno DESC";

$result = $conn->query($sql);

if($result->num_rows>0)
{
    if ($row = $result->fetch_assoc()) {
        echo "Sno: " . $row["Sno"]. " - Seller Name: " . $row["SellerName"]. " - Address" . $row["Address"]. "City : " . $row["City"].
        "Phone: " . $row["Phone"]. "Email: " . $row["Email"]. "Model: " . $row["Model"]."<br>";
    }
    
}

else {
    echo "0 results";
}
$conn->close();
?>