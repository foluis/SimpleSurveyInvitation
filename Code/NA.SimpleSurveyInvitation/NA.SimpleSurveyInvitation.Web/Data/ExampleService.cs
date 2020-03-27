using NA.SimpleSurveyInvitation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NA.SimpleSurveyInvitation.Web.Data
{
    public class ExampleService
    {
        private readonly IHttpClientFactory _clientFactory;        

        public IEnumerable<GitHubBranch> Branches { get; private set; }

        public bool GetBranchesError { get; private set; }

        public ExampleService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<GitHubBranch>> OnGet(string value)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/aspnet/AspNetCore.Docs/branches");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Branches = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }

            return Branches.ToList();
        }

        public async Task<string> Grittings(string qrText)
        {
            string greattings = string.Empty;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44308/api/QR/Grittings/pepe");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                greattings = await JsonSerializer.DeserializeAsync<string>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }

            return greattings;
        }

        public async Task<byte[]> QRImage(string qrText)
        {
            if(String.IsNullOrEmpty(qrText))
            {
                qrText = "Empty string";
            }

            byte[] byteArray = { };

            //var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44308/api/QR/Generate/{qrText}/");
            //var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44308/api/QR/GenerateURL/{qrText}/");
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://testqrgeneratorapi.azurewebsites.net/api/QR/GenerateURL/{qrText}/");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<byte[]>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }

            return byteArray;
        }
    }
}
