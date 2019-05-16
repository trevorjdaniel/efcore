using HiveBrite.Functions.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace HiveBrite.Functions
{
    public class Engine
    {
        public static HBAuthData Authorize(string baseUrl, string adminEmail, string password, string clientId, string clientSecret)
        {
            // the result
            HBAuthData result = new HBAuthData();

            // build the url
            string url = "https://" + baseUrl + "/oauth/token?grant_type=password&scope=admin&admin_email=" + adminEmail + "&password=" + password + "&client_id=" + clientId + "&client_secret=" + clientSecret;

            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(url);

            // call the api
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<HBAuthData>(content);
            }
            return result;
        }

        public static List<HBUser> ListUsers(HBAuthData hBAuthData, string baseUrl, DateTime? updatedSince = null, bool fullProfile = false, int resultsPerPage = 250)
        {
            // the result
            List<HBUser> results = new List<HBUser>();

            // convert the updatedSince to the correct format accepted by the API
            string convertedDate = string.Empty;
            if (updatedSince != null)
            {
                convertedDate = string.Format("{0:yyyy-MM-ddTHH:mm:ss.FFFZ}", updatedSince);
            }

            // the page counter
            int page = 1;

            // build the url for the first page
            string url = "https://" + baseUrl + "/api/admin/v1/users?page=" + page + "&access_token=" + hBAuthData.access_token + "&per_page=" + resultsPerPage;

            // add the updated since filter if needed
            if (updatedSince != null)
                url = url + "&updated_since=" + convertedDate;

            // add the full profile param if required
            if (fullProfile)
                url = url + "&full_profile=true";

            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);

            // call the api
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;

                //bool containsRN = content.Contains("\r\n");

                //string result = JObject.Parse(content.Replace("\r\n  ", string.Empty)).ToString();

                // attempt to clean the Topic Interests
                //content = content.Replace(Environment.NewLine, "");
                //content = content.Replace("\r\n", null);

                HBUsers usersReturned = JsonConvert.DeserializeObject<HBUsers>(content);

                HBUser testUserObject = usersReturned.users.Where(x => x.id == 464105).FirstOrDefault();
                string testUserJSON = JsonConvert.SerializeObject(testUserObject);
                object TopicInterests = testUserObject.custom_attributes.Where(x => x.name == "_Topic_Interests").FirstOrDefault().value;

                //JArray trev = TopicInterests;

                results.AddRange(usersReturned.users);

                // are there more users?
                while (usersReturned.users.Count == resultsPerPage)
                {
                    // incremement the page counter
                    page += 1;

                    // build the url
                    url = "https://" + baseUrl + "/api/admin/v1/users?page=" + page + "&access_token=" + hBAuthData.access_token + "&per_page=" + resultsPerPage;

                    // add the updated since filter if needed
                    if (updatedSince != null)
                        url = url + "&updated_since=" + convertedDate;

                    // change the url of the call
                    request = new HttpRequestMessage();
                    request.Headers.Add("cache-control", "no-cache");
                    request.Method = HttpMethod.Get;
                    request.RequestUri = new Uri(url);

                    // make another call
                    response = client.SendAsync(request).Result;
                    content = response.Content.ReadAsStringAsync().Result;
                    usersReturned = JsonConvert.DeserializeObject<HBUsers>(content);
                    results.AddRange(usersReturned.users);

                }
            }
            return results;
        }

        public static CreateUpdateUserResponse CreateUpdateUser(HBAuthData hBAuthData, string baseUrl, CreateUpdateUser user, HttpMethod method)
        {
            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = method;
            request.RequestUri = new Uri("https://" + baseUrl + "/api/admin/v1/users?access_token=" + hBAuthData.access_token);
            request.Content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");

            // the user created
            CreateUpdateUserResponse createUserResponse = new CreateUpdateUserResponse();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    // process the user
                    createUserResponse = JsonConvert.DeserializeObject<CreateUpdateUserResponse>(content);
                    createUserResponse.Success = true;
                }
                else
                {
                    // process the error
                    createUserResponse.Success = false;
                    createUserResponse.ErrorObject = JsonConvert.DeserializeObject<ErrorObject>(content);
                }
            }
            return createUserResponse;
        }

        public static List<CompanyProfileDetails> ListCompanies(HBAuthData hBAuthData, string baseUrl, int resultsPerPage = 250)
        {
            // the result
            List<CompanyProfileDetails> results = new List<CompanyProfileDetails>();

            // the page counter
            int page = 0;

            // build the url for the first page
            string url = "https://" + baseUrl + "/api/admin/v1/companies?page=" + page + "&access_token=" + hBAuthData.access_token + "&per_page=" + resultsPerPage;

            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);

            // call the api
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                Companies companiesReturned = JsonConvert.DeserializeObject<Companies>(content);
                results.AddRange(companiesReturned.companies);

                // are there more companies?
                while (companiesReturned.companies.Count == resultsPerPage)
                {
                    // incremement the page counter
                    page += 1;

                    // build the url
                    url = "https://" + baseUrl + "/api/admin/v1/companies?page=" + page + "&access_token=" + hBAuthData.access_token + "&per_page=" + resultsPerPage;

                    // change the url of the call
                    request = new HttpRequestMessage();
                    request.Headers.Add("cache-control", "no-cache");
                    request.Method = HttpMethod.Get;
                    request.RequestUri = new Uri(url);

                    // make another call
                    response = client.SendAsync(request).Result;
                    content = response.Content.ReadAsStringAsync().Result;
                    companiesReturned = JsonConvert.DeserializeObject<Companies>(content);
                    results.AddRange(companiesReturned.companies);

                }
            }
            return results;
        }
        public static CompanyProfile GetCompanyProfile(HBAuthData hBAuthData, string baseUrl, int id, string key = null)
        {
            // build the url for the first page
            string url = "https://" + baseUrl + "/api/admin/v1/companies/" + id + "?access_token=" + hBAuthData.access_token;

            // add the key if necessary
            if (key != null)
                url = url + "&key=" + key;

            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);

            // the result
            CompanyProfile companyProfile = new CompanyProfile();

            // call the api
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                companyProfile = JsonConvert.DeserializeObject<CompanyProfile>(content);
            }
            return companyProfile;
        }

        public static List<string> GetInterests(HBAuthData hBAuthData, string baseUrl, string customized_type = null, string customized_id = null)
        {
            // build the url for the first page
            string url = "https://" + baseUrl + "/api/admin/v1/settings/customizable_attributes?access_token=" + hBAuthData.access_token;

            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);

            // the result
            GetInterestsResponse getInterestsResponse = new GetInterestsResponse();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                getInterestsResponse = JsonConvert.DeserializeObject<GetInterestsResponse>(content);
            }

            if (getInterestsResponse.customizable_attributes != null)
            {
                return getInterestsResponse.customizable_attributes.Where(x => x.name == "_Topic_Interests").FirstOrDefault().options;
            }

            return null;
        }

        public static CreateUserInterestsResponse CreateUserInterest(HBAuthData hBAuthData, string baseUrl, int id, CreateInterest userInterest)
        {
            // build the url for the first page
            string url = "https://" + baseUrl + "/api/admin/v1/users/" + id + "?access_token=" + hBAuthData.access_token;

            // build the http request message
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("cache-control", "no-cache");
            request.Method = HttpMethod.Put;
            request.RequestUri = new Uri(url);
            request.Content = new StringContent(JsonConvert.SerializeObject(userInterest), System.Text.Encoding.UTF8, "application/json");

            CreateUserInterestsResponse CreateUserInterestResponse = new CreateUserInterestsResponse();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.SendAsync(request).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    // process the user
                    CreateUserInterestResponse = JsonConvert.DeserializeObject<CreateUserInterestsResponse>(content);
                    CreateUserInterestResponse.Success = true;
                }
                else
                {
                    // process the error
                    CreateUserInterestResponse.Success = false;
                    CreateUserInterestResponse.ErrorObject = JsonConvert.DeserializeObject<ErrorObject>(content);
                }
            }
            return CreateUserInterestResponse;
        }
    }
}
