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
    public delegate void OnFiltroEvent(CFiltro filtro);
    public partial class FormFiltro : Form
    {
        public event OnFiltroEvent OnFiltro;
        private bool OperadorEnable = true;
        public FormFiltro(bool operadores=true)
        {
            OperadorEnable = operadores;
            InitializeComponent();
        }

        private void FormFiltro_Load(object sender, EventArgs e)
        {
            CargaTipos();
            cargaOperadores();
        }
        private void CargaTipos()
        {
            ComboTipo.Items.Clear();
            ComboTipo.Items.Add(new CTipoBusqueda("Todos", MotorDB.EnumTipoObjeto.NONE));
            ComboTipo.Items.Add(new CTipoBusqueda("Tablas", MotorDB.EnumTipoObjeto.TABLE));
            ComboTipo.Items.Add(new CTipoBusqueda("Type Table", MotorDB.EnumTipoObjeto.TYPE_TABLE));
            ComboTipo.Items.Add(new CTipoBusqueda("Vistas", MotorDB.EnumTipoObjeto.VIEW));
            ComboTipo.Items.Add(new CTipoBusqueda("Procediientos almacenados", MotorDB.EnumTipoObjeto.PROCEDURE));
            ComboTipo.Items.Add(new CTipoBusqueda("Funciones", MotorDB.EnumTipoObjeto.FUNCION));
            ComboTipo.Items.Add(new CTipoBusqueda("Trigers", MotorDB.EnumTipoObjeto.TRIGER));
            ComboTipo.Items.Add(new CTipoBusqueda("Buscar campos en objetos", MotorDB.EnumTipoObjeto.CAMPO));
            ComboTipo.Items.Add(new CTipoBusqueda("Buscar en el codigo", MotorDB.EnumTipoObjeto.CODE));
            ComboTipo.SelectedIndex = 0;

        }
        private void cargaOperadores()
        {
            ComboOperador.Items.Clear();
            ComboOperador.Items.Add(OPERADOR.AND);
            ComboOperador.Items.Add(OPERADOR.OR);
            ComboOperador.Items.Add(OPERADOR.NOT);
            Loperador.Visible = OperadorEnable;
            ComboOperador.Visible = OperadorEnable;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (TNombre.Text == "")
            {
                MessageBox.Show("Falta el texto a buscar", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CTipoBusqueda busqueda = (CTipoBusqueda)ComboTipo.SelectedItem;
            if (busqueda == null)
            {
                MessageBox.Show("Falta el tipo de busqueda", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OPERADOR operador = OPERADOR.NONE;
            if (OperadorEnable)
            {
                if (ComboOperador.SelectedItem==null)
                {
                    MessageBox.Show("Falta el operador de busqueda", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                operador = (OPERADOR)ComboOperador.SelectedItem;
            }
            CFiltro filtro = new CFiltro(TNombre.Text, busqueda.Tipo, operador);
            if (OnFiltro != null)
                OnFiltro(filtro);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }
}
