using Allure.NUnit.Attributes;
using FinalSurgeTests.SeleniumFramework;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages
{
    public class ChangeWorkoutPage : BasePage
    {
        private By ChangeWorkoutPageLocator = By.XPath("//h5[text()='Select an Activity Type']");
        private By WorkoutDescriptionInputLocator = By.XPath("//label[text()='Workout Description']/following-sibling::textarea");
        private By UpdateWorkoutButtonLocator = By.XPath("//input[@value='Update Workout']");               

        InputElement WorkoutDescriptionInput => new InputElement(WorkoutDescriptionInputLocator);
        ButtonElement UpdateWorkoutButton => new ButtonElement(UpdateWorkoutButtonLocator);

        [AllureStep("Проверка открытия страницы для изменения тренировки")]
        public bool IsChangeWorkoutPageOpen()
        {
            if (driver.FindElements(ChangeWorkoutPageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Ввод текста в поле описания тренировки")]
        public void ChangeDescriptionOfWorkout(string text)
        {
            WorkoutDescriptionInput.SetUpTextWithClear(text);
            UpdateWorkoutButton.ClickIfEnabled();
        }

        [AllureStep("Получение текста из поля описания тренировки")]
        public string GetTextInDescriptionOfWorkout()
        {
            return WorkoutDescriptionInput.GetText();
        }
    }
}
