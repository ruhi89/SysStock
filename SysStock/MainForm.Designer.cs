﻿namespace SysStock
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
            this.btnSales = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnBrands = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tlpHeader.SuspendLayout();
            this.pFooter.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpHeader
            // 
            this.tlpHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpHeader.ColumnCount = 3;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tlpHeader.Controls.Add(this.llblLogo, 0, 0);
            this.tlpHeader.Controls.Add(this.lblHeader, 1, 0);
            this.tlpHeader.Controls.Add(this.btnLogout, 2, 0);
            this.tlpHeader.Location = new System.Drawing.Point(-1, 1);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(1002, 60);
            this.tlpHeader.TabIndex = 2;
            this.tlpHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpHeader_Paint);
            // 
            // llblLogo
            // 
            this.llblLogo.ActiveLinkColor = System.Drawing.Color.Transparent;
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
            this.llblLogo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLogo_LinkClicked);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(934, 19);
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
            this.pMenuBar.Controls.Add(this.btnSettings);
            this.pMenuBar.Controls.Add(this.btnSales);
            this.pMenuBar.Controls.Add(this.btnUsers);
            this.pMenuBar.Controls.Add(this.btnBrands);
            this.pMenuBar.Controls.Add(this.btnProducts);
            this.pMenuBar.Controls.Add(this.btnCategories);
            this.pMenuBar.Controls.Add(this.btnDashboard);
            this.pMenuBar.Location = new System.Drawing.Point(0, 60);
            this.pMenuBar.Name = "pMenuBar";
            this.pMenuBar.Size = new System.Drawing.Size(1002, 80);
            this.pMenuBar.TabIndex = 4;
            // 
            // btnSales
            // 
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(719, 1);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(130, 75);
            this.btnSales.TabIndex = 5;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.Location = new System.Drawing.Point(575, 1);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(130, 75);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnBrands
            // 
            this.btnBrands.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrands.FlatAppearance.BorderSize = 0;
            this.btnBrands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrands.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrands.Location = new System.Drawing.Point(431, 1);
            this.btnBrands.Name = "btnBrands";
            this.btnBrands.Size = new System.Drawing.Size(130, 75);
            this.btnBrands.TabIndex = 3;
            this.btnBrands.Text = "Brands";
            this.btnBrands.UseVisualStyleBackColor = true;
            // 
            // btnProducts
            // 
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.Location = new System.Drawing.Point(143, 1);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(130, 75);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnCategories
            // 
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.Location = new System.Drawing.Point(287, 1);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(130, 75);
            this.btnCategories.TabIndex = 1;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Location = new System.Drawing.Point(-1, 1);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(130, 75);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMain.Location = new System.Drawing.Point(3, 146);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(995, 510);
            this.panelMain.TabIndex = 5;
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(863, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(130, 75);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.btnLogout.Image = global::SysStock.Properties.Resources.logout_5087606__2_;
            this.btnLogout.Location = new System.Drawing.Point(944, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(50, 50);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.button8_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.panelMain);
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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBrands;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
    }
}