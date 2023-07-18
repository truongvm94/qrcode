using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using QRCodeCore.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuartzProjcect.Quartz
{
    [DisallowConcurrentExecution]
    public class HelloWorldJob : IJob
    {
        public HelloWorldJob()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {

            var jsonData = string.Empty;
            string tmpPath = System.IO.Path.GetTempPath();
            string tmpFile = tmpPath + "expiredjob.json";
            bool existFile = System.IO.File.Exists(tmpFile);

            var tmpId = Guid.NewGuid().ToString();
            var dataList = new List<CheckExpiredModel>();
            string tmpExpired = DateTime.Now.AddMinutes(5).Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            var tmpDataList = new CheckExpiredModel()
            {
                Id = tmpId,
                Path = "http://qr-code.vhec.vn/Home/InsertData/?id=" + tmpExpired,
                Expired = tmpExpired
            };

            if (!existFile)
            {
                dataList.Add(tmpDataList);
                jsonData = JsonConvert.SerializeObject(dataList);
                System.IO.File.WriteAllText(tmpFile, jsonData);
            }
            else
            {
                // Read existing json data
                jsonData = System.IO.File.ReadAllText(tmpFile);
                // De-serialize to object or create new list
                dataList = JsonConvert.DeserializeObject<List<CheckExpiredModel>>(jsonData)
                                     ?? new List<CheckExpiredModel>();
                dataList.Add(tmpDataList);

                jsonData = JsonConvert.SerializeObject(dataList);
                System.IO.File.WriteAllText(tmpFile, jsonData);
            }


            Console.WriteLine($"Job 1 zaman dilim {DateTime.Now:U}");
            return Task.CompletedTask;
        }
    }
}
