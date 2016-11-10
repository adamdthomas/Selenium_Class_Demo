using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.pages
{
    public class VehiclePage
    {

        WebDriverWait wait;
        IWebDriver driver;

        public enum FinanceType
        {
            Owned,
            Financed,
            Leased
        }

        public enum Use
        {
            Commute,
            Pleasure,
            Business
        }

        public VehiclePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            this.driver = driver;
        }

        [FindsBy(How = How.Id, Using = "vehicleYear")] public IWebElement yearDrpDwn { get; set; }
        [FindsBy(How = How.Id, Using = "vehicleMake")] public IWebElement makeDrpDwn { get; set; }
        [FindsBy(How = How.Id, Using = "vehicleModel")] public IWebElement modelDrpDwn { get; set; }
        [FindsBy(How = How.Id, Using = "bodyStyles")] public IWebElement bodyDrpDwn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='vehicleForm']/div[1]/div[16]/div[2]/div/div/div/label[1]")] public IWebElement owned { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='vehicleForm']/div[1]/div[16]/div[2]/div/div/div/label[2]")] public IWebElement financed { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='vehicleForm']/div[1]/div[16]/div[2]/div/div/div/label[3]")] public IWebElement Leased { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='vehicleForm']/div[1]/div[17]/div[1]/div[2]/div/div/div/label[1]")] public IWebElement Commute { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='vehicleForm']/div[1]/div[17]/div[1]/div[2]/div/div/div/label[2]")] public IWebElement Pleasure { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='vehicleForm']/div[1]/div[17]/div[1]/div[2]/div/div/div/label[3]")] public IWebElement Business { get; set; }
        [FindsBy(How = How.Id, Using = "btnSubmit")] public IWebElement Submit { get; set; }

        public void FillOutForm(string Year, string Make, string Model, string BodyType, FinanceType FinanceType, Use Use)
        {
            SelectElement sltYear = new SelectElement(yearDrpDwn);
            sltYear.SelectByText("2007");
            System.Threading.Thread.Sleep(1500);

            SelectElement sltMake = new SelectElement(makeDrpDwn);
            sltMake.SelectByText("Honda");
            System.Threading.Thread.Sleep(1500);

            SelectElement sltModel = new SelectElement(modelDrpDwn);
            sltModel.SelectByText("Accord");
            System.Threading.Thread.Sleep(1500);

            SelectElement sltBody = new SelectElement(bodyDrpDwn);
            sltBody.SelectByText("Sedan 4 Door");
            System.Threading.Thread.Sleep(1500);


            switch (FinanceType)
            {
                case FinanceType.Owned:
                    owned.Click();
                    break;
                case FinanceType.Financed:
                    financed.Click();
                    break;
                case FinanceType.Leased:
                    Leased.Click();
                    break;
                default:
                    break;
            }

            switch (Use)
            {
                case Use.Commute:
                    Commute.Click();
                    break;
                case Use.Pleasure:
                    Pleasure.Click();
                    break;
                case Use.Business:
                    Business.Click();
                    break;
                default:
                    break;
            }


            Submit.Click();

            


            //IWebElement radioBtnOwnership = this.RbOwned;
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("arguments[0].click();", radioBtnOwnership);



        }

    }


}
