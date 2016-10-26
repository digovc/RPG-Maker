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
            this.pnlTitulo = new Rpg.Controle.Painel.PnlRpgTitulo();
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
            this.pnlCampo.Location = new System.Drawing.Point(0, 39);
            this.pnlCampo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCampo.Name = "pnlCampo";
            this.pnlCampo.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.pnlCampo.Size = new System.Drawing.Size(200, 61);
            this.pnlCampo.TabIndex = 1;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.booTituloFixo = false;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 19);
            this.pnlTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(200, 20);
            this.pnlTitulo.strTitulo = "Título";
            this.pnlTitulo.TabIndex = 2;
            // 
            // pnlComando
            // 
            this.pnlComando.Controls.Add(this.btnJogadorVisivel);
            this.pnlComando.Controls.Add(this.btnJogadorBloquear);
            this.pnlComando.Controls.Add(this.btnBloquear);
            this.pnlComando.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComando.Location = new System.Drawing.Point(0, 1);
            this.pnlComando.Margin = new System.Windows.Forms.Padding(4);
            this.pnlComando.Name = "pnlComando";
            this.pnlComando.Size = new System.Drawing.Size(200, 18);
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
            this.ctrLinha.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrLinha.Name = "ctrLinha";
            this.ctrLinha.TabIndex = 0;
            // 
            // EditAtributoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCampo);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlComando);
            this.Controls.Add(this.ctrLinha);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditAtributoBase";
            this.Size = new System.Drawing.Size(200, 100);
            this.pnlComando.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlComando;
        private DigoFramework.Controle.Botao.BotaoAtalho btnBloquear;
        private DigoFramework.Controle.Botao.BotaoAtalho btnJogadorVisivel;
        private DigoFramework.Controle.Botao.BotaoAtalho btnJogadorBloquear;
        private Painel.PnlRpgTitulo pnlTitulo;
        protected System.Windows.Forms.Panel pnlCampo;
        private DigoFramework.Controle.Diverso.Linha ctrLinha;
    }
}
