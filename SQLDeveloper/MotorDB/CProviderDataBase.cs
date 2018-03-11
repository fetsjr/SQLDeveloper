using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorDB
{
    //provee servicios de administracion de conexiones a base de datos
    public enum EnumMotoresDB
    {
        SQLSERVER,
        MYSQL,
        ORACLE,
    }
    public class CProviderDataBase
    {
        public static IMotorDB DameMotor(EnumMotoresDB motor)
        {
            IMotorDB obj = null;
            switch(motor)
            {
                case EnumMotoresDB.SQLSERVER:
                    obj = new CMotorSQLServer();
                    break;
            }
            return obj;
        }
    }
}
