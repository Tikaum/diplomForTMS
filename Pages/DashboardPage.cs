using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.SeleniumFramework;
using FinalSurgeTests.Utils;
using OpenQA.Selenium;
using static System.String;

namespace FinalSurgeTests.Pages
{
    public class DashboardPage : BasePage
    {
        private By DashboardPageLocator = By.XPath("//a[text()='Dashboard']");
        private By RecentPastWorkoutsListButtomLocator = By.XPath("//h4[text()='Recent Past Workouts']");
        private readonly string WorkoutsLocatorFormat = "//span[@class='minor' and contains(text(),'{0}')]";
        private readonly string WorkoutLinkLocatorFormat = "//span[@class='minor' and contains(text(),'{0}')]/following-sibling::a[@href]";
        private By OtherCalculatorButtomLocator = By.ClassName("icsw16-calculator");
        private readonly string OtherCalculatorFrameLocator = "OtherCalciFrame";
        private By NoticeOfAbsenceUpcomingWorkoutsLocator = By.XPath("//span[contains(text(),'You have no upcoming workouts')]");
        private By NoticeOfAbsencepastPastWorkoutsLocator = By.XPath("//span[contains(text(),'You have no past workouts')]");

        ButtonElement RecentPastWorkoutsListButtom => new ButtonElement(RecentPastWorkoutsListButtomLocator);
        ButtonElement OtherCalculatorButtom => new ButtonElement(OtherCalculatorButtomLocator);

        [AllureStep("Проверка открытия страницы дашборда")]
        public bool IsDashboardPageOpen()
        {
            if (driver.FindElements(DashboardPageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Проверка наличия тренировки за определенную дату")]
        public bool IsWorkoutExist(string workoutDate)
        {
            if (driver.FindElements(By.XPath(Format(WorkoutsLocatorFormat, workoutDate))).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Переход на страницу с деталями тренировки")]
        public void GoToWorkoutDetailsPage(string workoutDate)
        {
            RecentPastWorkoutsListButtom.ClickIfEnabled();
            IWebElement workoutLink = driver.FindElement(By.XPath(Format(WorkoutLinkLocatorFormat, workoutDate)));
            workoutLink.Click();
        }

        [AllureStep("Вызов фрейма с калькулятором калорий")]
        public void GoToOtherCalculatorFrame()
        {
            OtherCalculatorButtom.ClickIfEnabled();
            driver.SwitchTo().Frame(OtherCalculatorFrameLocator);
        }

        [AllureStep("Проверка отсутствия тренировок будущих или прошедших")]
        public bool[] IsWorkoutNotExist()
        {
            bool[] isUpcomingAndPastWorkoutNotExist = new bool[2];
            if (driver.FindElements(NoticeOfAbsenceUpcomingWorkoutsLocator).Count() > 0)
            {
                isUpcomingAndPastWorkoutNotExist[0] = true;
            }
            if (driver.FindElements(NoticeOfAbsencepastPastWorkoutsLocator).Count() > 0)
            {
                isUpcomingAndPastWorkoutNotExist[1] = true;
            }
            return isUpcomingAndPastWorkoutNotExist;
        }

        [AllureStep("Переход на страницу добавления тренировки")]
        public void GoToAddWorkoutPage()
        {
            BrowserUtils.OpenPage(Datas.URLAddWorkoutPage);
        }

        [AllureStep("Переход на страницу со спортивной обувью")]
        public void GoToAddShoePage()
        {
            BrowserUtils.OpenPage(Datas.URLShoePage);
        }

        [AllureStep("Переход на страницу с маршрутами")]
        public void GoToRoutePage()
        {
            BrowserUtils.OpenPage(Datas.URLRoutePage);
        }
    }
}
