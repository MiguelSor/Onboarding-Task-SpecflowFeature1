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
    public class AddACertificationOnProfile
    {
        [Given(@"I clicked on the certification tab")]
        public void GivenIClickedOnTheCertificationTab()
        {
            //Wait for 1.5 seconds
            Thread.Sleep(1500);

            //Click on the Certifications tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'fourth')]")).Click();

        }
        
        [When(@"I add a certification")]
        public void WhenIAddACertification()
        {
            //wait for 1.5 seconds
            Thread.Sleep(1500);

            //Click on Add New Button
            Driver.driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div.row > div.twelve.wide.column.scrollTable > div > table > thead > tr > th.right.aligned > div")).Click();

            IWebElement CertField = Driver.driver.FindElement(By.XPath("//input[contains(@class,'certification-award capitalize')]"));
            CertField.Click();//Click on the Certificate or Award Field
            CertField.SendKeys("Foundation Certificate");//type on the award field

            IWebElement CertFrom = Driver.driver.FindElement(By.XPath("//input[contains(@class,'received-from capitalize')]"));
            CertFrom.Click();//Click on the from field
            CertFrom.SendKeys("ISTQB"); // type on the from field

            IWebElement CertYear = Driver.driver.FindElement(By.Name("certificationYear"));
            CertYear.Click();//click the drop down menu

            IWebElement ChosenCertYear = Driver.driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div.row > div.twelve.wide.column.scrollTable > div > div > div:nth-child(2) > div.three.wide.field > select > option:nth-child(3)"));
            ChosenCertYear.Click();//Choose the year 2018

            IWebElement AddButton = Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]"));
            AddButton.Click();//click to add the all the details provided
        }
        
        [Then(@"the certification I added should be displayed on my profile")]
        public void ThenTheCertificationIAddedShouldBeDisplayedOnMyProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "Foundation Certificate";
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

