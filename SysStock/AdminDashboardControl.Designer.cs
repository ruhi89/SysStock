namespace SysStock
{
    partial class AdminDashboardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHero
            // 
            this.lblHero.AutoSize = true;
            this.lblHero.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHero.Location = new System.Drawing.Point(27, 43);
            this.lblHero.Name = "lblHero";
            this.lblHero.Size = new System.Drawing.Size(0, 30);
            this.lblHero.TabIndex = 0;
            // 
            // AdminDashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHero);
            this.Name = "AdminDashboardControl";
            this.Size = new System.Drawing.Size(994, 511);
            this.Load += new System.EventHandler(this.AdminDashboardControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHero;
    }
}
