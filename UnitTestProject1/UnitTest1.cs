using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.pages;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;
        WebDriverWait wait;
        CustomerPage customer;
        VehiclePage vehicle;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
             //Setup once per fixture
        }

        [SetUp]
        public void Setup()
        {
            //Runs once before every test
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://auto-buy-gz-user1.geico.com/");

            try
            {
                IWebElement overrideLink = driver.FindElement(By.Id("overridelink"));
                overrideLink.Click();
            }
            catch (Exception) { }

            customer = new CustomerPage(driver);
            vehicle = new VehiclePage(driver);
        }

        //[Test]
        public void MyFirstTest()
        {
            
            //IWebElement overrideLink = driver.FindElement(By.Id("overridelink"));
            //overrideLink.Click();

            //IWebElement firstName = driver.FindElement(By.Id("firstName"));
            //IWebElement lastName = driver.FindElement(By.Id("lastName"));
            //IWebElement address = driver.FindElement(By.Id("street"));
            //IWebElement zipCode = driver.FindElement(By.Id("zip"));
            //IWebElement month = driver.FindElement(By.Id("date-monthdob"));
            //IWebElement day = driver.FindElement(By.Id("date-daydob"));
            //IWebElement year = driver.FindElement(By.Id("date-yeardob"));
            //IWebElement effectiveDate = driver.FindElement(By.Id("effectiveDate"));
            //IWebElement next = driver.FindElement(By.Id("btnSubmit"));
            
            //overridelink

            //System.Threading.Thread.Sleep(10000);
            //string SearchTerm = "GEICO";

            //IWebElement googleSearchBar = driver.FindElement(By.Name("q"));
            //googleSearchBar.SendKeys(SearchTerm);

            //IWebElement googleSearchButton = driver.FindElement(By.Name("btnG"));
            //googleSearchButton.Click();

            ////System.Threading.Thread.Sleep(1000);

            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.PartialLinkText(SearchTerm)));

            //var resultLinks = driver.FindElements(By.PartialLinkText(SearchTerm));

            //string FirstLink = resultLinks[0].Text;


            //Assert.IsTrue(FirstLink.Contains(SearchTerm));




        }

        //[Test]
        //[TestCase("Adam", "Thomas", "7025 Albert Pick Rd", "27409", "01", "02", "1980")]
        //[TestCase("John", "Johnson", "7025 Albert Pick Rd", "27410", "01", "02", "1979")]
        //[TestCase("Gary", "Frankfurtinstien", "7025 Albert Pick Rd", "27409", "01", "02", "1940")]
        //[TestCase("Perry", "Trump", "7025 Albert Pick Rd", "27411", "01", "02", "1930")]
        //[TestCase("Brook", "Clinton", "7025 Albert Pick Rd", "27409", "01", "02", "1920")]

        public void TestCustomerForm(string FirstName, string LastName, string Address, string ZipCode, string DOBMonth, string DOBDay, string DOBYear)
        {

           // bool didItWork = customer.FillOutForm("Adam", "Thomas", "7025 Albert Pick Rd", "27407", "01", "02","1980");

            bool didItWork = customer.FillOutForm(FirstName, LastName, Address, ZipCode, DOBMonth, DOBDay, DOBYear);

            Assert.IsTrue(didItWork);

        }



        [Test]
        public void TestVehicleForm()
        {


            customer.FillOutForm();
           bool DidItWork = vehicle.FillOutForm("2007", "Honda", "Accord", "Sedan 4 Door", VehiclePage.FinanceType.Owned, VehiclePage.Use.Commute);
            Assert.IsTrue(DidItWork);

        }


        [TearDown]
        public void Teardown()
        {
            //run something once after each test
         //  driver.Quit();
        }



        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            //run at the end of the test fixture
        }


    }
}
