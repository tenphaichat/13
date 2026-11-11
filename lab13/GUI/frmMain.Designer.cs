namespace Lab13_CrystalReport.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoKhoa;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoHocPhan;
        private System.Windows.Forms.ToolStripMenuItem mnuKiemThu;
        private System.Windows.Forms.ToolStripMenuItem mnuKiemThuXuatPdf;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.Label lblBannerSub;
        private System.Windows.Forms.Label lblBannerTitle;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button btnNavHocPhan;
        private System.Windows.Forms.Button btnNavKhoa;
        private System.Windows.Forms.Button btnNavSinhVien;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblInfoText;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoHocPhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKiemThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKiemThuXuatPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.panelBanner = new System.Windows.Forms.Panel();
            this.lblBannerSub = new System.Windows.Forms.Label();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnNavHocPhan = new System.Windows.Forms.Button();
            this.btnNavKhoa = new System.Windows.Forms.Button();
            this.btnNavSinhVien = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblInfoText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelBanner.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuBaoCao,
            this.mnuKiemThu,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(89, 25);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(185, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBaoCaoSinhVien,
            this.mnuBaoCaoKhoa,
            this.mnuBaoCaoHocPhan});
            this.mnuBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.mnuBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(76)))), ((int)(((byte)(120)))));
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(186, 25);
            this.mnuBaoCao.Text = "Báo Cáo Crystal Report";
            // 
            // mnuBaoCaoSinhVien
            // 
            this.mnuBaoCaoSinhVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mnuBaoCaoSinhVien.Name = "mnuBaoCaoSinhVien";
            this.mnuBaoCaoSinhVien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mnuBaoCaoSinhVien.Size = new System.Drawing.Size(325, 26);
            this.mnuBaoCaoSinhVien.Text = "Báo Cáo Danh Sách Sinh Viên";
            this.mnuBaoCaoSinhVien.Click += new System.EventHandler(this.mnuBaoCaoSinhVien_Click);
            // 
            // mnuBaoCaoKhoa
            // 
            this.mnuBaoCaoKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mnuBaoCaoKhoa.Name = "mnuBaoCaoKhoa";
            this.mnuBaoCaoKhoa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mnuBaoCaoKhoa.Size = new System.Drawing.Size(325, 26);
            this.mnuBaoCaoKhoa.Text = "Báo Cáo Thống Kê Theo Khoa";
            this.mnuBaoCaoKhoa.Click += new System.EventHandler(this.mnuBaoCaoKhoa_Click);
            // 
            // mnuBaoCaoHocPhan
            // 
            this.mnuBaoCaoHocPhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mnuBaoCaoHocPhan.Name = "mnuBaoCaoHocPhan";
            this.mnuBaoCaoHocPhan.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.mnuBaoCaoHocPhan.Size = new System.Drawing.Size(325, 26);
            this.mnuBaoCaoHocPhan.Text = "Báo Cáo Danh Mục Học Phần";
            this.mnuBaoCaoHocPhan.Click += new System.EventHandler(this.mnuBaoCaoHocPhan_Click);
            // 
            // mnuKiemThu
            // 
            this.mnuKiemThu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKiemThuXuatPdf});
            this.mnuKiemThu.Name = "mnuKiemThu";
            this.mnuKiemThu.Size = new System.Drawing.Size(147, 25);
            this.mnuKiemThu.Text = "Kiểm Thử (Bài 10)";
            // 
            // mnuKiemThuXuatPdf
            // 
            this.mnuKiemThuXuatPdf.Name = "mnuKiemThuXuatPdf";
            this.mnuKiemThuXuatPdf.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuKiemThuXuatPdf.Size = new System.Drawing.Size(328, 26);
            this.mnuKiemThuXuatPdf.Text = "Kiểm Thử Xuất Hàng Loạt PDF";
            this.mnuKiemThuXuatPdf.Click += new System.EventHandler(this.mnuKiemThuXuatPdf_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongTin});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(81, 25);
            this.mnuTroGiup.Text = "Trợ Giúp";
            // 
            // mnuThongTin
            // 
            this.mnuThongTin.Name = "mnuThongTin";
            this.mnuThongTin.Size = new System.Drawing.Size(217, 26);
            this.mnuThongTin.Text = "Thông Tin Tác Giả";
            this.mnuThongTin.Click += new System.EventHandler(this.mnuThongTin_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblUser,
            this.lblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 615);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 26);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(434, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Hệ thống sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(76)))), ((int)(((byte)(120)))));
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(350, 20);
            this.lblUser.Text = "SV: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212";
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(135, 20);
            this.lblTime.Text = "11/11/2026 00:00:00";
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(76)))), ((int)(((byte)(120)))));
            this.panelBanner.Controls.Add(this.lblBannerSub);
            this.panelBanner.Controls.Add(this.lblBannerTitle);
            this.panelBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBanner.Location = new System.Drawing.Point(0, 29);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(984, 90);
            this.panelBanner.TabIndex = 2;
            // 
            // lblBannerSub
            // 
            this.lblBannerSub.AutoSize = true;
            this.lblBannerSub.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblBannerSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.lblBannerSub.Location = new System.Drawing.Point(22, 50);
            this.lblBannerSub.Name = "lblBannerSub";
            this.lblBannerSub.Size = new System.Drawing.Size(698, 25);
            this.lblBannerSub.TabIndex = 1;
            this.lblBannerSub.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á - KHOA CÔNG NGHỆ THÔNG TIN (IT3212)";
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBannerTitle.ForeColor = System.Drawing.Color.White;
            this.lblBannerTitle.Location = new System.Drawing.Point(20, 10);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(731, 37);
            this.lblBannerTitle.TabIndex = 0;
            this.lblBannerTitle.Text = "LAB 13: TẠO BÁO CÁO CƠ BẢN BẰNG CRYSTAL REPORT";
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.panelNav.Controls.Add(this.btnNavHocPhan);
            this.panelNav.Controls.Add(this.btnNavKhoa);
            this.panelNav.Controls.Add(this.btnNavSinhVien);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 119);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(984, 75);
            this.panelNav.TabIndex = 3;
            // 
            // btnNavHocPhan
            // 
            this.btnNavHocPhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnNavHocPhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavHocPhan.ForeColor = System.Drawing.Color.White;
            this.btnNavHocPhan.Location = new System.Drawing.Point(595, 14);
            this.btnNavHocPhan.Name = "btnNavHocPhan";
            this.btnNavHocPhan.Size = new System.Drawing.Size(260, 48);
            this.btnNavHocPhan.TabIndex = 2;
            this.btnNavHocPhan.Text = "📚 3. Báo Cáo Học Phần (Bài 8)";
            this.btnNavHocPhan.UseVisualStyleBackColor = false;
            this.btnNavHocPhan.Click += new System.EventHandler(this.btnNavHocPhan_Click);
            // 
            // btnNavKhoa
            // 
            this.btnNavKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(112)))), ((int)(((byte)(214)))));
            this.btnNavKhoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this.btnNavKhoa.Location = new System.Drawing.Point(315, 14);
            this.btnNavKhoa.Name = "btnNavKhoa";
            this.btnNavKhoa.Size = new System.Drawing.Size(260, 48);
            this.btnNavKhoa.TabIndex = 1;
            this.btnNavKhoa.Text = "🏛️ 2. Báo Cáo Khoa (Bài 6)";
            this.btnNavKhoa.UseVisualStyleBackColor = false;
            this.btnNavKhoa.Click += new System.EventHandler(this.btnNavKhoa_Click);
            // 
            // btnNavSinhVien
            // 
            this.btnNavSinhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.btnNavSinhVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavSinhVien.ForeColor = System.Drawing.Color.White;
            this.btnNavSinhVien.Location = new System.Drawing.Point(35, 14);
            this.btnNavSinhVien.Name = "btnNavSinhVien";
            this.btnNavSinhVien.Size = new System.Drawing.Size(260, 48);
            this.btnNavSinhVien.TabIndex = 0;
            this.btnNavSinhVien.Text = "🎓 1. Báo Cáo Sinh Viên (Bài 4)";
            this.btnNavSinhVien.UseVisualStyleBackColor = false;
            this.btnNavSinhVien.Click += new System.EventHandler(this.btnNavSinhVien_Click);
            // 
            // grpInfo
            // 
            this.grpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInfo.Controls.Add(this.lblInfoText);
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpInfo.Location = new System.Drawing.Point(35, 215);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(20);
            this.grpInfo.Size = new System.Drawing.Size(915, 380);
            this.grpInfo.TabIndex = 4;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Mục tiêu bài lab & Trạng thái các chức năng báo cáo";
            // 
            // lblInfoText
            // 
            this.lblInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoText.Location = new System.Drawing.Point(20, 43);
            this.lblInfoText.Name = "lblInfoText";
            this.lblInfoText.Size = new System.Drawing.Size(875, 317);
            this.lblInfoText.TabIndex = 0;
            this.lblInfoText.Text = "1. Môi trường: SAP Crystal Reports / Engine & Shared & Windows.Forms\r\n" +
                "2. View nguồn CSDL QLSinhVien: vw_BaoCaoSinhVien, vw_BaoCaoKhoa, vw_BaoCaoHocPhan\r\n" +
                "3. Kiến trúc 3 tầng: GUI - BUS - DAL - DTO - Reports kết nối chặt chẽ\r\n" +
                "4. Xem trước báo cáo tương tác với thanh công cụ Zoom, Điều hướng trang, In ấn\r\n" +
                "5. Xuất báo cáo trực tiếp sang file chuẩn PDF chất lượng cao (Bài 5)\r\n" +
                "6. Báo cáo danh sách khoa kèm số lượng sinh viên và điểm trung bình khoa (Bài 6)\r\n" +
                "7. Định dạng chuẩn: Tiêu đề, Logo, Thời điểm kết xuất, Đánh số trang (Trang N/M) (Bài 7)\r\n" +
                "8. Báo cáo danh sách học phần đào tạo sắp xếp theo tên (A-Z) (Bài 8)\r\n" +
                "9. Tích hợp thanh Menu thông minh: Mở form chống mở trùng, tự động giải phóng bộ nhớ (Bài 9)\r\n" +
                "10. Kiểm thử toàn diện in và xuất báo cáo PDF (Bài 10)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panelBanner);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Báo Cáo Crystal Report - IT3212 EAUT";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelBanner.ResumeLayout(false);
            this.panelBanner.PerformLayout();
            this.panelNav.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
