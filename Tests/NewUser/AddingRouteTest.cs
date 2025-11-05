using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages;
using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Tests.NewUser
{
    [AllureNUnit]
    public class AddingRouteTest : BaseTestForNewUser
    {
        DashboardPage dashboardPage = new DashboardPage();        
        RoutePage routePage = new RoutePage();

        [Test]
        [Category("Tests for new user")]
        [AllureSuite("Adding a route with a specified name, activity type, and distance")]
        public void CheckingSuccessAddingRoute()
        {
            dashboardPage.GoToRoutePage();
            bool isRoutePageOpened = routePage.IsRoutePageOpened();
            Assert.That(isRoutePageOpened, Is.True, "Page of routes not open");
            string randomNameOfRoute = GeneratorUtil.RandomText();
            string randomRouteDistance = Convert.ToString(GeneratorUtil.RandomDistance());
            routePage.SetRouteName(randomNameOfRoute)
                .SetRouteActivity(Datas.ActivityType1)
                .SetRouteDistance(randomRouteDistance)
                .SaveEntity();
            routePage.IsRouteActivityExists(Datas.ActivityType1, out bool isGivenValueOfRouteActivityExists)
                .GetNameOfRoute(Datas.ActivityType1, out string receivedNameOfRoute)
                .GetDistanceOfRoute(Datas.ActivityType1, out string receivedDistanceOfRoute);
            Assert.Multiple(() =>
            {
                Assert.That(isGivenValueOfRouteActivityExists, Is.True, 
                    "There are no cells with a route for this type of activity.");
                Assert.That(receivedNameOfRoute, Is.EqualTo(randomNameOfRoute), 
                    "The received route name does not match the specified one.");
                Assert.That(receivedDistanceOfRoute, Does.Contain(randomRouteDistance), 
                    "The received route distance does not match the specified one");
            });
        }
    }
}
