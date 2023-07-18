using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeCore.Models
{
    public enum Status
    {
        Hoàn_Thành,
        Hủy
    }
    public class InsertDataModel
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public int SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public Status? TrangThai { get; set; }
    }
}
