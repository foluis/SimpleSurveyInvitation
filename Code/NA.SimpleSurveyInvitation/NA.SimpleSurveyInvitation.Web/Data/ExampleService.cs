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


        public string Greattings { get; private set; }


        public IEnumerable<GitHubBranch> Branches { get; private set; }
        public bool GetBranchesError { get; private set; }

        public ExampleService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> OnGet1(string value)
        {
            string result = string.Empty;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44308/api/QR/Grittings/pepe");

            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                //Branches = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(responseStream);
                Greattings = await JsonSerializer.DeserializeAsync<string>(responseStream);
            }
            else
            {
                GetBranchesError = true;
                //Branches = Array.Empty<GitHubBranch>();
                Greattings = "Pailas";
            }

            result = Greattings;
            return result;
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
    }

    //public class Commit
    //{
    //    public string Sha { get; set; }
    //    public string Url { get; set; }
    //}

    //public class GitHubBranch
    //{
    //    public string Name { get; set; }
    //    public Commit Commit { get; set; }
    //    public bool Protected { get; set; }
    //}
}
