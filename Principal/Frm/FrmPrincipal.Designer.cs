namespace Rpg.Frm
{
    partial class FrmPrincipal
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
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.tsmArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.dcp = new DigoFramework.Controle.DockPanel.DockPanelGeral();
            this.tsmJogoAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAtalho = new DigoFramework.Controle.Painel.PainelAtalho();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmArquivo});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(284, 24);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // tsmArquivo
            // 
            this.tsmArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmJogoAbrir});
            this.tsmArquivo.Name = "tsmArquivo";
            this.tsmArquivo.Size = new System.Drawing.Size(61, 20);
            this.tsmArquivo.Text = "Arquivo";
            // 
            // dcp
            // 
            this.dcp.Name = "dcp";
            this.dcp.TabIndex = 1;
            // 
            // tsmJogoAbrir
            // 
            this.tsmJogoAbrir.Name = "tsmJogoAbrir";
            this.tsmJogoAbrir.Size = new System.Drawing.Size(152, 22);
            this.tsmJogoAbrir.Text = "Abrir jogo";
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Name = "pnlAtalho";
            this.pnlAtalho.TabIndex = 3;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dcp);
            this.Controls.Add(this.pnlAtalho);
            this.Controls.Add(this.mnu);
            this.MainMenuStrip = this.mnu;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem tsmArquivo;
        private DigoFramework.Controle.DockPanel.DockPanelGeral dcp;
        private System.Windows.Forms.ToolStripMenuItem tsmJogoAbrir;
        private DigoFramework.Controle.Painel.PainelAtalho pnlAtalho;
    }
}