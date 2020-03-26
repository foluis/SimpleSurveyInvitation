using NA.SimpleSurveyInvitation.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NA.SimpleSurveyInvitation.Web.Pages
{
    public partial class GenericQR
    {      
        private List<GitHubBranch> gitHubBranches;
        private string valueToConvert = string.Empty;
        byte[] byteArray = { };

        protected override async Task OnInitializedAsync()
        {
            gitHubBranches = await MyService.OnGet("Luis Fer");
        }

        private async Task GetGenericQR()
        {            
            byteArray = await MyService.QRImage(valueToConvert);
        }
    }
}
