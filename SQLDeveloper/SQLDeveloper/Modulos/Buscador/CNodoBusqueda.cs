using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQLDeveloper.Modulos.Buscador
{
    public class CNodoBusqueda: TreeNode
    {
        private MotorDB.EnumTipoObjeto FTipo;
        public MotorDB.EnumTipoObjeto Tipo
        {
            get
            {
                return FTipo;
            }
            set
            {
                FTipo = value;
                switch(FTipo)
                {
                    case MotorDB.EnumTipoObjeto.FUNCION:
                        ImageIndex = 2;
                        SelectedImageIndex = 2;
                        Tag = "Funcion";
                        break;
                    case MotorDB.EnumTipoObjeto.PROCEDURE:
                        ImageIndex = 3;
                        SelectedImageIndex = 3;
                        Tag = "Procediiento almacenado";
                        break;
                    case MotorDB.EnumTipoObjeto.TABLE:
                        ImageIndex = 0;
                        SelectedImageIndex = 0;
                        Tag = "Tabla";
                        break;
                    case MotorDB.EnumTipoObjeto.TRIGER:
                        ImageIndex = 4;
                        SelectedImageIndex = 4;
                        Tag = "Trigger";
                        break;
                    case MotorDB.EnumTipoObjeto.VIEW:
                        ImageIndex = 1;
                        SelectedImageIndex = 1;
                        Tag = "Vista";
                        break;
                    case MotorDB.EnumTipoObjeto.CHECK:
                        ImageIndex = 5;
                        SelectedImageIndex = 5;
                        Tag = "Regla (Check)";
                        break;
                    case MotorDB.EnumTipoObjeto.DEFAULT:
                        ImageIndex = 6;
                        SelectedImageIndex = 6;
                        Tag = "Valor por default";
                        break;
                    case MotorDB.EnumTipoObjeto.FOREIGNKEY:
                        ImageIndex = 7;
                        SelectedImageIndex = 7;
                        Tag = "LLave foranea";
                        break;
                    case MotorDB.EnumTipoObjeto.PRIMARYKEY:
                        ImageIndex = 8;
                        SelectedImageIndex = 8;
                        Tag = "LLave primaria";
                        break;
                    case MotorDB.EnumTipoObjeto.UNIQUE:
                        ImageIndex = 9;
                        SelectedImageIndex = 9;
                        Tag = "Valor unico";
                        break;
                    case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                        ImageIndex = 11;
                        SelectedImageIndex = 11;
                        Tag = "Valor unico";
                        break;
                    default:
                        ImageIndex = 10;
                        SelectedImageIndex = 10;
                        Tag = "Desconocido";
                        break;

                }
            }
        }
        public string Nombre
        {
            get

            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }
        public override string ToString()
        {
            return Nombre;
        }
        public MotorDB.IMotorDB Motor
        {
            get;
            set;
        }
    }
}
