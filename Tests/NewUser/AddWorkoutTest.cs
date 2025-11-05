using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages;
using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Tests.NewUser
{
    [AllureNUnit]
    public class AddWorkoutTest : BaseTestForNewUser
    {
        AddWorkoutPage addWorkoutPage = new AddWorkoutPage();
        DashboardPage dashboardPage = new DashboardPage();
        WorkoutDetailsPage workoutDetailsPage = new WorkoutDetailsPage();

        [Test]
        [Category("All_users")]
        [Category("Tests_for_new_user")]
        [AllureTag("Tests_for_new_user")]
        [AllureSuite("Adding a new workout with a specified name, start time, activity type, and description")]
        public void CheckingAddingWorkout()
        {
            dashboardPage.GoToAddWorkoutPage();
            bool isAddWorkoutPageOpen = addWorkoutPage.IsAddWorkoutPageOpened();
            Assert.That(isAddWorkoutPageOpen, Is.True, "Page for adding workouts  not open");
            string randomNameOfWorkout = GeneratorUtil.RandomText();
            string randomDescriptionOfWorkout = GeneratorUtil.RandomText();
            addWorkoutPage.SelectActivityType(out string selectedActivityType)
                .SetTimeOfWorkout(Datas.TimeForAddingWorkout)
                .SetNameOfWorkout(randomNameOfWorkout)
                .SetDescriptionOfWorkout(randomDescriptionOfWorkout)
                .SaveEntity();
            bool isWorkoutDetailsPageOpened = workoutDetailsPage.IsWorkoutDetailsPageOpen();
            workoutDetailsPage.GetActivityTypeName(out string receivedActivityTypeName)
                .GetWorkoutDateTime(out string receivedWorkoutDateTime)
                .GetWorkoutName(out string receivedWorkoutName)
                .GetTextInDescriptionOfWorkout(out string receivedWorkoutDescription);
            Assert.Multiple(() =>
            {
                Assert.That(isWorkoutDetailsPageOpened, Is.True, 
                    "After creating a new workout, I was not redirected to its page.");
                Assert.That(receivedActivityTypeName, Is.EqualTo(selectedActivityType), 
                    "The selected activity type does not match the one received");
                Assert.That(receivedWorkoutDateTime, Does.Contain(Datas.TimeForAddingWorkout), 
                    "The set training time does not match the received one");
                Assert.That(receivedWorkoutName, Is.EqualTo(randomNameOfWorkout), 
                    "The specified workout name does not match the one received.");
                Assert.That(receivedWorkoutDescription, Does.Contain(randomDescriptionOfWorkout), 
                    "The specified workout description does not match the one received");
            });
        }
    }
}
