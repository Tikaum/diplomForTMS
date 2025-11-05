using Allure.NUnit.Attributes;
using FinalSurgeTests.SeleniumFramework;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages
{
    public class WorkoutDetailsPage : BasePage
    {
        private By WorkoutDetailsPageLocator = By.XPath("//span[text()='View and Edit your workout.']");
        private By UpdateWorkoutButtonLocator = By.XPath("//span[contains(text(),'Update Workout')]");
        private By WorkoutDescriptionFieldLocator = By.XPath("//small[contains(text(),'Workout Description')]/ancestor::p");
        private By ActivityTypeNameLocator = By.ClassName("activityTypeName");
        private By WorkoutNameLocator = By.XPath("//span[@class='activityTypeName']/following::div");
        private By WorkoutDateTimeLocator = By.XPath("//small[@class='muted']");

        ButtonElement UpdateWorkoutButton => new ButtonElement(UpdateWorkoutButtonLocator);
        InfoElement WorkoutDescriptionField => new InfoElement(WorkoutDescriptionFieldLocator);
        InfoElement ActivityTypeName => new InfoElement(ActivityTypeNameLocator);
        InfoElement WorkoutName => new InfoElement(WorkoutNameLocator);
        InfoElement WorkoutDateTime => new InfoElement(WorkoutDateTimeLocator);

        [AllureStep("Проверка открытия страницы с деталями тренировки")]
        public bool IsWorkoutDetailsPageOpen()
        {
            if (driver.FindElements(WorkoutDetailsPageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Переход на страницу изменения тренировки")]
        public void GoToPageOfChangeWorkout()
        {
            UpdateWorkoutButton.ClickIfEnabled();
        }

        [AllureStep("Получение текста описания тренировки")]
        public WorkoutDetailsPage GetTextInDescriptionOfWorkout(out string workoutDescriptionField)
        {
            workoutDescriptionField = WorkoutDescriptionField.GetText();
            return this;
        }

        [AllureStep("Получение типа активности тренировки")]
        public WorkoutDetailsPage GetActivityTypeName(out string activityTypeName)
        {
            activityTypeName = ActivityTypeName.GetText();
            return this;
        }

        [AllureStep("Получение названия тренировки")]
        public WorkoutDetailsPage GetWorkoutName(out string workoutName)
        {
            workoutName = WorkoutName.GetText();
            return this;
        }

        [AllureStep("Получение даты тренировки")]
        public WorkoutDetailsPage GetWorkoutDateTime(out string workoutDateTime)
        {
            workoutDateTime = WorkoutDateTime.GetText();
            return this;
        }
    }
}
