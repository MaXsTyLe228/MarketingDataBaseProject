
namespace Курсач
{
    partial class Adv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adv));
            this.gradientGrid1 = new Курсач.gradientGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gradientGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientGrid1
            // 
            this.gradientGrid1.Bot = System.Drawing.Color.OrangeRed;
            this.gradientGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gradientGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientGrid1.Location = new System.Drawing.Point(0, 0);
            this.gradientGrid1.Name = "gradientGrid1";
            this.gradientGrid1.Size = new System.Drawing.Size(284, 191);
            this.gradientGrid1.TabIndex = 0;
            this.gradientGrid1.Top = System.Drawing.Color.DarkTurquoise;
            // 
            // Adv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.gradientGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 1000);
            this.MinimumSize = new System.Drawing.Size(300, 230);
            this.Name = "Adv";
            this.Text = "Аналіз реклами";
            this.Load += new System.EventHandler(this.Adv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private gradientGrid gradientGrid1;
    }
}