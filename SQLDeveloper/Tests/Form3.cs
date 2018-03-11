using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sucursalesCopiaoriginalDataSet.articulos' Puede moverla o quitarla según sea necesario.

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.articulosTableAdapter.Fill(this.sucursalesCopiaoriginalDataSet.articulos);
            DataSet ds = new DataSet();
            foreach (DataTable dt in sucursalesCopiaoriginalDataSet.Tables)
            {
                if (dt.Rows.Count > 0)
                {
                    DataTable dt2 = dt.Copy();
                    ds.Tables.Add(dt2);
                }
            }
            controlerGrid1.DataSet = ds;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            l.Add("Error1");
            l.Add("Error2");
            l.Add("Error3");
            controlerGrid1.SetMensaje(l);
        }

        private void controlerGrid1_OnMessage(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
