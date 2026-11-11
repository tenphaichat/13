using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;
using Lab13_CrystalReport.GUI;

namespace Lab13_CrystalReport
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            // Nếu truyền tham số --capture thì thực hiện chụp tự động và xuất báo cáo mẫu PDF
            if (args.Length > 0 && args[0].Equals("--capture", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string rootDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
                    string screenshotsDir = Path.Combine(rootDir, "screenshots");
                    
                    Console.WriteLine($"[Program] Đang xuất báo cáo mẫu và chụp ảnh minh chứng tại: {screenshotsDir}");
                    ScreenshotCapture.RunCaptureAll(screenshotsDir);

                    // Xuất 3 file PDF mẫu ra thư mục gốc lab13
                    BaoCaoBUS bus = new BaoCaoBUS();
                    string pdfSv = Path.Combine(rootDir, "DanhSachSinhVien.pdf");
                    string pdfKhoa = Path.Combine(rootDir, "DanhSachKhoa.pdf");
                    string pdfHp = Path.Combine(rootDir, "DanhSachHocPhan.pdf");

                    PdfExportHelper.ExportSinhVienPdf(bus.GetStudentReportData(), pdfSv, "Tất cả các khoa");
                    Console.WriteLine($"[Program] Đã xuất: {pdfSv}");

                    PdfExportHelper.ExportKhoaPdf(bus.GetFacultyReportData(), pdfKhoa);
                    Console.WriteLine($"[Program] Đã xuất: {pdfKhoa}");

                    PdfExportHelper.ExportHocPhanPdf(bus.GetCourseReportData(), pdfHp);
                    Console.WriteLine($"[Program] Đã xuất: {pdfHp}");

                    Console.WriteLine("[Program] Hoàn tất quá trình tạo minh chứng và PDF mẫu!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Program Error] {ex}");
                }
                return;
            }

            Application.Run(new frmMain());
        }
    }
}
