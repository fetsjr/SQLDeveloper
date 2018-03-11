using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Comparador
{
    public delegate void ONFormSelectorEvent(string opcion1, string opcion2, String Codigo1, String Codigo2);
    public partial class FormSelector : Form
    {
        public event ONFormSelectorEvent OnSeleccion;
        public FormSelector()
        {
            InitializeComponent();
        }
        public FormSelector(string titulo, string texto1, string texto2, List<Modulos.Editores.EditorGenerico> lista1, List<Modulos.Editores.EditorGenerico> lista2)
        {
            InitializeComponent();
            Titulo = titulo;
            TextoArriba = texto1;
            TextoAbajo = texto2;
            ListaArriba = lista1;
            ListaAbajo = lista2;
        }
        public string Titulo
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        public string TextoArriba
        {
            get
            {
                return LPrimero.Text;
            }
            set
            {
                LPrimero.Text = value;
            }
        }
        public string TextoAbajo
        {
            get
            {
                return LSegundo.Text;
            }
            set
            {
                LSegundo.Text = value;
            }
        }
        private List<Modulos.Editores.EditorGenerico> FListaArriba;
        public List<Modulos.Editores.EditorGenerico> ListaArriba
        {
            get
            {
                List<Modulos.Editores.EditorGenerico> l = new List<Modulos.Editores.EditorGenerico>();
                foreach (Modulos.Editores.EditorGenerico s in FListaArriba)
                {
                    l.Add(s);
                }
                return l;
            }
            set
            {
                FListaArriba = new List<Editores.EditorGenerico>();
                Combo1.Items.Clear();
                foreach (Modulos.Editores.EditorGenerico s in value)
                {
                    FListaArriba.Add(s);
                    Combo1.Items.Add(s.ToString());
                }
            }
        }
        private List<Modulos.Editores.EditorGenerico> FListaAbajo;
        public List<Modulos.Editores.EditorGenerico> ListaAbajo
        {
            get
            {
                List<Modulos.Editores.EditorGenerico> l = new List<Modulos.Editores.EditorGenerico>();
                foreach (Modulos.Editores.EditorGenerico s in FListaAbajo)
                {
                    l.Add(s);
                }
                return l;
            }
            set
            {
                FListaAbajo = new List<Editores.EditorGenerico>();
                Combo2.Items.Clear();
                foreach (Modulos.Editores.EditorGenerico s in value)
                {
                    FListaAbajo.Add(s);
                    Combo2.Items.Add(s.ToString());
                }
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(Combo1.SelectedIndex==-1 || Combo2.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar los textos a comparar","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Modulos.Editores.CTextEdit ed1 = (Modulos.Editores.CTextEdit)ListaArriba[Combo1.SelectedIndex];
            Modulos.Editores.CTextEdit ed2 = (Modulos.Editores.CTextEdit)ListaAbajo[Combo2.SelectedIndex];
            if (OnSeleccion != null)
                OnSeleccion(Combo1.SelectedItem.ToString(), Combo2.SelectedItem.ToString(), ed1.CodigoFuente, ed2.CodigoFuente);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
