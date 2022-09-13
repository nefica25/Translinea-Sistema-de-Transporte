namespace TranslineaN
{
    partial class frmTiquetesTraslados
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboAgenciaSucursalDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.DtgTraslado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtValorTiquete = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAsientoActual = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtValorTiqueteT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboAsientoTraslado = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboRecorrido = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnImprimir = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoTraslado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTraslado)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Agencia Destino\r\n";
            // 
            // cboAgenciaSucursalDestino
            // 
            this.cboAgenciaSucursalDestino.FormattingEnabled = true;
            this.cboAgenciaSucursalDestino.Location = new System.Drawing.Point(102, 34);
            this.cboAgenciaSucursalDestino.Name = "cboAgenciaSucursalDestino";
            this.cboAgenciaSucursalDestino.Size = new System.Drawing.Size(175, 21);
            this.cboAgenciaSucursalDestino.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codigo Tiquete";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(102, 8);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(175, 20);
            this.txtCodigo.TabIndex = 5;
            // 
            // DtgTraslado
            // 
            this.DtgTraslado.BackgroundColor = System.Drawing.Color.White;
            this.DtgTraslado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTraslado.Location = new System.Drawing.Point(13, 216);
            this.DtgTraslado.Name = "DtgTraslado";
            this.DtgTraslado.Size = new System.Drawing.Size(577, 112);
            this.DtgTraslado.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cboTipoTraslado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtValorTiquete);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAsientoActual);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.cboOrigen);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(13, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 96);
            this.panel1.TabIndex = 7;
            // 
            // txtValorTiquete
            // 
            this.txtValorTiquete.Location = new System.Drawing.Point(390, 62);
            this.txtValorTiquete.Name = "txtValorTiquete";
            this.txtValorTiquete.Size = new System.Drawing.Size(175, 20);
            this.txtValorTiquete.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Valor";
            // 
            // txtAsientoActual
            // 
            this.txtAsientoActual.Location = new System.Drawing.Point(102, 62);
            this.txtAsientoActual.Name = "txtAsientoActual";
            this.txtAsientoActual.Size = new System.Drawing.Size(175, 20);
            this.txtAsientoActual.TabIndex = 15;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(102, 34);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(175, 20);
            this.txtFecha.TabIndex = 7;
            // 
            // cboOrigen
            // 
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(390, 35);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(175, 21);
            this.cboOrigen.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Asiento Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ciudad  Origen";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtValorTiqueteT);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cboAsientoTraslado);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cboRecorrido);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.DtpFecha);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboDestino);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboAgenciaSucursalDestino);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 95);
            this.panel2.TabIndex = 8;
            // 
            // txtValorTiqueteT
            // 
            this.txtValorTiqueteT.Location = new System.Drawing.Point(390, 64);
            this.txtValorTiqueteT.Name = "txtValorTiqueteT";
            this.txtValorTiqueteT.Size = new System.Drawing.Size(175, 20);
            this.txtValorTiqueteT.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Valor";
            // 
            // cboAsientoTraslado
            // 
            this.cboAsientoTraslado.FormattingEnabled = true;
            this.cboAsientoTraslado.Location = new System.Drawing.Point(102, 61);
            this.cboAsientoTraslado.Name = "cboAsientoTraslado";
            this.cboAsientoTraslado.Size = new System.Drawing.Size(175, 21);
            this.cboAsientoTraslado.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Asiento Trasladar";
            // 
            // cboRecorrido
            // 
            this.cboRecorrido.FormattingEnabled = true;
            this.cboRecorrido.Location = new System.Drawing.Point(390, 39);
            this.cboRecorrido.Name = "cboRecorrido";
            this.cboRecorrido.Size = new System.Drawing.Size(175, 21);
            this.cboRecorrido.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Recorrido";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(102, 6);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(175, 20);
            this.DtpFecha.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fecha";
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(390, 12);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(175, 21);
            this.cboDestino.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ciudad Destino\r\n";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.bttnBuscar);
            this.panel7.Controls.Add(this.bttnImprimir);
            this.panel7.Controls.Add(this.bttnSalir);
            this.panel7.Controls.Add(this.bttnGuardar);
            this.panel7.Controls.Add(this.bttnAdicionar);
            this.panel7.Location = new System.Drawing.Point(13, 334);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(577, 49);
            this.panel7.TabIndex = 25;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(332, 7);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 15;
            this.bttnBuscar.Text = "&Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnImprimir
            // 
            this.bttnImprimir.Location = new System.Drawing.Point(411, 7);
            this.bttnImprimir.Name = "bttnImprimir";
            this.bttnImprimir.Size = new System.Drawing.Size(75, 33);
            this.bttnImprimir.TabIndex = 14;
            this.bttnImprimir.Text = "&Imprimir";
            this.bttnImprimir.UseVisualStyleBackColor = true;
            this.bttnImprimir.Click += new System.EventHandler(this.bttnImprimir_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(492, 7);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 13;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(251, 7);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 12;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(170, 7);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 11;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tipo Traslado";
            // 
            // cboTipoTraslado
            // 
            this.cboTipoTraslado.FormattingEnabled = true;
            this.cboTipoTraslado.Location = new System.Drawing.Point(390, 8);
            this.cboTipoTraslado.Name = "cboTipoTraslado";
            this.cboTipoTraslado.Size = new System.Drawing.Size(175, 21);
            this.cboTipoTraslado.TabIndex = 24;
            // 
            // frmTiquetesTraslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 393);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgTraslado);
            this.Name = "frmTiquetesTraslados";
            this.Text = "frmTiquetesTraslados";
            this.Load += new System.EventHandler(this.frmTiquetesTraslados_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTiquetesTraslados_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmTiquetesTraslados_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTraslado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAgenciaSucursalDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView DtgTraslado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboRecorrido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAsientoActual;
        private System.Windows.Forms.ComboBox cboAsientoTraslado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValorTiquete;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtValorTiqueteT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnImprimir;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.ComboBox cboTipoTraslado;
        private System.Windows.Forms.Label label1;
    }
}