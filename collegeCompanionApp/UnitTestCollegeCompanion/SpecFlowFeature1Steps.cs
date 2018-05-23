using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestCollegeCompanion
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I am on https://collegecompanionapp\.azurewebsites\.net/")]
        public void GivenIAmOnHttpsCollegecompanionapp_Azurewebsites_Net()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered Oregon into the search bar")]
        public void GivenIHaveEnteredOregonIntoTheSearchBar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should have (.*)")]
        public void ThenTheResultShouldHave(string theDivThatHoldsCollegeInfo)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
