using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.NewUser
{
    [AllureNUnit]
    public class RegistrationTest : BaseTest
    {
        RegistrationPage registrationPage = new();
        DashboardPage dashboardPage = new();

        [Test]
        [Category("Tests for new user")]
        [AllureSuite("Checking new user registration")]
        public void RegistrationNewUser()
        {
            registrationPage.RegistrationNewUser();
            bool userSuccessfullyRegistred = dashboardPage.IsDashboardPageOpen();            
            Assert.That(userSuccessfullyRegistred, Is.True, "Registration failed");
        }
    }
}
