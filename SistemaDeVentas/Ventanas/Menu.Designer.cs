
namespace SistemaDeVentas.Ventanas
{
    partial class Menu
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
            this.lbEncargado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbEncargado
            // 
            this.lbEncargado.AutoSize = true;
            this.lbEncargado.Location = new System.Drawing.Point(290, 120);
            this.lbEncargado.Name = "lbEncargado";
            this.lbEncargado.Size = new System.Drawing.Size(51, 20);
            this.lbEncargado.TabIndex = 0;
            this.lbEncargado.Text = "label1";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbEncargado);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEncargado;
    }
}