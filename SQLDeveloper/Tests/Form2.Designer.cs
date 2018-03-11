namespace Tests
{
    partial class Form2
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
            this.controlerGrid1 = new GridControl.ControlerGrid();
            this.SuspendLayout();
            // 
            // controlerGrid1
            // 
            this.controlerGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlerGrid1.Location = new System.Drawing.Point(0, 114);
            this.controlerGrid1.Name = "controlerGrid1";
            this.controlerGrid1.Size = new System.Drawing.Size(399, 147);
            this.controlerGrid1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 261);
            this.Controls.Add(this.controlerGrid1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl.ControlerGrid controlerGrid1;
    }
}