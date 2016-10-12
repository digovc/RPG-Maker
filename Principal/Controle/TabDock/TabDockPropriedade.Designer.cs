namespace Rpg.Controle.TabDock
{
    partial class TabDockPropriedade
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
            this.pnlConteudo = new DigoFramework.Controle.Painel.PainelConteudo();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.TabIndex = 1;
            // 
            // TabDockPropriedade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.pnlConteudo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TabDockPropriedade";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.pnlConteudo, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DigoFramework.Controle.Painel.PainelConteudo pnlConteudo;
    }
}
