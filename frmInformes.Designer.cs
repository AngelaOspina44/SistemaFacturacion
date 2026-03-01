namespace Pantallas_Sistema_facturacion1
{
    partial class frmInformes
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
            this.dgvInformes = new System.Windows.Forms.DataGridView();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitulo.Location = new System.Drawing.Point(304, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(215, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "INFORMES DEL SISTEMA";
            // 
            // dgvInformes
            // 
            this.dgvInformes.AllowUserToAddRows = false;
            this.dgvInformes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformes.Location = new System.Drawing.Point(12, 174);
            this.dgvInformes.Name = "dgvInformes";
            this.dgvInformes.ReadOnly = true;
            this.dgvInformes.RowHeadersWidth = 51;
            this.dgvInformes.RowTemplate.Height = 24;
            this.dgvInformes.Size = new System.Drawing.Size(776, 218);
            this.dgvInformes.TabIndex = 1;
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Facturas",
            "Clientes",
            "Productos",
            "Empleados"});
            this.cbTipo.Location = new System.Drawing.Point(321, 52);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(144, 33);
            this.cbTipo.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(331, 110);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(125, 37);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.dgvInformes);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmInformes";
            this.Text = "frmInformes";
            this.Load += new System.EventHandler(this.frmInformes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvInformes;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button btnConsultar;
    }
}