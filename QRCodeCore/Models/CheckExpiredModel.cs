using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeCore.Models
{
    public class CheckExpiredModel
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public string Expired { get; set; }
    }
}
