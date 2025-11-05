using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.SeleniumFramework;
using FinalSurgeTests.Utils;
using OpenQA.Selenium;
using static System.String;

namespace FinalSurgeTests.Pages
{
    public class AddWorkoutPage : BasePage
    {
        private By AddWorkoutPageLocator = By.XPath("//p[text()='Please select an Activity Type to begin adding your workout.']");
        private readonly string ActivityTypeDropdownListLocatorFormat = "//a[contains(text(),'{0}')]";
        private By WorkoutTimeFieldLocator = By.Id("WorkoutTime");
        private By WorkoutNameFieldLocator = By.Id("Name");
        private By WorkoutDescriptionFieldLocator = By.Id("Desc");        

        InputElement WorkoutTimeField => new InputElement(WorkoutTimeFieldLocator);
        InputElement WorkoutNameField => new InputElement(WorkoutNameFieldLocator);
        InputElement WorkoutDescriptionField => new InputElement(WorkoutDescriptionFieldLocator);

        [AllureStep("Проверка открытия страницы добавления тренировки")]
        public bool IsAddWorkoutPageOpened()
        {
            if (driver.FindElements(AddWorkoutPageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Выбор (случайный) типа тренировки")]
        public AddWorkoutPage SelectActivityType(out string activityType)
        {
            string[] ActivityTypes = new string[] { Datas.ActivityType1, Datas.ActivityType2, Datas.ActivityType3 };
            int randomIndex = GeneratorUtil.RandomNumber();
            activityType = ActivityTypes[randomIndex];
            IWebElement SelectedActivityType = driver.FindElement(By.XPath(Format(ActivityTypeDropdownListLocatorFormat, activityType)));
            SelectedActivityType.Click();
            return this;
        }

        [AllureStep("Указание времени начала тренировки")]
        public AddWorkoutPage SetTimeOfWorkout(string time)
        {
            WorkoutTimeField.SetUpTextWithClear(time);
            return this;
        }

        [AllureStep("Указание названия тренировки")]
        public AddWorkoutPage SetNameOfWorkout(string name)
        {
            WorkoutNameField.SetUpTextWithClear(name);
            return this;
        }

        [AllureStep("Указание описания тренировки")]
        public AddWorkoutPage SetDescriptionOfWorkout(string description)
        {
            WorkoutDescriptionField.SetUpTextWithClear(description);
            return this;
        }
    }
}
