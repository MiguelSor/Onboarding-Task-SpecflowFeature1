using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.WaitHelpers;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class DeleteSkills
    {
        [Given(@"I clicked on the skills tab under Profile")]
        public void GivenIClickedOnTheSkillsTabUnderProfile()
        {
            //Wait
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@data-tab,'second')]")));

            //Click on skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'second')]")).Click();
        }
        
        [When(@"I delete the chosen skills")]
        public void WhenIDeleteTheChosenSkills()
        {
            Thread.Sleep(1000);
            string ExpectedValue = "Selenium";
            string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Selenium')]")).Text;
            Assert.AreEqual(ExpectedValue, ActualValue);

            Thread.Sleep(500);

            if (ExpectedValue == ActualValue)
            {
                //click on the delete button
                Driver.driver.FindElement(By.XPath("//td[contains(text(),'Selenium')]//following::td//following::span[2]")).Click();
            }
            
        }
        
        [Then(@"the deleted skills should NOT be displayed on my listings")]
        public void ThenTheDeletedSkillsShouldNOTBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Selenium";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Selenium')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Deleted");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }
    }
 }

