using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


namespace EsoteriaTestSuite
{
    internal class TarotHelper
    {
        public static void SwitchTab(IWebDriver driver, String originalWindow)
        {
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public static void MobileWindow(IWebDriver driver, string localHost)
        {
            var options = new ChromeOptions();
            options.AddArgument("--window-size=430,932");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(localHost);
        }
    }
}
