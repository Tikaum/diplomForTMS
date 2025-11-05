using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.OldUser
{
    [AllureNUnit]
    public class PreviouslyСreatedWorkoutsExistTest : BaseTestForOldUser
    {        
        DashboardPage dashboardPage = new DashboardPage();

        [Test]
        [Category("All users")]
        [Category("Tests for previously registered user")]
        [AllureTag("Tests for previously registered user")]
        [AllureSuite("Checking if a registered user has previously created workouts")]
        public void CheckingPreviouslyCreatedWorkouts()
        {               
            bool IsWorkout1Exist = dashboardPage.IsWorkoutExist(Datas.WorkoutDate1);
            bool IsWorkout2Exist = dashboardPage.IsWorkoutExist(Datas.WorkoutDate2);
            bool IsWorkout3Exist = dashboardPage.IsWorkoutExist(Datas.WorkoutDate3);
            Assert.Multiple(() =>
            {
                Assert.That(IsWorkout1Exist, Is.True, "Workout of date October 29 not exist");
                Assert.That(IsWorkout2Exist, Is.True, "Workout of date October 28 not exist");
                Assert.That(IsWorkout3Exist, Is.True, "Workout of date October 27 not exist");
            });
        }
    }
}
