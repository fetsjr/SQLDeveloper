namespace Tests
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.controlerGrid1 = new GridControl.ControlerGrid();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sucursalesCopiaoriginalDataSet = new Tests.SucursalesCopiaoriginalDataSet();
            this.articulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.articulosTableAdapter = new Tests.SucursalesCopiaoriginalDataSetTableAdapters.articulosTableAdapter();
            this.sucursalesCopiaoriginalDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sucursalesCopiaoriginalDataSet1 = new Tests.SucursalesCopiaoriginalDataSet();
            this.sucursalesCopiaoriginalDataSet2 = new Tests.SucursalesCopiaoriginalDataSet();
            this.articulosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.controlerGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(616, 464);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(616, 180);
            this.textBox1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(616, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // controlerGrid1
            // 
            this.controlerGrid1.DataSet = null;
            this.controlerGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlerGrid1.Location = new System.Drawing.Point(0, 0);
            this.controlerGrid1.Name = "controlerGrid1";
            this.controlerGrid1.Size = new System.Drawing.Size(616, 255);
            this.controlerGrid1.TabIndex = 0;
            this.controlerGrid1.OnMessage += new GridControl.OnMessageEvent(this.controlerGrid1_OnMessage);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.sucursalesCopiaoriginalDataSet;
            this.bindingSource1.Position = 0;
            // 
            // sucursalesCopiaoriginalDataSet
            // 
            this.sucursalesCopiaoriginalDataSet.DataSetName = "SucursalesCopiaoriginalDataSet";
            this.sucursalesCopiaoriginalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // articulosBindingSource
            // 
            this.articulosBindingSource.DataMember = "articulos";
            this.articulosBindingSource.DataSource = this.bindingSource1;
            // 
            // articulosTableAdapter
            // 
            this.articulosTableAdapter.ClearBeforeFill = true;
            // 
            // sucursalesCopiaoriginalDataSetBindingSource
            // 
            this.sucursalesCopiaoriginalDataSetBindingSource.DataSource = this.sucursalesCopiaoriginalDataSet;
            this.sucursalesCopiaoriginalDataSetBindingSource.Position = 0;
            // 
            // sucursalesCopiaoriginalDataSet1
            // 
            this.sucursalesCopiaoriginalDataSet1.DataSetName = "SucursalesCopiaoriginalDataSet";
            this.sucursalesCopiaoriginalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sucursalesCopiaoriginalDataSet2
            // 
            this.sucursalesCopiaoriginalDataSet2.DataSetName = "SucursalesCopiaoriginalDataSet";
            this.sucursalesCopiaoriginalDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // articulosBindingSource1
            // 
            this.articulosBindingSource1.DataMember = "articulos";
            this.articulosBindingSource1.DataSource = this.bindingSource1;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 464);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesCopiaoriginalDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private GridControl.ControlerGrid controlerGrid1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private SucursalesCopiaoriginalDataSet sucursalesCopiaoriginalDataSet;
        private System.Windows.Forms.BindingSource articulosBindingSource;
        private SucursalesCopiaoriginalDataSetTableAdapters.articulosTableAdapter articulosTableAdapter;
        private System.Windows.Forms.BindingSource sucursalesCopiaoriginalDataSetBindingSource;
        private SucursalesCopiaoriginalDataSet sucursalesCopiaoriginalDataSet1;
        private SucursalesCopiaoriginalDataSet sucursalesCopiaoriginalDataSet2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.BindingSource articulosBindingSource1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}