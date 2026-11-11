using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;

namespace Lab13_CrystalReport.GUI
{
    public enum ReportType
    {
        SinhVien,
        Khoa,
        HocPhan
    }

    public partial class frmReportViewer : Form
    {
        private DataTable _dataSource;
        private ReportType _reportType;
        private string _reportTitle;
        private string _filterInfo;
        private float _zoomLevel = 1.0f;
        private int _currentPage = 1;
        private int _totalPages = 1;

        public frmReportViewer(ReportType reportType, DataTable dataSource, string reportTitle = "", string filterInfo = "")
        {
            _reportType = reportType;
            _dataSource = dataSource;
            _reportTitle = reportTitle;
            _filterInfo = filterInfo;

            InitializeComponent();
            SetupReportDimensions();
        }

        private void SetupReportDimensions()
        {
            if (_reportType == ReportType.SinhVien)
            {
                int count = _dataSource != null ? _dataSource.Rows.Count : 0;
                _totalPages = (int)Math.Ceiling((double)Math.Max(1, count) / 22);
            }
            else
            {
                _totalPages = 1;
            }
            UpdateToolbar();
        }

        public void RefreshData(DataTable newData, string filterInfo = "")
        {
            _dataSource = newData;
            _filterInfo = filterInfo;
            SetupReportDimensions();
            panelCanvas.Invalidate();
        }

