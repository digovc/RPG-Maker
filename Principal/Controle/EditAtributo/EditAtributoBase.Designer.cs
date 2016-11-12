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
            this.components = new System.ComponentModel.Container();
            this.pnlCampo = new System.Windows.Forms.Panel();
            this.pnlTitulo = new Rpg.Controle.Painel.PnlRpgTitulo();
            this.pnlComando = new System.Windows.Forms.Panel();
            this.btnJogadorVisivel = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnJogadorBloquear = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnAlterarTipo = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnAlterarNome = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnBloquear = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.ctrLinha = new DigoFramework.Controle.Diverso.Linha();
            this.cmsAlterarTipo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmTipoAlfanumerico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTipoNumerico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTipoFaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTipoBoolean = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlComando.SuspendLayout();
            this.cmsAlterarTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampo.Location = new System.Drawing.Point(0, 33);
            this.pnlCampo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCampo.Name = "pnlCampo";
            this.pnlCampo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.pnlCampo.Size = new System.Drawing.Size(300, 27);
            this.pnlCampo.TabIndex = 1;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.booTituloFixo = false;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 17);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlTitulo.Size = new System.Drawing.Size(300, 16);
            this.pnlTitulo.strTitulo = "Título";
            this.pnlTitulo.TabIndex = 2;
            // 
            // pnlComando
            // 
            this.pnlComando.Controls.Add(this.btnJogadorVisivel);
            this.pnlComando.Controls.Add(this.btnJogadorBloquear);
            this.pnlComando.Controls.Add(this.btnAlterarTipo);
            this.pnlComando.Controls.Add(this.btnAlterarNome);
            this.pnlComando.Controls.Add(this.btnBloquear);
            this.pnlComando.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComando.Location = new System.Drawing.Point(0, 1);
            this.pnlComando.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlComando.Name = "pnlComando";
            this.pnlComando.Size = new System.Drawing.Size(300, 16);
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
            // btnAlterarTipo
            // 
            this.btnAlterarTipo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAlterarTipo.Name = "btnAlterarTipo";
            this.btnAlterarTipo.TabIndex = 4;
            this.btnAlterarTipo.Click += new System.EventHandler(this.btnAlterarTipo_Click);
            // 
            // btnAlterarNome
            // 
            this.btnAlterarNome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAlterarNome.Name = "btnAlterarNome";
            this.btnAlterarNome.TabIndex = 3;
            this.btnAlterarNome.Click += new System.EventHandler(this.btnAlterarNome_Click);
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
            // cmsAlterarTipo
            // 
            this.cmsAlterarTipo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAlterarTipo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTipoAlfanumerico,
            this.tsmTipoNumerico,
            this.tsmTipoFaixa,
            this.tsmTipoBoolean});
            this.cmsAlterarTipo.Name = "cmsAlterarTipo";
            this.cmsAlterarTipo.Size = new System.Drawing.Size(147, 92);
            // 
            // tsmTipoAlfanumerico
            // 
            this.tsmTipoAlfanumerico.Name = "tsmTipoAlfanumerico";
            this.tsmTipoAlfanumerico.Size = new System.Drawing.Size(146, 22);
            this.tsmTipoAlfanumerico.Text = "Alfanumérico";
            this.tsmTipoAlfanumerico.Click += new System.EventHandler(this.tsmTipoAlfanumerico_Click);
            // 
            // tsmTipoNumerico
            // 
            this.tsmTipoNumerico.Name = "tsmTipoNumerico";
            this.tsmTipoNumerico.Size = new System.Drawing.Size(146, 22);
            this.tsmTipoNumerico.Text = "Numérico";
            this.tsmTipoNumerico.Click += new System.EventHandler(this.tsmTipoNumerico_Click);
            // 
            // tsmTipoFaixa
            // 
            this.tsmTipoFaixa.Name = "tsmTipoFaixa";
            this.tsmTipoFaixa.Size = new System.Drawing.Size(146, 22);
            this.tsmTipoFaixa.Text = "Faixa";
            this.tsmTipoFaixa.Click += new System.EventHandler(this.tsmTipoFaixa_Click);
            // 
            // tsmTipoBoolean
            // 
            this.tsmTipoBoolean.Name = "tsmTipoBoolean";
            this.tsmTipoBoolean.Size = new System.Drawing.Size(146, 22);
            this.tsmTipoBoolean.Text = "Sim ou não";
            this.tsmTipoBoolean.Click += new System.EventHandler(this.tsmTipoBoolean_Click);
            // 
            // EditAtributoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCampo);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlComando);
            this.Controls.Add(this.ctrLinha);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditAtributoBase";
            this.Size = new System.Drawing.Size(300, 60);
            this.pnlComando.ResumeLayout(false);
            this.cmsAlterarTipo.ResumeLayout(false);
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
        private DigoFramework.Controle.Botao.BotaoAtalho btnAlterarNome;
        private DigoFramework.Controle.Botao.BotaoAtalho btnAlterarTipo;
        private System.Windows.Forms.ContextMenuStrip cmsAlterarTipo;
        private System.Windows.Forms.ToolStripMenuItem tsmTipoAlfanumerico;
        private System.Windows.Forms.ToolStripMenuItem tsmTipoNumerico;
        private System.Windows.Forms.ToolStripMenuItem tsmTipoFaixa;
        private System.Windows.Forms.ToolStripMenuItem tsmTipoBoolean;
    }
}
