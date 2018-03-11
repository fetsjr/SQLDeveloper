using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalizadorLexico;
namespace SQLDeveloper.Modulos.Inteliences.TextAnaliser
{
    public partial class CSQLTextAnaliser : CBaseTextAnaliser
    {
        private List<string> Lineas;
        public CSQLTextAnaliser()
        {
            InitializeComponent();
        }

        public CSQLTextAnaliser(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private void BuscaVariables()
        {
            //recorro todas las lineas para buacar la @
            int comentario =0; //para llevar el control de los comentarios
            for (int pos = 0; pos < Lineas.Count;pos++ )
            {
                string s=Lineas[pos];
                cAnaLex1.Texto = s;
                CLexema lex=null;
                do
                {
                    //me traigo el soguiente item
                    lex = cAnaLex1.DameItem();
                    if (lex != null)
                    {
                        #region eliminacion de comentarios
                        if (comentario>0)
                        {
                            //estoy en medio de un comentario en bloque, por lo que busco el final del cometarop
                            if(lex.cadena=="*")
                            {
                                //posiblemente sea el final de un comentario
                                lex = cAnaLex1.DameItem();
                                if(lex!=null)
                                {
                                    if(lex.cadena=="/")
                                    {
                                        //si es el final de un comentario, por lo que decremento el contador
                                        comentario--;
                                    }
                                    else if(lex.cadena=="*")
                                    {
                                        //caso especial. puede ser un comentario del tipo /*********/ 
                                        while(lex!=null && lex.cadena=="*")
                                        {
                                            lex = cAnaLex1.DameItem();
                                        }
                                        if(lex!=null)
                                        {
                                            if(lex.cadena=="/")
                                            {
                                                //encontre el final del comentario
                                                comentario--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        #region identificacion de variables
                        else if (lex.cadena == "@")
                        {
                            //el siguiente item debe de ser el nombre de la variable
                            lex = cAnaLex1.DameItem();
                            if (lex != null)
                            {
                                if (lex.cadena != "@") //ignoso si es una variable de sistema
                                {
                                    //el siguiente item debe de ser el tipo de la variable
                                    CSimbolo obj = new CSimbolo();
                                    obj.DeclarationLinea = pos;
                                    obj.Tipo = TIPO_SIMBOLO.VARIABLE;
                                    obj.Name ="@"+ lex.cadena; 
                                    //me traigo el tipo
                                    lex = cAnaLex1.DameItem(); //se supone que este es un separador
                                    lex = cAnaLex1.DameItem();
                                    if (lex != null)
                                    {
                                        if (lex.cadena.ToUpper().Trim() == "TABLE")
                                        {
                                            //se trata de una tabla, por lo que la agrego a la lista de tablas variable
                                            obj.Tipo = TIPO_SIMBOLO.TABLA;
                                        }
                                    }
                                    AddSimbol(obj);
                                }
                            }
                        }
                        #endregion
                        #region identificacion de tablas temporales
                        else if (lex.cadena[0] == '#')
                        {
                            //es una tabla temporal
                            CSimbolo obj = new CSimbolo();
                            obj.DeclarationLinea = pos;
                            obj.Tipo = TIPO_SIMBOLO.TABLA;
                            obj.Name = lex.cadena;
                            AddSimbol(obj);
                        }
                        #endregion
                        #region identificacion de comentarios
                        else if (lex.cadena == "-")
                        {
                            //posiblemente sea un comentario
                            lex = cAnaLex1.DameItem();
                            if (lex != null)
                            {
                                if (lex.cadena == "-")
                                {
                                    //si es un comentario. hayq que ignorar el resto de la linea
                                    break; //obligo a que se pase a analizar la siguiente linea
                                }
                            }
                        }
                        else if (lex.cadena == "/")
                        {
                            //posiblemente sea un comentario ya sea de // o de /*
                            lex = cAnaLex1.DameItem();
                            if (lex != null)
                            {
                                // lex = cAnaLex1.DameItem();
                                if (lex.cadena == "/")
                                {
                                    //es uncomentario de linea //
                                    break; //ignoro el resto de la linea
                                }
                                else if (lex.cadena == "*")
                                {
                                    //es comentario de bloque
                                    comentario++; //incremento el contador de comentarios de bloque
                                }
                            }
                        }
                        #endregion
                    }
                }
                while (lex != null);
            }
        }
        //esta funcion se llama cada vez que hay que analisar la cadena
        protected override void AnalizaTexto(string texto)
        {
            //primero separo el texto en  lineas
            string[] l = texto.Split('\n');
            Lineas = new List<string>();
            foreach(string s in l)
            {
                Lineas.Add(s);
            }
            BuscaVariables();
        }
    }
}
