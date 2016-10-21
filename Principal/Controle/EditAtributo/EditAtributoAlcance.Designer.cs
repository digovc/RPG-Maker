namespace Rpg.Controle.EditAtributo
{
    partial class EditAtributoAlcance
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
            this.txtStrValor = new System.Windows.Forms.TextBox();
            this.txtStrValorMaximo = new System.Windows.Forms.TextBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.pnlEspaco = new System.Windows.Forms.Panel();
            this.pnlProgressBar = new System.Windows.Forms.Panel();
            this.pnlProgressBarValor = new System.Windows.Forms.Panel();
            this.pnlCampo.SuspendLayout();
            this.pnlProgressBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Controls.Add(this.pnlProgressBar);
            this.pnlCampo.Controls.Add(this.pnlEspaco);
            this.pnlCampo.Controls.Add(this.txtStrValorMaximo);
            this.pnlCampo.Controls.Add(this.lblDe);
            this.pnlCampo.Controls.Add(this.txtStrValor);
            this.pnlCampo.Size = new System.Drawing.Size(1343, 25);
            // 
            // txtStrValor
            // 
            this.txtStrValor.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtStrValor.Location = new System.Drawing.Point(10, 0);
            this.txtStrValor.Name = "txtStrValor";
            this.txtStrValor.Size = new System.Drawing.Size(50, 22);
            this.txtStrValor.TabIndex = 2;
            this.txtStrValor.TextChanged += new System.EventHandler(this.txtStrValor_TextChanged);
            // 
            // txtStrValorMaximo
            // 
            this.txtStrValorMaximo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtStrValorMaximo.Location = new System.Drawing.Point(110, 0);
            this.txtStrValorMaximo.Name = "txtStrValorMaximo";
            this.txtStrValorMaximo.Size = new System.Drawing.Size(50, 22);
            this.txtStrValorMaximo.TabIndex = 3;
            this.txtStrValorMaximo.TextChanged += new System.EventHandler(this.txtStrValorMaximo_TextChanged);
            // 
            // lblDe
            // 
            this.lblDe.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDe.Location = new System.Drawing.Point(60, 0);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(50, 25);
            this.lblDe.TabIndex = 4;
            this.lblDe.Text = "de";
            this.lblDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEspaco
            // 
            this.pnlEspaco.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEspaco.Location = new System.Drawing.Point(160, 0);
            this.pnlEspaco.Name = "pnlEspaco";
            this.pnlEspaco.Size = new System.Drawing.Size(25, 25);
            this.pnlEspaco.TabIndex = 6;
            // 
            // pnlProgressBar
            // 
            this.pnlProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgressBar.Controls.Add(this.pnlProgressBarValor);
            this.pnlProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProgressBar.Location = new System.Drawing.Point(185, 0);
            this.pnlProgressBar.Name = "pnlProgressBar";
            this.pnlProgressBar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlProgressBar.Size = new System.Drawing.Size(1148, 25);
            this.pnlProgressBar.TabIndex = 7;
            // 
            // pnlProgressBarValor
            // 
            this.pnlProgressBarValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProgressBarValor.Location = new System.Drawing.Point(0, 10);
            this.pnlProgressBarValor.Name = "pnlProgressBarValor";
            this.pnlProgressBarValor.Size = new System.Drawing.Size(1146, 3);
            this.pnlProgressBarValor.TabIndex = 0;
            // 
            // EditAtributoAlcance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EditAtributoAlcance";
            this.Size = new System.Drawing.Size(1343, 50);
            this.pnlCampo.ResumeLayout(false);
            this.pnlCampo.PerformLayout();
            this.pnlProgressBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtStrValor;
        private System.Windows.Forms.TextBox txtStrValorMaximo;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Panel pnlEspaco;
        private System.Windows.Forms.Panel pnlProgressBar;
        private System.Windows.Forms.Panel pnlProgressBarValor;
    }
}
