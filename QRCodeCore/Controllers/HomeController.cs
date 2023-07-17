using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRCodeCore.Models;
using QRCoder;
using System;
using System.Web;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json;
using static QRCoder.PayloadGenerator;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace QRCodeCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ViewData()
        {
            var data = new InsertDataModel();
            return View();
        }


        public IActionResult InsertData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertData(InsertDataModel model)
        {
            var dataList = new List<InsertDataModel>();
            var jsonData = string.Empty;
            string tmpPath = System.IO.Path.GetTempPath();
            string tmpFile = tmpPath + "jsondata.json";
            bool existFile = System.IO.File.Exists(tmpFile);
            if (!existFile)
            {
                jsonData = JsonConvert.SerializeObject(dataList);
                System.IO.File.WriteAllText(tmpFile, jsonData);
            }
            else
            {
                // Read existing json data
                jsonData = System.IO.File.ReadAllText(tmpFile);
                // De-serialize to object or create new list
                dataList = JsonConvert.DeserializeObject<List<InsertDataModel>>(jsonData)
                                     ?? new List<InsertDataModel>();
                dataList.Add(new InsertDataModel
                {
                    DiaChi = model.DiaChi,
                    HoTen = model.HoTen,
                    Email = model.Email,
                    SoDienThoai = model.SoDienThoai
                });

                jsonData = JsonConvert.SerializeObject(dataList);
                System.IO.File.WriteAllText(tmpFile, jsonData);
            }

            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel model)
        {
            var WebUri = new Url(model.QRCodeText);
            string UriPayload = WebUri.ToString();
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(UriPayload, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();


            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            ViewBag.QrCodeUri = QrUri;
            return View();
        }


    }

    //Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
