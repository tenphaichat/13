namespace Lab13_CrystalReport.GUI
{
    partial class frmBaoCaoSinhVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(76)))), ((int)(((byte)(120)))));
            this.panelTop.Controls.Add(this.lblHeaderTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(964, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(16, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(434, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "BÁO CÁO DANH SÁCH SINH VIÊN (BÀI 4 & 5)";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnLamMoi);
            this.grpFilter.Controls.Add(this.btnXuatPdf);
            this.grpFilter.Controls.Add(this.btnXemBaoCao);
            this.grpFilter.Controls.Add(this.btnLoc);
            this.grpFilter.Controls.Add(this.cboKhoa);
            this.grpFilter.Controls.Add(this.lblKhoa);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpFilter.Location = new System.Drawing.Point(0, 55);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(964, 75);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Bộ lọc và Thao tác Báo cáo";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(825, 27);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 32);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuatPdf
            // 
            this.btnXuatPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXuatPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatPdf.ForeColor = System.Drawing.Color.White;
            this.btnXuatPdf.Location = new System.Drawing.Point(675, 27);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(135, 32);
            this.btnXuatPdf.TabIndex = 4;
            this.btnXuatPdf.Text = "Xuất Ra PDF";
            this.btnXuatPdf.UseVisualStyleBackColor = false;
            this.btnXuatPdf.Click += new System.EventHandler(this.btnXuatPdf_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(495, 27);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(165, 32);
            this.btnXemBaoCao.TabIndex = 3;
            this.btnXemBaoCao.Text = "Xem Báo Cáo (Viewer)";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(395, 27);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(85, 32);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Text = "Lọc Dữ Liệu";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(125, 29);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(250, 28);
            this.cboKhoa.TabIndex = 1;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(22, 33);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(84, 20);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Chọn Khoa:";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvPreview);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpData.Location = new System.Drawing.Point(0, 130);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(10);
            this.grpData.Size = new System.Drawing.Size(964, 465);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Nguồn dữ liệu báo cáo (vw_BaoCaoSinhVien)";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.Location = new System.Drawing.Point(10, 30);
            this.dgvPreview.MultiSelect = false;
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersWidth = 35;
            this.dgvPreview.RowTemplate.Height = 26;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(944, 425);
            this.dgvPreview.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 595);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(964, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(799, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 20);
            this.lblTotal.Text = "Tổng số sinh viên: 0";
            // 
            // frmBaoCaoSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 621);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmBaoCaoSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Danh Sách Sinh Viên";
            this.Load += new System.EventHandler(this.frmBaoCaoSinhVien_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
