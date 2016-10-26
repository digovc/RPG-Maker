namespace Rpg.Controle.EditAtributo
{
    partial class EditAtributoBase
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
            this.pnlCampo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlComando = new System.Windows.Forms.Panel();
            this.btnJogadorVisivel = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnJogadorBloquear = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnBloquear = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.ctrLinha = new DigoFramework.Controle.Diverso.Linha();
            this.pnlComando.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampo.Location = new System.Drawing.Point(0, 30);
            this.pnlCampo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCampo.Name = "pnlCampo";
            this.pnlCampo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.pnlCampo.Size = new System.Drawing.Size(150, 120);
            this.pnlCampo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 15);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 15);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlComando
            // 
            this.pnlComando.Controls.Add(this.btnJogadorVisivel);
            this.pnlComando.Controls.Add(this.btnJogadorBloquear);
            this.pnlComando.Controls.Add(this.btnBloquear);
            this.pnlComando.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComando.Location = new System.Drawing.Point(0, 0);
            this.pnlComando.Name = "pnlComando";
            this.pnlComando.Size = new System.Drawing.Size(150, 15);
            this.pnlComando.TabIndex = 2;
            // 
            // btnJogadorVisivel
            // 
            this.btnJogadorVisivel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnJogadorVisivel.Name = "btnJogadorVisivel";
            this.btnJogadorVisivel.TabIndex = 2;
            this.btnJogadorVisivel.Click += new System.EventHandler(this.btnJogadorVisivel_Click);
            // 
            // btnJogadorBloquear
            // 
            this.btnJogadorBloquear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnJogadorBloquear.Name = "btnJogadorBloquear";
            this.btnJogadorBloquear.TabIndex = 1;
            this.btnJogadorBloquear.Click += new System.EventHandler(this.btnJogadorBloquear_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.TabIndex = 0;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // ctrLinha
            // 
            this.ctrLinha.BackColor = System.Drawing.Color.Gray;
            this.ctrLinha.Name = "ctrLinha";
            this.ctrLinha.TabIndex = 0;
            // 
            // EditAtributoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrLinha);
            this.Controls.Add(this.pnlCampo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlComando);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditAtributoBase";
            this.pnlComando.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        protected System.Windows.Forms.Panel pnlCampo;
        private System.Windows.Forms.Panel pnlComando;
        private DigoFramework.Controle.Botao.BotaoAtalho btnBloquear;
        private DigoFramework.Controle.Botao.BotaoAtalho btnJogadorVisivel;
        private DigoFramework.Controle.Botao.BotaoAtalho btnJogadorBloquear;
        private DigoFramework.Controle.Diverso.Linha ctrLinha;
    }
}
