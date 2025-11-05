using Allure.NUnit.Attributes;
using FinalSurgeTests.Models;
using FinalSurgeTests.SeleniumFramework;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages.Forms
{
    public class RegistrationForm : BasePage
    {
        private By FirstNameLocator = By.Id("create_first");
        private By LastNameLocator = By.Id("create_last");
        private By EmailLocator = By.Id("create_email");
        private By PasswordLocator = By.Id("password_meter");
        private By RePasswordLocator = By.Id("create_passwordmatch");
        private By CreateNewAccountButtonLocator = By.XPath("//button[text()='Create New Account']");

        public InputElement FirstNameField => new InputElement(FirstNameLocator);
        public InputElement LastNameField => new InputElement(LastNameLocator);
        public InputElement EmailField => new InputElement(EmailLocator);
        public InputElement PasswordField => new InputElement(PasswordLocator);
        public InputElement RePasswordField => new InputElement(RePasswordLocator);
        public ButtonElement CreateNewAccountButton => new ButtonElement(CreateNewAccountButtonLocator);

        [AllureStep("Регистрация нового юзера с введением его данных и пароля")]
        public void RegistrationUser(User user)
        {
            FirstNameField.SetUpTextWithClear(user.FirstName);
            LastNameField.SetUpTextWithClear(user.LastName);
            EmailField.SetUpTextWithClear(user.UserEmail);
            PasswordField.SetUpTextWithClear(user.Password);
            RePasswordField.SetUpTextWithClear(user.RePassword);
            CreateNewAccountButton.ClickIfEnabled();            
        }
    }
}
