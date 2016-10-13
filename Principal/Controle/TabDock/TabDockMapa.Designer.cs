namespace Rpg.Controle.TabDock
{
    partial class TabDockMapa
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlConteudo = new DigoFramework.Controle.Painel.PainelConteudo();
            this.ctrDisplay = new Rpg.Controle.Editor.Display();
            this.pnlConteudo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.Controls.Add(this.ctrDisplay);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.TabIndex = 1;
            // 
            // ctrDisplay
            // 
            this.ctrDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrDisplay.Location = new System.Drawing.Point(5, 5);
            this.ctrDisplay.Name = "ctrDisplay";
            this.ctrDisplay.objMapa = null;
            this.ctrDisplay.Size = new System.Drawing.Size(770, 704);
            this.ctrDisplay.TabIndex = 0;
            // 
            // TabDockMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 741);
            this.Controls.Add(this.pnlConteudo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TabDockMapa";
            this.Text = "Mapa";
            this.Enter += new System.EventHandler(this.TabDockMapa_Enter);
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.pnlConteudo, 0);
            this.pnlConteudo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DigoFramework.Controle.Painel.PainelConteudo pnlConteudo;
        private Editor.Display ctrDisplay;
    }
}