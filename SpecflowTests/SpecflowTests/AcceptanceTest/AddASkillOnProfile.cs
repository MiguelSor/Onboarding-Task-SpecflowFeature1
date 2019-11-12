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
    public class AddASkillOnProfile
    {
    

        [Given(@"I clicked on the skills tab")]
        public void GivenIClickedOnTheSkillsTab()
        {
            //Wait
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(@data-tab,'second')]")));

            //Click on skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'second')]")).Click();
        }

        [When(@"I add a skill")]
        public void WhenIAddASkill()
        {
            //Click on add new button
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click();

            //Click on the "Add Skill" field and type "React" on the field
            Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]")).SendKeys("React");

            //Click on the skills level
            Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]")).Click();

            //Choose the skill level
            IWebElement skillLevel = Driver.driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > div > div:nth-child(2) > select > option:nth-child(4)"));
            skillLevel.Click();

            //Click the add button
            Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click();
        }

        [Then(@"the skill i added should be displayed om my profile")]
        public void ThenTheSkillIAddedShouldBeDisplayedOmMyProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "React";
                string ActualValue = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
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
