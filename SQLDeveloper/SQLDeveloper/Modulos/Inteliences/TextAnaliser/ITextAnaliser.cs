using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDeveloper.Modulos.Inteliences.TextAnaliser
{
    //interfase para el analisis de texto y crear tabla de variables
    public interface ITextAnaliser
    {
        void SetTextEditor(ICSharpCode.TextEditor.TextEditorControl editor); //Para asignar el editor de codigo
        List<string> GetVariableNames(); //regresa la lista de los nombres de las variables 
        List<string> GetTablesNames(); //regresa la lista de tablas variables, tablas temporales y alias que se tengan en eltexto
        List<string> GetTableFields(string tabla); //regresa los campos de las tablas
        int GetDeclarationLine(string nombre); //regresa la linea donde el objeto fue declarado
    }
}
