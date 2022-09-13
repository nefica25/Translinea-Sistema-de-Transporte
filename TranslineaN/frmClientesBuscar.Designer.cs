namespace TranslineaN
{
    partial class frmClientesBuscar
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
            this.DtgBuscar = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboOpcion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBuscar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgBuscar
            // 
            this.DtgBuscar.BackgroundColor = System.Drawing.Color.White;
            this.DtgBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBuscar.Location = new System.Drawing.Point(12, 73);
            this.DtgBuscar.Name = "DtgBuscar";
            this.DtgBuscar.Size = new System.Drawing.Size(363, 117);
            this.DtgBuscar.TabIndex = 2;
            this.DtgBuscar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgBuscar_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboOpcion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.LblBuscar);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 60);
            this.panel1.TabIndex = 3;
            // 
            // cboOpcion
            // 
            this.cboOpcion.FormattingEnabled = true;
            this.cboOpcion.Location = new System.Drawing.Point(55, 5);
            this.cboOpcion.Name = "cboOpcion";
            this.cboOpcion.Size = new System.Drawing.Size(295, 21);
            this.cboOpcion.TabIndex = 2;
            this.cboOpcion.Leave += new System.EventHandler(this.cboOpcion_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Opcion";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(55, 32);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(295, 20);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // LblBuscar
            // 
            this.LblBuscar.AutoSize = true;
            this.LblBuscar.Location = new System.Drawing.Point(8, 36);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(40, 13);
            this.LblBuscar.TabIndex = 1;
            this.LblBuscar.Text = "Buscar";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bttnBuscar);
            this.panel2.Controls.Add(this.bttnSalir);
            this.panel2.Location = new System.Drawing.Point(12, 196);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 43);
            this.panel2.TabIndex = 4;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(204, 4);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 34);
            this.bttnBuscar.TabIndex = 0;
            this.bttnBuscar.Text = "&Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(283, 3);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 34);
            this.bttnSalir.TabIndex = 0;
            this.bttnSalir.Text = "Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // frmClientesBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 246);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgBuscar);
            this.Name = "frmClientesBuscar";
            this.Text = "frmClientesBuscar";
            this.Load += new System.EventHandler(this.frmClientesBuscar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmClientesBuscar_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBuscar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboOpcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
    }
}