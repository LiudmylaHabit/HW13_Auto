using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary1
{
    public class SeleniumTests
    {
        IWebDriver chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32");

        [Test]
        public void GoToDevEducationMainPage()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/ua/");
            IWebElement mainText = chrome.FindElement(By.CssSelector("body > div.wrapper > main > section > div > div.main-home__info > h1"));            
            Assert.AreEqual("Міжнародний IT-коледж", mainText.Text);
            //chrome.Quit();
        }

        [SetUp]
        public void NavigateToMainPage()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/ua/");
        }

        [Test (Description = "Checking correctness of navigation to branch site throught map pointers")]
        public void NavigateToPitersBranchPage()
        {
            IWebElement mapPoint = chrome.FindElement(By.CssSelector(".map-pointer.piter-point"));
            IWebElement location = chrome.FindElement(By.LinkText("Санкт-Петербург"));
            Assert.AreEqual(location.Text, "Санкт-Петербург");
        }
        /*
        [Test]
        public void CheckLinkedInstagramPages()
        {
            chrome.Navigate().GoToUrl("https://deveducation.com/ua/");
            IWebElement instagramButton = chrome.FindElement(By.XPath("/html/body/div[2]/footer/div/ul/li[3]/a/img"));
            instagramButton.Click();
            IWebElement instagramPage = chrome.FindElement(By.XPath("/html/body/div[1]/section/main/div/header/section/div[1]/h2"));
            Assert.AreEqual("dev.education", instagramPage.Text);
            chrome.Quit();
        }
        
        [Test]
        public void CheckLinkedYouTubePages()
        {
            IWebElement youTubeButton = chrome.FindElement(By.XPath("/html/body/div[2]/footer/div/ul/li[5]/a/img"));
            youTubeButton.Click();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
            //    .Until(ExpectedConditions.ElementExists(By.Id("text")));
            //WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            //wait.Until(d => chrome.FindElements(By.Id("text")));
            IWebElement youTubePage = chrome.FindElement(By.Id("text"));
            Assert.AreEqual("DevEducation", youTubePage.Text);
            chrome.Quit();
        }//*/

        [TearDown]
        public void OnClose()
        {
            chrome.Quit();
        }
    }
}
