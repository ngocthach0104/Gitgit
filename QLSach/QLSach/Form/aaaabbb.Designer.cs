namespace QLSach
{
    partial class aaaabbb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btn_ThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ThongKeTheoSach = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_QuanLySach = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_ThongKe,
            this.btn_QuanLySach});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_ThongKeTheoSach});
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(68, 20);
            this.btn_ThongKe.Text = "Thống kê";
            // 
            // btn_ThongKeTheoSach
            // 
            this.btn_ThongKeTheoSach.Name = "btn_ThongKeTheoSach";
            this.btn_ThongKeTheoSach.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.btn_ThongKeTheoSach.Size = new System.Drawing.Size(245, 22);
            this.btn_ThongKeTheoSach.Text = "Thống kê sách theo năm";
            this.btn_ThongKeTheoSach.Click += new System.EventHandler(this.btn_ThongKeTheoSach_Click);
            // 
            // btn_QuanLySach
            // 
            this.btn_QuanLySach.Name = "btn_QuanLySach";
            this.btn_QuanLySach.Size = new System.Drawing.Size(139, 20);
            this.btn_QuanLySach.Text = "Quản lý thông tin sách";
            this.btn_QuanLySach.Click += new System.EventHandler(this.btn_QuanLySach_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_ThongKe;
        private System.Windows.Forms.ToolStripMenuItem btn_ThongKeTheoSach;
        private System.Windows.Forms.ToolStripMenuItem btn_QuanLySach;
    }
}