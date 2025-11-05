using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.NewUser
{
    [AllureNUnit]
    public class PreviouslyСreatedWorkoutsNotExistTest : BaseTestForNewUser
    {        
        DashboardPage dashboardPage = new DashboardPage();

        [Test]
        [Category("Tests for new user")]
        [AllureSuite("Checking for the absence of previously created future and past trainings")]
        public void CheckingPreviouslyCreatedWorkouts()
        {
            var StateOfWorkouts = dashboardPage.IsWorkoutNotExist();            
            Assert.Multiple(() =>
            {
                Assert.That(StateOfWorkouts[0], Is.True, "Upcoming workouts exist");
                Assert.That(StateOfWorkouts[1], Is.True, "Past workouts exist");                
            });
        }
    }
}
