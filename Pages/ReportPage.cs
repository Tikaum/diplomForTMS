using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.SeleniumFramework;
using FinalSurgeTests.Utils;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages
{
    public class ReportPage : BasePage
    {
        private By ReportPageLocator = By.XPath("//strong[text()='Workout Report']");
        private By DefaultViewTableLocator = By.XPath("//h4[text()='Athlete Workout Report']");
        private By GroupByActivityRadioButtonLocator = By.CssSelector("#groupBy4");
        private By SaveButtonLocator = By.Id("saveButton");
        private By GroupByActivityViewTable1Locator = By.XPath("//h4[text()='Cross Training']");
        private By GroupByActivityViewTable2Locator = By.XPath("//h4[text()='Run']");
        private By StartDateFieldLocator = By.Id("WorkoutDate");

        ButtonElement GroupByActivityRadioButton => new ButtonElement(GroupByActivityRadioButtonLocator);
        ButtonElement SaveButton => new ButtonElement(SaveButtonLocator);
        InputElement StartDateField => new InputElement(StartDateFieldLocator);

        [AllureStep("Переход на страницу с отчетами о тренировках")]
        public void GoToReportPage()
        {
            BrowserUtils.OpenPage(Datas.URLReportPage);
        }

        [AllureStep("Проверка открытия страницы с отчетами о тренировках")]
        public bool IsReportPageOpen()
        {
            if (driver.FindElements(ReportPageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Проверка дефолтного отображения отчета о тренировках")]
        public bool IsReportPageInDefaultView()
        {
            if (driver.FindElements(DefaultViewTableLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Включение отображения отчета о тренировках с группировкой по типу активности")]
        public void ChangeReportPageToGroupByActivityView()
        {
            GroupByActivityRadioButton.ClickIfEnabled();
            SaveButton.ClickIfEnabled();
        }

        [AllureStep("Проверка отображения отчета о тренировках с группировкой по типу активности")]
        public bool[] IsReportPageGroupByActivityView()        
        {
            bool[] isReportPageGroupByActivity = new bool[2];
            if (driver.FindElements(GroupByActivityViewTable1Locator).Count() > 0)
            {
                isReportPageGroupByActivity[0] = true;
            }
            if (driver.FindElements(GroupByActivityViewTable2Locator).Count() > 0)
            {
                isReportPageGroupByActivity[1] = true;
            }
            return isReportPageGroupByActivity;
        }

        [AllureStep("Указание даты начала формирования отчета о тренировках")]
        public void SetStartDate(string startDate)
        {
            StartDateField.SetUpTextWithClear(startDate);
            SaveButton.ClickIfEnabled();
        }
    }
}
