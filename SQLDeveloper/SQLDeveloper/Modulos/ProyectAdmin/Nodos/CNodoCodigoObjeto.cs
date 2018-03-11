using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SQLDeveloper.Modulos.ProyectAdmin
{
    public delegate void OnNodoSeleccionadoEvent();
    class CNodoCodigoObjeto: CNodoBase
    {
        public event OnNodoSeleccionadoEvent OnNodoVisto; 
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem MenuVerCodigo;
        private System.Windows.Forms.ToolStripMenuItem MenuComentarios;
        DateTime FFecha;
        private bool FVisto;
        public CModelCodigoObjeto COdigoObjeto
        {
            get;
            set;
        }
        public CNodoCodigoObjeto()
        {
            FFecha = System.DateTime.Now;
            FVisto = true;
            ImageIndex = 18;
            SelectedImageIndex = 18;
        }
        public DateTime Fecha
        {
            get
            {
                return FFecha;
            }
            set
            {
                FFecha = value;
                Nombre = FFecha.ToString("dd/MMMM/yyyy: hh:mm tt");
            }
        }
        public string NombreObjeto
        {
            get;
            set;
        }
        public string Comentarios
        {
            get;
            set;
        }
        public string Servidor
        {
            get;
            set;
        }
        public Conexiones.CConexion Conexion
        {
            get;
            set;
        }
        public bool Visto
        {
            get
            {
                return FVisto;
            }
            set
            {
                FVisto = value;
                if(FVisto==false)
                {
                    ForeColor = Color.Red;
                }
                else
                {
                    ForeColor = Color.Black;
                }

            }
        }
        protected override System.Windows.Forms.ContextMenuStrip CreaMenu()
        {
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuVerCodigo = new System.Windows.Forms.ToolStripMenuItem();
            MenuComentarios = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // MenuTabla
            // 
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVerCodigo,MenuComentarios});
            this.MenuPrinciapl.Name = "MenuPrinciapl";
            this.MenuPrinciapl.Size = new System.Drawing.Size(202, 70);
            // 
            // MenuVerCodigo
            // 
            this.MenuVerCodigo.Image = ((System.Drawing.Image)(resources.GetObject("IconoEditar")));
            this.MenuVerCodigo.Name = "MenuVerCodigo";
            this.MenuVerCodigo.Size = new System.Drawing.Size(201, 22);
            this.MenuVerCodigo.Text = "Ver Código";
            this.MenuVerCodigo.Click += new System.EventHandler(this.MenuVerCodigo_Click);
            // 
            // MenuComentarios
            // 
            this.MenuComentarios.Image = ((System.Drawing.Image)(resources.GetObject("comentario")));
            this.MenuComentarios.Name = "MenuVerCodigo";
            this.MenuComentarios.Size = new System.Drawing.Size(201, 22);
            this.MenuComentarios.Text = "Cometarios";
            this.MenuComentarios.Click += new System.EventHandler(this.MenuComentarios_Click);

             
            return MenuPrinciapl;
        }
        private void MenuComentarios_Click(object sender, EventArgs e)
        {
            FormComentario dlg = new FormComentario();
            dlg.Texto = COdigoObjeto.Cometarios;
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Modelo.AsignaComentario(COdigoObjeto.ID_Codigo, dlg.Texto);
            COdigoObjeto.Cometarios = dlg.Texto;
        }
        public override void Seleccionado()
        {
            Modelo.HistoricoVisto(COdigoObjeto);
            COdigoObjeto.Visto = true;
            Visto = true;
            if (OnNodoVisto != null)
                OnNodoVisto();
        }
        private void MenuVerCodigo_Click(object sender, EventArgs e)
        {
            //me traigo el acceso al formulario
            FormProyect dlg = (FormProyect)TreeView.Tag;
            //me traigo el codigo de la base de datos

            CModelCodigoObjeto obj = Modelo.DameCodigo(Servidor, Conexion.Nombre, NombreObjeto, COdigoObjeto.ID_Codigo);
            if (obj == null)
                return;
            //string s = Codigo;
            //me traigo el motor
            MotorDB.IMotorDB motor = Conexiones.ControladorConexiones.DameMotor(Conexion);
            //mando a mostrar el codigo
            dlg.VerCodigo(NombreObjeto+" "+Nombre, obj.Codigo, motor, Servidor, Conexion.Nombre);
        }
    }
}