        private void UpdateToolbar()
        {
            lblPageInfo.Text = $"Trang {_currentPage} / {_totalPages}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            lblZoom.Text = $"{(int)(_zoomLevel * 100)}%";
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateToolbar();
                panelCanvas.Invalidate();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                UpdateToolbar();
                panelCanvas.Invalidate();
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (_zoomLevel < 1.8f)
            {
                _zoomLevel += 0.15f;
                UpdateCanvasSize();
                UpdateToolbar();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (_zoomLevel > 0.6f)
            {
                _zoomLevel -= 0.15f;
                UpdateCanvasSize();
                UpdateToolbar();
            }
        }

        private void UpdateCanvasSize()
        {
            int baseW = 820;
            int baseH = 1120;
            panelCanvas.Size = new Size((int)(baseW * _zoomLevel), (int)(baseH * _zoomLevel));
            panelCanvas.Invalidate();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Document (*.pdf)|*.pdf";
                dlg.DefaultExt = "pdf";
                dlg.FileName = _reportType == ReportType.SinhVien ? "DanhSachSinhVien.pdf" :
                               _reportType == ReportType.Khoa ? "DanhSachKhoa.pdf" : "DanhSachHocPhan.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (_reportType == ReportType.SinhVien)
                            PdfExportHelper.ExportSinhVienPdf(_dataSource, dlg.FileName, _filterInfo);
                        else if (_reportType == ReportType.Khoa)
                            PdfExportHelper.ExportKhoaPdf(_dataSource, dlg.FileName);
                        else
                            PdfExportHelper.ExportHocPhanPdf(_dataSource, dlg.FileName);

                        MessageBox.Show($"Báo cáo đã được xuất thành công ra PDF:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Lệnh in đã được chuyển đến máy in thành công.", "Thông báo In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            panelCanvas.Invalidate();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.ScaleTransform(_zoomLevel, _zoomLevel);

            using (Font fOrg = new Font("Arial", 9, FontStyle.Regular))
            using (Font fOrgB = new Font("Arial", 9, FontStyle.Bold))
            using (Font fTitle = new Font("Arial", 16, FontStyle.Bold))
            using (Font fSub = new Font("Arial", 9.5f, FontStyle.Italic))
            using (Font fTh = new Font("Arial", 9, FontStyle.Bold))
            using (Font fTd = new Font("Arial", 8.5f, FontStyle.Regular))
            using (Font fFooter = new Font("Arial", 8.5f, FontStyle.Italic))
            using (Pen pLine = new Pen(Color.FromArgb(180, 180, 180), 1))
            using (Pen pBorder = new Pen(Color.FromArgb(210, 215, 225), 1))
            using (Pen pThBorder = new Pen(Color.FromArgb(50, 90, 140), 1.2f))
            using (SolidBrush bTh = new SolidBrush(Color.FromArgb(238, 243, 250)))
            using (SolidBrush bBlue = new SolidBrush(Color.FromArgb(20, 60, 110)))
            using (SolidBrush bText = new SolidBrush(Color.FromArgb(30, 30, 30)))
            using (SolidBrush bAlt = new SolidBrush(Color.FromArgb(249, 251, 254)))
            {
                float left = 40;
                float top = 40;
                float width = 740;

                // Header
                g.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fOrgB, bBlue, left, top);
                g.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - BỘ MÔN CÔNG NGHỆ PHẦN MỀM", fOrg, bText, left, top + 18);
                g.DrawString("Học phần: Lập trình .NET (IT3212)", fOrg, Brushes.DimGray, left, top + 34);

                g.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fOrgB, bText, width + left - 250, top);
                g.DrawString("Độc lập - Tự do - Hạnh phúc", fOrg, bText, width + left - 210, top + 18);
                g.DrawLine(pLine, width + left - 180, top + 36, width + left - 60, top + 36);

                g.DrawLine(pLine, left, top + 55, left + width, top + 55);

                // Title
                float titleY = top + 75;
                StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                StringFormat sfLeft = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

                string mainTitle = _reportType == ReportType.SinhVien ? "BÁO CÁO DANH SÁCH SINH VIÊN" :
                                  _reportType == ReportType.Khoa ? "BÁO CÁO THỐNG KÊ SINH VIÊN THEO KHOA" :
                                  "BÁO CÁO DANH SÁCH HỌC PHẦN ĐÀO TẠO";

                g.DrawString(mainTitle, fTitle, bBlue, new RectangleF(left, titleY, width, 28), sfCenter);

                string subTitle = _reportType == ReportType.SinhVien ? $"Khoa áp dụng: {(!string.IsNullOrEmpty(_filterInfo) ? _filterInfo : "Tất cả")} | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}" :
                                  _reportType == ReportType.Khoa ? $"Thống kê tổng hợp số lượng sinh viên theo từng khoa | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}" :
                                  $"Danh mục học phần toàn trường sắp xếp theo tên (A-Z) | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}";

                g.DrawString(subTitle, fSub, Brushes.DimGray, new RectangleF(left, titleY + 28, width, 20), sfCenter);

                // Table Render
                float startY = titleY + 60;

                if (_reportType == ReportType.SinhVien)
                {
                    float[] colW = { 40, 75, 150, 85, 55, 125, 60, 150 };
                    string[] headers = { "STT", "Mã SV", "Họ và tên", "Ngày sinh", "Phái", "Khoa", "ĐTB", "Email" };

                    float curX = left;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(bTh, curX, startY, colW[c], 26);
                        g.DrawRectangle(pThBorder, curX, startY, colW[c], 26);
                        g.DrawString(headers[c], fTh, bBlue, new RectangleF(curX + 2, startY, colW[c] - 4, 26),
                            c == 0 || c == 1 || c == 3 || c == 4 || c == 6 ? sfCenter : sfLeft);
                        curX += colW[c];
                    }

                    float curY = startY + 26;
                    int rowsPerPage = 22;
                    int startIdx = (_currentPage - 1) * rowsPerPage;
                    int endIdx = _dataSource != null ? Math.Min(startIdx + rowsPerPage, _dataSource.Rows.Count) : 0;

                    for (int r = startIdx; r < endIdx; r++)
                    {
                        DataRow row = _dataSource.Rows[r];
                        curX = left;

                        DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                        decimal dtb = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;

                        string[] vals = {
                            (r + 1).ToString(),
                            row["MaSV"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            ns != DateTime.MinValue ? ns.ToString("dd/MM/yyyy") : "",
                            row["GioiTinh"]?.ToString() ?? "",
                            row["TenKhoa"]?.ToString() ?? "",
                            dtb.ToString("N2"),
                            row["Email"]?.ToString() ?? ""
                        };

                        if (r % 2 == 1)
                            g.FillRectangle(bAlt, curX, curY, width, 22);

                        for (int c = 0; c < vals.Length; c++)
                        {
                            g.DrawRectangle(pBorder, curX, curY, colW[c], 22);
                            StringFormat fmt = (c == 0 || c == 1 || c == 3 || c == 4) ? sfCenter :
                                               (c == 6 ? sfRight : sfLeft);
                            g.DrawString(vals[c], fTd, bText, new RectangleF(curX + 4, curY, colW[c] - 8, 22), fmt);
                            curX += colW[c];
                        }
                        curY += 22;
                    }

                    if (_currentPage == _totalPages)
                    {
                        float sumY = curY + 15;
                        g.DrawString($"Tổng cộng: {_dataSource?.Rows.Count ?? 0} sinh viên", fTh, bBlue, left, sumY);

                        float signY = sumY + 30;
                        g.DrawString("Người lập biểu", fOrgB, bText, width + left - 150, signY);
                        g.DrawString("(Ký, họ tên)", fSub, Brushes.Gray, width + left - 135, signY + 18);
                        g.DrawString("Phan Văn Thắng", fOrgB, bBlue, width + left - 155, signY + 65);
                    }
                }
                else if (_reportType == ReportType.Khoa)
                {
                    float[] colW = { 50, 110, 260, 160, 160 };
                    string[] headers = { "STT", "Mã Khoa", "Tên Khoa Quản Lý", "Số Lượng Sinh Viên", "Điểm Trung Bình Khoa" };

                    float curX = left;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(bTh, curX, startY, colW[c], 26);
                        g.DrawRectangle(pThBorder, curX, startY, colW[c], 26);
                        g.DrawString(headers[c], fTh, bBlue, new RectangleF(curX + 2, startY, colW[c] - 4, 26),
                            c <= 1 ? sfCenter : (c >= 3 ? sfRight : sfLeft));
                        curX += colW[c];
                    }

                    float curY = startY + 26;
                    int totalSv = 0;

                    if (_dataSource != null)
                    {
                        for (int r = 0; r < _dataSource.Rows.Count; r++)
                        {
                            DataRow row = _dataSource.Rows[r];
                            curX = left;

                            int sl = row["SoLuongSinhVien"] != DBNull.Value ? Convert.ToInt32(row["SoLuongSinhVien"]) : 0;
                            totalSv += sl;
                            decimal dtb = row["DiemTrungBinhKhoa"] != DBNull.Value ? Convert.ToDecimal(row["DiemTrungBinhKhoa"]) : 0.0m;

                            string[] vals = {
                                (r + 1).ToString(),
                                row["MaKhoa"]?.ToString() ?? "",
                                row["TenKhoa"]?.ToString() ?? "",
                                sl.ToString("N0"),
                                dtb.ToString("N2")
                            };

                            if (r % 2 == 1)
                                g.FillRectangle(bAlt, curX, curY, width, 24);

                            for (int c = 0; c < vals.Length; c++)
                            {
                                g.DrawRectangle(pBorder, curX, curY, colW[c], 24);
                                StringFormat fmt = c <= 1 ? sfCenter : (c >= 3 ? sfRight : sfLeft);
                                g.DrawString(vals[c], fTd, bText, new RectangleF(curX + 5, curY, colW[c] - 10, 24), fmt);
                                curX += colW[c];
                            }
                            curY += 24;
                        }

                        // Summary
                        curX = left;
                        float w3 = colW[0] + colW[1] + colW[2];
                        g.FillRectangle(bTh, curX, curY, w3, 24);
                        g.DrawRectangle(pThBorder, curX, curY, w3, 24);
                        g.DrawString("TỔNG CỘNG:", fTh, bBlue, new RectangleF(curX, curY, w3 - 10, 24), sfRight);

                        curX += w3;
                        g.FillRectangle(bTh, curX, curY, colW[3], 24);
                        g.DrawRectangle(pThBorder, curX, curY, colW[3], 24);
                        g.DrawString(totalSv.ToString("N0"), fTh, bBlue, new RectangleF(curX, curY, colW[3] - 8, 24), sfRight);

                        curX += colW[3];
                        g.FillRectangle(bTh, curX, curY, colW[4], 24);
                        g.DrawRectangle(pThBorder, curX, curY, colW[4], 24);

                        float signY = curY + 45;
                        g.DrawString("Người lập biểu", fOrgB, bText, width + left - 150, signY);
                        g.DrawString("(Ký, họ tên)", fSub, Brushes.Gray, width + left - 135, signY + 18);
                        g.DrawString("Phan Văn Thắng", fOrgB, bBlue, width + left - 155, signY + 65);
                    }
                }
                else if (_reportType == ReportType.HocPhan)
                {
                    float[] colW = { 50, 110, 300, 130, 150 };
                    string[] headers = { "STT", "Mã HP", "Tên Học Phần Đào Tạo", "Số Tín Chỉ", "Số SV Đăng Ký" };

                    float curX = left;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(bTh, curX, startY, colW[c], 26);
                        g.DrawRectangle(pThBorder, curX, startY, colW[c], 26);
                        g.DrawString(headers[c], fTh, bBlue, new RectangleF(curX + 2, startY, colW[c] - 4, 26),
                            c <= 1 ? sfCenter : (c >= 3 ? sfRight : sfLeft));
                        curX += colW[c];
                    }

                    float curY = startY + 26;
                    int totalTinChi = 0;

                    if (_dataSource != null)
                    {
                        for (int r = 0; r < _dataSource.Rows.Count; r++)
                        {
                            DataRow row = _dataSource.Rows[r];
                            curX = left;

                            int stc = row["SoTinChi"] != DBNull.Value ? Convert.ToInt32(row["SoTinChi"]) : 0;
                            totalTinChi += stc;
                            int sldk = row["SoLuongDangKy"] != DBNull.Value ? Convert.ToInt32(row["SoLuongDangKy"]) : 0;

                            string[] vals = {
                                (r + 1).ToString(),
                                row["MaHP"]?.ToString() ?? "",
                                row["TenHP"]?.ToString() ?? "",
                                stc.ToString(),
                                sldk.ToString()
                            };

                            if (r % 2 == 1)
                                g.FillRectangle(bAlt, curX, curY, width, 24);

                            for (int c = 0; c < vals.Length; c++)
                            {
                                g.DrawRectangle(pBorder, curX, curY, colW[c], 24);
                                StringFormat fmt = c <= 1 ? sfCenter : (c >= 3 ? sfRight : sfLeft);
                                g.DrawString(vals[c], fTd, bText, new RectangleF(curX + 5, curY, colW[c] - 10, 24), fmt);
                                curX += colW[c];
                            }
                            curY += 24;
                        }

                        // Summary
                        curX = left;
                        float w3 = colW[0] + colW[1] + colW[2];
                        g.FillRectangle(bTh, curX, curY, w3, 24);
                        g.DrawRectangle(pThBorder, curX, curY, w3, 24);
                        g.DrawString($"Tổng cộng: {_dataSource.Rows.Count} học phần", fTh, bBlue, new RectangleF(curX + 10, curY, w3 - 20, 24), sfLeft);

                        curX += w3;
                        g.FillRectangle(bTh, curX, curY, colW[3], 24);
                        g.DrawRectangle(pThBorder, curX, curY, colW[3], 24);
                        g.DrawString(totalTinChi.ToString(), fTh, bBlue, new RectangleF(curX, curY, colW[3] - 8, 24), sfRight);

                        curX += colW[3];
                        g.FillRectangle(bTh, curX, curY, colW[4], 24);
                        g.DrawRectangle(pThBorder, curX, curY, colW[4], 24);

                        float signY = curY + 45;
                        g.DrawString("Người lập biểu", fOrgB, bText, width + left - 150, signY);
                        g.DrawString("(Ký, họ tên)", fSub, Brushes.Gray, width + left - 135, signY + 18);
                        g.DrawString("Phan Văn Thắng", fOrgB, bBlue, width + left - 155, signY + 65);
                    }
                }

                // Page numbering footer
                float footY = 1080;
                g.DrawLine(pLine, left, footY - 10, left + width, footY - 10);
                g.DrawString($"Trang {_currentPage} / {_totalPages}", fFooter, Brushes.Gray, new RectangleF(left, footY, width, 18), sfCenter);
                g.DrawString("Phần mềm Quản lý Đào tạo EAUT - Crystal Report", fFooter, Brushes.Gray, left, footY);
            }
        }
    }
}
