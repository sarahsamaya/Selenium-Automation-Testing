<!DOCTYPE HTML>
<html lang="en">
    <head>
        <!--New.html-->
        <title>Search Results</title>
        <meta charset="UTF-8"/>
        <link rel="stylesheet" type="text/css" href="style.css">
        <script src="javaScript.js"></script>   
    </head>
    <body>
        <div class="main4">
        <div class="design">
           
         <button type="button"><a href="Home.html">Home</a></button><br><br>    
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
                        while ($row = $result->fetch_assoc()) {
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
                    
                    function CreateLink($make,$model,$year){
                        $make = str_replace(' ', '-', $make);
                        $model = str_replace(' ', '-', $model);
                        echo "<a href='https://www.jdpower.com/Cars/".$year."/".$make."/".$model."'>
                        https://www.jdpower.com/Cars/".$year."/".$make."/".$model."</a>";
                    }
                    
                ?>
            </div>
            
        </div>
        
        </body>
    