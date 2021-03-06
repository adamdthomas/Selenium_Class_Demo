﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace UnitTestProject1.pages
{
    public class CustomerPage
    {
        WebDriverWait wait;
        IWebDriver driver;

        public CustomerPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            this.driver = driver;
        }

        [FindsBy(How = How.Id, Using = "firstName")] public IWebElement firstNameEdit { get; set; }
        [FindsBy(How = How.Id, Using = "lastName")] public IWebElement lastNameEdit { get; set; }
        [FindsBy(How = How.Id, Using = "street")] public IWebElement streetAddressEdit { get; set; }
        [FindsBy(How = How.Id, Using = "zip")] public IWebElement zipCodeEdit { get; set; }
        [FindsBy(How = How.Id, Using = "date-monthdob")] public IWebElement dobMonthEdit { get; set; }
        [FindsBy(How = How.Id, Using = "date-daydob")] public IWebElement dobDayEdit { get; set; }
        [FindsBy(How = How.Id, Using = "date-yeardob")] public IWebElement dobYearEdit { get; set; }
        [FindsBy(How = How.Id, Using = "effectiveDate")] public IWebElement effectiveDateEdit { get; set; }
        [FindsBy(How = How.Id, Using = "btnSubmit")] public IWebElement nextBtn { get; set; }

        public bool FillOutForm(string FirstName, string LastName, string Address, string ZipCode, string DOBMonth, string DOBDay, string DOBYear)
        {
            bool vehiclePageExist;
            string TodaysDate = DateTime.Now.ToString("dd'/'MM'/'yyyy"); 

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));

            firstNameEdit.SendKeys(FirstName);
            lastNameEdit.SendKeys(LastName);
            streetAddressEdit.SendKeys(Address);
            zipCodeEdit.SendKeys(ZipCode);
            dobMonthEdit.SendKeys(DOBMonth);
            dobDayEdit.SendKeys(DOBDay);
            dobYearEdit.SendKeys(DOBYear);
            System.Threading.Thread.Sleep(1000);
            effectiveDateEdit.SendKeys(TodaysDate);
            System.Threading.Thread.Sleep(2000);
            nextBtn.Click();

            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='mainContent']/div[2]/div/div[1]/div/div[1]/h2")));
                vehiclePageExist = true;
            }
            catch (Exception e)
            {
                vehiclePageExist = false;
            }

            return vehiclePageExist;
        }


        public bool FillOutForm()
        {
            bool vehiclePageExist;
            string TodaysDate = DateTime.Now.ToString("dd/MM/yyyy");

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstName")));

            //Example of retreiving a collection of elements


            firstNameEdit.SendKeys("Adam");
            lastNameEdit.SendKeys("Thomas");
            streetAddressEdit.SendKeys("7025 Albert Pick Rd");
            zipCodeEdit.SendKeys("27409");
            dobMonthEdit.SendKeys("01");
            dobDayEdit.SendKeys("01");
            dobYearEdit.SendKeys("1980");
            
            effectiveDateEdit.Clear();

            //System.Threading.Thread.Sleep(1000);
            effectiveDateEdit.SendKeys(TodaysDate);
            // System.Threading.Thread.Sleep(2000);

            //IList<IWebElement> editFields = driver.FindElements(By.TagName("input"));

            //foreach (var field in editFields)
            //{
            //    var idIs = field.GetAttribute("id");
            //    var valueIs = field.GetAttribute("value");

            //}



            nextBtn.Click();




            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='mainContent']/div[2]/div/div[1]/div/div[1]/h2")));
                vehiclePageExist = true;
            }
            catch (Exception e)
            {
                vehiclePageExist = false;
            }

            return vehiclePageExist;
        }

    }
}
