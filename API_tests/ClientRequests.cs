using API_tests.Models;
using API_tests.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_tests
{
    class ClientRequests
    {
        public static ClientAuthModel CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            var user = new Dictionary<string, string>
                {
                    { "email" , $"its{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                    { "first_name" , "Petter" },
                    { "last_name" ,"Parker" },
                    { "password" ,"123qweQWE!"},
                    { "phone_number" , "3453453454"}
                };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }

        public static string SendRequestChangeClientEmailPost(string password, string newEmail, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", newEmail },
                { "password", password }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return changedEmailResponse.Email;
        }

        public static string SendRequestChangePhoneNumberPost(string password, string newPhone, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneModel = new Dictionary<string, string>
            {
                { "phone_number", newPhone },
                { "password", password }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedPhoneResponse = JsonConvert.DeserializeObject<ChangePhoneResponse>(response.Content);

            return changedPhoneResponse.Phone;
        }

        public static string SendRequestChangeFirstNamePatch(string newFirstName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newFirsNameModel = new Dictionary<string, string>
            {
                { "first_name", newFirstName }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newFirsNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedFirstNameResponse = JsonConvert.DeserializeObject<ChangeFirstNameResponse>(response.Content);

            return changedFirstNameResponse.FirstName;
        }

        public static string SendRequestChangeLastNamePatch(string newLastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newLastNameModel = new Dictionary<string, string>
            {
                { "last_name", newLastName }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newLastNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedLastNameResponse = JsonConvert.DeserializeObject<ChangeLastNameResponse>(response.Content);

            return changedLastNameResponse.LastName;
        }

        public static string SendRequestChangePasswordPost(string oldPassword, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>
            {
                { "old_password", oldPassword },
                { "new_password", newPassword }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedPasswordResponse = JsonConvert.DeserializeObject<TokenData>(response.Content);

            return changedPasswordResponse.Token;
        }

        public static string SendRequestSignInPost(string email, string password)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);
            var newSignInModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password }
            };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(newSignInModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var token = JsonConvert.DeserializeObject<ResponseSignInModel>(response.Content).TokenData.Token;

            return token;
        }

        public static string SendRequestChangeIndustryPatch(string industry, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newIndustryModel = new Dictionary<string, string>
            {               
                { "industry", industry},
                { "location_latitude", "100"},
                { "location_longitude", "-74.1007318"}
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newIndustryModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedIndustryResponse = JsonConvert.DeserializeObject<GeneralModel>(response.Content);

            return changedIndustryResponse.Industry;
        }

        public static string SendRequestChangeCompanyAddressPatch(string address, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newAddressModel = new Dictionary<string, string>
            {
                { "company_address", address},
                { "location_latitude", "100"},
                { "location_longitude", "-74.1007318"}
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newAddressModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedAddressResponse = JsonConvert.DeserializeObject<GeneralModel>(response.Content);

            return changedAddressResponse.CompanyAddress;
        }

        public static string SendRequestChangeCompanyDescriptionPatch(string description, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newDescriptionModel = new Dictionary<string, string>
            {
                { "company_description", description},
                { "location_latitude", "100"},
                { "location_longitude", "-74.1007318"}
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newDescriptionModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedDescriptionResponse = JsonConvert.DeserializeObject<GeneralModel>(response.Content);

            return changedDescriptionResponse.CompanyDescription.ToString();
        }

        public static string SendRequestChangeCompanyNamePatch(string name, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newNameModel = new Dictionary<string, string>
            {
                { "company_name", name},
                { "location_latitude", "100"},
                { "location_longitude", "-74.1007318"}
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedNameResponse = JsonConvert.DeserializeObject<GeneralModel>(response.Content);

            return changedNameResponse.CompanyName.ToString();
        }

        public static string SendRequestChangeCompanyWebsitePatch(string website, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newWebsiteModel = new Dictionary<string, string>
            {
                { "company_website", website},
                { "location_latitude", "100"},
                { "location_longitude", "-74.1007318"}
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newWebsiteModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedWebsiteResponse = JsonConvert.DeserializeObject<GeneralModel>(response.Content);

            return changedWebsiteResponse.CompanyWebsite.ToString();
        }
        
        public static string SendRequestChangeAvatarPost(string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/images/upload/");

            var request = new RestRequest(Method.POST);

            request.AddHeader("authorization", token);
            request.AddHeader("Content-Disposition", "form-data; name=\"file\"; filename=\"avatar.jpeg\"");
            request.AddHeader("Content-Type", "image/jpeg");
            request.AddFile("file", "C:\\Users\\CKOT4\\Desktop\\avatar.jpeg");
            //request.AddParameter("image/png", @"C:\Users\CKOT4\Desktop\EOM.png", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            /* var client = new RestClient("https://api.newbookmodels.com/api/images/upload/");
             client.Timeout = -1;
             var request = new RestRequest(Method.POST);
             request.AddHeader("Content-Disposition", "form-data; name=\"file\"; filename=\"avatar.jpeg\"");
             request.AddHeader("content-type", "image/png");
             request.AddHeader("authorization", token);
             request.AddParameter("image/jpeg", @"‪C:\Users\CKOT4\Desktop\avatar.jpeg", ParameterType.RequestBody);
             IRestResponse response = client.Execute(request);

 */
            var changedAvatarResponse = JsonConvert.DeserializeObject<Image>(response.Content);

            return changedAvatarResponse.Id;
        }
    }
}