using Allure.NUnit.Attributes;
using FinalSurgeTests.Builders;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages.Forms;
using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Pages
{
    public class RegistrationPage
    {
        RegistrationForm regForm = new RegistrationForm();

        [AllureStep("Генерация данных, их ввод и регистрация нового пользователя")]
        public void RegistrationNewUser()
        {
            BrowserUtils.OpenPage(Datas.URLRegistrationPage);
            string firstName = GeneratorUtil.RandomName();
            string lastName = GeneratorUtil.RandomName();
            string password = GeneratorUtil.RandomPass();
            string email = GeneratorUtil.RandomEmail();
            var user = new UserBuilder()
                .WithFirstName(firstName)
                .WithLasttName(lastName)
                .WithEmail(email)
                .WithPassword(password)
                .WithPassword(password)
                .BuildUserForRegistration();
            regForm.RegistrationUser(user);            
        }
    }
}
