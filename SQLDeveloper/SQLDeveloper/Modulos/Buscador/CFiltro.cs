using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Buscador
{
    public enum OPERADOR
    {
        AND
        ,OR
        ,NOT
        ,NONE
    };
 
    public class CFiltro : CTipoBusqueda
    {
        public  CFiltro()
        {
            operador = OPERADOR.NONE;
        }
        public  CFiltro(string cadena, MotorDB.EnumTipoObjeto tipo,OPERADOR oper)
        {
            Cadena = cadena;
            Tipo = tipo;
            operador = oper;
        }
        public OPERADOR operador
        {
            get;
            set;
        }
        static public bool operator==(CFiltro a,CFiltro b)
        {
            if(Object.ReferenceEquals(a,null))
            {
                return object.ReferenceEquals(b, null);
            }
            if (object.ReferenceEquals(b, null))
            {
                return false;
            }
            if (a.Cadena != b.Cadena)
                return false;
            if (a.operador != b.operador)
                return false;
            if (a.Tipo != b.Tipo)
                return false;
            return true;
        }
        static public bool operator !=(CFiltro a, CFiltro b)
        {
            return !(a == b);
        }
    }
}
