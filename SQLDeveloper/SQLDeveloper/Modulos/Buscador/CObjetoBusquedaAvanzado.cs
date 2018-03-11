using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Buscador
{
    public class CObjetoBusquedaAvanzado: CObetoBuqueda
    {
       public  MotorDB.IMotorDB Motor
        {
            get;
            set;
        }
    }
}
