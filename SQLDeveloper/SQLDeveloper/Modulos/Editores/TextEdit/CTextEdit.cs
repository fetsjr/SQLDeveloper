using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Collections;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;

namespace SQLDeveloper.Modulos.Editores
{
    public delegate void OnBuscarTextoEvent(ICSharpCode.TextEditor.TextEditorControl Editor);
    public partial class CTextEdit : EditorGenerico
    {
        private bool FUsarConexionPrincipal = false;
        public event OnBuscarTextoEvent OnBuscarTexto;
        public event OnBuscarTextoEvent OnFoco;
        private bool ModificadoExternamente = false;
        private string FColorEditor = "SQL";
        FileManager.CFIleInfo InfoFile;
        FileManager.IFileManager fFileManager;
        DataSet Resultado;
        string Query;
        MotorDB.IMotorDB FMotor;
        private bool Modificado
        {
            set
            {
                BGuardar.Enabled = value;
            }
            get
            {
                return BGuardar.Enabled;
            }
        }
        public FileManager.IFileManager GestorArchivo
        {
            get
            {
                return fFileManager;
            }
            set
            {
                fFileManager = value;
                fFileManager.OnFileNameChange += new FileManager.OnFileNameChangeEvent(FileNameChange);
            }
        }
        public CTextEdit()
        {
            InitializeComponent();
            Guardado = true;
            Contenedor.Panel2Collapsed = true;
            Modificado = false;
            UsarConexionPrincipal = false;
            Comparable = true;
        }
        public string ColorEditor
        {
            get
            {
                return FColorEditor;
            }
            set
            {
                FColorEditor = value;
                CargaColor();
            }
        }
        private void CargaColor()
        {
            try
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Colores";
                ICSharpCode.TextEditor.Document.FileSyntaxModeProvider provider = new ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(appPath);
                ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(provider);
                TCodigo.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter(FColorEditor);
                //esta parte es para los tabuladores
                TCodigo.Document.FoldingManager.FoldingStrategy = new Ez_SQL.Clases.TxtEditor.SQLFoldingStrategy();
                TCodigo.Document.FoldingManager.UpdateFoldings(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ActualizaColores()
        {
            //este codigo hay que sobre escribirlo
            //  TCodigo.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter(FColorEditor);
            CargaColor();
        }
        public bool Guardado
        {
            get
            {
                return !Modificado;
            }
            set
            {
                Modificado = !value;
            }
        }
        public string FileName
        {
            get;
            set;
        }
        public void Abrir()
        {
            Babrir_Click(null, null);
        }
        public string CodigoFuente
        {
            get
            {
                return TCodigo.Text;
            }
            set
            {
                TCodigo.Text = value;
                cGestorDesaser1.TextoInicial = value;
                Modificado = false;
            }
        }
        public string Grupo
        {
            get
            {
                return Trgupo.Text;
            }
            set
            {
                Trgupo.Text = value;
            }
        }
        public string Conexion
        {
            get
            {

                return TConexion.Text;
            }
            set
            {
                TConexion.Text = value;
            }
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
                if (Parent != null)
                {
                    TabPage p = (TabPage)Parent;
                    p.Text = value;
                }
            }
        }

        private void Babrir_Click(object sender, EventArgs e)
        {
            InfoFile = GestorArchivo.Abrir();
            if (InfoFile == null)
                return;
            TCodigo.Text = InfoFile.Contenido;
            TCodigo.Refresh();
            LArchivo.Text = InfoFile.NombreCompleto;
            Nombre = InfoFile.NombreCorto;
            InfoFile.OnFileChange += new FileManager.OnFileChangeEvent(FileChangeEvent);
            ModificadoExternamente = false;
            TimerArchivo.Enabled = true;
            Modificado = false;
        }
        void FileChangeEvent(FileManager.CFIleInfo info, FileManager.TIPOC_AMBIO tipo)
        {
            if (tipo == FileManager.TIPOC_AMBIO.CMABIO_CONTENIDO)
            {
                ModificadoExternamente = true;
            }
        }

        private void TextEdit_Enter(object sender, EventArgs e)
        {
        }

        private void TimerArchivo_Tick(object sender, EventArgs e)
        {
            if (ModificadoExternamente && this.Visible == true)
            {
                TimerArchivo.Enabled = false;
                if (MessageBox.Show(this, "el contenido del archivo ha cambiado. ¿Deseas recargarlo?", "Archivo actualizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InfoFile = GestorArchivo.Abrir(LArchivo.Text);
                    TCodigo.Text = InfoFile.Contenido;
                    TCodigo.Refresh();
                    InfoFile.OnFileChange += new FileManager.OnFileChangeEvent(FileChangeEvent);
                    ModificadoExternamente = false;
                }
                TimerArchivo.Enabled = true;
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (InfoFile == null)
            {
                InfoFile = new FileManager.CFIleInfo();
                InfoFile.NombreCorto = TNombre.Text;
                InfoFile.NombreCompleto = LArchivo.Text;
            }
            InfoFile.Contenido = TCodigo.Text;
            InfoFile.NombreCompleto = GestorArchivo.Guardar(InfoFile);
            LArchivo.Text = InfoFile.NombreCompleto;
            Nombre = InfoFile.NombreCorto;
            InfoFile.OnFileChange += new FileManager.OnFileChangeEvent(FileChangeEvent);
            ModificadoExternamente = false;
            TimerArchivo.Enabled = true;
            Modificado = false;
        }

        private void BguardarComo_Click(object sender, EventArgs e)
        {
            if (InfoFile == null)
            {
                InfoFile = new FileManager.CFIleInfo();
                InfoFile.NombreCorto = TNombre.Text;
                InfoFile.NombreCompleto = LArchivo.Text;
            }
            InfoFile.Contenido = TCodigo.Text;
            InfoFile.NombreCompleto = GestorArchivo.GuardarComo(InfoFile);
            LArchivo.Text = InfoFile.NombreCompleto;
            Nombre = InfoFile.NombreCorto;
            InfoFile.OnFileChange += new FileManager.OnFileChangeEvent(FileChangeEvent);
            ModificadoExternamente = false;
            TimerArchivo.Enabled = true;
            Modificado = false;
        }

        private void BDeshacer_Click(object sender, EventArgs e)
        {
            cGestorDesaser1.Desaser();
        }

        private void BRehacer_Click(object sender, EventArgs e)
        {
            cGestorDesaser1.ReHacer();
        }

        private void cGestorDesaser1_OnDesaserChange(bool valor)
        {
            BDeshacer.Enabled = valor;
        }

        private void cGestorDesaser1_OnReHacerChange(bool valor)
        {
            BRehacer.Enabled = valor;
        }

        private void BNumeroLinea_Click(object sender, EventArgs e)
        {
            TCodigo.ShowLineNumbers = !TCodigo.ShowLineNumbers;

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (OnBuscarTexto != null)
                OnBuscarTexto(TCodigo);
        }
        public override void SetFocus()
        {
            if (OnFoco != null)
                OnFoco(TCodigo);
        }

        private void BEjecutar_Click(object sender, EventArgs e)
        {
            Contenedor.Panel2Collapsed = false;
            waitControl1.Animar = true;
            BEjecutar.Enabled = false;
            Grid.DataSet = null;
            if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectedText.Trim() == "")
                Query = TCodigo.Text;
            else
                Query = TCodigo.ActiveTextAreaControl.SelectionManager.SelectedText;
            if (!BkConsulta.IsBusy)
                BkConsulta.RunWorkerAsync();
        }

        private void BkConsulta_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!FUsarConexionPrincipal)
                    Resultado = Motor.Execute(Query);
                else
                    Resultado = DBProvider.DB.Execute(Query);
            }
            catch (MotorDB.ExceptionDB ex)
            {
                BkConsulta.ReportProgress(0, ex);
            }

        }

