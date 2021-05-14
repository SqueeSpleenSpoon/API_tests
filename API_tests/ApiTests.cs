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

        [Test]
        public void ChangeLastNameWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var userLastName = ClientRequests.SendRequestChangeLastNamePatch("Alibaba", user.TokenData.Token);

            Assert.AreEqual("Alibaba", userLastName);
        }

        [Test]
        public void ChangePasswordWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var userPassword = ClientRequests.SendRequestChangePasswordPost("123qweQWE!", "123qweQWE!1", user.TokenData.Token);

            var userAuth = ClientRequests.SendRequestSignInPost(user.User.Email.ToString() , "123qweQWE!1");

            Assert.AreNotEqual(userAuth , userPassword);
        }

        [Test]
        public void ChangeIndustryWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var userIndustry = ClientRequests.SendRequestChangeIndustryPatch("Alibaba", user.TokenData.Token);

            Assert.AreEqual("Alibaba", userIndustry);
        }

        [Test]
        public void ChangeCompanyAddressWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var companyAddress = ClientRequests.SendRequestChangeCompanyAddressPatch("Saddle Brook, NJ 07663, USA", user.TokenData.Token);

            Assert.AreEqual("Saddle Brook, NJ 07663, USA", companyAddress);
        }

        [Test]
        public void ChangeCompanyDescriptionWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var companyDescription = ClientRequests.SendRequestChangeCompanyDescriptionPatch("Description", user.TokenData.Token);

            Assert.AreEqual("Description", companyDescription);
        }

        [Test]
        public void ChangeCompanyNameWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var companyName = ClientRequests.SendRequestChangeCompanyNamePatch("White House", user.TokenData.Token);

            Assert.AreEqual("White House", companyName);
        }

        [Test]
        public void ChangeCompanyWebsiteWithApi()
        {
            var user = ClientRequests.CreateUserViaApi();

            var companyName = ClientRequests.SendRequestChangeCompanyWebsitePatch("https://json2csharp.com/", user.TokenData.Token);

            Assert.AreEqual("https://json2csharp.com/", companyName);
        }
    }
}