using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;



namespace Seng8040a4_Test
{
    [TestFixture]
    public class MainTest
    {
            private IWebDriver driver;
            public IDictionary<string, object> vars { get; private set; }
            private IJavaScriptExecutor js;

            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                js = (IJavaScriptExecutor)driver;
                vars = new Dictionary<string, object>();
            }

            [TearDown]
            protected void TearDown()
            {
                driver.Quit();
            }

            [Test, Order(1)]
            public void NewCarForm_InputEmptyFields_ExpectedFormNotSavedAndItStaysOnSamePage()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Patty");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();
                driver.FindElement(By.CssSelector(".main2")).Click();

                Assert.That(driver.FindElement(By.CssSelector(".H1")).Text, Is.EqualTo("New Car Form"));
            }

            [Test, Order(2)]
            public void NewCarForm_InputInvalidEmail_ExpectedMessageInvalidEmail()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Mary Castro");
                driver.FindElement(By.Name("address")).SendKeys("10 Adelaide St W");
                driver.FindElement(By.Name("city")).SendKeys("Toronto");
                driver.FindElement(By.Name("number")).SendKeys("(647)765-4334");
                driver.FindElement(By.Name("email")).SendKeys("martgmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Jaguar");
                driver.FindElement(By.Name("Model")).SendKeys("XJ Series");
                driver.FindElement(By.Name("Year")).SendKeys("2009");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.Id("message")).Text, Is.EqualTo("Invalid email"));
            }

            [Test, Order(3)]
            public void NewCarForm_InputInvalidModel_ExpectedMessageInvalidModel()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Marcos");
                driver.FindElement(By.Name("address")).SendKeys("80 Pearl St");
                driver.FindElement(By.Name("city")).SendKeys("Toronto");
                driver.FindElement(By.Name("number")).SendKeys("(647)876-7878");
                driver.FindElement(By.Name("email")).SendKeys("marcos@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Lamborghini");
                driver.FindElement(By.Name("Model")).SendKeys("Hurac@a#");
                driver.FindElement(By.Name("Year")).SendKeys("2017");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.Id("message")).Text, Is.EqualTo("Invalid Model"));
            }

            [Test, Order(4)]
            public void NewCarForm_InputInvalidName_ExpectedMessageInvalidName()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("1");
                driver.FindElement(By.Name("address")).SendKeys("76 Queen St W");
                driver.FindElement(By.Name("city")).SendKeys("Toronto");
                driver.FindElement(By.Name("number")).SendKeys("(647)765-9878");
                driver.FindElement(By.Name("email")).SendKeys("monica@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Cardillac");
                driver.FindElement(By.Name("Model")).SendKeys("ATS Sedan");
                driver.FindElement(By.Name("Year")).SendKeys("2018");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.Id("message")).Text, Is.EqualTo("Invalid name"));
            }

            [Test, Order(5)]
            public void NewCarForm_InputInvalidPhoneNumber_ExpectedMessageInvalidNumber()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Henry Clarck");
                driver.FindElement(By.Name("address")).Click();
                driver.FindElement(By.Name("address")).SendKeys("67 Highland Rd W");
                driver.FindElement(By.Name("city")).SendKeys("Kitchener");
                driver.FindElement(By.Name("number")).SendKeys("76548889965");
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.Name("email")).SendKeys("henry@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Dodge");
                driver.FindElement(By.Name("Model")).SendKeys("Hourney");
                driver.FindElement(By.Name("Year")).Click();
                {
                    var element = driver.FindElement(By.Name("Year"));
                    Actions builder = new Actions(driver);
                    builder.DoubleClick(element).Perform();
                }
                driver.FindElement(By.Name("Year")).SendKeys("2019");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();
               
                Assert.That(driver.FindElement(By.Id("message")).Text, Is.EqualTo("Invalid number"));
            }

            [Test, Order(6)]
            public void NewCarForm_InputInvalidVehiclemake_ExpectedMessageInvalidVehiclemake()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Victor Serano");
                driver.FindElement(By.Name("address")).SendKeys("60 Unversity Ave");
                driver.FindElement(By.Name("city")).SendKeys("Toronto");
                driver.FindElement(By.Name("number")).SendKeys("(647)765-8767");
                driver.FindElement(By.Name("email")).SendKeys("victor@gmaill.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Ki@");
                driver.FindElement(By.Name("Model")).SendKeys("Rio 5-Door");
                driver.FindElement(By.Name("Year")).SendKeys("2019");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.Id("message")).Text, Is.EqualTo("Invalid Vehicle make"));
            }

            [Test, Order(7)]
            public void NewCarForm_InputInvalidYear_ExpectedMessageInvalidYear()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Doug Moron");
                driver.FindElement(By.Name("address")).SendKeys("76 Queen St W");
                driver.FindElement(By.Name("city")).SendKeys("Toronto");
                driver.FindElement(By.Name("number")).SendKeys("(647)765-9878");
                driver.FindElement(By.Name("email")).SendKeys("monica@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Cardillac");
                driver.FindElement(By.Name("Model")).SendKeys("ATS Sedan");
                driver.FindElement(By.Name("Year")).SendKeys("33");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.Id("message")).Text, Is.EqualTo("Invalid Year"));
            }

            [Test, Order(8)]
            public void NewCarForm_InputManoelSellingBMW8Series2020_ExpectedDisplayStoredDataAndJDPowerWebsite()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector(".main")).Click();
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Manoel Inacio");
                driver.FindElement(By.Name("address")).Click();
                driver.FindElement(By.Name("address")).SendKeys("11 Overlea");
                driver.FindElement(By.Name("city")).SendKeys("Kitchener");
                driver.FindElement(By.Name("number")).SendKeys("(647)765-7667");
                driver.FindElement(By.Name("email")).SendKeys("manoeli@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("BMW");
                driver.FindElement(By.Name("Model")).SendKeys("8 Series");
                driver.FindElement(By.Name("Year")).SendKeys("2020");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(2)")).Text, Is.EqualTo("11 Overlea"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(2)")).Text, Is.EqualTo("Manoel Inacio"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(3) > td:nth-child(2)")).Text, Is.EqualTo("Kitchener"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(4) > td:nth-child(2)")).Text, Is.EqualTo("(647)765-7667"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(5) > td:nth-child(2)")).Text, Is.EqualTo("manoeli@gmail.com"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(6) > td:nth-child(2)")).Text, Is.EqualTo("BMW"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(7) > td:nth-child(2)")).Text, Is.EqualTo("8 Series"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(8) > td:nth-child(2)")).Text, Is.EqualTo("2020"));

                driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2020/BMW/8-Series")).Click();

                Assert.That(driver.FindElement(By.CssSelector(".track-ymm-year-dropdown")).Text, Is.EqualTo("2020"));
                Assert.That(driver.FindElement(By.CssSelector(".u-bold")).Text, Is.EqualTo("BMW 8 Series"));
                Assert.That(driver.FindElement(By.CssSelector(".track-ymm-trim-dropdown")).Text, Is.EqualTo("840i Gran Coupe"));
            }

            [Test, Order(9)]
            public void NewCarForm_InputPedroSellingAudiA32016_ExpectedDisplayStoredDataAndJDPowerWebsite()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Pedro Erm");
                driver.FindElement(By.Name("address")).SendKeys("10 Victoria Avenue");
                driver.FindElement(By.Name("city")).SendKeys("Kitchener");
                driver.FindElement(By.Name("number")).SendKeys("(226)765-4675");
                driver.FindElement(By.Name("email")).SendKeys("pedroe@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Audi");
                driver.FindElement(By.Name("Model")).SendKeys("A3");
                driver.FindElement(By.Name("Year")).SendKeys("2016");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(2)")).Text, Is.EqualTo("Pedro Erm"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(2)")).Text, Is.EqualTo("10 Victoria Avenue"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(3) > td:nth-child(2)")).Text, Is.EqualTo("Kitchener"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(4) > td:nth-child(2)")).Text, Is.EqualTo("(226)765-4675"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(5) > td:nth-child(2)")).Text, Is.EqualTo("pedroe@gmail.com"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(6) > td:nth-child(2)")).Text, Is.EqualTo("Audi"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(7) > td:nth-child(2)")).Text, Is.EqualTo("A3"));
                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(8) > td:nth-child(2)")).Text, Is.EqualTo("2016"));

                driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2016/Audi/A3")).Click();

                Assert.That(driver.FindElement(By.CssSelector(".track-ymm-year-dropdown")).Text, Is.EqualTo("2016"));
                Assert.That(driver.FindElement(By.CssSelector(".u-bold")).Text, Is.EqualTo("Audi A3"));
                Assert.That(driver.FindElement(By.CssSelector(".track-ymm-trim-dropdown")).Text, Is.EqualTo("4dr Sdn quattro 2.0T Premium"));
            }

            [Test, Order(10)]
            public void SearchSavedData_InputClickOnSearch_ExpectedList2ItemsAudiAndBMW()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(4) > .button1")).Click();

                Assert.That(driver.FindElement(By.XPath("//table[@id=\'table2\']/tbody/tr[6]/td[2]")).Text, Is.EqualTo("Audi"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2016/Audi/A3")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2016/Audi/A3"));
                Assert.That(driver.FindElement(By.XPath("(//table[@id=\'table2\']/tbody/tr[6]/td[2])[2]")).Text, Is.EqualTo("BMW"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2020/BMW/8-Series")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2020/BMW/8-Series"));


            }
            [Test,Order(11)]
            public void SearchSavedData_InputClickOnSearchThenAddNewCar_ExpectedList3ItemsAudiAndBMWAnd8Series()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(4) > .button1")).Click();

                Assert.That(driver.FindElement(By.XPath("//table[@id=\'table2\']/tbody/tr[6]/td[2]")).Text, Is.EqualTo("Audi"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2016/Audi/A3")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2016/Audi/A3"));
                Assert.That(driver.FindElement(By.XPath("(//table[@id=\'table2\']/tbody/tr[6]/td[2])[2]")).Text, Is.EqualTo("BMW"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2020/BMW/8-Series")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2020/BMW/8-Series"));

                driver.FindElement(By.LinkText("Home")).Click();
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Jerry Mac");
                driver.FindElement(By.Name("address")).SendKeys("99 Queen St W");
                driver.FindElement(By.Name("city")).SendKeys("Toronto");
                driver.FindElement(By.Name("number")).SendKeys("(647)768-8778");
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.Name("email")).SendKeys("jerry@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Cardillac");
                driver.FindElement(By.Name("Model")).SendKeys("ATS Sedan");
                driver.FindElement(By.Name("Year")).SendKeys("2018");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();
                driver.FindElement(By.LinkText("Home")).Click();
                driver.FindElement(By.CssSelector("a:nth-child(4) > .button1")).Click();

                Assert.That(driver.FindElement(By.XPath("//table[@id=\'table2\']/tbody/tr[7]/td[2]")).Text, Is.EqualTo("ATS Sedan"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2018/Cardillac/ATS-Sedan")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2018/Cardillac/ATS-Sedan"));
                Assert.That(driver.FindElement(By.XPath("(//table[@id=\'table2\']/tbody/tr[7]/td[2])[2]")).Text, Is.EqualTo("A3"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2016/Audi/A3")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2016/Audi/A3"));
                Assert.That(driver.FindElement(By.XPath("(//table[@id=\'table2\']/tbody/tr[7]/td[2])[3]")).Text, Is.EqualTo("8 Series"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2020/BMW/8-Series")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2020/BMW/8-Series"));
            }

            [Test, Order(12)]
            public void GoHomeButton_InputNewCarAndClickGoHome_ExpectedHomePage()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Mary");
                driver.FindElement(By.Name("address")).SendKeys("88 Victoria Street");
                driver.FindElement(By.Name("city")).SendKeys("Kitchener");
                driver.FindElement(By.Name("number")).SendKeys("(226)445-6777");
                driver.FindElement(By.Name("email")).SendKeys("mary@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Dodge");
                driver.FindElement(By.Name("Model")).SendKeys("Hourney");
                driver.FindElement(By.Name("Year")).SendKeys("2019");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();
                driver.FindElement(By.LinkText("Home")).Click();

                Assert.That(driver.FindElement(By.CssSelector("h1")).Text, Is.EqualTo("Sell your car!"));
            }

            [Test, Order(13)]
            public void GoHomeButton_InputListCarsAndClickGoHome_ExpectedHomePage()
            {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(4) > .button1")).Click();
                driver.FindElement(By.LinkText("Home")).Click();

                Assert.That(driver.FindElement(By.CssSelector("h1")).Text, Is.EqualTo("Sell your car!"));
            }

        [Test, Order(14)]
        public void NewCarFormInput_3NewCarconsecutivelyFerrariGTC4Lusso2020AndHyunda2009JaguarAndKonaXJSeries2009_ExpectedDisplayAllStoredCarDataPlus3Inputted()
        {
                driver.Navigate().GoToUrl("http://localhost/seng8040a4/Home.html");
                driver.Manage().Window.Size = new System.Drawing.Size(1050, 852);
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Lady Gaga");
                driver.FindElement(By.Name("address")).SendKeys("80, Karn St");
                driver.FindElement(By.Name("city")).SendKeys("Waterloo");
                driver.FindElement(By.Name("number")).SendKeys("(226)876-2222");
                driver.FindElement(By.Name("email")).SendKeys("lady@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Ferrari");
                driver.FindElement(By.Name("Model")).SendKeys("GTC4Lusso");
                driver.FindElement(By.Name("Year")).SendKeys("2020");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(7) > td:nth-child(2)")).Text, Is.EqualTo("GTC4Lusso"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2020/Ferrari/GTC4Lusso")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2020/Ferrari/GTC4Lusso"));
               
                driver.FindElement(By.LinkText("Home")).Click();
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("George Ezra");
                driver.FindElement(By.Name("address")).SendKeys("Beilton Dr");
                driver.FindElement(By.Name("address")).Click();
                driver.FindElement(By.Name("address")).SendKeys("90, Beilton Dr");
                driver.FindElement(By.Name("city")).SendKeys("Waterloo");
                driver.FindElement(By.Name("number")).SendKeys("(226)998-7777");
                driver.FindElement(By.Name("email")).SendKeys("gerge@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Hyundai");
                driver.FindElement(By.Name("Model")).SendKeys("Kona");
                driver.FindElement(By.Name("Year")).SendKeys("2009");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(7) > td:nth-child(2)")).Text, Is.EqualTo("Kona"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2009/Hyundai/Kona")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2009/Hyundai/Kona"));

                driver.FindElement(By.LinkText("Home")).Click();
                driver.FindElement(By.CssSelector("a:nth-child(2) > .button1")).Click();
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).SendKeys("Ed Sheeran");
                driver.FindElement(By.Name("address")).SendKeys("100, Weichel St");
                driver.FindElement(By.Name("city")).SendKeys("Waterloo");
                driver.FindElement(By.Name("number")).SendKeys("(226) 776-3333");
                driver.FindElement(By.Name("email")).SendKeys("ed@gmail.com");
                driver.FindElement(By.Name("Vehiclemake")).SendKeys("Jaguar");
                driver.FindElement(By.Name("Model")).SendKeys("XJ Series");
                driver.FindElement(By.Name("Year")).SendKeys("2009");
                driver.FindElement(By.CssSelector("tr:nth-child(9) input")).Click();

                Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(7) > td:nth-child(2)")).Text, Is.EqualTo("XJ Series"));
                Assert.That(driver.FindElement(By.LinkText("https://www.jdpower.com/Cars/2009/Jaguar/XJ-Series")).Text, Is.EqualTo("https://www.jdpower.com/Cars/2009/Jaguar/XJ-Series"));
            }
    }
    }



