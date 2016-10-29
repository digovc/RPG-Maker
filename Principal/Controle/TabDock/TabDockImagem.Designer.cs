namespace Rpg.Controle.TabDock
{
    partial class TabDockImagem
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
            this.imgDisplay = new Rpg.Controle.Editor.ImagemDisplay();
            this.txtTileTamanho = new System.Windows.Forms.TextBox();
            this.btnAtivarGrid = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.pnlAtalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Controls.Add(this.txtTileTamanho);
            this.pnlAtalho.Controls.Add(this.btnAtivarGrid);
            // 
            // imgDisplay
            // 
            this.imgDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgDisplay.intTamanhoX = 0;
            this.imgDisplay.intTamanhoY = 0;
            this.imgDisplay.intTileTamanho = 0;
            this.imgDisplay.Location = new System.Drawing.Point(0, 24);
            this.imgDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.imgDisplay.Name = "imgDisplay";
            this.imgDisplay.objImagem = null;
            this.imgDisplay.Size = new System.Drawing.Size(379, 297);
            this.imgDisplay.TabIndex = 1;
            // 
            // txtTileTamanho
            // 
            this.txtTileTamanho.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTileTamanho.Enabled = false;
            this.txtTileTamanho.Location = new System.Drawing.Point(30, 0);
            this.txtTileTamanho.Multiline = true;
            this.txtTileTamanho.Name = "txtTileTamanho";
            this.txtTileTamanho.Size = new System.Drawing.Size(35, 24);
            this.txtTileTamanho.TabIndex = 1;
            this.txtTileTamanho.Text = "10";
            this.txtTileTamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTileTamanho.TextChanged += new System.EventHandler(this.txtTileTamanho_TextChanged);
            // 
            // btnAtivarGrid
            // 
            this.btnAtivarGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAtivarGrid.Name = "btnAtivarGrid";
            this.btnAtivarGrid.TabIndex = 2;
            this.btnAtivarGrid.Click += new System.EventHandler(this.btnAtivarGrid_Click);
            // 
            // TabDockImagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.imgDisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TabDockImagem";
            this.Text = "TabDockImagem";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.imgDisplay, 0);
            this.pnlAtalho.ResumeLayout(false);
            this.pnlAtalho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtTileTamanho;
        public Editor.ImagemDisplay imgDisplay;
        private DigoFramework.Controle.Botao.BotaoAtalho btnAtivarGrid;
    }
}