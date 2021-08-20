using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FnzIeSeleniumDriver.Extensions
{
    public static class SwitchToExtensions
    {
        public static void SwitchFrame(this IWebDriver driver, string nameFrame, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Name(nameFrame)));

            //var elemento = WebDriverExtensions.WaitUntilFindElement(driver,By.Name(nameFrame), 0);

            //driver.SwitchTo().Frame(elemento);
        }

        public static void PrimeiroIframe(this IWebDriver driver, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

            //var elemento = WebDriverExtensions.WaitUntilFindElement(driver, By.TagName("iframe"), 0);

            //driver.SwitchTo().Frame(elemento);
        }

        public static void Primeiroframe(this IWebDriver driver, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("frame")));

            //var elemento = WebDriverExtensions.WaitUntilFindElement(driver, By.TagName("frame"), 0);

            //driver.SwitchTo().Frame(elemento);
        }

        public static void Popup(this IWebDriver driver, string janelaPrincipal)
        {
            var current = driver.CurrentWindowHandle;

            var nextWindow = driver.WindowHandles
                                    .FirstOrDefault(w => w != janelaPrincipal);

            driver.SwitchTo().Window(nextWindow);
        }

        public static void SwitchDefault(this IWebDriver driver, string janelaPrincipal)
        {
            driver.SwitchTo().Window(janelaPrincipal);

            driver.SwitchTo().DefaultContent();
        }

        public static IAlert SwitchAlertaOK(this IWebDriver driver)
        {
            IAlert alert = null;

            try
            {
                alert = driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException e)
            {

            }

            return alert;
        }

       
    }
}
