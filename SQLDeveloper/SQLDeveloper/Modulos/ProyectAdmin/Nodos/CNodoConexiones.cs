using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.ProyectAdmin
{
    class CNodoConexiones: CNodoBase
    {
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem MenuRefrescar;
        public CNodoConexiones()
        {
            Text = "Servidores";
            ImageIndex = 1;
            SelectedImageIndex = 1;
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRefrescar = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAgregar,
            this.MenuRefrescar});
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuPrimaryKey
            // 
            this.MenuAgregar.Image = ((System.Drawing.Image)(resources.GetObject("IconoAgregar")));
            this.MenuAgregar.Name = "MenuAgregar";
            this.MenuAgregar.Size = new System.Drawing.Size(201, 22);
            this.MenuAgregar.Text = "Agregar Conexiòn";
            this.MenuAgregar.Click += new System.EventHandler(this.MenuAgregar_Click);
            // 
            // MenuRefrescar
            // 
            this.MenuRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("refresh11")));
            this.MenuRefrescar.Name = "MenuRefrescar";
            this.MenuRefrescar.Size = new System.Drawing.Size(201, 22);
            this.MenuRefrescar.Text = "Refrescar";
            this.MenuRefrescar.Click += new System.EventHandler(this.MenuRefrescar_Click);
            return MenuPrinciapl;
        }
        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            Conexiones.FormSelectConecion dlg = new Conexiones.FormSelectConecion();
            dlg.OnConexion += new Conexiones.OnFormConexionInicialEvent(ConecionSeleccionada);
            dlg.ShowDialog();
        }
        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
        }
        private void ConecionSeleccionada(string grupo, Conexiones.CConexion conexion)
        {
            //veo si ya existe el grupo
            CNodoGrupo Grupo = null;
            foreach(CNodoGrupo obj in Nodes)
            {
                if(obj.Nombre==grupo)
                {
                    Grupo = obj;
                    break;
                }
            }
            if(Grupo==null)
            {
                Grupo = new CNodoGrupo();
                Grupo.Nombre = grupo;
                Grupo.Modelo = Modelo;
                Nodes.Add(Grupo);
                //lo agrego al modelo
                Modelo.AgregaServidor(Grupo.Nombre);
            }
            Grupo.AgregaConexion(conexion);
        }
        public override void ModeloAsignado()
        {
            //me traigo los servidores del modelo
            List<CModelServidor> l = Modelo.DameServidores();
            foreach (CModelServidor obj in l)
            {
                CNodoGrupo Grupo = new CNodoGrupo();
                Grupo.Nombre = obj.Nombre;
                Grupo.Modelo = Modelo;
                Nodes.Add(Grupo);
            }
 
        }
    }
}
