using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoDocument : CNodoBase
    {
        //menu del objeto
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        private System.Windows.Forms.ToolStripMenuItem MenuRenombrar;
        public CNodoDocument()
        {
            ImageIndex = 21;
            SelectedImageIndex = 21;
        }
        public int ID_Document
        {
            get;
            set;
        }
        public int ID_Conexion
        {
            get;
            set;
        }
        public int ID_Carpeta
        {
            get;
            set;
        }
        public Conexiones.CConexion Conexion
        {
            get;
            set;
        }
        public string Servidor
        {
            get;
            set;
        }
        public string Texto
        {
            get
            {
                if (Modelo != null)
                {
                    return Modelo.DameTextoDocumento(ID_Document);
                }
                return "";
            }
            set
            {
                if (Modelo != null)
                {
                    Modelo.AsignaTextoDocumento(ID_Document, value);
                }

            }
        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea quitar: " + Nombre + " del proyecto?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                Modelo.EliminaDocumento(ID_Document);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            MenuRenombrar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuComentarios,
            MenuRenombrar,
            this.MenuEliminar
             });
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Image = ((System.Drawing.Image)(resources.GetObject("IconoEliminar")));
            this.MenuEliminar.Name = "MenuRefrescar";
            this.MenuEliminar.Size = new System.Drawing.Size(201, 22);
            this.MenuEliminar.Text = "Quitar del proyecto";
            this.MenuEliminar.Click += new System.EventHandler(this.MenuEliminar_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
            this.MenuComentarios.Name = "MenuVerCodigo";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Editar";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);
            // 
            // MenuRenombrar
            // 
            this.MenuRenombrar.Image = ((System.Drawing.Image)(resources.GetObject("rename")));
            this.MenuRenombrar.Name = "MenuVerCodigo";
            this.MenuRenombrar.Size = new System.Drawing.Size(201, 22);
            this.MenuRenombrar.Text = "Cambiar Nombre";
            this.MenuRenombrar.Click += new System.EventHandler(this.MenuRenombrar_Click);
            return MenuPrinciapl;
        }
        private void MenuRenombrar_Click(object sender, EventArgs e)
        {
            Forms.FormNombre dlg = new Forms.FormNombre();
            dlg.Nombre = Nombre;
            dlg.OnNombre += new Forms.ONFormNombreEvent(NuevoNombre);
            dlg.ShowDialog();
        }
        private bool NuevoNombre(Forms.FormNombre sender, string nuevoNombre)
        {
            try
            {
                Modelo.RenameDocument(ID_Document,nuevoNombre);
                Nombre = nuevoNombre;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            CEditorComentarios editor = new CEditorComentarios();
            editor.Modelo = this.Modelo;
            editor.ID_Document = this.ID_Document;
            //me traigo el acceso al formulario
            FormProyect dlg = (FormProyect)TreeView.Tag;
            dlg.EditorComentario(editor, Nombre);
        }
        public override void DoubleClick(TreeNodeMouseClickEventArgs e)
        {
            MenuComentarios_Click(null, null);
        }
    }
}
