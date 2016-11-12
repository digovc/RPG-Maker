namespace Rpg.Controle.Painel
{
    partial class PnlAtributoGrupo
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
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.pnlTitulo = new Rpg.Controle.Painel.PnlRpgTitulo();
            this.pnlComando = new DigoFramework.Controle.Painel.PainelAtalho();
            this.btnAddAtributo = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnAlterarNome = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnVisivel = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.pnlComando.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.AutoSize = true;
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 36);
            this.pnlConteudo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(150, 45);
            this.pnlConteudo.TabIndex = 2;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.booTituloFixo = false;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 20);
            this.pnlTitulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.pnlTitulo.Size = new System.Drawing.Size(150, 16);
            this.pnlTitulo.strTitulo = "Título";
            this.pnlTitulo.TabIndex = 0;
            // 
            // pnlComando
            // 
            this.pnlComando.Controls.Add(this.btnAddAtributo);
            this.pnlComando.Controls.Add(this.btnAlterarNome);
            this.pnlComando.Controls.Add(this.btnVisivel);
            this.pnlComando.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComando.Name = "pnlComando";
            this.pnlComando.TabIndex = 3;
            // 
            // btnAddAtributo
            // 
            this.btnAddAtributo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddAtributo.Name = "btnAddAtributo";
            this.btnAddAtributo.TabIndex = 4;
            this.btnAddAtributo.Click += new System.EventHandler(this.btnAddAtributo_Click);
            // 
            // btnAlterarNome
            // 
            this.btnAlterarNome.BackgroundImage = global::Rpg.Properties.Resources.alterar_nome;
            this.btnAlterarNome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAlterarNome.Name = "btnAlterarNome";
            this.btnAlterarNome.TabIndex = 3;
            this.btnAlterarNome.Click += new System.EventHandler(this.btnAlterarNome_Click);
            // 
            // btnVisivel
            // 
            this.btnVisivel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVisivel.Name = "btnVisivel";
            this.btnVisivel.TabIndex = 2;
            this.btnVisivel.Click += new System.EventHandler(this.btnVisivel_Click);
            // 
            // PnlAtributoGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlComando);
            this.Name = "PnlAtributoGrupo";
            this.Size = new System.Drawing.Size(150, 81);
            this.pnlComando.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlConteudo;
        private PnlRpgTitulo pnlTitulo;
        private DigoFramework.Controle.Painel.PainelAtalho pnlComando;
        private DigoFramework.Controle.Botao.BotaoAtalho btnVisivel;
        private DigoFramework.Controle.Botao.BotaoAtalho btnAlterarNome;
        private DigoFramework.Controle.Botao.BotaoAtalho btnAddAtributo;
    }
}
