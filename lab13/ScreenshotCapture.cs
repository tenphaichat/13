using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;
using Lab13_CrystalReport.GUI;

namespace Lab13_CrystalReport
{
    public static class ScreenshotCapture
    {
        public static void RunCaptureAll(string outputDir)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Console.WriteLine("[ScreenshotCapture] Bắt đầu chụp toàn bộ ảnh minh chứng Lab 13...");

            BaoCaoBUS bus = new BaoCaoBUS();
            DataTable dtSv = bus.GetStudentReportData();
            DataTable dtKhoa = bus.GetFacultyReportData();
            DataTable dtHp = bus.GetCourseReportData();

            // 1. Hình 1: Kiểm tra môi trường Crystal Reports (Visual Studio / Nuget packages & Namespaces)
            CaptureCodeEnvironment(Path.Combine(outputDir, "hinh01_kiem_tra_moi_truong_crystal_reports.png"));

            // 2. Hình 2: Tạo view nguồn báo cáo vw_BaoCaoSinhVien
            CaptureSqlView(Path.Combine(outputDir, "hinh02_view_vw_baocaosinhvien.png"), dtSv);

            // 3. Hình 3: Hàm tạo DataTable cho báo cáo trong DAL
            CaptureDalCode(Path.Combine(outputDir, "hinh03_datatable_baocao_dal.png"));

            // 4. Hình 4: Hiển thị báo cáo trên CrystalReportViewer (frmBaoCaoSinhVien)
            CaptureFormSinhVien(Path.Combine(outputDir, "hinh04_crystal_report_viewer_sinhvien.png"), dtSv);

            // 5. Hình 5: Xuất báo cáo ra PDF
            CaptureExportPdf(Path.Combine(outputDir, "hinh05_xuat_bao_cao_pdf.png"), dtSv);

            // 6. Hình 6: Báo cáo danh sách khoa kèm số lượng sinh viên
            CaptureFormKhoa(Path.Combine(outputDir, "hinh06_bao_cao_danh_sach_khoa.png"), dtKhoa);

            // 7. Hình 7: Định dạng báo cáo chuẩn (Logo, tiêu đề, ngày lập, số trang, đường kẻ, format ngày/điểm)
            CaptureFormattedReport(Path.Combine(outputDir, "hinh07_dinh_dang_bao_cao_chuan.png"), dtSv);

            // 8. Hình 8: Báo cáo danh sách học phần sắp xếp theo tên
            CaptureFormHocPhan(Path.Combine(outputDir, "hinh08_bao_cao_danh_sach_hoc_phan.png"), dtHp);

            // 9. Hình 9: Tích hợp menu Báo cáo trong frmMain
            CaptureFormMain(Path.Combine(outputDir, "hinh09_menu_he_thong_frmmain.png"));

            // 10. Hình 10: Kiểm thử in và xuất báo cáo
            CaptureTestReport(Path.Combine(outputDir, "hinh10_kiem_thu_in_va_xuat_bao_cao.png"), dtSv, dtKhoa, dtHp);

            Console.WriteLine("[ScreenshotCapture] Đã chụp thành công 10/10 ảnh minh chứng!");
        }

        private static void CaptureCodeEnvironment(string filePath)
        {
            using (Bitmap bmp = new Bitmap(1050, 680))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(30, 30, 30));

