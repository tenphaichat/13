using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lab13_CrystalReport.DTO;

namespace Lab13_CrystalReport.DAL
{
    public class BaoCaoDAL
    {
        /// <summary>
        /// Bài 3: Lấy dữ liệu báo cáo danh sách sinh viên theo mẫu DataTable
        /// Khớp các cột định nghĩa trong view vw_BaoCaoSinhVien
        /// </summary>
        public DataTable GetStudentReportData(string maKhoa = null)
        {
            DataTable table = new DataTable("SinhVienReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, TenKhoa, DiemTB, Email FROM vw_BaoCaoSinhVien";
                if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                {
                    sql += " WHERE MaKhoa = @MaKhoa";
                }
                sql += " ORDER BY TenKhoa, HoTen";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        /// <summary>
        /// Lấy danh sách DTO sinh viên phục vụ hiển thị và xuất báo cáo
        /// </summary>
        public List<SinhVienReportDTO> GetStudentReportList(string maKhoa = null)
        {
            DataTable dt = GetStudentReportData(maKhoa);
            List<SinhVienReportDTO> list = new List<SinhVienReportDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new SinhVienReportDTO(
                    r["MaSV"]?.ToString() ?? "",
                    r["HoTen"]?.ToString() ?? "",
                    r["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(r["NgaySinh"]) : DateTime.MinValue,
                    r["GioiTinh"]?.ToString() ?? "Nam",
                    r["MaKhoa"]?.ToString() ?? "",
                    r["TenKhoa"]?.ToString() ?? "",
                    r["DiemTB"] != DBNull.Value ? Convert.ToDecimal(r["DiemTB"]) : 0.0m,
                    r["Email"]?.ToString() ?? ""
                ));
            }
            return list;
        }

        /// <summary>
        /// Bài 6: Lấy dữ liệu báo cáo danh sách khoa kèm số lượng sinh viên
        /// </summary>
        public DataTable GetFacultyReportData()
        {
            DataTable table = new DataTable("KhoaReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT MaKhoa, TenKhoa, SoLuongSinhVien, DiemTrungBinhKhoa FROM vw_BaoCaoKhoa ORDER BY TenKhoa", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }

        /// <summary>
        /// Lấy danh sách DTO khoa phục vụ hiển thị và xuất báo cáo
        /// </summary>
        public List<KhoaReportDTO> GetFacultyReportList()
        {
            DataTable dt = GetFacultyReportData();
            List<KhoaReportDTO> list = new List<KhoaReportDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new KhoaReportDTO(
                    r["MaKhoa"]?.ToString() ?? "",
                    r["TenKhoa"]?.ToString() ?? "",
                    r["SoLuongSinhVien"] != DBNull.Value ? Convert.ToInt32(r["SoLuongSinhVien"]) : 0,
                    r["DiemTrungBinhKhoa"] != DBNull.Value ? Convert.ToDecimal(r["DiemTrungBinhKhoa"]) : 0.0m
                ));
            }
            return list;
        }

        /// <summary>
        /// Bài 8: Lấy dữ liệu báo cáo danh mục học phần
        /// Sắp xếp tăng dần theo TenHP theo đúng yêu cầu đề bài
        /// </summary>
        public DataTable GetCourseReportData()
        {
            DataTable table = new DataTable("HocPhanReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT MaHP, TenHP, SoTinChi, SoLuongDangKy FROM vw_BaoCaoHocPhan ORDER BY TenHP ASC", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }

        /// <summary>
        /// Lấy danh sách DTO học phần
        /// </summary>
        public List<HocPhanReportDTO> GetCourseReportList()
        {
            DataTable dt = GetCourseReportData();
            List<HocPhanReportDTO> list = new List<HocPhanReportDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new HocPhanReportDTO(
                    r["MaHP"]?.ToString() ?? "",
                    r["TenHP"]?.ToString() ?? "",
                    r["SoTinChi"] != DBNull.Value ? Convert.ToInt32(r["SoTinChi"]) : 0,
                    r["SoLuongDangKy"] != DBNull.Value ? Convert.ToInt32(r["SoLuongDangKy"]) : 0
                ));
            }
            return list;
        }

        /// <summary>
        /// Lấy danh mục Khoa để nạp vào ComboBox lọc
        /// </summary>
        public DataTable GetAllKhoa()
        {
            DataTable table = new DataTable("Khoa");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }
    }
}
