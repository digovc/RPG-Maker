namespace Rpg.Controle.TabDock
{
    partial class TabDockMixer
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
            this.pnlMixer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMixer
            // 
            this.pnlMixer.AutoScroll = true;
            this.pnlMixer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMixer.Location = new System.Drawing.Point(0, 25);
            this.pnlMixer.Name = "pnlMixer";
            this.pnlMixer.Size = new System.Drawing.Size(284, 236);
            this.pnlMixer.TabIndex = 1;
            // 
            // TabDockMixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlMixer);
            this.Name = "TabDockMixer";
            this.Text = "TabDockAudio";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.pnlMixer, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMixer;
    }
}