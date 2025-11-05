using Allure.NUnit;
using Allure.NUnit.Attributes;
using FinalSurgeTests.Configs;
using FinalSurgeTests.Pages;

namespace FinalSurgeTests.Tests.OldUser
{
    [AllureNUnit]
    public class ReportTest : BaseTestForOldUser
    {        
        ReportPage reportPage = new ReportPage();

        [Test]
        [Category("All_users")]
        [Category("Tests_for_previously_registered_user")]
        [AllureTag("Tests_for_previously_registered_user")]
        [AllureSuite("Checking the display of the training report, with grouping of previously created trainings by default and by training type")]
        public void CheckingReportOfWorkout()
        {               
            reportPage.GoToReportPage();
            bool isReportPagePageOpen = reportPage.IsReportPageOpen();
            Assert.That(isReportPagePageOpen, Is.True, "Page of workout report not open");
            reportPage.SetStartDate(Datas.StartDateForReport);
            bool isReportPageInDefaultView = reportPage.IsReportPageInDefaultView();
            Assert.That(isReportPageInDefaultView, Is.True, "The report is not displayed in the default view (without grouping)");
            reportPage.ChangeReportPageToGroupByActivityView();
            var stateOfViewReportPage = reportPage.IsReportPageGroupByActivityView();            
            Assert.Multiple(() =>
            {
                Assert.That(stateOfViewReportPage[0], Is.True, "The report is not displayed as a grouping by type of training (there is no table for Cross Training workouts)");
                Assert.That(stateOfViewReportPage[1], Is.True, "The report is not displayed as a grouping by type of training (there is no table for training on Run)");
            });
        }
    }
}
