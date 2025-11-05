using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalSurgeTests.Utils
{
    public static class BrowserUtils
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = Init();
                }
                return driver;
            }
        }

        //private static IWebDriver Init()
        //{
        //    var options = new ChromeOptions();
        //    options.AddArgument("--start-maximized");
        //    var driver = new ChromeDriver(options);            
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    return driver;
        //}

        private static IWebDriver Init()
        {
            var options = new ChromeOptions();            
            options.AddUserProfilePreference("disable-popup-blocking", true);
            options.AddArguments(
                "--headless=new",       
                "--no-sandbox",         
                "--disable-dev-shm-usage",
                "--disable-gpu",
                "--window-size=1920,1080");
            return new ChromeDriver(options);
        }

        public static void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
