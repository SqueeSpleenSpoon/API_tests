using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace API_tests
{
    public class Tests 
    {

        [Test]
        public void Test1()
        {
            var user = ClientRequests.CreateUserViaApi();
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            IJavaScriptExecutor js = driver;
            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");

            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }

        [Test]
        public void Test2()
        {
            var user = ClientRequests.CreateUserViaApi();
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            IJavaScriptExecutor js = driver;

                    

            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");

            var userPhone = ClientRequests.SendRequestChangePhoneNumberPost("123qweQWE!", "1111111111", user.TokenData.Token);

            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }

    }
}