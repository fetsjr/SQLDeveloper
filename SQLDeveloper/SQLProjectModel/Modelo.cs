using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MotorDB;
namespace SQLProjectModel
{
    
    
    public partial class Modelo
    {
        CCampo campo2;
        #region Control de grupos
        public List<CGrupo> DameGrupos()
        {
            List<CGrupo> lista = new List<CGrupo>();
            var l = from gruppos in TGrupoConeccion select gruppos;
            foreach (var g in l)
            {
                CGrupo obj = new CGrupo();
                obj.Nombre = g.Nombre;
                obj.ID_Grupo = g.ID_Grupo;
                lista.Add(obj);
            }
            return lista;
        }
        public CGrupo DameGrupo(string nombre)
        {
            List<CGrupo> lista = new List<CGrupo>();
            var g = (from gruppo in TGrupoConeccion where gruppo.Nombre==nombre select gruppo).Single();
            if(g!=null)
            {
                CGrupo obj = new CGrupo();
                obj.Nombre = g.Nombre;
                obj.ID_Grupo = g.ID_Grupo;
                return obj;
            }
            return null;
        }
        public CGrupo AddGrupo(string grupo)
        {
            CGrupo g=DameGrupo(grupo) ;
            if (g== null)
            {
                DataRow dr = TGrupoConeccion.NewRow();
                dr["Nombre"] = grupo;
                TGrupoConeccion.Rows.Add(dr);
            }
            return DameGrupo(grupo);
        }
        #endregion
        #region Control de conexiones
        public List<CConexion> DameConexiones(string grupo)
        {
            CGrupo g=DameGrupo(grupo);
            List<CConexion> lista = new List<CConexion>();
            var l = from con in TConexion where con.ID_Grupo==g.ID_Grupo select con;
            foreach(var con in l)
            {
                CConexion obj = new CConexion();
                obj.ConnectionSting = con.ConnectionSting;
                obj.ID_Conexion = con.ID_Conexion;
                obj.ID_Grupo = con.ID_Grupo;
                obj.MotorDB = con.MotorDB;
                obj.Nombre = con.Nombre;
                lista.Add(obj);
            }
            return lista;
        }
        public CConexion DameConexion(int ID_Grupo, string conexion)
        {
            var l =( from con in TConexion where con.ID_Grupo == ID_Grupo && con.Nombre==conexion select con).Single();
            if(l!=null)
            {
                CConexion obj = new CConexion();
                obj.ConnectionSting = l.ConnectionSting;
                obj.ID_Conexion = l.ID_Conexion;
                obj.ID_Grupo = l.ID_Grupo;
                obj.MotorDB = l.MotorDB;
                obj.Nombre = l.Nombre;
                return obj;
            }
            return null;
        }
        public CConexion AddConexion(int  ID_Grupo, string nombre, string ConnectionSting, string Motor )
        {
            CConexion obj = DameConexion(ID_Grupo, nombre);
            if (obj != null)
            {
                throw new Exception("la conexion ya existe");
            }
            DataRow dr = TConexion.NewRow();
            dr["Nombre"] = nombre;
            dr["ID_Grupo"] = ID_Grupo;
            dr["ConnectionSting"] = ConnectionSting;
            dr["MotorDB"] = Motor;
            TConexion.Rows.Add(dr);
            return DameConexion(ID_Grupo, nombre);

        }
        #endregion
    }
}
