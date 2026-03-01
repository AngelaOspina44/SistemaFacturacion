namespace Pantallas_Sistema_facturacion1
{
    partial class frmAyuda
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtAyuda = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(276, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "AYUDA DEL SISTEMA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAyuda
            // 
            this.txtAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAyuda.BackColor = System.Drawing.SystemColors.Control;
            this.txtAyuda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAyuda.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAyuda.Location = new System.Drawing.Point(316, 40);
            this.txtAyuda.Multiline = true;
            this.txtAyuda.Name = "txtAyuda";
            this.txtAyuda.ReadOnly = true;
            this.txtAyuda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAyuda.Size = new System.Drawing.Size(464, 70);
            this.txtAyuda.TabIndex = 1;
            this.txtAyuda.Text = "Este módulo permite consultar la documentación del sistema de facturación.\nPara m" +
    "ás información visite la página oficial.";
            this.txtAyuda.TextChanged += new System.EventHandler(this.txtAyuda_TextChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(803, 466);
            this.webBrowser1.TabIndex = 3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCerrar.Location = new System.Drawing.Point(659, 431);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 466);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtAyuda);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnCerrar);
            this.Name = "frmAyuda";
            this.Text = "frmAyuda";
            this.Load += new System.EventHandler(this.frmAyuda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtAyuda;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnCerrar;
    }
}