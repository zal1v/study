﻿using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;
using TF.Pages;

namespace TF.Steps
{
    [Binding]
    public class LoginTestSteps
    {
        public static IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        public LoginPage loginPage = new LoginPage(driver);

        [Given(@"I launch browser and go to DC login page")]
        public void OpenBrowserAndGoToLoginPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://app.dealcloud.eu/");
        }
        [Given(@"I fill in (.*) and (.*)")]
        public void FillInUsernameAndPassword(string p0, string p1)
        {
            loginPage.EnterUsername("ayankouski@dealcloud.com");
            loginPage.EnterPassword("kHrkw7bb?");
        }
        [When(@"I select client site")]
        public void SelectSite()
        {
            BasePage.WaitForLoad(driver, 16);
            loginPage.ChooseClient();
        }
        [Then(@"navigated to Home Page")]
        public void NavigateToHomepage()
        {
            loginPage.CheckAlchemyLogo();
            driver.Quit();

        }
    }
}
