using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crownwood.Magic.Common;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Menus;
using System.IO;
namespace SQLDeveloper
{
    public delegate void OnRecargaColoresEvent();
    public partial class FormPrincipal : Form
    {
        public event OnRecargaColoresEvent OnRecargaColores;
        #region VENTANAS ACOPLABLES
        private int childFormNumber = 0;
        protected DockingManager AdministradorVentanasAcoplables;
        private bool dox;
        WindowContent ContenedorIzquierdo;
        WindowContent ContenedorDerecho;
        private Modulos.Editores.FormEditor VEditor;
        private bool CerrarPespaña = true;

        #endregion
        #region Ventanas comunes

        #endregion
        private bool Cerrando;
        public FormPrincipal()
        {
            Cerrando = false;
            InitializeComponent();
            EnableCOnexion = false;
            #region VENTANAS ACOPLABLES
            AdministradorVentanasAcoplables = new DockingManager(this, VisualStyle.Plain);
            AdministradorVentanasAcoplables.ContentHiding += new DockingManager.ContentHidingHandler(DestruirAlCerrar);
            #endregion
        }
        #region VENTANAS ACOPLABLES
        private void DestruirAlCerrar(Content c, CancelEventArgs e)
        {
            //Este evento se genera al momento de cerrar la venta acoplable 
            //y lo que va a hacer es cerrar la ventana y destruirla
            Form f = (Form)c.Control;
            f.Close();
        }
        private void VentanaAcoplable(Form dlg, int ImajenIndex, bool PositionTop, State state)
        {
            Size s = new Size(dlg.Width, dlg.Height);
            Content contenedor = AdministradorVentanasAcoplables.Contents.Add(dlg, dlg.Text, imageList1, ImajenIndex);
            contenedor.CaptionBar = true;
            contenedor.CloseButton = true;
            contenedor.DisplaySize = s;
            if (state == State.DockLeft)
            {
                if (ContenedorIzquierdo == null || ContenedorIzquierdo.Visible == false)
                {
                    ContenedorIzquierdo = AdministradorVentanasAcoplables.AddContentWithState(contenedor, state);
                }
                else
                {
                    AdministradorVentanasAcoplables.AddContentToWindowContent(contenedor, ContenedorIzquierdo);
                }
            }
            else if (state == State.DockRight)
            {
                if (ContenedorDerecho == null || ContenedorDerecho.Visible == false)
                {
                    ContenedorDerecho = AdministradorVentanasAcoplables.AddContentWithState(contenedor, state);
                }
                else
                {
                    AdministradorVentanasAcoplables.AddContentToWindowContent(contenedor, ContenedorDerecho);
                }
            }
            else
            {
                AdministradorVentanasAcoplables.AddContentWithState(contenedor, state);
            }
            contenedor.PropertyChanged += new Content.PropChangeHandler(PropChangeHandler);
            contenedor.PropertyChanging += new Content.PropChangeHandler(PropChangeHandlerX);
            WindowContentTabbed wct = contenedor.ParentWindowContent as WindowContentTabbed;
            if (wct != null)
            {
                wct.TabControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
                wct.TabControl.PositionTop = PositionTop;
                wct.BringContentToFront(contenedor);
            }
        }
        private void PropChangeHandler(Content c, Content.Property p)
        {
        }
        private void PropChangeHandlerX(Content c, Content.Property p)
        {
            if (c.Docked == dox)
                return;
            dox = c.Docked;
            int o = c.Order;
        }
        private bool ExisteVentanaIzquierda(Type tipo)
        {
            foreach (Content c in AdministradorVentanasAcoplables.Contents)
            {

                if (c.Control.GetType() == tipo && c.Visible)
                    return true;
            }
            return false;
        }
        private Form DameVentana(Type tipo)
        {
            foreach (Content c in AdministradorVentanasAcoplables.Contents)
            {

                if (c.Control.GetType() == tipo && c.Visible)
                    return (Form)c.Control;
            }
            return null;

        }
        private List<Content> DameContenedorVentana(Type tipo)
        {
            List<Content> l = new List<Content>();
            foreach (Content c in AdministradorVentanasAcoplables.Contents)
            {

                if (c.Control.GetType() == tipo && c.Visible)
                {
                    l.Add(c);
                }
            }
            return l;

        }
        private void CierraContenedor(Content c)
        {
            AdministradorVentanasAcoplables.Contents.Remove(c);
        }
        #endregion
        private bool EnableCOnexion
        {
            set
            {
                //aqui hay que agregar los controles que se tienen que habilitar cuando se tenga una conexion valida
                BBuscador.Enabled = value;
                BNuevaTabla.Enabled = value;
                Bnuevo.Enabled = value;
                BAbrir.Enabled = value;
                BComparar.Enabled = value;
            }
        }

