﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProjectModel
{
    public class CConexion
    {
        public int ID_Conexion
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        
        public int ID_Grupo
        {
            get;
            set;
        }
        public string ConnectionSting
        {
            get;
            set;
        }
        public string MotorDB
        {
            get;
            set;
        }
    }
}
