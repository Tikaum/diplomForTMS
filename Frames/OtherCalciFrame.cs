using FinalSurgeTests.Pages;
using FinalSurgeTests.SeleniumFramework;
using OpenQA.Selenium;

namespace FinalSurgeTests.Frames
{
    public class OtherCalciFrame : BasePage
    {
        private By CaloricNeedsCalcButtomLocator = By.XPath("//a[text()='Caloric Needs']");
        private By SaveButtonLocator = By.Id("saveButtonSettings");
        private By WeightInputLocator = By.Id("Weight");
        private By HeightInputLocator = By.Id("HeightInchCent");
        private By AgeInputLocator = By.Id("Age");
        private By RunDistInputLocator = By.Id("RunDist");
        private By GenderMaleRadioButtomLocator = By.Id("optionsRadios5");
        private By TotalCaloricCellLocator = By.XPath("//table/tbody/tr/td[3]");

        ButtonElement CaloricNeedsCalcButtom => new ButtonElement(CaloricNeedsCalcButtomLocator);
        ButtonElement SaveButton => new ButtonElement(SaveButtonLocator);
        ButtonElement GenderMaleRadioButtom => new ButtonElement(GenderMaleRadioButtomLocator);
        InputElement WeightInput => new InputElement(WeightInputLocator);
        InputElement HeightInput => new InputElement(HeightInputLocator);
        InputElement AgeInput => new InputElement(AgeInputLocator);
        InputElement RunDistInput => new InputElement(RunDistInputLocator);

        public OtherCalciFrame SetWeightOfAthlet(string weight)
        {
            WeightInput.SetUpTextWithClear(weight);
            return this;
        }

        public OtherCalciFrame SetHeightOfAthlet(string height)
        {
            HeightInput.SetUpTextWithClear(height);
            return this;
        }

        public OtherCalciFrame SetAgeOfAthlet(string age)
        {
            AgeInput.SetUpTextWithClear(age);
            return this;
        }

        public OtherCalciFrame SetRunDistance(string runDist)
        {
            RunDistInput.SetUpTextWithClear(runDist);
            return this;
        }

        public OtherCalciFrame SaveEnteredData()
        {
            GenderMaleRadioButtom.ClickIfEnabled();
            SaveButton.ClickIfEnabled();
            return this;
        }

        public OtherCalciFrame GetTotalCaloricValue(out string totalCaloricValue)
        {
            totalCaloricValue = driver.FindElement(TotalCaloricCellLocator).Text;
            return this;
        }
    }
}
