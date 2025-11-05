using Allure.NUnit.Attributes;
using FinalSurgeTests.Builders;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages.Forms;
using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Pages
{
    public class LoginPage : BasePage
    {
        LoginForm loginForm = new LoginForm();

        [AllureStep("Авторизация ранее зарегистрированного пользователя")]
        public void AuthorizationgRegisteredUser()
        {
            BrowserUtils.OpenPage(Datas.URLStartPage);
            string UserName = Datas.MyUserName;
            string Password = Datas.MyUserPassword;
            var user = new UserBuilder()
            .WithEmail(UserName)
            .WithPassword(Password)
            .BuildUserForAutorization();
            loginForm.LoginUser(user);
        }
    }
}
