using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.NewUser
{
    public class BaseTestForNewUser : BaseTest
    {
        RegistrationPage registrationPage = new RegistrationPage();

        [SetUp]
        public new void Setup()
        {
            registrationPage.RegistrationNewUser();
        }
    }
}
