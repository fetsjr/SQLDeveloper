using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MotorDB;
using System.Data;
namespace SQLProjectModel
{
    public partial class SQLProjectModel : Component
    {
        public SQLProjectModel()
        {
            InitializeComponent();
        }
        public SQLProjectModel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public string NombreProyecto
        {
            get;
            set;
        }
        public void Guardar(string fileName)
        {
            modelo1.WriteXml(fileName);
        }
        public void Abrir(string fileName)
        {
            modelo1.ReadXml(fileName);
        }
        #region Administracion de conexiones
        public void AddConexion(string grupo, string motorDataBase,  string nombre, string connectionString)
        {
            //verifico si existe el grupo
            CGrupo g = modelo1.AddGrupo(grupo);
            //ahora agrego la conexion
            CConexion con=modelo1.AddConexion(g.ID_Grupo, nombre, connectionString, motorDataBase );
        }
        #endregion
    }
}
