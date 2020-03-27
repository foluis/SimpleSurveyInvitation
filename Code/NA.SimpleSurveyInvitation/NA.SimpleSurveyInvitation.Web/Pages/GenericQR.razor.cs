﻿using NA.SimpleSurveyInvitation.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NA.SimpleSurveyInvitation.Web.Pages
{
    public partial class GenericQR
    {      
        List<GitHubBranch> gitHubBranches;
        string valueToConvert = string.Empty;
        byte[] byteArray = { };
        bool processingQR = false;

        protected override async Task OnInitializedAsync()
        {
            gitHubBranches = await MyService.OnGet("Luis Fer");
        }

        private async Task GetGenericQR()
        {
            processingQR = true;
            byteArray = await MyService.QRImage(valueToConvert);
            processingQR = false;
        }
    }
}
