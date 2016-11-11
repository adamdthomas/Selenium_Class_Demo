using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.utilities
{
    public static class Extensions
    {
        public static SelectElement FindSelectElementWhenPopulated(this IWebDriver driver, By by, int delayInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(delayInSeconds));
            return wait.Until<SelectElement>(drv =>
            {
                wait.Until(ExpectedConditions.ElementExists(by));
                IWebElement element = drv.FindElement(by);

                SelectElement selectElement = new SelectElement(element);
                if (selectElement.Options.Count >= 2)
                {
                    return selectElement;
                }

                return null;
            }
            );
        }
    }


}

