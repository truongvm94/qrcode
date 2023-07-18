using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QRCodeCore.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using static QRCoder.PayloadGenerator;

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
            try
            {
                string tmpPath = System.IO.Path.GetTempPath();
                string tmpFile = tmpPath + "jsondata.json";


                string jsonContent = System.IO.File.ReadAllText(tmpFile);

                var jsonObject = JsonConvert.DeserializeObject<List<InsertDataModel>>(jsonContent);

                //var data = new InsertDataModel();
                return View(jsonObject);
            }
            catch
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

        [HttpGet]
        public IActionResult DetailData(string modelId)
        {
            try
            {
                string tmpPath = System.IO.Path.GetTempPath();
                string tmpFile = tmpPath + "jsondata.json";


                string jsonContent = System.IO.File.ReadAllText(tmpFile);

                var jsonObject = JsonConvert.DeserializeObject<List<InsertDataModel>>(jsonContent);

                var data = jsonObject.Where(x => x.Id == modelId).FirstOrDefault();

                return View(data);
            }
            catch
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        public IActionResult DetailData(InsertDataModel model)
        {
            var dataList = new List<InsertDataModel>();
            var jsonData = string.Empty;
            string tmpPath = System.IO.Path.GetTempPath();
            string tmpFile = tmpPath + "jsondata.json";

            bool existFile = System.IO.File.Exists(tmpFile);
            if (!existFile)
            {
                try
                {
                    jsonData = JsonConvert.SerializeObject(dataList);
                    System.IO.File.WriteAllText(tmpFile, jsonData);
                }
                catch
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }

            }
            else
            {
                try
                {
                    // Read existing json data
                    jsonData = System.IO.File.ReadAllText(tmpFile);

                    // De-serialize to object or create new list
                    dataList = JsonConvert.DeserializeObject<List<InsertDataModel>>(jsonData)
                                         ?? new List<InsertDataModel>();

                    var data = dataList.Where(x => x.Id == model.Id).FirstOrDefault();

                    if (data != null)
                    {
                        data.DiaChi = model.DiaChi;
                        data.HoTen = model.HoTen;
                        data.Email = model.Email;
                        data.SoDienThoai = model.SoDienThoai;
                        data.TrangThai = model.TrangThai;
                    }

                    jsonData = JsonConvert.SerializeObject(dataList);
                    System.IO.File.WriteAllText(tmpFile, jsonData);
                    return View(data);
                }
                catch (Exception ex)
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }

            return View(model);
        }

        public IActionResult InsertData()
        {
            var getExpired = HttpContext.Request.Query["Id"];

            double tmpTimeSpand = Convert.ToDouble(getExpired.ToString());
            DateTime dateExpired = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            dateExpired = dateExpired.AddSeconds(tmpTimeSpand).ToLocalTime();
            //dateExpired = dateExpired.AddMinutes(5);

            var dtNow = DateTime.Now;
            if (dateExpired >= dtNow)
            {
                return View();
            }
            else
            {
                // hết hạn token => bắt quét lại
                return RedirectToAction("CreateQRCode");
            }
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
                try
                {
                    jsonData = JsonConvert.SerializeObject(dataList);
                    System.IO.File.WriteAllText(tmpFile, jsonData);
                }
                catch
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }

            }
            else
            {
                try
                {
                    // Read existing json data
                    jsonData = System.IO.File.ReadAllText(tmpFile);


                    // De-serialize to object or create new list
                    dataList = JsonConvert.DeserializeObject<List<InsertDataModel>>(jsonData)
                                         ?? new List<InsertDataModel>();
                    dataList.Add(new InsertDataModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        DiaChi = model.DiaChi,
                        HoTen = model.HoTen,
                        Email = model.Email,
                        SoDienThoai = model.SoDienThoai
                    });

                    jsonData = JsonConvert.SerializeObject(dataList);
                    System.IO.File.WriteAllText(tmpFile, jsonData);
                }
                catch (Exception ex)
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateQRCode()
        {
            string tmpPath = System.IO.Path.GetTempPath();
            string tmpFile = tmpPath + "expiredjob.json";
            bool existFile = System.IO.File.Exists(tmpFile);
            string pathQr = string.Empty;
            if (existFile)
            {
                var tmpId = Guid.NewGuid().ToString();
                var dataList = new List<CheckExpiredModel>();
                string tmpExpired = DateTime.Now.AddMinutes(5).Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                var tmpDataList = new CheckExpiredModel()
                {
                    Id = tmpId,
                    Path = "http://qr-code.vhec.vn/Home/InsertData/?id=" + tmpExpired,
                    Expired = tmpExpired
                };
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(tmpFile);
                // De-serialize to object or create new list
                dataList = JsonConvert.DeserializeObject<List<CheckExpiredModel>>(jsonData)
                                     ?? new List<CheckExpiredModel>();
                dataList.Add(tmpDataList);

                jsonData = JsonConvert.SerializeObject(dataList);
                System.IO.File.WriteAllText(tmpFile, jsonData);
                FileStream str = new FileStream(tmpFile,FileMode.Open);
                str.Dispose();

                using (StreamReader r = new StreamReader(tmpFile))
                {
                    string json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<CheckExpiredModel>>(json);
                    //#TODO lay ngay con hieu luc moi nhat
                    //pathQr = items[0].Path;
                    pathQr = items.Last().Path;
                }


            }

            var WebUri = new Url(pathQr);
            string UriPayload = WebUri.ToString();
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(UriPayload, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();


            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            ViewBag.QrCodeUri = QrUri;
            ViewBag.PathQr = pathQr;
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel model)
        {
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
