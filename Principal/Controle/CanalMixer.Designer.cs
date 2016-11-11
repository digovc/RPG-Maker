namespace Rpg.Controle
{
    partial class CanalMixer
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
            this.btnPlay = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.btnStop = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.tcbVolume = new System.Windows.Forms.TrackBar();
            this.tcbTime = new System.Windows.Forms.TrackBar();
            this.pnlComando = new DigoFramework.Controle.Painel.PainelAtalho();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.btnLoop = new DigoFramework.Controle.Botao.BotaoAtalho();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ctrLinha = new DigoFramework.Controle.Diverso.Linha();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbTime)).BeginInit();
            this.pnlComando.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStop.Name = "btnStop";
            this.btnStop.TabIndex = 2;
            // 
            // tcbVolume
            // 
            this.tcbVolume.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcbVolume.Location = new System.Drawing.Point(90, 0);
            this.tcbVolume.Maximum = 100;
            this.tcbVolume.Name = "tcbVolume";
            this.tcbVolume.Size = new System.Drawing.Size(75, 25);
            this.tcbVolume.TabIndex = 3;
            this.tcbVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbVolume.ValueChanged += new System.EventHandler(this.tcbVolume_ValueChanged);
            // 
            // tcbTime
            // 
            this.tcbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcbTime.Location = new System.Drawing.Point(199, 0);
            this.tcbTime.Name = "tcbTime";
            this.tcbTime.Size = new System.Drawing.Size(267, 25);
            this.tcbTime.TabIndex = 4;
            this.tcbTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tcbTime.Scroll += new System.EventHandler(this.tcbTime_Scroll);
            // 
            // pnlComando
            // 
            this.pnlComando.Controls.Add(this.tcbTime);
            this.pnlComando.Controls.Add(this.lblTimeOut);
            this.pnlComando.Controls.Add(this.lblTimeIn);
            this.pnlComando.Controls.Add(this.tcbVolume);
            this.pnlComando.Controls.Add(this.btnLoop);
            this.pnlComando.Controls.Add(this.btnStop);
            this.pnlComando.Controls.Add(this.btnPlay);
            this.pnlComando.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComando.Name = "pnlComando";
            this.pnlComando.TabIndex = 5;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimeOut.Location = new System.Drawing.Point(466, 0);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(34, 25);
            this.lblTimeOut.TabIndex = 7;
            this.lblTimeOut.Text = "00:00";
            this.lblTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTimeIn.Location = new System.Drawing.Point(165, 0);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(34, 25);
            this.lblTimeIn.TabIndex = 6;
            this.lblTimeIn.Text = "00:00";
            this.lblTimeIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoop
            // 
            this.btnLoop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.TabIndex = 5;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 20);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Nome do arquivo de audio";
            // 
            // ctrLinha
            // 
            this.ctrLinha.BackColor = System.Drawing.Color.Gray;
            this.ctrLinha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrLinha.Name = "ctrLinha";
            this.ctrLinha.TabIndex = 7;
            // 
            // CanalMixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrLinha);
            this.Controls.Add(this.pnlComando);
            this.Controls.Add(this.lblTitulo);
            this.Name = "CanalMixer";
            this.Size = new System.Drawing.Size(500, 50);
            ((System.ComponentModel.ISupportInitialize)(this.tcbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcbTime)).EndInit();
            this.pnlComando.ResumeLayout(false);
            this.pnlComando.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DigoFramework.Controle.Botao.BotaoAtalho btnPlay;
        private DigoFramework.Controle.Botao.BotaoAtalho btnStop;
        private System.Windows.Forms.TrackBar tcbVolume;
        private System.Windows.Forms.TrackBar tcbTime;
        private DigoFramework.Controle.Painel.PainelAtalho pnlComando;
        private System.Windows.Forms.Label lblTitulo;
        private DigoFramework.Controle.Diverso.Linha ctrLinha;
        private DigoFramework.Controle.Botao.BotaoAtalho btnLoop;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblTimeOut;
    }
}
