using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.SimpleSurveyInvitation.Web.Models
{
    public class QRServiceResponse
    {
        public bool IsSuccessStatusCode { get; set; }
        public byte[] byteArray { get; set; }

    }
}
