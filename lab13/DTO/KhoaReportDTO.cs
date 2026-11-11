namespace Lab13_CrystalReport.DTO
{
    public class KhoaReportDTO
    {
        public string MaKhoa { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public int SoLuongSinhVien { get; set; } = 0;
        public decimal DiemTrungBinhKhoa { get; set; } = 0.0m;

        public KhoaReportDTO() { }

        public KhoaReportDTO(string maKhoa, string tenKhoa, int soLuongSinhVien, decimal diemTrungBinhKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            SoLuongSinhVien = soLuongSinhVien;
            DiemTrungBinhKhoa = diemTrungBinhKhoa;
        }
    }
}
