using System;
using System.Data;
using System.Windows.Forms;
using Lab13_CrystalReport.BUS;

namespace Lab13_CrystalReport.GUI
{
    public partial class frmBaoCaoHocPhan : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTable;

        public frmBaoCaoHocPhan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHocPhan_Load(object sender, EventArgs e)
        {
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            try
            {
                _dataTable = _bus.GetCourseReportData();
                dgvHocPhan.DataSource = _dataTable;
                FormatGridHeaders();

                int totalTinChi = 0;
                foreach (DataRow row in _dataTable.Rows)
                {
                    if (row["SoTinChi"] != DBNull.Value)
                        totalTinChi += Convert.ToInt32(row["SoTinChi"]);
                }

                lblTotalCourses.Text = $"Tổng số học phần: {_dataTable.Rows.Count} | Tổng tín chỉ: {totalTinChi}";
                lblStatus.Text = $"Nạp thành công {_dataTable.Rows.Count} học phần từ vw_BaoCaoHocPhan vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu báo cáo học phần: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridHeaders()
        {
            if (dgvHocPhan.Columns["MaHP"] != null) dgvHocPhan.Columns["MaHP"].HeaderText = "Mã Học Phần";
            if (dgvHocPhan.Columns["TenHP"] != null) dgvHocPhan.Columns["TenHP"].HeaderText = "Tên Học Phần Đào Tạo";
            if (dgvHocPhan.Columns["SoTinChi"] != null)
            {
                dgvHocPhan.Columns["SoTinChi"].HeaderText = "Số Tín Chỉ";
                dgvHocPhan.Columns["SoTinChi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvHocPhan.Columns["SoLuongDangKy"] != null)
            {
                dgvHocPhan.Columns["SoLuongDangKy"].HeaderText = "Số SV Đăng Ký";
                dgvHocPhan.Columns["SoLuongDangKy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            frmReportViewer viewer = new frmReportViewer(ReportType.HocPhan, _dataTable, "BÁO CÁO DANH SÁCH HỌC PHẦN ĐÀO TẠO");
            viewer.ShowDialog(this);
        }

        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF file|*.pdf";
                dlg.FileName = "DanhSachHocPhan.pdf";
                dlg.Title = "Chọn nơi lưu tệp Báo cáo Học phần PDF";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfExportHelper.ExportHocPhanPdf(_dataTable, dlg.FileName);
                        MessageBox.Show($"Đã xuất báo cáo học phần ra tệp:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadCourseData();
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
