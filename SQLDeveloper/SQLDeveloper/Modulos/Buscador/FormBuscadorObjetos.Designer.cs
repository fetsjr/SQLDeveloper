﻿namespace SQLDeveloper.Modulos.Buscador
{
    partial class FormBuscadorObjetos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscadorObjetos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.waitControl1 = new WaitControl.WaitControl();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.Linfo = new System.Windows.Forms.Label();
            this.LMensaje = new System.Windows.Forms.Label();
            this.TimerTextChange = new System.Windows.Forms.Timer(this.components);
            this.BKBuscar = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.waitControl1);
            this.panel1.Controls.Add(this.ComboTipo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 84);
            this.panel1.TabIndex = 0;
            // 
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 25;
            this.waitControl1.Animar = false;
            this.waitControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitControl1.Location = new System.Drawing.Point(0, 74);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(268, 10);
            this.waitControl1.TabIndex = 4;
            // 
            // ComboTipo
            // 
            this.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipo.FormattingEnabled = true;
            this.ComboTipo.Location = new System.Drawing.Point(37, 49);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(198, 21);
            this.ComboTipo.TabIndex = 3;
            this.ComboTipo.SelectedIndexChanged += new System.EventHandler(this.ComboTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 15);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(182, 20);
            this.TNombre.TabIndex = 1;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            this.TNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TNombre_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.AllowDrop = true;
            this.ListaObjetos.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList1;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 84);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.ShowNodeToolTips = true;
            this.ListaObjetos.Size = new System.Drawing.Size(268, 380);
            this.ListaObjetos.StateImageList = this.imageList1;
            this.ListaObjetos.TabIndex = 1;
            this.ListaObjetos.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.ListaObjetos_DrawNode);
            this.ListaObjetos.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListaObjetos_ItemDrag);
            this.ListaObjetos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListaObjetos_AfterSelect);
            this.ListaObjetos.DoubleClick += new System.EventHandler(this.ListaObjetos_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTodosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // verTodosToolStripMenuItem
            // 
            this.verTodosToolStripMenuItem.Name = "verTodosToolStripMenuItem";
            this.verTodosToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.verTodosToolStripMenuItem.Text = "Ver todos";
            this.verTodosToolStripMenuItem.Click += new System.EventHandler(this.verTodosToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Vista.ico");
            this.imageList1.Images.SetKeyName(1, "vista.png");
            this.imageList1.Images.SetKeyName(2, "funcion.png");
            this.imageList1.Images.SetKeyName(3, "SP.ICO");
            this.imageList1.Images.SetKeyName(4, "trriger.jpg");
            this.imageList1.Images.SetKeyName(5, "check.png");
            this.imageList1.Images.SetKeyName(6, "default.png");
            this.imageList1.Images.SetKeyName(7, "FK.ico");
            this.imageList1.Images.SetKeyName(8, "llaves.jpg");
            this.imageList1.Images.SetKeyName(9, "Trasar2.jpg");
            this.imageList1.Images.SetKeyName(10, "desconocido.jpg");
            this.imageList1.Images.SetKeyName(11, "molde2.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Linfo);
            this.panel2.Controls.Add(this.LMensaje);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 49);
            this.panel2.TabIndex = 2;
            // 
            // Linfo
            // 
            this.Linfo.AutoSize = true;
            this.Linfo.Location = new System.Drawing.Point(3, 27);
            this.Linfo.Name = "Linfo";
            this.Linfo.Size = new System.Drawing.Size(0, 13);
            this.Linfo.TabIndex = 1;
            // 
            // LMensaje
            // 
            this.LMensaje.AutoSize = true;
            this.LMensaje.Location = new System.Drawing.Point(3, 3);
            this.LMensaje.Name = "LMensaje";
            this.LMensaje.Size = new System.Drawing.Size(117, 13);
            this.LMensaje.TabIndex = 0;
            this.LMensaje.Text = "Objetos encontrados: 0";
            // 
            // TimerTextChange
            // 
            this.TimerTextChange.Interval = 1000;
            this.TimerTextChange.Tick += new System.EventHandler(this.TimerTextChange_Tick);
            // 
            // BKBuscar
            // 
            this.BKBuscar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BKBuscar_DoWork);
            this.BKBuscar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BKBuscar_RunWorkerCompleted);
            // 
            // FormBuscadorObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 513);
            this.Controls.Add(this.ListaObjetos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormBuscadorObjetos";
            this.Text = "Buscador de Objetos";
            this.Load += new System.EventHandler(this.FormBuscadorObjetos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LMensaje;
        private WaitControl.WaitControl waitControl1;
        private System.Windows.Forms.Timer TimerTextChange;
        private System.ComponentModel.BackgroundWorker BKBuscar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label Linfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem;
    }
}