using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public class CConexion
    {
        public int ID_Conexion
        {
            get;
            set;
        }
        public int ID_Servidor
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public string ConecctionString
        {
            get;
            set;
        }
        public string MotorDB
        {
            get;
            set;
        }
        /// <summary>
        /// regresa el motor
        /// </summary>
        /// <returns></returns>
        public MotorDB.IMotorDB DameMotor()
        {
            Conexiones.CConexion con=new Conexiones.CConexion()
            {
                 ConecctionString=ConecctionString
                 , MotorDB=MotorDB
                 , Nombre=Nombre
            };
            return Conexiones.ControladorConexiones.DameMotor(con);
        }
    }
}
