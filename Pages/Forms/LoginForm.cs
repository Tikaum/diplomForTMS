using Allure.NUnit.Attributes;
using FinalSurgeTests.Models;
using FinalSurgeTests.SeleniumFramework;
using OpenQA.Selenium;

namespace FinalSurgeTests.Pages.Forms
{
    public class LoginForm : BasePage
    {
        private By LoginFieldUserLocator = By.Id("login_name");
        private By PasswordFieldUserLocator = By.Id("login_password");
        private By LoginButtonLocator = By.XPath("//button[text()='Login']");

        public InputElement LoginFieldUserInput => new InputElement(LoginFieldUserLocator);
        public InputElement PasswordFieldUserInput => new InputElement(PasswordFieldUserLocator);
        public InputElement LoginButtonInput => new InputElement(LoginButtonLocator);

        [AllureStep("Авторизация юзера, с введением логина и пароля")]
        public void LoginUser(User user)
        {
            LoginFieldUserInput.SetUpTextWithClear(user.UserEmail);
            PasswordFieldUserInput.SetUpTextWithClear(user.Password);
            LoginButtonInput.ClickElement();
        }
    }
}
