namespace SysStock
{
    partial class MainForm
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
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.llblLogo = new System.Windows.Forms.LinkLabel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pFooter = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.pMenuBar = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.tlpHeader.SuspendLayout();
            this.pFooter.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpHeader
            // 
            this.tlpHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpHeader.ColumnCount = 2;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.Controls.Add(this.llblLogo, 0, 0);
            this.tlpHeader.Controls.Add(this.lblHeader, 1, 0);
            this.tlpHeader.Location = new System.Drawing.Point(-1, 1);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.Size = new System.Drawing.Size(1002, 60);
            this.tlpHeader.TabIndex = 2;
            this.tlpHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpHeader_Paint);
            // 
            // llblLogo
            // 
            this.llblLogo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblLogo.AutoSize = true;
            this.llblLogo.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblLogo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblLogo.LinkColor = System.Drawing.Color.White;
            this.llblLogo.Location = new System.Drawing.Point(3, 15);
            this.llblLogo.Name = "llblLogo";
            this.llblLogo.Size = new System.Drawing.Size(456, 30);
            this.llblLogo.TabIndex = 0;
            this.llblLogo.TabStop = true;
            this.llblLogo.Text = "SysStock Inventory Management System";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(999, 19);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(0, 21);
            this.lblHeader.TabIndex = 1;
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.Location = new System.Drawing.Point(415, 20);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(129, 21);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "© 2025 SysStock";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFooter.Click += new System.EventHandler(this.lblFooter_Click);
            // 
            // pFooter
            // 
            this.pFooter.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.pFooter.Controls.Add(this.lblFooter);
            this.pFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pFooter.Location = new System.Drawing.Point(0, 662);
            this.pFooter.Name = "pFooter";
            this.pFooter.Size = new System.Drawing.Size(1002, 50);
            this.pFooter.TabIndex = 2;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.pHeader.Controls.Add(this.tlpHeader);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1002, 60);
            this.pHeader.TabIndex = 3;
            // 
            // pMenuBar
            // 
            this.pMenuBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pMenuBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMenuBar.Controls.Add(this.button6);
            this.pMenuBar.Controls.Add(this.button5);
            this.pMenuBar.Controls.Add(this.button4);
            this.pMenuBar.Controls.Add(this.button3);
            this.pMenuBar.Controls.Add(this.button2);
            this.pMenuBar.Controls.Add(this.button1);
            this.pMenuBar.Location = new System.Drawing.Point(0, 60);
            this.pMenuBar.Name = "pMenuBar";
            this.pMenuBar.Size = new System.Drawing.Size(1002, 80);
            this.pMenuBar.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(587, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 75);
            this.button5.TabIndex = 4;
            this.button5.Text = "Users";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(441, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 75);
            this.button4.TabIndex = 3;
            this.button4.Text = "Brands";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(149, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 75);
            this.button3.TabIndex = 2;
            this.button3.Text = "Products";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(295, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 75);
            this.button2.TabIndex = 1;
            this.button2.Text = "Categories";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(3, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(3, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 510);
            this.panel1.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(733, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 75);
            this.button6.TabIndex = 5;
            this.button6.Text = "Sales";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pMenuBar);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.pFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.pFooter.ResumeLayout(false);
            this.pFooter.PerformLayout();
            this.pHeader.ResumeLayout(false);
            this.pMenuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.LinkLabel llblLogo;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Panel pFooter;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pMenuBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}