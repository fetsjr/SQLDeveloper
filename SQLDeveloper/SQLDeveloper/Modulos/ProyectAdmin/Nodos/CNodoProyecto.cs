using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public delegate void CNodoProyectoEvent(CNodoProyecto sender); 
    public class CNodoProyecto : CNodoBase
    {
        public event CNodoProyectoEvent OnCerrarproyecto;
        private CNodoConexiones Conexiones;
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuCerrar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        public CNodoProyecto()
        {
            Text = "Proyecto nuevo";
            ImageIndex = 0;
            SelectedImageIndex = 0;
            Conexiones = new CNodoConexiones();
            Conexiones.Modelo = Modelo;
            Nodes.Add(Conexiones);
        }
        public override void ModeloAsignado()
        {
            Conexiones.Modelo = Modelo;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRefrescar = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRefrescar ,
            MenuComentarios,
            this.MenuCerrar});
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuPrimaryKey
            // 
            this.MenuCerrar.Image = ((System.Drawing.Image)(resources.GetObject("exit32")));
            this.MenuCerrar.Name = "MenuCerrar";
            this.MenuCerrar.Size = new System.Drawing.Size(201, 22);
            this.MenuCerrar.Text = "Cerrar Proyecto";
            this.MenuCerrar.Click += new System.EventHandler(this.MenuCerrar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh11")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refrescar";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ((System.Drawing.Image)(resources.GetObject("comentario")));
            this.MenuComentarios.Name = "MenuComentarios";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Cometarios";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);

            return MenuPrinciapl;
        }
        private void MenuCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el proyecto", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            if (OnCerrarproyecto != null)
                OnCerrarproyecto(this);
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            Modelo.Refrescar();
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            FormComentario dlg = new FormComentario();
            dlg.Texto = Modelo.ComentariosProyecto;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Modelo.ComentariosProyecto = dlg.Texto;
        }
    }
}
