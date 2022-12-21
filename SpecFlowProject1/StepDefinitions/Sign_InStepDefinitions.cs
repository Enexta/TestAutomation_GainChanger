using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Sign_InStepDefinitions
    {

         IWebDriver driver = new ChromeDriver();

        [Given(@"\[I navigate to the site]")]
        public void GivenINavigateToTheSite()
        {
            driver.Navigate().GoToUrl("https://cozy-fairy-5394bc.netlify.app/");
            driver.Manage().Window.Maximize();

            //Assert.IsTrue(driver.FindElement(By.Name("Login To Your Account")).Displayed);

        }

        [When(@"\[I enter username and Password]")]
        public void WhenIEnterUsernameAndPassword()
        {
            driver.FindElement(By.Id("username")).SendKeys("gainchanger");
            driver.FindElement(By.Id("password")).SendKeys("justdoit");
            
        }

        [When(@"\[I click on Login]")]
        public void WhenIClickOnLogin()
        {
            driver.FindElement(By.Id("submit")).Click();
         
        }

        [Then(@"\[I should be logged in successfully]")]
        public void ThenIShouldBeLoggedInSuccessfully()

        {
            Assert.IsTrue(driver.Url.ToLower().Contains("https://www.gainchanger.com/"));
            driver.Quit();
        }
    }
}
