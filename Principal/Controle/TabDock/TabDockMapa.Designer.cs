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
            this.ctrMapa = new Rpg.Controle.Editor.MapaDisplay();
            this.btnLapis = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnBorracha = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnSelecionar = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.pnlAtalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Controls.Add(this.btnBorracha);
            this.pnlAtalho.Controls.Add(this.btnLapis);
            this.pnlAtalho.Controls.Add(this.btnSelecionar);
            // 
            // ctrDisplay
            // 
            this.ctrMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrMapa.intTamanhoX = 0;
            this.ctrMapa.intTamanhoY = 0;
            this.ctrMapa.intTileTamanho = 50;
            this.ctrMapa.Location = new System.Drawing.Point(0, 24);
            this.ctrMapa.Margin = new System.Windows.Forms.Padding(4);
            this.ctrMapa.Name = "ctrDisplay";
            this.ctrMapa.objMapa = null;
            this.ctrMapa.Size = new System.Drawing.Size(1043, 888);
            this.ctrMapa.TabIndex = 0;
            // 
            // btnLapis
            // 
            this.btnLapis.Name = "btnLapis";
            this.btnLapis.TabIndex = 1;
            this.btnLapis.Click += new System.EventHandler(this.btnLapis_Click);
            // 
            // btnBorracha
            // 
            this.btnBorracha.Name = "btnBorracha";
            this.btnBorracha.TabIndex = 2;
            this.btnBorracha.Click += new System.EventHandler(this.btnBorracha_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.TabIndex = 3;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // TabDockMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 912);
            this.Controls.Add(this.ctrMapa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TabDockMapa";
            this.Text = "Mapa";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.ctrMapa, 0);
            this.pnlAtalho.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Editor.MapaDisplay ctrMapa;
        private DigoFramework.Controle.Botao.BotaoAtalho btnBorracha;
        private DigoFramework.Controle.Botao.BotaoAtalho btnLapis;
        private DigoFramework.Controle.Botao.BotaoAtalho btnSelecionar;
    }
}