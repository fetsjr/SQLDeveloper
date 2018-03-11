namespace SQLDeveloper.Modulos.Inteliences.TextAnaliser
{
    partial class CSQLTextAnaliser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cAnaLex1 = new AnalizadorLexico.CAnaLex(this.components);
            // 
            // cAnaLex1
            // 
            this.cAnaLex1.Texto = null;

        }

        #endregion

        private AnalizadorLexico.CAnaLex cAnaLex1;

    }
}