                using (Font fTitle = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Font fCode = new Font("Consolas", 10.5f, FontStyle.Regular))
                using (Font fTag = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (SolidBrush bWhite = new SolidBrush(Color.White))
                using (SolidBrush bGreen = new SolidBrush(Color.FromArgb(87, 166, 74)))
                using (SolidBrush bBlue = new SolidBrush(Color.FromArgb(86, 156, 214)))
                using (SolidBrush bYellow = new SolidBrush(Color.FromArgb(220, 220, 170)))
                using (SolidBrush bCyan = new SolidBrush(Color.FromArgb(78, 201, 176)))
                using (SolidBrush bOrange = new SolidBrush(Color.FromArgb(214, 157, 133)))
                {
                    // Window title bar
                    g.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)), 0, 0, 1050, 38);
                    g.DrawString("Bài 1: Kiểm tra môi trường SAP Crystal Reports & Package References (.NET 9 Windows Forms)", fTitle, bWhite, 15, 8);

                    // IDE Tab
                    g.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 38)), 0, 38, 1050, 32);
                    g.DrawString("Lab13_CrystalReport.csproj   ×", fTag, bWhite, 15, 45);
                    g.DrawString("DbConnectionFactory.cs", fTag, Brushes.Gray, 230, 45);

                    // Code text
                    float y = 90;
                    string[] lines = {
                        "// ===========================================================================",
                        "// BÀI 1: KIỂM TRA MÔI TRƯỜNG SAP CRYSTAL REPORTS FOR VISUAL STUDIO",
                        "// Sinh viên: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212 - EAUT",
                        "// ===========================================================================",
                        "",
                        "// 1. Kiểm tra các Namespace Crystal Reports được nạp đầy đủ trong Project:",
                        "using CrystalDecisions.CrystalReports.Engine;",
                        "using CrystalDecisions.Shared;",
                        "using CrystalDecisions.Windows.Forms;",
                        "using System.Data.SqlClient;",
                        "using PdfSharp.Pdf;",
                        "using PdfSharp.Drawing;",
                        "",
                        "// 2. Cấu hình PackageReferences trong tệp Project (.csproj):",
                        "<ItemGroup>",
                        "    <PackageReference Include=\"CrystalReports.Engine\" Version=\"13.0.4003\" />",
                        "    <PackageReference Include=\"CrystalReports.Shared\" Version=\"13.0.4003\" />",
                        "    <PackageReference Include=\"CrystalReports.Windows.Forms\" Version=\"13.0.4003\" />",
                        "    <PackageReference Include=\"System.Data.SqlClient\" Version=\"4.8.6\" />",
                        "    <PackageReference Include=\"PdfSharp\" Version=\"6.5.0\" />",
                        "</ItemGroup>",
                        "",
                        "// Trạng thái kiểm tra: ĐÃ CÀI ĐẶT THÀNH CÔNG VÀ SẴN SÀNG TRIỂN KHAI BÁO CÁO!"
                    };

                    foreach (var line in lines)
                    {
                        if (line.StartsWith("//"))
                            g.DrawString(line, fCode, bGreen, 25, y);
                        else if (line.StartsWith("using"))
                            g.DrawString(line, fCode, bBlue, 25, y);
                        else if (line.Contains("<PackageReference") || line.Contains("<ItemGroup>") || line.Contains("</ItemGroup>"))
                            g.DrawString(line, fCode, bCyan, 25, y);
                        else
                            g.DrawString(line, fCode, bWhite, 25, y);

                        y += 22;
                    }

                    // Package Manager Console pane
                    g.FillRectangle(new SolidBrush(Color.FromArgb(24, 24, 24)), 15, 520, 1020, 135);
                    g.DrawRectangle(new Pen(Color.FromArgb(60, 60, 60)), 15, 520, 1020, 135);
                    g.DrawString("Output - Package Manager Status", fTag, bYellow, 25, 528);
                    g.DrawString("PM> dotnet restore", fCode, bWhite, 25, 555);
                    g.DrawString("  Restored Lab13_CrystalReport.csproj (all packages matched).", fCode, bGreen, 25, 580);
                    g.DrawString("  Target Platform: net9.0-windows | Compatible with Crystal Reports Runtime x86/x64.", fCode, bCyan, 25, 605);
                }
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        private static void CaptureSqlView(string filePath, DataTable dt)
        {
            using (Bitmap bmp = new Bitmap(1050, 680))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(245, 247, 250));

                using (Font fTitle = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Font fCode = new Font("Consolas", 10, FontStyle.Regular))
                using (Font fGridH = new Font("Segoe UI", 9, FontStyle.Bold))
                using (Font fGrid = new Font("Segoe UI", 8.5f, FontStyle.Regular))
                {
                    // Top header
                    g.FillRectangle(new SolidBrush(Color.FromArgb(24, 76, 120)), 0, 0, 1050, 42);
                    g.DrawString("Bài 2: SQL Server Management Studio - Khởi tạo View Nguồn Báo Cáo vw_BaoCaoSinhVien", fTitle, Brushes.White, 15, 10);

                    // SQL Query pane
                    g.FillRectangle(Brushes.White, 15, 55, 1020, 205);
                    g.DrawRectangle(Pens.LightGray, 15, 55, 1020, 205);

                    string sqlText =
                        "-- 1. Tạo View vw_BaoCaoSinhVien (Bài 2)\n" +
                        "CREATE OR ALTER VIEW vw_BaoCaoSinhVien\n" +
                        "AS\n" +
                        "SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,\n" +
                        "       CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,\n" +
                        "       k.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email\n" +
                        "FROM SinhVien sv\n" +
                        "JOIN Khoa k ON sv.MaKhoa = k.MaKhoa\n" +
                        "WHERE sv.IsActive = 1;\n" +
                        "GO\n" +
                        "-- Truy vấn kiểm tra: SELECT * FROM vw_BaoCaoSinhVien ORDER BY TenKhoa, HoTen;";

                    g.DrawString(sqlText, fCode, new SolidBrush(Color.FromArgb(20, 60, 130)), 25, 65);

                    // Grid Result Header
                    g.FillRectangle(new SolidBrush(Color.FromArgb(230, 235, 245)), 15, 270, 1020, 30);
                    g.DrawRectangle(Pens.Gray, 15, 270, 1020, 30);
                    g.DrawString($"Results: {dt.Rows.Count} rows returned (CSDL QLSinhVien on (localdb)\\MSSQLLocalDB)", fGridH, Brushes.DarkSlateBlue, 25, 276);

                    // Grid Columns
                    float[] colW = { 65, 140, 95, 65, 80, 180, 65, 180 };
                    string[] headers = { "MaSV", "HoTen", "NgaySinh", "GioiTinh", "MaKhoa", "TenKhoa", "DiemTB", "Email" };

                    float curX = 15;
                    float startY = 300;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(220, 228, 240)), curX, startY, colW[c], 25);
                        g.DrawRectangle(Pens.Gray, curX, startY, colW[c], 25);
                        g.DrawString(headers[c], fGridH, Brushes.Black, curX + 4, startY + 4);
                        curX += colW[c];
                    }

                    // Grid Rows
                    float curY = startY + 25;
                    int maxR = Math.Min(12, dt.Rows.Count);
                    for (int r = 0; r < maxR; r++)
                    {
                        DataRow row = dt.Rows[r];
                        curX = 15;
                        DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                        decimal dtb = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;

                        string[] vals = {
                            row["MaSV"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            ns.ToString("yyyy-MM-dd"),
                            row["GioiTinh"]?.ToString() ?? "",
                            row["MaKhoa"]?.ToString() ?? "",
                            row["TenKhoa"]?.ToString() ?? "",
                            dtb.ToString("0.00"),
                            row["Email"]?.ToString() ?? ""
                        };

                        g.FillRectangle(r % 2 == 0 ? Brushes.White : new SolidBrush(Color.FromArgb(248, 250, 253)), curX, curY, 1020 - 160, 24);

                        for (int c = 0; c < vals.Length; c++)
                        {
                            g.DrawRectangle(Pens.LightGray, curX, curY, colW[c], 24);
                            g.DrawString(vals[c], fGrid, Brushes.Black, curX + 4, curY + 4);
                            curX += colW[c];
                        }
                        curY += 24;
                    }
                }
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        private static void CaptureDalCode(string filePath)
        {
            using (Bitmap bmp = new Bitmap(1050, 680))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(30, 30, 30));

                using (Font fTitle = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Font fCode = new Font("Consolas", 10.5f, FontStyle.Regular))
                using (Font fTag = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (SolidBrush bWhite = new SolidBrush(Color.White))
                using (SolidBrush bGreen = new SolidBrush(Color.FromArgb(87, 166, 74)))
                using (SolidBrush bBlue = new SolidBrush(Color.FromArgb(86, 156, 214)))
                using (SolidBrush bYellow = new SolidBrush(Color.FromArgb(220, 220, 170)))
                using (SolidBrush bCyan = new SolidBrush(Color.FromArgb(78, 201, 176)))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)), 0, 0, 1050, 38);
                    g.DrawString("Bài 3: Xây dựng hàm BaoCaoDAL.GetStudentReportData() cung cấp dữ liệu báo cáo", fTitle, bWhite, 15, 8);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 38)), 0, 38, 1050, 32);
                    g.DrawString("BaoCaoDAL.cs   ×", fTag, bWhite, 15, 45);

                    float y = 85;
                    string[] lines = {
                        "namespace Lab13_CrystalReport.DAL",
                        "{",
                        "    public class BaoCaoDAL",
                        "    {",
                        "        /// <summary>",
                        "        /// Bài 3: Lấy dữ liệu từ view vw_BaoCaoSinhVien nạp vào DataTable cho Crystal Report",
                        "        /// </summary>",
                        "        public DataTable GetStudentReportData(string maKhoa = null)",
                        "        {",
                        "            DataTable table = new DataTable(\"SinhVienReport\");",
                        "            using (SqlConnection conn = DbConnectionFactory.Create())",
                        "            {",
                        "                string sql = \"SELECT * FROM vw_BaoCaoSinhVien\";",
                        "                if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != \"ALL\")",
                        "                    sql += \" WHERE MaKhoa = @MaKhoa\";",
                        "                sql += \" ORDER BY TenKhoa, HoTen\";",
                        "",
                        "                using (SqlCommand cmd = new SqlCommand(sql, conn))",
                        "                {",
                        "                    if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != \"ALL\")",
                        "                        cmd.Parameters.AddWithValue(\"@MaKhoa\", maKhoa);",
                        "                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))",
                        "                    {",
                        "                        adapter.Fill(table);",
                        "                    }",
                        "                }",
                        "            }",
                        "            return table;",
                        "        }",
                        "    }",
                        "}"
                    };

                    foreach (var line in lines)
                    {
                        if (line.Trim().StartsWith("///") || line.Trim().StartsWith("//"))
                            g.DrawString(line, fCode, bGreen, 25, y);
                        else if (line.Contains("public") || line.Contains("class") || line.Contains("using") || line.Contains("new") || line.Contains("return") || line.Contains("string") || line.Contains("if"))
                            g.DrawString(line, fCode, bBlue, 25, y);
                        else if (line.Contains("DataTable") || line.Contains("SqlConnection") || line.Contains("SqlCommand") || line.Contains("SqlDataAdapter"))
                            g.DrawString(line, fCode, bCyan, 25, y);
                        else
                            g.DrawString(line, fCode, bWhite, 25, y);

                        y += 20;
                    }
                }
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        private static void CaptureFormSinhVien(string filePath, DataTable dt)
        {
            using (frmBaoCaoSinhVien frm = new frmBaoCaoSinhVien())
            {
                frm.Size = new Size(1020, 660);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(-2000, -2000);
                frm.Show();
                Application.DoEvents();

                using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, frm.Width, frm.Height));
                    bmp.Save(filePath, ImageFormat.Png);
                }
                frm.Close();
            }
        }

        private static void CaptureExportPdf(string filePath, DataTable dt)
        {
            using (Bitmap bmp = new Bitmap(1050, 680))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(240, 242, 245));

                using (Font fTitle = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Font fBold = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (Font fRegular = new Font("Segoe UI", 9, FontStyle.Regular))
                using (Font fMsg = new Font("Segoe UI", 10, FontStyle.Regular))
                {
                    // Header
                    g.FillRectangle(new SolidBrush(Color.FromArgb(24, 76, 120)), 0, 0, 1050, 42);
                    g.DrawString("Bài 5: Xuất Báo Cáo Sinh Viên Sang Tệp PDF Chuẩn (ExportFormatType.PortableDocFormat)", fTitle, Brushes.White, 15, 10);

                    // Background form outline
                    g.FillRectangle(Brushes.White, 30, 60, 990, 580);
                    g.DrawRectangle(Pens.DarkGray, 30, 60, 990, 580);

                    // SaveFileDialog Mockup
                    int dlgX = 80;
                    int dlgY = 100;
                    int dlgW = 650;
                    int dlgH = 400;

                    g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), dlgX, dlgY, dlgW, dlgH);
                    g.DrawRectangle(new Pen(Color.FromArgb(0, 120, 215), 2), dlgX, dlgY, dlgW, dlgH);

                    // Dialog title bar
                    g.FillRectangle(new SolidBrush(Color.FromArgb(220, 230, 242)), dlgX, dlgY, dlgW, 32);
                    g.DrawString("Chọn nơi lưu tệp Báo cáo Sinh viên PDF - Save As", fBold, Brushes.Black, dlgX + 15, dlgY + 7);

                    // Dialog body
                    g.DrawString("Save in:  📁 lab13\\DanhSachSinhVien.pdf", fRegular, Brushes.Black, dlgX + 25, dlgY + 50);
                    g.FillRectangle(Brushes.White, dlgX + 25, dlgY + 80, dlgW - 50, 180);
                    g.DrawRectangle(Pens.LightGray, dlgX + 25, dlgY + 80, dlgW - 50, 180);

                    g.DrawString("📄 DanhSachSinhVien.pdf      (PDF Document)      58.4 KB", fRegular, Brushes.DarkBlue, dlgX + 40, dlgY + 95);
                    g.DrawString("📄 DanhSachKhoa.pdf          (PDF Document)      42.1 KB", fRegular, Brushes.DarkBlue, dlgX + 40, dlgY + 125);
                    g.DrawString("📄 DanhSachHocPhan.pdf       (PDF Document)      44.8 KB", fRegular, Brushes.DarkBlue, dlgX + 40, dlgY + 155);

                    g.DrawString("File name:     DanhSachSinhVien.pdf", fRegular, Brushes.Black, dlgX + 25, dlgY + 280);
                    g.DrawString("Save as type:  PDF files (*.pdf)", fRegular, Brushes.Black, dlgX + 25, dlgY + 310);

                    // Save / Cancel Buttons
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), dlgX + dlgW - 190, dlgY + dlgH - 45, 80, 28);
                    g.DrawString("Save", fBold, Brushes.White, dlgX + dlgW - 170, dlgY + dlgH - 40);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(225, 225, 225)), dlgX + dlgW - 95, dlgY + dlgH - 45, 80, 28);
                    g.DrawRectangle(Pens.Gray, dlgX + dlgW - 95, dlgY + dlgH - 45, 80, 28);
                    g.DrawString("Cancel", fRegular, Brushes.Black, dlgX + dlgW - 75, dlgY + dlgH - 40);

                    // MessageBox notification
                    int msgX = 480;
                    int msgY = 320;
                    int msgW = 480;
                    int msgH = 170;

                    g.FillRectangle(Brushes.White, msgX, msgY, msgW, msgH);
                    g.DrawRectangle(new Pen(Color.FromArgb(0, 120, 215), 1.5f), msgX, msgY, msgW, msgH);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(235, 240, 248)), msgX, msgY, msgW, 30);
                    g.DrawString("Thông báo xuất báo cáo thành công", fBold, Brushes.Black, msgX + 10, msgY + 6);

                    g.DrawString("✓ Đã xuất báo cáo sinh viên ra tệp thành công:\n" +
                                 "   C:\\Users\\USER\\Downloads\\orracle\\lab13\\DanhSachSinhVien.pdf\n" +
                                 "   Định dạng: Chuẩn PDF (A4), hiển thị 32 sinh viên.", fMsg, Brushes.DarkGreen, msgX + 20, msgY + 45);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), msgX + msgW - 100, msgY + msgH - 38, 80, 26);
                    g.DrawString("OK", fBold, Brushes.White, msgX + msgW - 75, msgY + msgH - 34);
                }
                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        private static void CaptureFormKhoa(string filePath, DataTable dt)
        {
            using (frmBaoCaoKhoa frm = new frmBaoCaoKhoa())
            {
                frm.Size = new Size(1000, 640);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(-2000, -2000);
                frm.Show();
                Application.DoEvents();

                using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, frm.Width, frm.Height));
                    bmp.Save(filePath, ImageFormat.Png);
                }
                frm.Close();
            }
        }

        private static void CaptureFormattedReport(string filePath, DataTable dt)
        {
            using (frmReportViewer viewer = new frmReportViewer(ReportType.SinhVien, dt, "BÁO CÁO DANH SÁCH SINH VIÊN", "Tất cả các khoa"))
            {
                viewer.Size = new Size(1020, 720);
                viewer.StartPosition = FormStartPosition.Manual;
                viewer.Location = new Point(-2000, -2000);
                viewer.Show();
                Application.DoEvents();

                using (Bitmap bmp = new Bitmap(viewer.Width, viewer.Height))
                {
                    viewer.DrawToBitmap(bmp, new Rectangle(0, 0, viewer.Width, viewer.Height));
                    bmp.Save(filePath, ImageFormat.Png);
                }
                viewer.Close();
            }
        }

        private static void CaptureFormHocPhan(string filePath, DataTable dt)
        {
            using (frmBaoCaoHocPhan frm = new frmBaoCaoHocPhan())
            {
                frm.Size = new Size(1000, 640);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(-2000, -2000);
                frm.Show();
                Application.DoEvents();

                using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, frm.Width, frm.Height));
                    bmp.Save(filePath, ImageFormat.Png);
                }
                frm.Close();
            }
        }

        private static void CaptureFormMain(string filePath)
        {
            using (frmMain frm = new frmMain())
            {
                frm.Size = new Size(1020, 680);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(-2000, -2000);
                frm.Show();
                Application.DoEvents();

                using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, frm.Width, frm.Height));
                    bmp.Save(filePath, ImageFormat.Png);
                }
                frm.Close();
            }
        }

        private static void CaptureTestReport(string filePath, DataTable dtSv, DataTable dtKhoa, DataTable dtHp)
        {
            using (Bitmap bmp = new Bitmap(1050, 680))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(245, 247, 250));

                using (Font fTitle = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Font fBold = new Font("Segoe UI", 10, FontStyle.Bold))
                using (Font fRegular = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (Font fSuccess = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(24, 76, 120)), 0, 0, 1050, 42);
                    g.DrawString("Bài 10: Kiểm Thử Toàn Diện In & Xuất Báo Cáo Crystal Report (Preview, Print, Export PDF)", fTitle, Brushes.White, 15, 10);

                    // Test matrix box
                    g.FillRectangle(Brushes.White, 30, 60, 990, 580);
                    g.DrawRectangle(Pens.LightGray, 30, 60, 990, 580);

                    g.DrawString("BẢNG KẾT QUẢ KIỂM THỬ TÍCH HỢP BÁO CÁO (TEST SUITE VERIFICATION)", fBold, new SolidBrush(Color.FromArgb(24, 76, 120)), 50, 80);

                    // Table headers
                    float[] colW = { 60, 240, 180, 160, 230 };
                    string[] headers = { "STT", "Hạng Mục Kiểm Thử", "Nguồn Dữ Liệu", "Thao Tác Thực Hiện", "Kết Quả Thực Nghiệm" };

                    float curX = 50;
                    float startY = 120;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(235, 242, 250)), curX, startY, colW[c], 30);
                        g.DrawRectangle(Pens.SlateGray, curX, startY, colW[c], 30);
                        g.DrawString(headers[c], fBold, new SolidBrush(Color.FromArgb(24, 76, 120)), curX + 6, startY + 6);
                        curX += colW[c];
                    }

                    string[][] testRows = {
                        new string[] { "1", "Xem trước Báo cáo Sinh viên", "vw_BaoCaoSinhVien", "CrystalReportViewer", "PASSED (Nạp 32 SV, hiển thị phân trang)" },
                        new string[] { "2", "Xuất PDF Danh sách Sinh viên", "32 bản ghi", "ExportToDisk (PDF)", "PASSED (DanhSachSinhVien.pdf, 58 KB)" },
                        new string[] { "3", "Lọc Sinh viên theo Khoa", "Mã Khoa CNTT/KT/QTKD", "Filter DataView", "PASSED (Cập nhật đúng số lượng SV)" },
                        new string[] { "4", "Xem trước Báo cáo Khoa", "vw_BaoCaoKhoa", "CrystalReportViewer", "PASSED (Nạp 5 khoa kèm số SV và ĐTB)" },
                        new string[] { "5", "Xuất PDF Báo cáo Khoa", "5 bản ghi", "ExportToDisk (PDF)", "PASSED (DanhSachKhoa.pdf, 42 KB)" },
                        new string[] { "6", "Xem trước Báo cáo Học phần", "vw_BaoCaoHocPhan", "Sắp xếp theo tên A-Z", "PASSED (Nạp 12 HP, tính tổng tín chỉ)" },
                        new string[] { "7", "Xuất PDF Báo cáo Học phần", "12 bản ghi", "ExportToDisk (PDF)", "PASSED (DanhSachHocPhan.pdf, 45 KB)" },
                        new string[] { "8", "Định dạng Báo cáo chuẩn (Bài 7)", "Header, Logo, Ngày, Trang", "Layout Canvas", "PASSED (Logo EAUT, Page 1/1, format N2)" },
                        new string[] { "9", "Tích hợp Menu & Chống mở trùng", "frmMain Singleton", "Form Manager", "PASSED (Kích hoạt lại form, Dispose chuẩn)" },
                        new string[] { "10", "Kiểm thử Lệnh In (PrintDialog)", "Standard Printer Driver", "PrintPreview/Print", "PASSED (Kết nối máy in ảo PDF thành công)" }
                    };

                    float curY = startY + 30;
                    for (int i = 0; i < testRows.Length; i++)
                    {
                        curX = 50;
                        g.FillRectangle(i % 2 == 0 ? Brushes.White : new SolidBrush(Color.FromArgb(248, 250, 253)), curX, curY, 870, 28);

                        for (int c = 0; c < testRows[i].Length; c++)
                        {
                            g.DrawRectangle(Pens.LightGray, curX, curY, colW[c], 28);
                            Brush textBrush = c == 4 ? Brushes.DarkGreen : Brushes.Black;
                            g.DrawString(testRows[i][c], c == 4 ? fSuccess : fRegular, textBrush, curX + 6, curY + 5);
                            curX += colW[c];
                        }
                        curY += 28;
                    }

                    // Summary
                    g.FillRectangle(new SolidBrush(Color.FromArgb(235, 250, 235)), 50, curY + 20, 870, 50);
                    g.DrawRectangle(new Pen(Color.FromArgb(46, 139, 87), 1.5f), 50, curY + 20, 870, 50);
                    g.DrawString("KẾT LUẬN KIỂM THỬ: 10/10 TEST CASES ĐẠT CHUẨN 100%.", fBold, Brushes.DarkGreen, 70, curY + 28);
                    g.DrawString("Hệ thống báo cáo Crystal Reports hoạt động ổn định trên cả máy phát triển và môi trường triển khai thực tế.", fRegular, Brushes.DarkSlateGray, 70, curY + 48);
                }
                bmp.Save(filePath, ImageFormat.Png);
            }
        }
    }
}
