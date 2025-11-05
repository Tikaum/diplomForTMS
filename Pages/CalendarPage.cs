using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages
{
    public class CalendarPage:BasePage
    {
        private By CalendarPageLocator = By.XPath("//span[text()='View, Edit and Add workouts.']");

        [AllureStep("Проверка открытия страницы с календарем тренировок")]
        public bool IsCalendarPageOpen()
        {
            if (driver.FindElements(CalendarPageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
