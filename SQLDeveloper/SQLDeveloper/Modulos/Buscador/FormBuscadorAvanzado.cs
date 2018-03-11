using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Buscador
{
    public partial class FormBuscadorAvanzado : Form
    {
        MotorDB.IMotorDB MotorInicial;
        private List<CNodoBusqueda> Encontrados=new List<CNodoBusqueda>();
        private bool NorecargarFiltros;
        public event OnVerObjetoEvent OnVerObjeto;
        Conexiones.CNodoRaiz NodoRaiz;
        public FormBuscadorAvanzado(MotorDB.IMotorDB motor)
        {
            MotorInicial = motor;
            InitializeComponent();
            CargaConexiones();
        }
        private void CargaConexiones()
        {
            NodoRaiz = new Conexiones.CNodoRaiz();
            treeView1.Nodes.Add(NodoRaiz);
            NodoRaiz.CargaGrupos();
            if (MotorInicial != null)
            {
                NodoRaiz.MarcaMotor(MotorInicial);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Conexiones.CNodoBase nodo = (Conexiones.CNodoBase)e.Node;
            nodo.AfterCheck();
        }

        private void BAgregarFiltro_Click(object sender, EventArgs e)
        {
            bool tipos = true;
            if (cBuscadorAvanzado1.DameFiltros().Count == 0)
                tipos = false;
            FormFiltro dlg = new FormFiltro(tipos);
            dlg.OnFiltro += new OnFiltroEvent(OnFiltro);
            dlg.ShowDialog();
        }
        private void OnFiltro(CFiltro filtro)
        {
            cBuscadorAvanzado1.AgregarFiltro(filtro);
        }

        private void cBuscadorAvanzado1_OnFiltroChange(CBuscadorAvanzado sender)
        {
            if (NorecargarFiltros == false)
            {
                ListaFiltros.Items.Clear();
                foreach (CFiltro obj in cBuscadorAvanzado1.DameFiltros())
                {
                    ListaFiltros.Items.Add(obj);
                }
            }
        }

        private void BQuitarFiltro_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Eliminar los filtros seleccionados","Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                NorecargarFiltros = true;
                foreach(CFiltro obj in ListaFiltros.SelectedItems)
                {
                    cBuscadorAvanzado1.EliminaFiltro(obj);
                }
                NorecargarFiltros = false;
                cBuscadorAvanzado1_OnFiltroChange(cBuscadorAvanzado1);
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            //me traigo las conexiones seleccionadas
            List<Conexiones.CConexion> conexiones = NodoRaiz.DameConexionesSeleccionadas();
            if(conexiones .Count()==0)
            {
                MessageBox.Show("Seleccione las conexiones a buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //agrego las conexiones
            cBuscadorAvanzado1.DameMotores().Clear();
            foreach(Conexiones.CConexion obj in conexiones)
            {

                cBuscadorAvanzado1.AgregaMotor(Conexiones.ControladorConexiones.DameMotor(obj));
            }
            if(cBuscadorAvanzado1.DameFiltros().Count()==0)
            {
                MessageBox.Show("Tiene que agregar los filtros de busqueda", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cBuscadorAvanzado1.Buscar();
        }

        private void cBuscadorAvanzado1_OnInicioBusqueda(CBuscadorAvanzado sender)
        {
            LResultado.Text = "Buscando";
            Encontrados = new List<CNodoBusqueda>();
            ListaObjetos.Nodes.Clear();
            waitControl1.Animar = true;
        }

        private void cBuscadorAvanzado1_OnFinBusqueda(CBuscadorAvanzado sender)
        {
            waitControl1.Animar = false;

        }

        private void cBuscadorAvanzado1_OnObjetoEncontrado(CBuscadorAvanzado sender, CObjetoBusquedaAvanzado obj)
        {
//            TimerLLena.Enabled = true;
            CNodoBusqueda nodo = new CNodoBusqueda();
            nodo.Nombre = obj.Nombre;
            nodo.Tipo = obj.Tipo;
            nodo.Motor = obj.Motor;
            Encontrados.Add(nodo);
        }

        private void TimerLLena_Tick(object sender, EventArgs e)
        {
            while(Encontrados.Count()>0)
            {
                CNodoBusqueda nodo =Encontrados[0];
                Encontrados.RemoveAt(0);
                ListaObjetos.Nodes.Add(nodo);
                LResultado.Text =ListaObjetos.Nodes.Count.ToString()+ " Objetos encontrados";
            }
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                if (OnVerObjeto != null)
                {
                    OnVerObjeto(nodo.Motor,nodo.Nombre, nodo.Tipo);
                }
            }
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            CNodoBusqueda nodo = (CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                OnVerObjeto(nodo.Motor,nodo.Nombre, nodo.Tipo);
            }

        }
    }
}
