namespace Rpg.Controle.EditAtributo
{
    partial class EditAtributoNumerico
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
            this.txtStrValor = new System.Windows.Forms.TextBox();
            this.pnlCampo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Controls.Add(this.txtStrValor);
            this.pnlCampo.Size = new System.Drawing.Size(1125, 25);
            // 
            // txtStrValor
            // 
            this.txtStrValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStrValor.Location = new System.Drawing.Point(10, 0);
            this.txtStrValor.Name = "txtStrValor";
            this.txtStrValor.Size = new System.Drawing.Size(1105, 22);
            this.txtStrValor.TabIndex = 1;
            this.txtStrValor.TextChanged += new System.EventHandler(this.txtStrValor_TextChanged);
            // 
            // EditAtributoTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EditAtributoTexto";
            this.pnlCampo.ResumeLayout(false);
            this.pnlCampo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtStrValor;
    }
}
