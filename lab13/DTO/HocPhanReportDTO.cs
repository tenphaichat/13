namespace Lab13_CrystalReport.DTO
{
    public class HocPhanReportDTO
    {
        public string MaHP { get; set; } = string.Empty;
        public string TenHP { get; set; } = string.Empty;
        public int SoTinChi { get; set; } = 3;
        public int SoLuongDangKy { get; set; } = 0;

        public HocPhanReportDTO() { }

        public HocPhanReportDTO(string maHP, string tenHP, int soTinChi, int soLuongDangKy)
        {
            MaHP = maHP;
            TenHP = tenHP;
            SoTinChi = soTinChi;
            SoLuongDangKy = soLuongDangKy;
        }
    }
}
