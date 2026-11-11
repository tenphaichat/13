using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Lab13_CrystalReport.DTO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Lab13_CrystalReport.BUS
{
    /// <summary>
    /// Helper xuất báo cáo chuyên nghiệp ra PDF theo đúng yêu cầu Bài 5, Bài 7, Bài 10:
    /// - Tiêu đề trường, khoa, bộ môn
    /// - Ngày lập báo cáo định dạng dd/MM/yyyy HH:mm
    /// - Đánh số trang "Trang N / M"
    /// - Đường kẻ phân cách, bảng dữ liệu chuẩn chỉ
    /// - Định dạng điểm số N2, ngày sinh dd/MM/yyyy
    /// </summary>
    public static class PdfExportHelper
    {
        public static void ExportSinhVienPdf(DataTable data, string filePath, string tieuDePhu = "Tất cả các khoa")
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "BÁO CÁO DANH SÁCH SINH VIÊN";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            int rowsPerPage = 22;
            int totalRows = data.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)Math.Max(1, totalRows) / rowsPerPage);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 10, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(240, 244, 250));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            for (int p = 0; p < totalPages; p++)
            {
                PdfPage page = doc.AddPage();
                page.Size = PdfSharp.PageSize.A4;
                page.Orientation = PdfSharp.PageOrientation.Portrait;
                XGraphics gfx = XGraphics.FromPdfPage(page);

                double left = 35;
                double top = 35;
                double width = page.Width.Point - 70;

                // Header
                gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
                gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

                gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
                gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
                gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);

                gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

                // Title
                double titleY = top + 55;
                gfx.DrawString("BÁO CÁO DANH SÁCH SINH VIÊN", fontTitle, brushTextBlue, new XRect(left, titleY, width, 25), XStringFormats.TopCenter);
                gfx.DrawString($"Khoa áp dụng: {tieuDePhu} | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 22, width, 18), XStringFormats.TopCenter);

                // Table Layout
                double startY = titleY + 48;
                double[] colWidths = { 35, 60, 115, 65, 45, 95, 45, 90 };
                string[] headers = { "STT", "Mã SV", "Họ và tên", "Ngày sinh", "Giới", "Khoa", "ĐTB", "Email" };

                // Draw Table Header
                double curX = left;
                for (int c = 0; c < headers.Length; c++)
                {
                    gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 22);
                    gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 22);
                    gfx.DrawString(headers[c], fontTh, brushTextBlue,
                        new XRect(curX + 2, startY + 4, colWidths[c] - 4, 16),
                        c == 0 || c == 1 || c == 3 || c == 4 || c == 6 ? XStringFormats.TopCenter : XStringFormats.TopLeft);
                    curX += colWidths[c];
                }

                // Draw Table Rows
                double curY = startY + 22;
                int startRow = p * rowsPerPage;
                int endRow = Math.Min(startRow + rowsPerPage, totalRows);

                for (int r = startRow; r < endRow; r++)
                {
                    DataRow row = data.Rows[r];
                    curX = left;

                    string stt = (r + 1).ToString();
                    string maSV = row["MaSV"]?.ToString() ?? "";
                    string hoTen = row["HoTen"]?.ToString() ?? "";
                    DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                    string ngaySinh = ns != DateTime.MinValue ? ns.ToString("dd/MM/yyyy") : "";
                    string gioiTinh = row["GioiTinh"]?.ToString() ?? "";
                    string tenKhoa = row["TenKhoa"]?.ToString() ?? "";
                    decimal dtb = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                    string diemTB = dtb.ToString("N2");
                    string email = row["Email"]?.ToString() ?? "";

                    string[] vals = { stt, maSV, hoTen, ngaySinh, gioiTinh, tenKhoa, diemTB, email };

                    XBrush rowBg = (r % 2 == 0) ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252));
                    gfx.DrawRectangle(rowBg, curX, curY, width, 19);

                    for (int c = 0; c < vals.Length; c++)
                    {
                        gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 19);
                        XStringFormat fmt = (c == 0 || c == 1 || c == 3 || c == 4) ? XStringFormats.TopCenter :
                                            (c == 6 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                        gfx.DrawString(vals[c], fontTd, brushText,
                            new XRect(curX + 3, curY + 3.5, colWidths[c] - 6, 14), fmt);
                        curX += colWidths[c];
                    }
                    curY += 19;
                }

                // Footer
                if (p == totalPages - 1)
                {
                    double summaryY = curY + 12;
                    gfx.DrawString($"Tổng số sinh viên: {totalRows} sinh viên", fontTh, brushTextBlue, left, summaryY);

                    double signY = summaryY + 20;
                    gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
                    gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
                    gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 55);
                }

                // Page numbering (Page N of M)
                string pageInfo = $"Trang {p + 1} / {totalPages}";
                gfx.DrawString(pageInfo, fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 35, width, 15), XStringFormats.TopCenter);
                gfx.DrawString("Học phần: Lập trình .NET (IT3212) - EAUT", fontFooter, XBrushes.Gray, left, page.Height.Point - 35);
            }

            doc.Save(filePath);
        }

        public static void ExportKhoaPdf(DataTable data, string filePath)
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "BÁO CÁO DANH SÁCH KHOA VÀ SỐ LƯỢNG SINH VIÊN";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            PdfPage page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 10, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9.5, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(235, 242, 250));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            double left = 45;
            double top = 40;
            double width = page.Width.Point - 90;

            // Header
            gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
            gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

            gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
            gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
            gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);

            gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

            // Title
            double titleY = top + 60;
            gfx.DrawString("BÁO CÁO THỐNG KÊ SINH VIÊN THEO KHOA", fontTitle, brushTextBlue, new XRect(left, titleY, width, 25), XStringFormats.TopCenter);
            gfx.DrawString($"Thời điểm kết xuất: {DateTime.Now:dd/MM/yyyy HH:mm} | Hệ thống quản lý đào tạo", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 22, width, 18), XStringFormats.TopCenter);

            // Table Layout
            double startY = titleY + 50;
            double[] colWidths = { 45, 90, 195, 85, 90 };
            string[] headers = { "STT", "Mã Khoa", "Tên Khoa", "Số lượng SV", "ĐTB Khoa" };

            double curX = left;
            for (int c = 0; c < headers.Length; c++)
            {
                gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 24);
                gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 24);
                gfx.DrawString(headers[c], fontTh, brushTextBlue,
                    new XRect(curX + 2, startY + 5, colWidths[c] - 4, 18),
                    c == 0 || c == 1 ? XStringFormats.TopCenter : (c >= 3 ? XStringFormats.TopRight : XStringFormats.TopLeft));
                curX += colWidths[c];
            }

            double curY = startY + 24;
            int totalSv = 0;

            for (int r = 0; r < data.Rows.Count; r++)
            {
                DataRow row = data.Rows[r];
                curX = left;
                int sl = row["SoLuongSinhVien"] != DBNull.Value ? Convert.ToInt32(row["SoLuongSinhVien"]) : 0;
                totalSv += sl;
                decimal dtb = row["DiemTrungBinhKhoa"] != DBNull.Value ? Convert.ToDecimal(row["DiemTrungBinhKhoa"]) : 0.0m;

                string[] vals = {
                    (r + 1).ToString(),
                    row["MaKhoa"]?.ToString() ?? "",
                    row["TenKhoa"]?.ToString() ?? "",
                    sl.ToString(),
                    dtb.ToString("N2")
                };

                XBrush rowBg = (r % 2 == 0) ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252));
                gfx.DrawRectangle(rowBg, curX, curY, width, 22);

                for (int c = 0; c < vals.Length; c++)
                {
                    gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 22);
                    XStringFormat fmt = (c == 0 || c == 1) ? XStringFormats.TopCenter :
                                        (c >= 3 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                    gfx.DrawString(vals[c], fontTd, brushText,
                        new XRect(curX + 4, curY + 4, colWidths[c] - 8, 16), fmt);
                    curX += colWidths[c];
                }
                curY += 22;
            }

            // Summary
            curX = left;
            gfx.DrawRectangle(brushThBg, curX, curY, colWidths[0] + colWidths[1] + colWidths[2], 22);
            gfx.DrawRectangle(penThBorder, curX, curY, colWidths[0] + colWidths[1] + colWidths[2], 22);
            gfx.DrawString("TỔNG CỘNG:", fontTh, brushTextBlue,
                new XRect(curX + 10, curY + 4, colWidths[0] + colWidths[1] + colWidths[2] - 20, 16), XStringFormats.TopRight);

            curX += colWidths[0] + colWidths[1] + colWidths[2];
            gfx.DrawRectangle(brushThBg, curX, curY, colWidths[3], 22);
            gfx.DrawRectangle(penThBorder, curX, curY, colWidths[3], 22);
            gfx.DrawString(totalSv.ToString(), fontTh, brushTextBlue,
                new XRect(curX + 4, curY + 4, colWidths[3] - 8, 16), XStringFormats.TopRight);

            curX += colWidths[3];
            gfx.DrawRectangle(brushThBg, curX, curY, colWidths[4], 22);
            gfx.DrawRectangle(penThBorder, curX, curY, colWidths[4], 22);

            // Sign
            double signY = curY + 35;
            gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
            gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
            gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 55);

            // Page info
            gfx.DrawString("Trang 1 / 1", fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 35, width, 15), XStringFormats.TopCenter);
            gfx.DrawString("Học phần: Lập trình .NET (IT3212) - EAUT", fontFooter, XBrushes.Gray, left, page.Height.Point - 35);

            doc.Save(filePath);
        }

        public static void ExportHocPhanPdf(DataTable data, string filePath)
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "BÁO CÁO DANH SÁCH HỌC PHẦN";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            PdfPage page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 10, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9.5, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(235, 242, 250));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            double left = 45;
            double top = 40;
            double width = page.Width.Point - 90;

            // Header
            gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
            gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

            gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
            gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
            gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);

            gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

            // Title
            double titleY = top + 60;
            gfx.DrawString("BÁO CÁO DANH SÁCH HỌC PHẦN ĐÀO TẠO", fontTitle, brushTextBlue, new XRect(left, titleY, width, 25), XStringFormats.TopCenter);
            gfx.DrawString($"Sắp xếp theo tên học phần (A-Z) | Ngày kết xuất: {DateTime.Now:dd/MM/yyyy HH:mm}", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 22, width, 18), XStringFormats.TopCenter);

            // Table Layout
            double startY = titleY + 50;
            double[] colWidths = { 45, 90, 215, 75, 80 };
            string[] headers = { "STT", "Mã HP", "Tên học phần", "Số tín chỉ", "Số SV đăng ký" };

            double curX = left;
            for (int c = 0; c < headers.Length; c++)
            {
                gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 24);
                gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 24);
                gfx.DrawString(headers[c], fontTh, brushTextBlue,
                    new XRect(curX + 2, startY + 5, colWidths[c] - 4, 18),
                    c == 0 || c == 1 ? XStringFormats.TopCenter : (c >= 3 ? XStringFormats.TopRight : XStringFormats.TopLeft));
                curX += colWidths[c];
            }

            double curY = startY + 24;
            int totalTinChi = 0;

            for (int r = 0; r < data.Rows.Count; r++)
            {
                DataRow row = data.Rows[r];
                curX = left;
                int stc = row["SoTinChi"] != DBNull.Value ? Convert.ToInt32(row["SoTinChi"]) : 0;
                totalTinChi += stc;
                int slDk = row["SoLuongDangKy"] != DBNull.Value ? Convert.ToInt32(row["SoLuongDangKy"]) : 0;

                string[] vals = {
                    (r + 1).ToString(),
                    row["MaHP"]?.ToString() ?? "",
                    row["TenHP"]?.ToString() ?? "",
                    stc.ToString(),
                    slDk.ToString()
                };

                XBrush rowBg = (r % 2 == 0) ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252));
                gfx.DrawRectangle(rowBg, curX, curY, width, 22);

                for (int c = 0; c < vals.Length; c++)
                {
                    gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 22);
                    XStringFormat fmt = (c == 0 || c == 1) ? XStringFormats.TopCenter :
                                        (c >= 3 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                    gfx.DrawString(vals[c], fontTd, brushText,
                        new XRect(curX + 4, curY + 4, colWidths[c] - 8, 16), fmt);
                    curX += colWidths[c];
                }
                curY += 22;
            }

            // Summary
            curX = left;
            gfx.DrawRectangle(brushThBg, curX, curY, colWidths[0] + colWidths[1] + colWidths[2], 22);
            gfx.DrawRectangle(penThBorder, curX, curY, colWidths[0] + colWidths[1] + colWidths[2], 22);
            gfx.DrawString($"Tổng cộng: {data.Rows.Count} học phần", fontTh, brushTextBlue,
                new XRect(curX + 10, curY + 4, colWidths[0] + colWidths[1] + colWidths[2] - 20, 16), XStringFormats.TopLeft);

            curX += colWidths[0] + colWidths[1] + colWidths[2];
            gfx.DrawRectangle(brushThBg, curX, curY, colWidths[3], 22);
            gfx.DrawRectangle(penThBorder, curX, curY, colWidths[3], 22);
            gfx.DrawString(totalTinChi.ToString(), fontTh, brushTextBlue,
                new XRect(curX + 4, curY + 4, colWidths[3] - 8, 16), XStringFormats.TopRight);

            curX += colWidths[3];
            gfx.DrawRectangle(brushThBg, curX, curY, colWidths[4], 22);
            gfx.DrawRectangle(penThBorder, curX, curY, colWidths[4], 22);

            // Sign
            double signY = curY + 35;
            gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
            gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
            gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 55);

            // Page info
            gfx.DrawString("Trang 1 / 1", fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 35, width, 15), XStringFormats.TopCenter);
            gfx.DrawString("Học phần: Lập trình .NET (IT3212) - EAUT", fontFooter, XBrushes.Gray, left, page.Height.Point - 35);

            doc.Save(filePath);
        }
    }
}
