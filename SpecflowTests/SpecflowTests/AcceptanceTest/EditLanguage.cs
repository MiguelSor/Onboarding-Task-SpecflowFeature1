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
    public class EditLanguage
    {
        [Given(@"I clicked on the language tab under the profile page")]
        public void GivenIClickedOnTheLanguageTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

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
                Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]")).Click();

                //Choose the language level
                Driver.driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > tbody:nth-child(4) > tr > td > div > div:nth-child(2) > select > option:nth-child(2)")).Click();

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
                string ExpectedValue = "tagalog";
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

