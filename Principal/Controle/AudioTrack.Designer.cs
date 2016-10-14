namespace Rpg.Controle
{
    partial class AudioTrack
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
            this.pnlComando = new System.Windows.Forms.Panel();
            this.pnlVolume = new System.Windows.Forms.Panel();
            this.tcbVolume = new System.Windows.Forms.TrackBar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.pnlComando.SuspendLayout();
            this.pnlVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlComando
            // 
            this.pnlComando.Controls.Add(this.btnAvancar);
            this.pnlComando.Controls.Add(this.btnRetroceder);
            this.pnlComando.Controls.Add(this.btnLoop);
            this.pnlComando.Controls.Add(this.btnPlayPause);
            this.pnlComando.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlComando.Location = new System.Drawing.Point(0, 0);
            this.pnlComando.Name = "pnlComando";
            this.pnlComando.Size = new System.Drawing.Size(50, 137);
            this.pnlComando.TabIndex = 0;
            // 
            // pnlVolume
            // 
            this.pnlVolume.Controls.Add(this.tcbVolume);
            this.pnlVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVolume.Location = new System.Drawing.Point(50, 0);
            this.pnlVolume.Name = "pnlVolume";
            this.pnlVolume.Size = new System.Drawing.Size(25, 137);
            this.pnlVolume.TabIndex = 1;
            // 
            // tcbVolume
            // 
            this.tcbVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcbVolume.Location = new System.Drawing.Point(0, 0);
            this.tcbVolume.Name = "tcbVolume";
            this.tcbVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tcbVolume.Size = new System.Drawing.Size(25, 137);
            this.tcbVolume.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitulo.Location = new System.Drawing.Point(0, 137);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(75, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "audio_name";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlayPause.Location = new System.Drawing.Point(0, 0);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(50, 23);
            this.btnPlayPause.TabIndex = 0;
            this.btnPlayPause.UseVisualStyleBackColor = true;
            // 
            // btnLoop
            // 
            this.btnLoop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoop.Location = new System.Drawing.Point(0, 23);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(50, 23);
            this.btnLoop.TabIndex = 1;
            this.btnLoop.UseVisualStyleBackColor = true;
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRetroceder.Location = new System.Drawing.Point(0, 46);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(50, 23);
            this.btnRetroceder.TabIndex = 2;
            this.btnRetroceder.UseVisualStyleBackColor = true;
            // 
            // btnAvancar
            // 
            this.btnAvancar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAvancar.Location = new System.Drawing.Point(0, 69);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(50, 23);
            this.btnAvancar.TabIndex = 3;
            this.btnAvancar.UseVisualStyleBackColor = true;
            // 
            // AudioTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlVolume);
            this.Controls.Add(this.pnlComando);
            this.Controls.Add(this.lblTitulo);
            this.Name = "AudioTrack";
            this.Size = new System.Drawing.Size(75, 150);
            this.pnlComando.ResumeLayout(false);
            this.pnlVolume.ResumeLayout(false);
            this.pnlVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcbVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlComando;
        private System.Windows.Forms.Panel pnlVolume;
        private System.Windows.Forms.TrackBar tcbVolume;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnRetroceder;
    }
}
