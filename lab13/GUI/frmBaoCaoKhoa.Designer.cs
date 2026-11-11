namespace Lab13_CrystalReport.GUI
{
    partial class frmBaoCaoKhoa
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalKhoa;

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
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalKhoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(900, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(16, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(515, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "BÁO CÁO DANH SÁCH KHOA VÀ SỐ LƯỢNG SV (BÀI 6)";
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnLamMoi);
            this.grpAction.Controls.Add(this.btnXuatPdf);
            this.grpAction.Controls.Add(this.btnXemBaoCao);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpAction.Location = new System.Drawing.Point(0, 55);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(900, 70);
            this.grpAction.TabIndex = 1;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Thao tác Báo cáo";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(390, 26);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 32);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuatPdf
            // 
            this.btnXuatPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXuatPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatPdf.ForeColor = System.Drawing.Color.White;
            this.btnXuatPdf.Location = new System.Drawing.Point(215, 26);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(155, 32);
            this.btnXuatPdf.TabIndex = 1;
            this.btnXuatPdf.Text = "Xuất Ra PDF";
            this.btnXuatPdf.UseVisualStyleBackColor = false;
            this.btnXuatPdf.Click += new System.EventHandler(this.btnXuatPdf_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(25, 26);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(175, 32);
            this.btnXemBaoCao.TabIndex = 0;
            this.btnXemBaoCao.Text = "Xem Báo Cáo (Viewer)";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvKhoa);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpData.Location = new System.Drawing.Point(0, 125);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(10);
            this.grpData.Size = new System.Drawing.Size(900, 430);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Dữ liệu danh sách khoa & tổng hợp sinh viên (vw_BaoCaoKhoa)";
            // 
            // dgvKhoa
            // 
            this.dgvKhoa.AllowUserToAddRows = false;
            this.dgvKhoa.AllowUserToDeleteRows = false;
            this.dgvKhoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoa.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoa.Location = new System.Drawing.Point(10, 30);
            this.dgvKhoa.MultiSelect = false;
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.ReadOnly = true;
            this.dgvKhoa.RowHeadersWidth = 35;
            this.dgvKhoa.RowTemplate.Height = 28;
            this.dgvKhoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoa.Size = new System.Drawing.Size(880, 390);
            this.dgvKhoa.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblTotalKhoa});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(635, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalKhoa
            // 
            this.lblTotalKhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalKhoa.Name = "lblTotalKhoa";
            this.lblTotalKhoa.Size = new System.Drawing.Size(250, 20);
            this.lblTotalKhoa.Text = "Tổng số khoa: 0 | Tổng sinh viên: 0";
            // 
            // frmBaoCaoKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 581);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmBaoCaoKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Danh Sách Khoa";
            this.Load += new System.EventHandler(this.frmBaoCaoKhoa_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
