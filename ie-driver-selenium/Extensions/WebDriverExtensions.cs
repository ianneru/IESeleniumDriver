using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace FnzIeSeleniumDriver.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            return WaitUntilFindElement(driver, by, 0);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }

        public static IWebElement WaitUntilFindElement(IWebDriver driver, By by, int quantidadeErros = 0)
        {
            if (quantidadeErros == 10)
                throw new Exception("Não achou elemento");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.IgnoreExceptionTypes(typeof(Exception));

            try
            {
                IWebElement element = wait.Until(drv => drv.FindElement(by));

                return element;
            }
            catch (Exception ex)
            {
                quantidadeErros++;

                WaitUntilFindElement(driver, by, quantidadeErros);
            }

            return null;
        }
    }
}
