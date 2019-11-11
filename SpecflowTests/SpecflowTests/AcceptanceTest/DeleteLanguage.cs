using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
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
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("(//a[@class='item'][contains(.,'Profile')])[2]")).Click();
        }
        
        [When(@"I delete the chosen language")]
        public void WhenIDeleteTheChosenLanguage()
        {
            Thread.Sleep(1000);
            string ExpectedValue = "tagalog";
            string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='tagalog']")).Text;

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
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
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
  
