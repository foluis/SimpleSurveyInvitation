using NA.SimpleSurveyInvitation._472API.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static QRCoder.PayloadGenerator;

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
            //Bitmap qrCodeImage = qrCode.GetGraphic(20);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);
            return BitmapToBytes(qrCodeImage);
        }

        [Route("api/QR/GenerateURL/{Value}")]
        [HttpGet]
        // GET: https://localhost:44308/api/QR/GenerateURL/value
        public byte[] GetUrl(string value)
        {
            Url generator = new Url(value);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20);
            
            return BitmapToBytes(qrCodeAsBitmap);
        }

        [Route("api/QR/GetQRByteArray")]
        [HttpPost]
        // POST: https://localhost:44308/api/QR/GetQRByteArray
        public byte[] GetQRByteArray([FromBody] DataToConvert dataToConvert)
        {           
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(dataToConvert.Value, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20);
           
            return BitmapToBytes(qrCodeAsBitmap);
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
