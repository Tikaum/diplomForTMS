using OpenQA.Selenium;

namespace FinalSurgeTests.SeleniumFramework
{
    public class InputElement : BaseElement
    {
        public InputElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }
    }
}
