using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Forerunner.PageObject
{
    //Proxy class to avoid interacting with elements directly when writing tests
    //Hiding element interactions behind Get() forces the element to be refound in the DOM directly before trying to interact with it, reduces stale element exceptions
    public class ElementProxy
    {
        private By locator;
        private IWebDriver driver;
        public ElementProxy(IWebDriver driver, By locator)
        {
            this.locator = locator;
            this.driver = driver;
        }

        public IWebElement Get()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(drv => drv.FindElement(locator));
        }

        public bool IsInteractable()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(drv => Get().Enabled);
        }
    }
}
