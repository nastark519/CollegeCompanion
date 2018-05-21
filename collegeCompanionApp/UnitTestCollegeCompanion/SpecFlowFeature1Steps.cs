using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using collegeCompanionApp.Models;

namespace UnitTestCollegeCompanion
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        //The context is here only if I need it, and idk yet if I do
        //private CompanionContext compContex;

        private IWebDriver driver = new FirefoxDriver();
        private string appURL = "https://collegecompanionapp.azurewebsites.net/";

        [Given(@"I am on https://collegecompanionapp\.azurewebsites\.net/")]
        public void GivenIAmOnHttpsCollegecompanionapp_Azurewebsites_Net()
        {
            driver.Navigate().GoToUrl(appURL);
        }
        
        [Given(@"I have entered Oregon into the search bar")]
        public void GivenIHaveEnteredOregonIntoTheSearchBar()
        {
            driver.FindElement(By.Id("stateInput")).SendKeys("Oregon");
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            driver.FindElement(By.Id("submit")).Click();
        }
        
        
        [Then(@"the result should have (.*)")]
        public void ThenTheResultShouldHave(string theDivThatHoldsCollegeInfo)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
