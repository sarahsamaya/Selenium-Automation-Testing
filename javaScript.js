function validationform()
{
    var fname = document.forms["myForm"]["firstname"].value;
    if(fname=="")
        {
            document.getElementById("message").innerHTML="Enter the name";
            return false;
        }
    
    var reg=/[a-zA-Z]/;
    var result=reg.test(fname);
    if(result==false)
        {
            document.getElementById("message").innerHTML="Invalid name";
            return false;
        }
    
    
   var city = document.forms["myForm"]["city"].value;
    if(city=="")
        {
            document.getElementById("message").innerHTML="Enter the city";
            return false;
        }
    var reg2=/[a-zA-Z]/;
    var result2=reg2.test(email);
    if(result2==false)
        {
            document.getElementById("message").innerHTML="Invalid city";
            return false;
        }
    
    var number = document.forms["myForm"]["number"].value;
    if(number=="")
        {
            document.getElementById("message").innerHTML="Enter the number";
            return false;
        }
    
    //var reg3=/(?:\d{3}|\(\d{3}\))([-\/\.])\d{3}\1\d{4}/ ;
    //var reg3=/(?:\d{3}|\(\d{3}\))([-])\d{3}\1\d{4}/ ;
    var reg3=/((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$/ ;
    var result3=reg3.test(number);
    if(result3==false)
        {
            document.getElementById("message").innerHTML="Invalid number";
            return false;
        } 
    
    var email = document.forms["myForm"]["email"].value;
    if(email=="")
        {
            document.getElementById("message").innerHTML="Enter the email";
            return false;
        }
    var reg1=/[a-zA-Z0-9]@[a-zA-Z0-9].[a-zA-Z0-9]/;
    var result1=reg1.test(email);
    if(result1==false)
        {
            document.getElementById("message").innerHTML="Invalid email";
            return false;
        }
    
    var Vehiclemake = document.forms["myForm"]["Vehiclemake"].value;
    if(Vehiclemake=="")   
        {
            document.getElementById("message").innerHTML="Enter the Vehiclemake";
            return false;
        }
    //var reg4=/(?:[0-9]+ ){1}(?:[A-Za-z]+ ){1}[A-Za-z]+/;
    var reg4=/^\w+\s*\w+?$/;
    var result4=reg4.test(Vehiclemake);
    if(result4==false)
        {
            document.getElementById("message").innerHTML="Invalid Vehicle make";
            return false;
        }
    
    var Model = document.forms["myForm"]["Model"].value;
    if(Model=="")   
        {
            document.getElementById("message").innerHTML="Enter the Model";
            return false;
        }
    //var reg4=/(?:[0-9]+ ){1}(?:[A-Za-z]+ ){1}[A-Za-z]+/;
    var reg5=/^\w+\s*\w+?$/;
    var result5=reg5.test(Model);
    if(result5==false)
        {
            document.getElementById("message").innerHTML="Invalid Model";
            return false;
        }
    
    var Year = document.forms["myForm"]["Year"].value;
    if(Year=="")   
        {
            document.getElementById("message").innerHTML="Enter the Year";
            return false;
        }
    //var reg4=/(?:[0-9]+ ){1}(?:[A-Za-z]+ ){1}[A-Za-z]+/;
    var reg6=/^\d{4}$/;
    var result6=reg6.test(Year);
    if(result6==false)
        {
            document.getElementById("message").innerHTML="Invalid Year";
            return false;
        }
    
   
    var address = document.forms["myForm"]["address"].value;
    if(address=="")
        {
            document.getElementById("message").innerHTML="Enter the address";
            return false;
        }
        
    
}
