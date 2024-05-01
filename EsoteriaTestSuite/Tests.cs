using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static EsoteriaTestSuite.TarotHelper;
using OpenQA.Selenium.DevTools.V121.SystemInfo;
using OpenQA.Selenium.DevTools.V123.SystemInfo;


namespace EsoteriaTestSuite
{

    public class Tests
    {
        #region IWeb Variables
        IWebDriver driver;
        IWebElement element;
        #endregion

        #region String Variables
        List<string> links = ["Daily Reflection", "Tarot Pull", "Moon Calendar", "Buy your own Deck"];
        string homeText = "This is HOME";
        string tarotText = "This is TAROT";
        string calendarText = "This is CALENDAR";
        string buyDeckText = "This is BUY YOUR OWN DECK";
        string brandName = "Esoteria";
        string subHeader = "Cartomancy Companion";
        string url;
        string originalWindow;
        string copyright = "© 2024";
        string elementText;
        #endregion

        #region Link Variables 
        string localHost = "http://localhost:5173/"; //ensure matches local host instance after npm run dev
        string githubLink = "https://github.com/joshuavickstrom/TarotWebapp";
        string liliLinkedIn = "https://www.linkedin.com/in/lili-clift/";
        string kenzLinkedIn = "https://www.linkedin.com/in/mackenzie-branch/";
        string joshLinkedIn = "https://www.linkedin.com/in/joshuakvickstrom/";
        #endregion

        #region Boolean Variabls 
        bool isEqual = false;
        #endregion

        #region Element Ids 
        string headerIdNavTitle = "NavHeaderTitle";
        string headerIdNavMoon = "NavHeaderMoon";
        string headerIdNavSubtitle = "NavHeaderSubtitle";
        string headerIdNavHome = "NavLinkHome";
        string headerIdNavTarot = "NavLinkTarot";
        string headerIdNavCalendar = "NavLinkCalendar";
        string headerIdNavMobileDeck = "NavLinkMobileBuyDeck";
        string headerIdNavBuyDeck = "NavLinkBuyDeck";
        string footerIdCopyright = "FooterCopyright";
        string footerIdLili = "FooterLinkLili";
        string footerIdKenz = "FooterLinkMackenzie";
        string footerIdJosh = "FooterLinkJoshua";
        string footerIdGit = "FooterLinkGithub";
        #endregion

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(localHost);

            //MobileWindow(driver, localHost);

        }

        #region Header Tests
        [Test]
        public void TestHeaderTitle()
        {
            element = driver.FindElement(By.Id(headerIdNavTitle));
            elementText = Regex.Replace(element.Text, "\r\nd", "");
            Console.WriteLine(elementText); //returns "Esoteria"

            Assert.That(elementText.Equals(brandName));
        }

        [Test]
        public void TestHeaderSubtitle()
        {
            element = driver.FindElement(By.Id(headerIdNavSubtitle));
            elementText = element.Text;
            Console.WriteLine(elementText); //returns "Cartomancy Companion"

            Assert.That(elementText.Equals(subHeader));
        }

        [Test]
        public void TestHeaderMoonHover()
        {
            element = driver.FindElement(By.ClassName("moon"));
            elementText = element.GetAttribute("title");
            Console.WriteLine(elementText); //returns contents of title that should contain moon description

            Assert.That(elementText, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void TestNavBarLinkDailyReflection()
        {
            element = driver.FindElement(By.Id(headerIdNavHome));
            element.Click();
            element = driver.FindElement(By.ClassName("home"));
            elementText = element.Text;
            Assert.That(elementText.Equals(homeText));

        }

        [Test]
        public void TestNavBarLinkTarotPull()
        {
            element = driver.FindElement(By.Id(headerIdNavTarot));
            element.Click();
            element = driver.FindElement(By.ClassName("tarot"));
            elementText = element.Text;
            Assert.That(elementText.Equals(tarotText));
        }

        [Test]
        public void TestNavBarLinkMoonCalendar()
        {
            element = driver.FindElement(By.Id(headerIdNavCalendar));
            element.Click();
            element = driver.FindElement(By.ClassName("calendar"));
            elementText = element.Text;
            Assert.That(elementText.Equals(calendarText));

        }

        [Test]
        public void TestNavBarLinkBuyYourDeck()
        {
            element = driver.FindElement(By.Id(headerIdNavBuyDeck));
            element.Click();
            element = driver.FindElement(By.ClassName("buyadeck"));
            elementText = element.Text;
            Assert.That(elementText.Equals(buyDeckText));

        }

        [Test]
        public void TestNavBarMobileLinkBuyYourDeck()
        {
            //resizes for mobile 430 x 932
            driver.Manage().Window.Size = new System.Drawing.Size(430, 932);
            element = driver.FindElement(By.Id(headerIdNavMobileDeck));
            element.Click();
            element = driver.FindElement(By.ClassName("buyadeck"));
            elementText = element.Text;
            Assert.That(elementText.Equals(buyDeckText));
        }
        #endregion

        #region Footer Tests
        [Test]
        public void TestFooterLinkLili()
        {
            originalWindow = driver.CurrentWindowHandle;
            element = driver.FindElement(By.Id(footerIdLili));
            element.Click();
            SwitchTab(driver, originalWindow);
            url = driver.Url;
            Assert.That(url.Equals(liliLinkedIn));
        }

        [Test]
        public void TestFooterLinkMackenzie()
        {
            originalWindow = driver.CurrentWindowHandle;
            element = driver.FindElement(By.Id(footerIdKenz));
            element.Click();
            SwitchTab(driver, originalWindow);
            url = driver.Url;
            Assert.That(url.Equals(kenzLinkedIn));
        }

        [Test]
        public void TestFooterLinkJosh()
        {
            originalWindow = driver.CurrentWindowHandle;
            element = driver.FindElement(By.Id(footerIdJosh));
            element.Click();
            SwitchTab(driver, originalWindow);
            url = driver.Url;
            Assert.That(url.Equals(joshLinkedIn));
        }

        [Test]
        public void TestFooterLinkGitRepo()
        {
            originalWindow = driver.CurrentWindowHandle;
            element = driver.FindElement(By.Id(footerIdGit));
            element.Click();
            SwitchTab(driver, originalWindow);
            url = driver.Url;
            Assert.That(url.Equals(githubLink));
        }

        [Test]
        public void TestFooterCopyright()
        {
            element = driver.FindElement(By.Id(footerIdCopyright));
            elementText = element.Text;
            Assert.That(elementText.Equals(copyright));
        }
        #endregion

        [OneTimeTearDown]
        public void TearDown() { driver.Quit(); }
    }
}