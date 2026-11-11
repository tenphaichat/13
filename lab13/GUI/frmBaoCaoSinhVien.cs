using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;

namespace Lab13_CrystalReport.GUI
{
    public partial class frmBaoCaoSinhVien : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTable;

        public frmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void frmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            LoadReportData();
        }

        private void LoadKhoaComboBox()
        {
            try
            {
                DataTable dtKhoa = _bus.GetAllKhoa();
                DataRow allRow = dtKhoa.NewRow();
                allRow["MaKhoa"] = "ALL";
                allRow["TenKhoa"] = "-- Tất cả các khoa --";
                dtKhoa.Rows.InsertAt(allRow, 0);

                cboKhoa.DataSource = dtKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh mục khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReportData()
        {
            try
            {
                string selectedKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
                _dataTable = _bus.GetStudentReportData(selectedKhoa);

                dgvPreview.DataSource = _dataTable;
                FormatGridHeaders();

                lblTotal.Text = $"Tổng số sinh viên: {_dataTable.Rows.Count}";
                lblStatus.Text = $"Nạp thành công {_dataTable.Rows.Count} bản ghi từ vw_BaoCaoSinhVien vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu báo cáo sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridHeaders()
        {
            if (dgvPreview.Columns["MaSV"] != null) dgvPreview.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvPreview.Columns["HoTen"] != null) dgvPreview.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvPreview.Columns["NgaySinh"] != null)
            {
                dgvPreview.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvPreview.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvPreview.Columns["GioiTinh"] != null) dgvPreview.Columns["GioiTinh"].HeaderText = "Giới Tính";
            if (dgvPreview.Columns["MaKhoa"] != null) dgvPreview.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            if (dgvPreview.Columns["TenKhoa"] != null) dgvPreview.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvPreview.Columns["DiemTB"] != null)
            {
                dgvPreview.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvPreview.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
            }
            if (dgvPreview.Columns["Email"] != null) dgvPreview.Columns["Email"].HeaderText = "Email";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            string khoaName = cboKhoa.Text;
            frmReportViewer viewer = new frmReportViewer(ReportType.SinhVien, _dataTable, "BÁO CÁO DANH SÁCH SINH VIÊN", khoaName);
            viewer.ShowDialog(this);
        }

        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF file|*.pdf";
                dlg.FileName = "DanhSachSinhVien.pdf";
                dlg.Title = "Chọn nơi lưu tệp Báo cáo Sinh viên PDF";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfExportHelper.ExportSinhVienPdf(_dataTable, dlg.FileName, cboKhoa.Text);
                        MessageBox.Show($"Đã xuất báo cáo sinh viên ra tệp:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboKhoa.SelectedIndex = 0;
            LoadReportData();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_dataTable != null)
            {
                _dataTable.Dispose();
                _dataTable = null;
            }
            base.OnFormClosed(e);
        }
    }
}
