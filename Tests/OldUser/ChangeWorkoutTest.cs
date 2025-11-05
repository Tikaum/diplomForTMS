using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages;
using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Tests.OldUser
{
    [AllureNUnit]
    public class ChangeWorkoutTest : BaseTestForOldUser
    {        
        DashboardPage dashboardPage = new DashboardPage();
        WorkoutDetailsPage workoutDetailsPage = new WorkoutDetailsPage();
        ChangeWorkoutPage changeWorkoutPage = new ChangeWorkoutPage();        

        [Test]
        [Category("All users")]
        [Category("Tests for previously registered user")]
        [AllureTag("Tests for previously registered user")]
        [AllureSuite("Editing a previously created workout")]
        public void CheckingSuccessChangeWorkout()
        {                        
            dashboardPage.GoToWorkoutDetailsPage(Datas.WorkoutDate1);
            bool isWorkoutPageOpen = workoutDetailsPage.IsWorkoutDetailsPageOpen();
            Assert.That(isWorkoutPageOpen, Is.True, "Workout page not open");
            workoutDetailsPage.GoToPageOfChangeWorkout();
            bool isChangeWorkoutPageOpen = changeWorkoutPage.IsChangeWorkoutPageOpen();
            Assert.That(isChangeWorkoutPageOpen, Is.True, "Page of change workout not open");
            string textForInputInDescription = GeneratorUtil.RandomText();
            changeWorkoutPage.ChangeDescriptionOfWorkout(textForInputInDescription);                                    
            workoutDetailsPage.GetTextInDescriptionOfWorkout(out string receivedTextInDescription);            
            Assert.That(receivedTextInDescription, Does.Contain(textForInputInDescription),
                "The existing text differs from the entered one.");                
        }
    }
}
