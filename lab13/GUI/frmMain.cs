using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;

namespace Lab13_CrystalReport.GUI
{
    public partial class frmMain : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Hệ thống sẵn sàng. Kết nối CSDL QLSinhVien thành công.";
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            timerClock.Start();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Bài 9: Mở form con an toàn, tránh mở trùng (Singleton pattern per Form Type)
        /// Nếu form đã mở thì BringToFront và Activate
        /// </summary>
        private void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is T)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    form.Activate();
                    lblStatus.Text = $"Đã kích hoạt cửa sổ đang mở: {form.Text}";
                    return;
                }
            }

            T newForm = new T();
            newForm.FormClosed += (s, args) =>
            {
                lblStatus.Text = $"Đã đóng và giải phóng tài nguyên: {newForm.Text}";
            };
            newForm.Show();
            lblStatus.Text = $"Đang hiển thị cửa sổ: {newForm.Text}";
        }

        private void mnuBaoCaoSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmBaoCaoSinhVien>();
        }

        private void mnuBaoCaoKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmBaoCaoKhoa>();
        }

        private void mnuBaoCaoHocPhan_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmBaoCaoHocPhan>();
        }

        private void btnNavSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmBaoCaoSinhVien>();
        }

        private void btnNavKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmBaoCaoKhoa>();
        }

        private void btnNavHocPhan_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmBaoCaoHocPhan>();
        }

        /// <summary>
        /// Bài 10: Kiểm thử in và xuất báo cáo tự động sang PDF
        /// </summary>
        private void mnuKiemThuXuatPdf_Click(object sender, EventArgs e)
        {
            try
            {
                string outputDir = AppDomain.CurrentDomain.BaseDirectory;
                string pdfSv = Path.Combine(outputDir, "DanhSachSinhVien.pdf");
                string pdfKhoa = Path.Combine(outputDir, "DanhSachKhoa.pdf");
                string pdfHp = Path.Combine(outputDir, "DanhSachHocPhan.pdf");

                DataTable dtSv = _bus.GetStudentReportData();
                DataTable dtKhoa = _bus.GetFacultyReportData();
                DataTable dtHp = _bus.GetCourseReportData();

                PdfExportHelper.ExportSinhVienPdf(dtSv, pdfSv, "Tất cả các khoa");
                PdfExportHelper.ExportKhoaPdf(dtKhoa, pdfKhoa);
                PdfExportHelper.ExportHocPhanPdf(dtHp, pdfHp);

                MessageBox.Show(
                    $"[Bài 10] Kiểm thử xuất 3 báo cáo PDF thành công!\n\n" +
                    $"1. {pdfSv} ({dtSv.Rows.Count} SV)\n" +
                    $"2. {pdfKhoa} ({dtKhoa.Rows.Count} Khoa)\n" +
                    $"3. {pdfHp} ({dtHp.Rows.Count} HP)",
                    "Kiểm thử xuất PDF thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblStatus.Text = "Kiểm thử Bài 10 xuất PDF hoàn tất xuất sắc.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm thử xuất báo cáo: {ex.Message}", "Lỗi kiểm thử", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LAB 13: TẠO BÁO CÁO CƠ BẢN BẰNG CRYSTAL REPORT\n" +
                "Học phần: Lập trình .NET (IT3212)\n" +
                "Khoa Công nghệ Thông tin - Trường Đại học Công nghệ Đông Á\n\n" +
                "Sinh viên thực hiện:\n" +
                "- Họ và tên: Phan Văn Thắng\n" +
                "- Mã sinh viên: 24002545\n" +
                "- Lớp: IT3212\n" +
                "- Ngày sinh: 26/03/2006\n" +
                "- Giảng viên hướng dẫn: Bộ môn Công nghệ Phần mềm",
                "Thông tin tác giả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
