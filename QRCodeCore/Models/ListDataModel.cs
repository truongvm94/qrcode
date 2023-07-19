using System;

namespace QRCodeCore.Models
{
    public class ListDataModel
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string Furigana { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ZipCode { get; set; }
        public string MucDich { get; set; }
        public Status? TrangThai { get; set; }
    }
}
