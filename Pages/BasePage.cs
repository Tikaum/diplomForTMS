using FinalSurgeTests.SeleniumFramework;
using FinalSurgeTests.Utils;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages
{
    public abstract class BasePage
    {
        public IWebDriver driver = BrowserUtils.Driver;

        private  By SaveButtonLocator = By.Id("saveButton");
        ButtonElement SaveButton => new ButtonElement(SaveButtonLocator);

        public  void SaveEntity()
        {
            SaveButton.ClickIfEnabled();          
        }
    }
}