        private void Conecciones(object sender, EventArgs e)
        {
            if (ExisteVentanaIzquierda(typeof(Conexiones.FormAdminConexiones)) == false)
            {
                Conexiones.FormAdminConexiones AdministradorConexiones = new Conexiones.FormAdminConexiones();
                VentanaAcoplable(AdministradorConexiones, 0, true, State.DockLeft);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void CargaGrupos()
        {
            List<string> grupos;
            grupos = Conexiones.ControladorConexiones.GetGrupos();
            ComboGrupos.Items.Clear();
            foreach (string s in grupos)
            {
                ComboGrupos.Items.Add(s);
            }
        }
        private void ComboGrupos_DropDown(object sender, EventArgs e)
        {
            CargaGrupos();
        }
        private void CargaConexiones()
        {
            //me traigo el grupo seleccionado
            if (ComboGrupos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ComboConexiones.Items.Clear();
            string grupo = ComboGrupos.Text;
            List<Conexiones.CConexion> lista = Conexiones.ControladorConexiones.GetConexiones(grupo);
            foreach (Conexiones.CConexion obj in lista)
            {
                ComboConexiones.Items.Add(obj);
            }
        }
        private void ComboConexiones_DropDown(object sender, EventArgs e)
        {
            CargaConexiones();
        }

        private void ComboConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
                return;
            //Asigno la conexion al motor de base de datos
            Conexiones.CConexion obj = (Conexiones.CConexion)ComboConexiones.SelectedItem;
            //me traigo el motor de base de datos
            MotorDB.EnumMotoresDB tipoDB = Conexiones.ControladorConexiones.DameTipoMotor(obj.MotorDB);
            DBProvider.DB = MotorDB.CProviderDataBase.DameMotor(tipoDB);
            DBProvider.DB.SetConnectionName(obj.Nombre);
            DBProvider.DB.SetConnectionString(obj.ConecctionString);
            try
            {
                if(DBProvider.DB.Conectar()==false)
                {
                    MessageBox.Show("No se puede conectar a la base de datos: "+DBProvider.DB.GetStringError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DBProvider.DB.Desconectar();
                EnableCOnexion = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //evito la seleccion de la conexion
                ComboConexiones.SelectedIndex = -1;
                EnableCOnexion = false;
                return;
            }
        }

        private void BBuscador_Click(object sender, EventArgs e)
        {
            //muestro la ventana de busqueda
            if (ExisteVentanaIzquierda(typeof(Modulos.Buscador.FormBuscadorObjetos)) == false)
            {
                Modulos.Buscador.FormBuscadorObjetos dlg = new Modulos.Buscador.FormBuscadorObjetos();
                dlg.OnVerObjeto += new OnVerObjetoEvent(VerObjeto);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }

        }
        private void VerObjeto(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            //dependiendo del tipo de objeto se muestra el visor correspondiente
            switch (tipo)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    VerCodigo(motor,nombre, motor.DameCodigoFuncction(nombre));
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    VerCodigo(motor,nombre, motor.DameCodigoStoreProcedure(nombre));
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    MuestraTabla(motor,nombre);                    
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    MuestraTypeTable(motor,nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    VerCodigo(motor,nombre, motor.DameCodigoTrigger(nombre));
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    MuestraVista(motor,nombre);
                    break;
            }
        }
        private void VerDependencias(MotorDB.IMotorDB motor,string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modulos.Visores.Dependencias.FormDependencias dlg = new Modulos.Visores.Dependencias.FormDependencias(motor,nombre);
            dlg.OnVerObjeto += new OnVerObjetoEvent(VerObjeto);
            VentanaAcoplable(dlg, 5, false, State.DockLeft);
        }
        private void VerRelaciones(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modulos.Visores.Relaciones.FormRelaciones dlg = new Modulos.Visores.Relaciones.FormRelaciones(motor,nombre);
            dlg.OnVerObjeto += new OnVerObjetoEvent(VerObjeto);
            VentanaAcoplable(dlg, 5, false, State.DockLeft);
        }
        private void VerTrrigers(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            Modulos.Visores.Trrigers.FormTrigger dlg = new Modulos.Visores.Trrigers.FormTrigger(nombre);
            dlg.OnVerObjeto += new OnVerObjetoEvent(VerObjeto);
            VentanaAcoplable(dlg, 6, false, State.DockLeft);
        }
        private void MuestraTabla(MotorDB.IMotorDB motor, string nombre)
        {
            Modulos.Visores.Tabla.FormTabla dlg = new Modulos.Visores.Tabla.FormTabla(motor,nombre);
            dlg.OnVerTablaPadre += new OnVerObjetoEvent(VerObjeto);
            dlg.OnVerDependencias += new OnVerObjetoEvent(VerDependencias);
            dlg.OnVerRelaciones += new OnVerObjetoEvent(VerRelaciones);
            dlg.OnVerTrrigers += new OnVerObjetoEvent(VerTrrigers);
            dlg.OnPropiedadesCampo += new OnPropiedadesEvent(MuestraPropuedades);
            dlg.OnVerCodigoTabla += new OnVerObjetoEvent(VerCodigoTabla);
            VentanaAcoplable(dlg, 4, true, State.DockRight);
        }
        private void MuestraTypeTable(MotorDB.IMotorDB motor, string nombre)
        {
            Modulos.Visores.Tabla.FormTabla dlg = new Modulos.Visores.Tabla.FormTabla(motor,nombre,true);
            dlg.OnVerTablaPadre += new OnVerObjetoEvent(VerObjeto);
            dlg.OnVerDependencias += new OnVerObjetoEvent(VerDependencias);
            dlg.OnVerRelaciones += new OnVerObjetoEvent(VerRelaciones);
            dlg.OnVerTrrigers += new OnVerObjetoEvent(VerTrrigers);
            dlg.OnPropiedadesCampo += new OnPropiedadesEvent(MuestraPropuedades);
            dlg.OnVerCodigoTabla += new OnVerObjetoEvent(VerCodigoTabla);
            VentanaAcoplable(dlg, 4, true, State.DockRight);
        }
        private void MuestraPropuedades(Modulos.Visores.CPropiedadesBase obj)
        {
            Modulos.Visores.Propiedades.FormPropiedades dlg = null;
            dlg = (Modulos.Visores.Propiedades.FormPropiedades)DameVentana(typeof(Modulos.Visores.Propiedades.FormPropiedades));
            if (dlg == null)
                return;
            dlg.Objeto = obj;
        }

        private void Bpropiedades_Click(object sender, EventArgs e)
        {
            //muestra la ventyana de propiedades
            Modulos.Visores.Propiedades.FormPropiedades dlg = null;
            dlg = (Modulos.Visores.Propiedades.FormPropiedades)DameVentana(typeof(Modulos.Visores.Propiedades.FormPropiedades));
            if (dlg == null)
            {
                dlg = new Modulos.Visores.Propiedades.FormPropiedades();
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }
        }

        private void BNuevaTabla_Click(object sender, EventArgs e)
        {
            Modulos.CreadorTabla.FormNuevaTabla dlg = new Modulos.CreadorTabla.FormNuevaTabla(DBProvider.DB);
            dlg.OnVerTabla += new OnVerObjetoEvent(VerObjeto);
            dlg.ShowDialog();
        }

        private void ComboConexiones_Click(object sender, EventArgs e)
        {

        }
        private void MuestraVista(MotorDB.IMotorDB motor, string nombre)
        {
            Modulos.Visores.Vista.FormVista dlg = new Modulos.Visores.Vista.FormVista(motor,nombre);
            dlg.OnVerTablaPadre += new OnVerObjetoEvent(VerObjeto);
            dlg.OnVerDependencias += new OnVerObjetoEvent(VerDependencias);
            dlg.OnVerRelaciones += new OnVerObjetoEvent(VerRelaciones);
            dlg.OnVerTrrigers += new OnVerObjetoEvent(VerTrrigers);
            dlg.OnPropiedadesCampo += new OnPropiedadesEvent(MuestraPropuedades);
            dlg.OnVerCodigoVista += new OnVerObjetoEvent(VerCodigoVista);
            VentanaAcoplable(dlg, 4, true, State.DockRight);
        }
        private void CargaEditor()
        {
            if (VEditor == null)
            {
                VEditor = new Modulos.Editores.FormEditor();
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Modulos.Editores.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Modulos.Editores.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
        }
        private void OnCerrarEditor()
        {
            VEditor = null;
        }
        private bool PuedoCerrarPestaña()
        {
            return CerrarPespaña;
        }

        private void Bnuevo_Click(object sender, EventArgs e)
        {
            CargaEditor();
            Modulos.Editores.CTextEdit edit = new Modulos.Editores.CTextEdit();
            edit.Motor = DBProvider.DB;
            edit.Nombre = "Sin titulo";
            edit.Grupo = ComboGrupos.Text;
            edit.Conexion = ComboConexiones.Text;
            edit.ColorEditor = DBProvider.DB.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new Modulos.Editores.OnBuscarTextoEvent(BuscarTexto);
            edit.OnFoco += new Modulos.Editores.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            VEditor.AgregaEditor(edit, "Sin titulo");
        }
        private void VerCodigo(MotorDB.IMotorDB motor, string nombre, string codigo)
        {
            Conexiones.CPropiedadesMotor propiedades = Conexiones.ControladorConexiones.DamePropiedadesMotor(motor);
            CargaEditor();
            Modulos.Editores.CTextEdit edit = new Modulos.Editores.CTextEdit();
            edit.Motor = motor;
            edit.CodigoFuente = codigo;
            edit.Nombre = nombre;
            edit.Grupo = propiedades.Grupo;
            edit.Conexion = propiedades.Conexion.Nombre;
            edit.ColorEditor = motor.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new Modulos.Editores.OnBuscarTextoEvent(BuscarTexto);
            edit.OnFoco += new Modulos.Editores.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            VEditor.AgregaEditor(edit, nombre);
            edit.SetFocus();
        }
        private void BuscarTexto(ICSharpCode.TextEditor.TextEditorControl Editor)
        {
            if (ExisteVentanaIzquierda(typeof(Modulos.Editores.FormBuscador)) == false)
            {
                Modulos.Editores.FormBuscador dlg = new Modulos.Editores.FormBuscador();
                dlg.Editor = Editor;
                VentanaAcoplable(dlg, 0, true, State.DockRight);
            }

        }
        private void EditorFocoText(ICSharpCode.TextEditor.TextEditorControl Editor)
        {
            Modulos.Editores.FormBuscador dlg;
            dlg = (Modulos.Editores.FormBuscador)DameVentana(typeof(Modulos.Editores.FormBuscador));
            if (dlg != null)
            {
                dlg.Editor = Editor;
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarPespaña = false;
            if (Cerrando == true)
                return;
            if (MessageBox.Show("Cerrar la aplicación", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
                Cerrando = false;
                return;
            }
            Cerrando = true;
            if (VEditor != null)
            {
                VEditor.CierraPestañas();
            }
            Application.Exit();

        }
        private void VerCodigoVista(MotorDB.IMotorDB motor, string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            VerCodigo(motor, nombre, motor.DameCodigoVista(nombre));
        }
        private void VerCodigoTabla(MotorDB.IMotorDB motor,string nombre, MotorDB.EnumTipoObjeto tipo)
        {
            VerCodigo(motor, nombre, motor.DameCodigoTabla(nombre));
        }

        private void BAbrir_Click(object sender, EventArgs e)
        {
            CargaEditor();
            Modulos.Editores.CTextEdit edit = new Modulos.Editores.CTextEdit();
            edit.Motor = DBProvider.DB;
            edit.Nombre = "Sin titulo";
            edit.Grupo = ComboGrupos.Text;
            edit.Conexion = ComboConexiones.Text;
            edit.ColorEditor = DBProvider.DB.GetMotor().ToString();
            edit.GestorArchivo = new FileManager.CFileManager();
            edit.OnBuscarTexto += new Modulos.Editores.OnBuscarTextoEvent(BuscarTexto);
            edit.OnFoco += new Modulos.Editores.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            VEditor.AgregaEditor(edit, "Sin titulo");
            edit.Abrir();
        }

        private void gestorDeTabuladoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLDeveloper.Modulos.Herramientas.GestorBloques.FormConfigBloques dlg = new Modulos.Herramientas.GestorBloques.FormConfigBloques();
            dlg.ShowDialog();
        }

        private void MenuTemas_Click(object sender, EventArgs e)
        {
            Modulos.Herramientas.GestorColors.FormGestorColor dlg = new Modulos.Herramientas.GestorColors.FormGestorColor();
            dlg.OnEditConfigChange += new Modulos.Herramientas.GestorColors.OnEditConfigChangeEvent(EditConfigChangeEvent);
            dlg.ShowDialog();
        }
        private void EditConfigChangeEvent(string archivo)
        {
            if (OnRecargaColores != null)
                OnRecargaColores();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfig dlg = new FormConfig();
            dlg.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LoadHistoryproyects();
            Conexiones.FormConexionInicial dlg = new Conexiones.FormConexionInicial();
            dlg.OnConexion += new Conexiones.OnFormConexionInicialEvent(ConexionInicial);
            dlg.ShowDialog();
        }
        private void ConexionInicial(string grupo, Conexiones.CConexion conexion)
        {
            //me cargo los grupos
            CargaGrupos();
            ComboGrupos.SelectedItem = grupo;
            CargaConexiones();
            foreach (Conexiones.CConexion obj in ComboConexiones.Items)
            {
                if (obj.Nombre == conexion.Nombre)
                {
                    ComboConexiones.SelectedItem = obj;
                }
            }
        }


        private void BComparar_Click(object sender, EventArgs e)
        {
            if (VEditor == null)
                return;
            Dictionary<int, Modulos.Editores.EditorGenerico> l = VEditor.GetTabs();
            List<Modulos.Editores.EditorGenerico> l2 = new List<Modulos.Editores.EditorGenerico>();
            foreach (KeyValuePair<int, Modulos.Editores.EditorGenerico> obj in l)
            {
                if (obj.Value.Comparable)
                {
                    l2.Add(obj.Value);
                }
            }
            Modulos.Comparador.FormSelector dlg = new Modulos.Comparador.FormSelector("Comprar", "Izquierda", "Derecha", l2, l2);
            dlg.OnSeleccion += new Modulos.Comparador.ONFormSelectorEvent(Comparar);
            dlg.ShowDialog();
        }
        private void MenuNuevoProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = ".dbp";
                string nombre = "";
                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                nombre = saveFileDialog1.FileName;
                if (!saveFileDialog1.FileName.Contains("."))
                    nombre = saveFileDialog1.FileName + ".dbp";
                Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.NewProject(saveFileDialog1.FileName);
                MuestraProyecto(modelo);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuAbrirProyecto_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.OpenProject(openFileDialog1.FileName);
                MuestraProyecto(modelo);
                //Modulos.ProyectAdmin.FormProyect dlg = new Modulos.ProyectAdmin.FormProyect(modelo);
                //dlg.ONVerCodigo += new Modulos.ProyectAdmin.OnFormProyectCodigoEvent(VerCodigoProyecto);
                //dlg.OnCerrarProyecto += new Modulos.ProyectAdmin.FormProyectEvent(CerrarProyecto);
                //dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
                //VentanaAcoplable(dlg, 4, true, State.DockLeft);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHistoryproyects()
        {
            try
            {
                MenuProyectoReciente.DropDownItems.Clear();
                //ahora lo agrego al menu abrir
                Dictionary<string, string> l = cProjectManager1.GetHistory();
                foreach (var obj in l)
                {
                    System.Windows.Forms.ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = obj.Key;
                    item.Tag = obj.Value;
                    item.Click += new EventHandler(MenuAbrirItem_Click);
                    MenuProyectoReciente.DropDownItems.Add(item);
                }
            }
            catch(System.Exception ex)
            {
                return;
            }
        }
        private void MenuAbrirItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                string archivo = menu.Tag.ToString();
                if (!System.IO.File.Exists(archivo))
                {
                    if (MessageBox.Show("EL proyecto: " + menu.Text + " ya no existe.\n ¿Desea quitarlo de la lista?", "Archivo no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        cProjectManager1.RemoveHistory(archivo);
                        LoadHistoryproyects();
                        return;
                    }
                }
                Modulos.ProyectAdmin.ModeloBasico modelo = cProjectManager1.OpenProject(archivo);
                MuestraProyecto(modelo);
                //Modulos.ProyectAdmin.FormProyect dlg = new Modulos.ProyectAdmin.FormProyect(modelo);
                //dlg.ONVerCodigo += new Modulos.ProyectAdmin.OnFormProyectCodigoEvent(VerCodigoProyecto);
                //dlg.OnCerrarProyecto += new Modulos.ProyectAdmin.FormProyectEvent(CerrarProyecto);
                //dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
                //VentanaAcoplable(dlg, 4, true, State.DockLeft);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CerrarProyecto(Modulos.ProyectAdmin.FormProyect sender, string archivo)
        {
            //cierro el formulario
            cProjectManager1.CierraProyecto(archivo);
            List<Content> l = DameContenedorVentana(typeof(Modulos.ProyectAdmin.FormProyect));
            foreach(Content c in l)
            {
                if((Modulos.ProyectAdmin.FormProyect)c.Control==sender)
                {
                    CierraContenedor(c);
                    break;
                }
            }            
            sender.Close();
        }

        private void BBuscaAvanzado_Click(object sender, EventArgs e)
        {
            //muestro la ventana de busqueda
            if (ExisteVentanaIzquierda(typeof(Modulos.Buscador.FormBuscadorAvanzado)) == false)
            {

                Modulos.Buscador.FormBuscadorAvanzado dlg = new Modulos.Buscador.FormBuscadorAvanzado(DBProvider.DB);
                dlg.OnVerObjeto += new  OnVerObjetoEvent(VerObjeto);
                VentanaAcoplable(dlg, 0, true, State.DockLeft);
            }
        }

        private void generadorLiberiaCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulos.CSharpLibaryGenerator.FormLybraryGenrator dlg = new Modulos.CSharpLibaryGenerator.FormLybraryGenrator();
            VentanaAcoplable(dlg, 0, true, State.DockLeft);
        }
        private void Comparar(string opcion1, string opcion2, String Codigo1, String Codigo2)
        {

            CargaEditor();
            Modulos.Comparador.CompareViewer edit = new Modulos.Comparador.CompareViewer();
            edit.TextIzquierdo = Codigo1;
            edit.TextoDerecho = Codigo2;
            edit.TituloIzquierdo = opcion1;
            edit.TituloDerech = opcion2;
            edit.ColorEditor = DBProvider.DB.GetMotor().ToString();
            VEditor.AgregaEditor(edit, "Comparador");
            edit.SetFocus();

        }
        private void Comparar(string Codigo1, string Codigo2, string titulo1, string titulo2, string ColorEditor)
        {
            CargaEditor();
            Modulos.Comparador.CompareViewer edit = new Modulos.Comparador.CompareViewer();
            edit.TextIzquierdo = Codigo1;
            edit.TextoDerecho = Codigo2;
            edit.TituloIzquierdo = titulo1;
            edit.TituloDerech = titulo2;
            edit.ColorEditor = ColorEditor;// DBProvider.DB.GetMotor().ToString();
            VEditor.AgregaEditor(edit, "Comparador");
            edit.SetFocus();
        }
        private void VerCodigoProyecto(string objeto, string codigo, MotorDB.IMotorDB motor, string grupo, string conexion, FileManager.IFileManager fm = null)
        {
            CargaEditor();
            Modulos.Editores.CTextEdit edit = new Modulos.Editores.CTextEdit();
            edit.Motor = motor;
            edit.CodigoFuente = codigo;
            edit.Nombre = objeto;
            edit.Grupo = grupo;
            edit.Conexion = conexion;
            edit.ColorEditor = motor.GetMotor().ToString();
            if (fm == null)
                edit.GestorArchivo = new FileManager.CFileManager();
            else
                edit.GestorArchivo = fm;
            edit.OnBuscarTexto += new Modulos.Editores.OnBuscarTextoEvent(BuscarTexto);
            edit.OnFoco += new Modulos.Editores.OnBuscarTextoEvent(EditorFocoText);
            OnRecargaColores += new OnRecargaColoresEvent(edit.ActualizaColores);
            VEditor.AgregaEditor(edit, objeto);
            edit.SetFocus();

        }
        private void MuestraProyecto(Modulos.ProyectAdmin.ModeloBasico modelo)
        {
            Modulos.ProyectAdmin.FormProyect dlg = new Modulos.ProyectAdmin.FormProyect(modelo);
            dlg.ONVerCodigo += new Modulos.ProyectAdmin.OnFormProyectCodigoEvent(VerCodigoProyecto);
            dlg.OnCerrarProyecto += new Modulos.ProyectAdmin.FormProyectEvent(CerrarProyecto);
            dlg.OnComparar += new Modulos.ProyectAdmin.FormProyectEventComparer(Comparar);
            dlg.OnEditorComentaro += new Modulos.ProyectAdmin.FormProyectEventEditorComentaro(MuestraEditor);
            VentanaAcoplable(dlg, 4, true, State.DockLeft);
        }
        private void MuestraEditor(Modulos.Editores.EditorGenerico edit,string titulo)
        {
            CargaEditor();
            VEditor.AgregaEditor(edit, titulo);
            edit.SetFocus();
        }
    }
}