        private void BkConsulta_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<string> l = new List<string>();
            MotorDB.ExceptionDB err = (MotorDB.ExceptionDB)e.UserState;
            foreach (MotorDB.CError obj in err.Errores)
            {
                l.Add(obj.ToString());
            }
            Grid.SetMensaje(l);
            Resultado = null;
            BEjecutar.Enabled = true;
        }

        private void BkConsulta_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitControl1.Animar = false;
            if (Resultado != null)
                Grid.DataSet = Resultado;
            Contenedor.Panel2Collapsed = false;
            BEjecutar.Enabled = true;
        }

        private void BGrid_Click(object sender, EventArgs e)
        {
            Contenedor.Panel2Collapsed = !Contenedor.Panel2Collapsed;
        }

        private void TCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            VerificaComando(e);
        }
        private void VerificaComando(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BEjecutar_Click(null, null);
                return;
            }
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R:
                        BGrid_Click(null, null);
                        break;
                    case Keys.G:
                        BGuardar_Click(null, null);
                        break;
                    case Keys.O:
                        Babrir_Click(null, null);
                        break;
                    case Keys.F:
                        BBuscar_Click(null, null);
                        break;
                }
            }
        }

        private void Grid_OnMessage(string mensaje)
        {
            try
            {
                int LineNumber;
                string[] tmp;
                tmp = mensaje.Split('>');
                LineNumber = int.Parse(tmp[0]);

                TCodigo.Focus();

                TCodigo.ActiveTextAreaControl.ScrollTo(LineNumber);
                TCodigo.ActiveTextAreaControl.SelectionManager.SetSelection(new ICSharpCode.TextEditor.TextLocation(0, LineNumber - 1),
                    new ICSharpCode.TextEditor.TextLocation(TCodigo.Document.GetLineSegment(LineNumber - 1).Length, LineNumber - 1));

            }
            catch (System.Exception)
            {
                return;
            }
        }

        private void cGestorDesaser1_OnTextChange(bool valor)
        {
            Modificado = valor;
            try
            {
                //TCodigo.Document.FoldingManager.UpdateFoldings(null, null);
                TimerFolders.Enabled = false;
                TimerFolders.Enabled = true;
            }
            catch (System.Exception)
            {
                return;
            }
        }
        public override void Guardar()
        {
            BGuardar_Click(null, null);
        }
        public MotorDB.IMotorDB Motor
        {
            get
            {
                return FMotor;
            }
            set
            {
                FMotor = value;
                cInteliences1.DB = FMotor;
            }
        }

        private void TimerFolders_Tick(object sender, EventArgs e)
        {
            TCodigo.Document.FoldingManager.UpdateFoldings(null, null);
            TimerFolders.Enabled = false;
        }

        private void BTabular_Click(object sender, EventArgs e)
        {
            int pos = TCodigo.ActiveTextAreaControl.VScrollBar.Value;
            BlockAnaliser analizador = new BlockAnaliser();
            List<CBlock> Lista;

            analizador.Document = TCodigo.Document;
            TCodigo.Text = analizador.AnalizaTabuladores();
            TCodigo.ActiveTextAreaControl.VScrollBar.Value = pos;
            TimerFolders.Enabled = true;
        }
        private string SelectedText
        {
            get
            {
                if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > 0)
                {
                    ICSharpCode.TextEditor.Document.ISelection s = TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
                    return s.SelectedText;
                }
                return "";
            }
            set
            {
                if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > 0)
                {
                    ICSharpCode.TextEditor.Document.ISelection s = TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
                    TCodigo.Document.Replace(s.Offset, s.Length, value);
                    TCodigo.Refresh();
                    return;
                }

                TCodigo.Document.Insert(TCodigo.ActiveTextAreaControl.Caret.Offset, value);
            }
        }

        private void BComentar_Click(object sender, EventArgs e)
        {
            //comenta el dodigo seleccionado
            string s;
            string s2 = "--";
            s = SelectedText;
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                s2 = s2 + s[i];
                if (s[i] == '\n')
                {
                    s2 = s2 + "--";
                }
            }
            SelectedText = s2;

        }

        private void BDescomentar_Click(object sender, EventArgs e)
        {
            //comenta el dodigo seleccionado
            string s;
            string s2 = "";
            s = SelectedText;
            s2 = s.Replace("--", "");
            SelectedText = s2;

        }

        private Form cInteliences1_OnParentForm()
        {
            return ParentForm;
        }
        private bool UsarConexionPrincipal
        {
            get
            {
                return (BCambiarConexion.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText);
            }
            set
            {
                FUsarConexionPrincipal = value;
                Lgrupo.Visible = !FUsarConexionPrincipal;
                Trgupo.Visible = !FUsarConexionPrincipal;
                LConexion.Visible = !FUsarConexionPrincipal;
                TConexion.Visible = !FUsarConexionPrincipal;

                if (value == true)
                {
                    BCambiarConexion.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    cInteliences1.DB = DBProvider.DB;
                }
                else
                {
                    BCambiarConexion.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    cInteliences1.DB = FMotor;
                }
            }
        }
        private void BCambiarConexion_Click(object sender, EventArgs e)
        {
            UsarConexionPrincipal = !UsarConexionPrincipal;
        }

        private void CTextEdit_Load(object sender, EventArgs e)
        {
            if (fFileManager != null)
            {
                Babrir.Enabled = fFileManager.EnableAbrir();
                BGuardar.Enabled = fFileManager.EnableGuardar();
                BguardarComo.Enabled = fFileManager.EnableGuardarComo();
            }
        }
        private void FileNameChange(string nombre, string nuevoNombre)
        {
            TabPage obj = (TabPage)this.Parent;
            obj.Text = nuevoNombre;
            TNombre.Text = nuevoNombre;
           // 
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
