using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.WaitHelpers;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class EditSkills
    {
        [Given(@"I clicked on the skills tab under the profile page")]
        public void GivenIClickedOnTheSkillsTabUnderTheProfilePage()
        {
            //Wait
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@data-tab,'second')]")));

            //Click on skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'second')]")).Click();
        }
        
        [When(@"I edit the chosen skills")]
        public void WhenIEditTheChosenSkills()
        {
            //Click on the edit button
            Driver.driver.FindElement(By.XPath("//td[contains(text(),'React')]//following::td//following::td//span[1]")).Click();

            //Clear the input
            Driver.driver.FindElement(By.XPath("//input[contains(@name,'name')]")).Clear();
            Driver.driver.FindElement(By.XPath("//input[contains(@name,'name')]")).SendKeys("Selenium");

            //Click on the level dropdown
            Driver.driver.FindElement(By.XPath("//select[contains(@name,'level')]")).Click();

            //Choose and click beginner
            Driver.driver.FindElement(By.XPath("//select[contains(@name,'level')]//child::option[2]")).Click();

            //Click on the update button
            Driver.driver.FindElement(By.XPath("//select[contains(@name,'level')]//following::input[1]")).Click();
        }
        
        [Then(@"the updated skills should be displayed on my listings")]
        public void ThenTheUpdatedSkillsShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Selenium";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Selenium')]")).Text;
                Assert.AreEqual(ExpectedValue,ActualValue);
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language Edited");
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

