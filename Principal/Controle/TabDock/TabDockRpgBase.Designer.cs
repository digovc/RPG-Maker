namespace Rpg.Controle.TabDock
{
    partial class TabDockRpgBase
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
            this.pnlAtalho = new DigoFramework.Controle.Painel.PainelAtalho();
            this.SuspendLayout();
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Name = "pnlAtalho";
            this.pnlAtalho.TabIndex = 0;
            // 
            // TabDockRpgBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlAtalho);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TabDockRpgBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected DigoFramework.Controle.Painel.PainelAtalho pnlAtalho;
    }
}
