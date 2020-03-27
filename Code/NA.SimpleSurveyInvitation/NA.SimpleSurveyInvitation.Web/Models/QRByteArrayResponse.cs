using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.SimpleSurveyInvitation.Web.Models
{
    public class QRByteArrayResponse
    {
        public byte[] byteArray { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
