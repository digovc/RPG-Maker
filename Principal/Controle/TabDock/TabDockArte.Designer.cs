namespace Rpg.Controle.TabDock
{
    partial class TabDockArte
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
            this.trv = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trv
            // 
            this.trv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv.Location = new System.Drawing.Point(0, 25);
            this.trv.Name = "trv";
            this.trv.Size = new System.Drawing.Size(284, 236);
            this.trv.TabIndex = 1;
            // 
            // TabDockArte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.trv);
            this.Name = "TabDockArte";
            this.Text = "TabDockArte";
            this.Controls.SetChildIndex(this.pnlAtalho, 0);
            this.Controls.SetChildIndex(this.trv, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trv;
    }
}