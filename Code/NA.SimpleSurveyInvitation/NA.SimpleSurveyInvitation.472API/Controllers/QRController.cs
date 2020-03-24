using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NA.SimpleSurveyInvitation._472API.Controllers
{
    [Route("api/[controller]")]
    public class QRController : ApiController
    {
        [Route("api/QR/Generate/{Value}")]
        [HttpGet]
        // GET: https://localhost:44308/api/QR/Generate/hola
        public byte[] Get(string value)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytes(qrCodeImage);
            //return View(BitmapToBytes(qrCodeImage));

            //return new string[] { "value1", "value2" };
        }

        [Route("api/QR/Grittings/{Value}")]
        [HttpGet]
        // GET: https://localhost:44308/api/QR/Grittings/pepe
        public string Grittings(string value)
        {
            return $"Hola {value}";
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        // GET: api/QR/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QR
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QR/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QR/5
        public void Delete(int id)
        {
        }
    }
}
