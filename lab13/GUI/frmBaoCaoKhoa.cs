using System;
using System.Data;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;

namespace Lab13_CrystalReport.GUI
{
    public partial class frmBaoCaoKhoa : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTable;

        public frmBaoCaoKhoa()
        {
            InitializeComponent();
        }

        private void frmBaoCaoKhoa_Load(object sender, EventArgs e)
        {
            LoadFacultyData();
        }

        private void LoadFacultyData()
        {
            try
            {
                _dataTable = _bus.GetFacultyReportData();
                dgvKhoa.DataSource = _dataTable;
                FormatGridHeaders();

                int totalSv = 0;
                foreach (DataRow row in _dataTable.Rows)
                {
                    if (row["SoLuongSinhVien"] != DBNull.Value)
                        totalSv += Convert.ToInt32(row["SoLuongSinhVien"]);
                }

                lblTotalKhoa.Text = $"Tổng số khoa: {_dataTable.Rows.Count} | Tổng sinh viên: {totalSv}";
                lblStatus.Text = $"Nạp thành công {_dataTable.Rows.Count} khoa từ vw_BaoCaoKhoa vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu báo cáo khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridHeaders()
        {
            if (dgvKhoa.Columns["MaKhoa"] != null) dgvKhoa.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            if (dgvKhoa.Columns["TenKhoa"] != null) dgvKhoa.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvKhoa.Columns["SoLuongSinhVien"] != null)
            {
                dgvKhoa.Columns["SoLuongSinhVien"].HeaderText = "Số Lượng Sinh Viên";
                dgvKhoa.Columns["SoLuongSinhVien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvKhoa.Columns["DiemTrungBinhKhoa"] != null)
            {
                dgvKhoa.Columns["DiemTrungBinhKhoa"].HeaderText = "Điểm TB Khoa";
                dgvKhoa.Columns["DiemTrungBinhKhoa"].DefaultCellStyle.Format = "N2";
                dgvKhoa.Columns["DiemTrungBinhKhoa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            frmReportViewer viewer = new frmReportViewer(ReportType.Khoa, _dataTable, "BÁO CÁO THỐNG KÊ SINH VIÊN THEO KHOA");
            viewer.ShowDialog(this);
        }

        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF file|*.pdf";
                dlg.FileName = "DanhSachKhoa.pdf";
                dlg.Title = "Chọn nơi lưu tệp Báo cáo Khoa PDF";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfExportHelper.ExportKhoaPdf(_dataTable, dlg.FileName);
                        MessageBox.Show($"Đã xuất báo cáo khoa ra tệp:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadFacultyData();
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
