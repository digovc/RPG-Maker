namespace Rpg.Controle.TabDock
{
    partial class TabDockExplorer
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
            this.trv = new System.Windows.Forms.TreeView();
            this.btnAddItem = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.cmsAddItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddItemGrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddItemMapa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddItemPersonagem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAtalho.SuspendLayout();
            this.cmsAddItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAtalho
            // 
            this.pnlAtalho.Controls.Add(this.btnAddItem);
            // 
            // trv
            // 
            this.trv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv.Location = new System.Drawing.Point(0, 24);
            this.trv.Margin = new System.Windows.Forms.Padding(4);
            this.trv.Name = "trv";
            this.trv.Size = new System.Drawing.Size(379, 297);
            this.trv.TabIndex = 0;
            this.trv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trv_NodeMouseClick);
            this.trv.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trv_NodeMouseDoubleClick);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cmsAddItem
            // 
            this.cmsAddItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAddItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddItemGrupo,
            this.tsmAddItemMapa,
            this.tsmAddItemPersonagem});
            this.cmsAddItem.Name = "cmsAddItem";
            this.cmsAddItem.Size = new System.Drawing.Size(166, 82);
            // 
            // tsmAddItemGrupo
            // 
            this.tsmAddItemGrupo.Name = "tsmAddItemGrupo";
            this.tsmAddItemGrupo.Size = new System.Drawing.Size(165, 26);
            this.tsmAddItemGrupo.Text = "Grupo";
            this.tsmAddItemGrupo.Click += new System.EventHandler(this.tsmAddItemGrupo_Click);
            // 
            // tsmAddItemMapa
            // 
            this.tsmAddItemMapa.Name = "tsmAddItemMapa";
            this.tsmAddItemMapa.Size = new System.Drawing.Size(165, 26);
            this.tsmAddItemMapa.Text = "Mapa";
            this.tsmAddItemMapa.Click += new System.EventHandler(this.tsmAddItemMapa_Click);
            // 
            // tsmAddItemPersonagem
            // 
            this.tsmAddItemPersonagem.Name = "tsmAddItemPersonagem";
            this.tsmAddItemPersonagem.Size = new System.Drawing.Size(165, 26);
            this.tsmAddItemPersonagem.Text = "Personagem";
            // 
            // TabDockJogoExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.trv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TabDockJogoExplorer";
            this.Text = "Jogo";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.trv, 0);
            this.pnlAtalho.ResumeLayout(false);
            this.cmsAddItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trv;
        private DigoFramework.Controle.Botao.BotaoAtalho btnAddItem;
        private System.Windows.Forms.ContextMenuStrip cmsAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAddItemGrupo;
        private System.Windows.Forms.ToolStripMenuItem tsmAddItemMapa;
        private System.Windows.Forms.ToolStripMenuItem tsmAddItemPersonagem;
    }
}
