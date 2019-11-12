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
    public class DeleteLanguage
    {
        [Given(@"I clicked on the Language tab under Profile")]
        public void GivenIClickedOnTheLanguageTabUnderProfile()
        {
            //Wait
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//a[@class='item'][contains(.,'Profile')])[2]")));

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("(//a[@class='item'][contains(.,'Profile')])[2]")).Click();
        }
        
        [When(@"I delete the chosen language")]
        public void WhenIDeleteTheChosenLanguage()
        {
            Thread.Sleep(1000);
            string ExpectedValue = "tagalog";
            string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='tagalog']")).Text;
            Assert.AreEqual(ExpectedValue, ActualValue);

            Thread.Sleep(500);

            if (ExpectedValue == ActualValue)
            {
                //Click on delete icon
                Driver.driver.FindElement(By.XPath("//td[text()='tagalog']//following-sibling::td[2]/child::span[2]")).Click();
            }
        }
        
        [Then(@"the deleted language should NOT be displayed on my listings")]
        public void ThenTheDeletedLanguageShouldNOTBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "tagalog";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='tagalog']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue != ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language Deleted");
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
  
