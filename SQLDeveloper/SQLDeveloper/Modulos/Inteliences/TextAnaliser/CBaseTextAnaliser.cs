using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SQLDeveloper.Modulos.Inteliences.TextAnaliser
{
    public partial class CBaseTextAnaliser : Component, ITextAnaliser
    {
        private string FTextoInterno = "";
        protected bool AnalisisActivo = false; //variable que indica que el anasisis esta activo
        protected List<CSimbolo> TablaSimbolos = new List<CSimbolo>();
        protected ICSharpCode.TextEditor.TextEditorControl TCodigo;
        public CBaseTextAnaliser()
        {
            TiempoRefresh = 1; 
            InitializeComponent();
        }

        public CBaseTextAnaliser(IContainer container)
        {
            TiempoRefresh = 1;
            container.Add(this);

            InitializeComponent();
        }
        #region implementacion de ITextAnaliser
        private void IniciaAnalisis()
        {
            AnalisisActivo = true;
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
        public void SetTextEditor(ICSharpCode.TextEditor.TextEditorControl editor)
        {
            TCodigo = editor;
            IniciaAnalisis();
        }

        public List<string> GetVariableNames()
        {
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.VARIABLE)
                {
                    l.Add(obj.Name);
                }
            }
            return l;
        }

        public List<string> GetTablesNames()
        {
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.TABLA)
                {
                    l.Add(obj.Name);
                }
            }
            return l;
        }

        public List<string> GetTableFields(string tabla)
        {
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.CAMPO)
                {
                    l.Add(obj.Name);
                }
            }
            return l;
        }

        public int GetDeclarationLine(string nombre)
        {
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Name.ToUpper().Trim() == nombre.ToUpper().Trim())
                {
                    return obj.DeclarationLinea;
                }
            }
            return -1;
        }
        #endregion
        protected virtual void AnalizaTexto( string Texto)
        {
            //esta funcion hay que sobreescribirla para dar la funcionalidad al sistema
        }
        public int TiempoRefresh
        {
            get;
            set;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string texto = "";
            DateTime hora = DateTime.Now;
            do
            {
                if (DateTime.Now >= hora)
                {
                    //hay que analisar el texto
                    try
                    {
                        //me traigo el codigo que se tiene actualmente en el editor
                        FTextoInterno = null;
                        backgroundWorker1.ReportProgress(-1);
                        while (FTextoInterno==null)
                            Thread.Sleep(1000);
                        texto = FTextoInterno;// TCodigo.Text;
                        //limpio la tabla de simbolos
                        TablaSimbolos.Clear();
                        AnalizaTexto(texto);
                    }
                    catch (System.Exception)
                    {
                        ;//no hace nada
                    }
                    hora = DateTime.Now.AddMinutes(TiempoRefresh);
                }
                Thread.Sleep(1000); // se duerme un segundo
            }
            while (AnalisisActivo);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnalisisActivo)
            {
                //se salio y no devia hacerlo
                IniciaAnalisis();
            }
        }
        protected void AddSimbol(CSimbolo obj)
        {
            //agrega el simbolo a la tabla de simbolos
            //verifica si no esta repetido
            foreach(CSimbolo obj2 in TablaSimbolos)
            {
                if (obj.Name.ToUpper().Trim() == obj2.Name.ToUpper().Trim() /*&& obj.DeclarationLinea == obj2.DeclarationLinea*/ && obj.Tipo == obj2.Tipo)
                    return; // ya se encuentra en la tabla de simbolos
            }
            //como no esta lo agrego
            TablaSimbolos.Add(obj);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //me traifo el texto
            if(TCodigo!=null)
            {
                FTextoInterno = TCodigo.Text;
            }
        }
    }
}
