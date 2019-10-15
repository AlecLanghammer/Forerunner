using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Forerunner.PageObject
{
    public abstract class BasePage : StandardLoad
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public virtual void WaitForPageTitle(string expectedTitle, int timeout = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(drv => drv.Title.Equals(expectedTitle));
        }
    }
}
