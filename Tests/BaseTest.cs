using FinalSurgeTests.Utils;

namespace FinalSurgeTests.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {            
        }

        [TearDown]
        public void Teardown()
        {
            BrowserUtils.Quit();
        }
    }
}
