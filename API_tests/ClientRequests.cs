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

        public static string SendRequestChangeLastNamePatch(string newSecondName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newLastNameModel = new Dictionary<string, string>
            {
                { "last_name", newSecondName }
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
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
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
            var changedPasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return changedPasswordResponse.Token;
        }
    }
}
