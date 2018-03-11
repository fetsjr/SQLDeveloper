using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LineaInicial");
            dt.Columns.Add("PosLineaInicial");
            dt.Columns.Add("PosicionGeneralInicial");
            dt.Columns.Add("LineaFinal");
            dt.Columns.Add("PosLineaFinal");
            dt.Columns.Add("PosicionGeneralFinal");
            dt.Columns.Add("SuperTipo");
            dt.Columns.Add("Tip");
            dt.Columns.Add("Texto");
            lecxer1.Cadena = textBox1.Text;
            foreach(Lexer.Lexema lex in lecxer1)
            {
                DataRow dr = dt.NewRow();
                
                dr["LineaInicial"]=lex.PosicionInicial.Linea;
                dr["PosLineaInicial"]=lex.PosicionInicial.PosicionLinea;
                dr["PosicionGeneralInicial"]=lex.PosicionInicial.PosicionGeneral;
                dr["LineaFinal"]=lex.PosicionFinal.Linea;
                dr["PosLineaFinal"]=lex.PosicionFinal.PosicionLinea;
                dr["PosicionGeneralFinal"]=lex.PosicionFinal.PosicionGeneral;
                dr["SuperTipo"]=lex.SuperTipo;
                dr["Tip"]=lex.Tipo;
                dr["Texto"] = lex.Texto;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }
    }
}
