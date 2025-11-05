using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.OldUser
{
    public class BaseTestForOldUser : BaseTest
    {
        LoginPage loginPage = new LoginPage();

        [SetUp]
        public new void Setup()
        {
            loginPage.AuthorizationgRegisteredUser();
        }
    }
}
