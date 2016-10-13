namespace Rpg.Controle.TabDock
{
    partial class TabDockCamada
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
            this.btnAddCamada = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.pnlConteudo = new DigoFramework.Controle.Painel.PainelConteudo();
            this.pnlAtalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Controls.Add(this.btnAddCamada);
            // 
            // btnAddCamada
            // 
            this.btnAddCamada.Name = "btnAddCamada";
            this.btnAddCamada.TabIndex = 1;
            this.btnAddCamada.Click += new System.EventHandler(this.btnAddCamada_Click);
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.TabIndex = 1;
            // 
            // TabDockCamada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.pnlConteudo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TabDockCamada";
            this.Text = "Camadas";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.pnlConteudo, 0);
            this.pnlAtalho.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DigoFramework.Controle.Botao.BotaoAtalho btnAddCamada;
        private DigoFramework.Controle.Painel.PainelConteudo pnlConteudo;
    }
}