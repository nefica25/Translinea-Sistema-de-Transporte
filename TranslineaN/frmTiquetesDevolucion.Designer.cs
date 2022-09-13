namespace TranslineaN
{
    partial class frmTiquetesDevolucion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.DtgDevolucion = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDevolucion = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bttnImprimir = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevolucion)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Tiquete";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(100, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(168, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // DtgDevolucion
            // 
            this.DtgDevolucion.BackgroundColor = System.Drawing.Color.White;
            this.DtgDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDevolucion.Location = new System.Drawing.Point(12, 81);
            this.DtgDevolucion.Name = "DtgDevolucion";
            this.DtgDevolucion.Size = new System.Drawing.Size(521, 227);
            this.DtgDevolucion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo Devolucion";
            // 
            // cboTipoDevolucion
            // 
            this.cboTipoDevolucion.FormattingEnabled = true;
            this.cboTipoDevolucion.Location = new System.Drawing.Point(363, 9);
            this.cboTipoDevolucion.Name = "cboTipoDevolucion";
            this.cboTipoDevolucion.Size = new System.Drawing.Size(136, 21);
            this.cboTipoDevolucion.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.bttnImprimir);
            this.panel7.Controls.Add(this.bttnSalir);
            this.panel7.Controls.Add(this.bttnGuardar);
            this.panel7.Controls.Add(this.bttnAdicionar);
            this.panel7.Location = new System.Drawing.Point(11, 314);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(521, 49);
            this.panel7.TabIndex = 25;
            // 
            // bttnImprimir
            // 
            this.bttnImprimir.Location = new System.Drawing.Point(352, 7);
            this.bttnImprimir.Name = "bttnImprimir";
            this.bttnImprimir.Size = new System.Drawing.Size(75, 33);
            this.bttnImprimir.TabIndex = 14;
            this.bttnImprimir.Text = "&Imprimir";
            this.bttnImprimir.UseVisualStyleBackColor = true;
            this.bttnImprimir.Click += new System.EventHandler(this.bttnImprimir_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(433, 7);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 13;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(271, 7);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 12;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(190, 7);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 11;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Destino";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Hora";
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(100, 37);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(168, 21);
            this.cboDestino.TabIndex = 28;
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.Color.White;
            this.txtHora.Location = new System.Drawing.Point(363, 37);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(136, 20);
            this.txtHora.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtHora);
            this.panel1.Controls.Add(this.cboDestino);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboTipoDevolucion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 68);
            this.panel1.TabIndex = 30;
            // 
            // frmTiquetesDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 370);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.DtgDevolucion);
            this.Name = "frmTiquetesDevolucion";
            this.Text = "Devolucion Tiquetes    <Translinea Software>";
            this.Load += new System.EventHandler(this.frmTiquetesDevolucion_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTiquetesDevolucion_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmTiquetesDevolucion_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevolucion)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView DtgDevolucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoDevolucion;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button bttnImprimir;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Panel panel1;
    }
}