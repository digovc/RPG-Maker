namespace Rpg.Controle.EditAtributo
{
    partial class EditAtributoBoolen
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
            this.ckbBooValor = new System.Windows.Forms.CheckBox();
            this.pnlCampo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Controls.Add(this.ckbBooValor);
            // 
            // ckbBooValor
            // 
            this.ckbBooValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbBooValor.Location = new System.Drawing.Point(10, 0);
            this.ckbBooValor.Name = "ckbBooValor";
            this.ckbBooValor.Size = new System.Drawing.Size(330, 25);
            this.ckbBooValor.TabIndex = 1;
            this.ckbBooValor.UseVisualStyleBackColor = true;
            this.ckbBooValor.CheckedChanged += new System.EventHandler(this.ckbBooValor_CheckedChanged);
            // 
            // EditAtributoBoolen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EditAtributoBoolen";
            this.pnlCampo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbBooValor;
    }
}
