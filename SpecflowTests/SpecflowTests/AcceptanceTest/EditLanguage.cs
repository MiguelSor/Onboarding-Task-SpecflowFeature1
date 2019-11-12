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
    public class EditLanguage
    {
        [Given(@"I clicked on the language tab under the profile page")]
        public void GivenIClickedOnTheLanguageTabUnderTheProfilePage()
        {
            //Wait
            WebDriverWait wait = new WebDriverWait(Driver.driver,TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//a[@class='item'][contains(.,'Profile')])[2]")));
               

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("(//a[@class='item'][contains(.,'Profile')])[2]")).Click();
        }
        
        [When(@"I edit the chosen language")]
        public void WhenIEditTheChosenLanguage()
        {

                    Thread.Sleep(1000);
                    string ExpectedValue = "tagalog";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='tagalog']")).Text;
                    Thread.Sleep(500);

            if (ExpectedValue == ActualValue)
            {
                Driver.driver.FindElement(By.XPath("//td[text()='tagalog']//following-sibling::td[2]/child::span")).Click();

                //type another language
                Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Language')]")).Clear();
                Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Language')]")).SendKeys("Spanish");

                //Click on Language Level
                Driver.driver.FindElement(By.XPath("//select[contains(@name,'level')]")).Click();
                //Choose the language level
                Driver.driver.FindElement(By.XPath("//select[contains(@name,'level')]/child::option[2]")).Click();

                //Click on update button
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
            }


        }

        [Then(@"the updated language should be displayed on my listings")]
        public void ThenTheUpdatedLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Spanish";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Spanish']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, edited a Language Successfully");
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

