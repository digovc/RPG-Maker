namespace Rpg.Controle.TabDock
{
    partial class TabDockMapa
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
            this.ctrDisplay = new Rpg.Controle.Editor.MapaDisplay();
            this.SuspendLayout();
            // 
            // ctrDisplay
            // 
            this.ctrDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrDisplay.Location = new System.Drawing.Point(0, 0);
            this.ctrDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.ctrDisplay.Name = "ctrDisplay";
            this.ctrDisplay.objMapa = null;
            this.ctrDisplay.Size = new System.Drawing.Size(1043, 912);
            this.ctrDisplay.TabIndex = 0;
            // 
            // TabDockMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 912);
            this.Controls.Add(this.ctrDisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TabDockMapa";
            this.Text = "Mapa";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.ctrDisplay, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Editor.MapaDisplay ctrDisplay;
    }
}