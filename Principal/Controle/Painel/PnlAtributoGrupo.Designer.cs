namespace Rpg.Controle.Painel
{
    partial class PnlAtributoGrupo
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
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.pnlTitulo = new Rpg.Controle.Painel.PnlRpgTitulo();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 0);
            this.pnlConteudo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.pnlConteudo.Size = new System.Drawing.Size(148, 148);
            this.pnlConteudo.TabIndex = 2;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.booTituloFixo = true;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(148, 20);
            this.pnlTitulo.strTitulo = "Título";
            this.pnlTitulo.TabIndex = 0;
            // 
            // PnlAtributoGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlConteudo);
            this.Name = "PnlAtributoGrupo";
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlConteudo;
        private PnlRpgTitulo pnlTitulo;
    }
}
