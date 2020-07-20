<!DOCTYPE HTML>
<html lang="en">
    <head>
        <!--New.html-->
        <title>Display.php</title>
        <meta charset="UTF-8"/>
        <link rel="stylesheet" type="text/css" href="style.css">
        <script src="javaScript.js"></script>   
    </head>
    <body>
        <div class="background3">
            <div class="main3">
                <div id="sec1">
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

                    $sql = "select * from cardetails ORDER BY SellerNumber DESC";

                    $result = $conn->query($sql);

                    if($result->num_rows>0)
                    {
                        if ($row = $result->fetch_assoc()) {
                            echo "<table id='table2'>
                                    <tr>
                                        <td>"." Seller Name : " ."</td>
                                        <td>". $row["SellerName"]. "</td>
                                    </tr>". 
                                    "<tr>
                                        <td>"." Address : "."</td>
                                        <td>" . $row["Address"]. "</td>
                                    </tr>".
                                    "<tr>
                                        <td>"."City : " ."</td>
                                        <td>". $row["City"]. "</td>
                                    </tr>".
                                    "<tr>
                                        <td>"."Phone : " ."</td>
                                        <td>". $row["Phone"]. "</td>
                                    </tr>". 
                                    "<tr>
                                        <td>"."Email : " ."</td>
                                        <td>". $row["Email"]. "</td>
                                    </tr>".
                                    "<tr>
                                        <td>"."Vehicle Make : "."</td>
                                        <td>" . $row["VehicleMake"]."</td>
                                    </tr>".
                                    "<tr>
                                        <td>"."Model : "."</td>
                                        <td>" . $row["Model"]."</td>
                                    </tr>".
                                    "<tr>
                                        <td>"."Year : "."</td>
                                        <td>" . $row["Year"]."</td>
                                    </tr>";
                                    "<tr>
                                        <td>"."Link : "."</td>
                                        <td>" . CreateLink($row["VehicleMake"],$row["Model"],$row["Year"])."</td>
                                        
                                    </tr>";
                        }

                    }

                    else {
                        echo "0 results";
                    }
                    $conn->close();
                    echo "</div>";
                    echo "<div class='sec2'>";
                    function CreateLink($make,$model,$year){
                        $make = str_replace(' ', '-', $make);
                        $model = str_replace(' ', '-', $model);
                        echo "<a href='https://www.jdpower.com/Cars/".$year."/".$make."/".$model."'>
                        https://www.jdpower.com/Cars/".$year."/".$make."/".$model."</a>";
                    }
                    echo "</div>";
                ?>
                </div>
                
            <button type="button"><a href="Home.html">Home</a></button> 
                 
            </div>
        </div>
    </body>