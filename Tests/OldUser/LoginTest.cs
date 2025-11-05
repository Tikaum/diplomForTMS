using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.OldUser
{
    [AllureNUnit]
    public class LoginTest: BaseTestForOldUser
    {        
        DashboardPage dashboardPage = new DashboardPage();        

        [Test]
        [Category("Tests for previously registered user")]
        [AllureSuite("Checking the authorization of a previously registered user")]
        public void EnteringLoginUser()
        {               
            bool userSuccessfullyLogged = dashboardPage.IsDashboardPageOpen();
            Assert.That(userSuccessfullyLogged, Is.True, "Login failed");
        }        
    }
}
