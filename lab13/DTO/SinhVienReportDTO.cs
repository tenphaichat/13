using System;

namespace Lab13_CrystalReport.DTO
{
    public class SinhVienReportDTO
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "Nam";
        public string MaKhoa { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public decimal DiemTB { get; set; } = 0.0m;
        public string Email { get; set; } = string.Empty;

        public SinhVienReportDTO() { }

        public SinhVienReportDTO(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string maKhoa, string tenKhoa, decimal diemTB, string email)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            DiemTB = diemTB;
            Email = email;
        }
    }
}
