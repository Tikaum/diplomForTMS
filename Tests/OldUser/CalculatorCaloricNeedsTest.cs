using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Frames;
using FinalSurgeTests.Pages;
using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Tests.OldUser
{
    [AllureNUnit]
    public class CalculatorCaloricNeedsTest
    {
        LoginPage loginPage = new LoginPage();
        DashboardPage dashboardPage = new DashboardPage();
        OtherCalciFrame otherCalciFrame = new OtherCalciFrame();

        [OneTimeSetUp]
        public void Setup()
        {
            loginPage.AuthorizationgRegisteredUser();
            dashboardPage.GoToOtherCalculatorFrame();
        }

        [Test]        
        [Category("All users")]
        [Category("Tests for previously registered user")]
        [AllureTag("Tests for previously registered user")]
        [AllureSuite("Testing the calorie calculator for users with different parameters (weight, height, age, running distance)")]
        [TestCaseSource(typeof(CsvDataOfAthlets), nameof(CsvDataOfAthlets.GetTestCases))]
        public void CheckingExpectedCaloriesForAthlets(string weight, string height, string age, string runDistance, string expectedTotalCalories)
        {
            otherCalciFrame.SetWeightOfAthlet(weight)
                .SetHeightOfAthlet(height)
                .SetAgeOfAthlet(age)
                .SetRunDistance(runDistance)
                .SaveEnteredData()
                .GetTotalCaloricValue(out string totalCaloricValue);               
            Assert.That(totalCaloricValue, Does.Contain(expectedTotalCalories), "The expected amount of calories matches the calculated amount.");            
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            BrowserUtils.Quit();
        }
    }
}
