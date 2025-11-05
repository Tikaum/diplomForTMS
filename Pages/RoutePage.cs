using Allure.NUnit.Attributes;
using FinalSurgeTests.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.String;

namespace FinalSurgeTests.Pages
{
    public class RoutePage : BasePage
    {
        DashboardPage dashboardPage = new DashboardPage();

        private By RoutePageLocator = By.XPath("//span[text()='Create and view your routes.']");                
        private By RouteNameFieldLocator = By.Id("RouteName");
        private By RouteActivityDropdownLocator = By.XPath("//select[@id='Activity']");
        private By RouteDistanceFieldLocator = By.XPath("//input[@id='Distance']");
        private readonly string RouteActivityInCellLocatorFormat = "//span[text()='{0}']";
        private readonly string RouteNameInCellLocatorFormat = "//span[text()='{0}']/following::a";
        private readonly string RouteDistanceInCellLocatorFormat = "//span[text()='{0}']/following::span";

        InputElement RouteNameField => new InputElement(RouteNameFieldLocator);        
        InputElement RouteDistanceField => new InputElement(RouteDistanceFieldLocator);

        [AllureStep("Проверка открытия страницы с маршрутами")]
        public bool IsRoutePageOpened()
        {
            if (driver.FindElements(RoutePageLocator).Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        [AllureStep("Указание названия маршрута")]
        public RoutePage SetRouteName(string routeName)
        {
            RouteNameField.SetUpTextWithClear(routeName);
            return this;
        }

        [AllureStep("Указание типа активности (из списка) для маршрута")]
        public RoutePage SetRouteActivity(string routeActivity)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement routeActivityDropdownElement = wait.Until(ExpectedConditions.ElementToBeClickable(RouteActivityDropdownLocator));
            routeActivityDropdownElement.Submit();
            SelectElement routeActivityDropdown = new SelectElement(routeActivityDropdownElement);            
            routeActivityDropdown.SelectByText(routeActivity);
            return this;
        }

        [AllureStep("Указание дистанции маршрута")]
        public RoutePage SetRouteDistance(string routeDistance)
        {
            RouteDistanceField.SetUpTextWithClear(routeDistance);
            return this;
        }

        [AllureStep("Проверка типа активности в ранее созданном маршруте")]
        public RoutePage IsRouteActivityExists(string routeActivity, out bool isGivenValueExists)
        {
            if (driver.FindElements(By.XPath(Format(RouteActivityInCellLocatorFormat, routeActivity))).Count() > 0)
            {
                isGivenValueExists = true;
            }
            else { isGivenValueExists = false; }
            return this;
        }

        [AllureStep("Получение названия ранее созданного маршруте")]
        public RoutePage GetNameOfRoute(string routeActivity, out string nameOfRoute)
        {
            nameOfRoute = driver.FindElement(By.XPath(Format(RouteNameInCellLocatorFormat, routeActivity))).Text;            
            return this;
        }

        [AllureStep("Получение дистанции ранее созданного маршруте")]
        public RoutePage GetDistanceOfRoute(string routeActivity, out string distanceOfRoute)
        {
            distanceOfRoute = driver.FindElement(By.XPath(Format(RouteDistanceInCellLocatorFormat, routeActivity))).Text;
            return this;
        }
    }
}
