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
    public class ApiTests
    {

        [Test]
        public void ChangePhoneNumberWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();
           
            var userPhone = ClientRequests.SendRequestChangePhoneNumberPost("123qweQWE!", "1111111111", user.TokenData.Token);

            Assert.AreEqual("1111111111", userPhone);
        }
        
            [Test]
        public void ChangeFirsNameWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var userName = ClientRequests.SendRequestChangeFirstNamePatch("Alibaba", user.TokenData.Token);

            Assert.AreEqual("Alibaba", userName);
        }

    }
}