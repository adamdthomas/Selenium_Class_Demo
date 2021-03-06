﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.utilities;

namespace UnitTestProject1.pages
{
    public class VehiclePage
    {

        WebDriverWait wait;
        IWebDriver driver;
        public List<string> dayStrings;


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
        [FindsBy(How = How.Name, Using = "daysDriven")] public IWebElement daysDriven { get; set; }
        [FindsBy(How = How.Id, Using = "milesDriven")] public IWebElement milesDriven { get; set; }
        [FindsBy(How = How.Id, Using = "typeOfBusinessUse")] public IWebElement typeOfBusiness { get; set; }
        [FindsBy(How = How.Id, Using = "annualMileage")] public IWebElement annualMileage { get; set; }



        public bool FillOutForm(string Year, string Make, string Model, string BodyType, FinanceType FinanceType, Use Use)
        {
            dayStrings = new List<string>();
            bool driverInfoPageExist;

            SelectElement sltYear = driver.FindSelectElementWhenPopulated(By.Id("vehicleYear"), 30);
            sltYear.SelectByText(Year);

            SelectElement sltMake = driver.FindSelectElementWhenPopulated(By.Id("vehicleMake"), 30);
            sltMake.SelectByText(Make);

            SelectElement sltModel = driver.FindSelectElementWhenPopulated(By.Id("vehicleModel"), 30);
            sltModel.SelectByText(Model);

            try
            {
                SelectElement sltBody = driver.FindSelectElementWhenPopulated(By.Id("bodyStyles"), 30);
                sltBody.SelectByText(BodyType);
            }
            catch (Exception) {}


            System.Threading.Thread.Sleep(500);


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

            SelectElement annualMileageSlt;
            SelectElement daysDrivenSlt;
            SelectElement businessUseSlt;


            switch (Use)
            {
                case Use.Commute:
                    Commute.Click();
                    //System.Threading.Thread.Sleep(3000);

                    daysDrivenSlt = driver.FindSelectElementWhenPopulated(By.Id("daysDriven"), 30);
                    IList<IWebElement> days; days = daysDrivenSlt.Options;
                    foreach (var day in days)
                    {
                        dayStrings.Add(day.GetAttribute("value").ToString());
                    }

 

                    daysDrivenSlt.SelectByValue("5");
                    milesDriven.SendKeys("15");

                    annualMileageSlt = driver.FindSelectElementWhenPopulated(By.Id("annualMileage"), 30);
                    annualMileageSlt.SelectByText("12,001 - 15,000");

                    
                    
                    break;
                case Use.Pleasure:
                    Pleasure.Click();


                    annualMileageSlt = driver.FindSelectElementWhenPopulated(By.Id("annualMileage"), 30);

                    IList<IWebElement> miles = annualMileageSlt.Options;
                    annualMileageSlt.SelectByText("12,001 - 15,000");
                    break;
                case Use.Business:
                    Business.Click();

                    businessUseSlt = driver.FindSelectElementWhenPopulated(By.Id("typeOfBusinessUse"), 30);
                    businessUseSlt.SelectByText("Clergy");
                    annualMileageSlt = driver.FindSelectElementWhenPopulated(By.Id("annualMileage"), 30);
                    annualMileageSlt.SelectByText("12,001 - 15,000");
                    break;
                default:
                    break;
            }


            Submit.Click();


            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.Id("maritalStatus")));
                driverInfoPageExist = true;
            }
            catch (Exception e)
            {
                driverInfoPageExist = false;
            }

            //IWebElement radioBtnOwnership = this.RbOwned;
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("arguments[0].click();", radioBtnOwnership);

            return driverInfoPageExist;

        }

    }


}
