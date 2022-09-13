namespace TranslineaN
{
    partial class frmRuta
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
            this.DtgRuta = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHora = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstampilla = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtValorMin = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mcFecha = new System.Windows.Forms.MonthCalendar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRuta)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCodigo.Location = new System.Drawing.Point(66, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(121, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // DtgRuta
            // 
            this.DtgRuta.BackgroundColor = System.Drawing.Color.White;
            this.DtgRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRuta.Location = new System.Drawing.Point(13, 193);
            this.DtgRuta.Name = "DtgRuta";
            this.DtgRuta.Size = new System.Drawing.Size(631, 113);
            this.DtgRuta.TabIndex = 2;
            this.DtgRuta.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DtgRuta_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Destino";
            // 
            // cboOrigen
            // 
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(66, 39);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(121, 21);
            this.cboOrigen.TabIndex = 4;
            this.cboOrigen.Leave += new System.EventHandler(this.cboOrigen_Leave);
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(259, 39);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(121, 21);
            this.cboDestino.TabIndex = 6;
            this.cboDestino.Leave += new System.EventHandler(this.cboDestino_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hora";
            // 
            // cboHora
            // 
            this.cboHora.FormattingEnabled = true;
            this.cboHora.Location = new System.Drawing.Point(259, 12);
            this.cboHora.MaxLength = 8;
            this.cboHora.Name = "cboHora";
            this.cboHora.Size = new System.Drawing.Size(121, 21);
            this.cboHora.TabIndex = 8;
            this.cboHora.Leave += new System.EventHandler(this.cboHora_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estampilla";
            // 
            // txtEstampilla
            // 
            this.txtEstampilla.Location = new System.Drawing.Point(64, 33);
            this.txtEstampilla.MaxLength = 7;
            this.txtEstampilla.Name = "txtEstampilla";
            this.txtEstampilla.Size = new System.Drawing.Size(121, 20);
            this.txtEstampilla.TabIndex = 10;
            this.txtEstampilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstampilla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstampilla_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Comision";
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(258, 7);
            this.txtComision.MaxLength = 7;
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(121, 20);
            this.txtComision.TabIndex = 12;
            this.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComision_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Reexp.";
            // 
            // txtReex
            // 
            this.txtReex.Location = new System.Drawing.Point(66, 66);
            this.txtReex.MaxLength = 7;
            this.txtReex.Name = "txtReex";
            this.txtReex.Size = new System.Drawing.Size(121, 20);
            this.txtReex.TabIndex = 14;
            this.txtReex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReex_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(208, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(259, 66);
            this.txtValor.MaxLength = 10;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(121, 20);
            this.txtValor.TabIndex = 16;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Valor Min";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtReex);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboHora);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboDestino);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboOrigen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 100);
            this.panel1.TabIndex = 18;
            // 
            // txtValorMin
            // 
            this.txtValorMin.Location = new System.Drawing.Point(64, 7);
            this.txtValorMin.MaxLength = 10;
            this.txtValorMin.Name = "txtValorMin";
            this.txtValorMin.Size = new System.Drawing.Size(121, 20);
            this.txtValorMin.TabIndex = 17;
            this.txtValorMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorMin_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboVehiculo);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtValorMin);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtComision);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtEstampilla);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(14, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 68);
            this.panel2.TabIndex = 19;
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(258, 36);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(121, 21);
            this.cboVehiculo.TabIndex = 17;
            this.cboVehiculo.Leave += new System.EventHandler(this.cboBus_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Vehiculo";
            // 
            // mcFecha
            // 
            this.mcFecha.Location = new System.Drawing.Point(417, 19);
            this.mcFecha.Name = "mcFecha";
            this.mcFecha.TabIndex = 20;
            this.mcFecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcFecha_DateChanged);
            this.mcFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcFecha_DateSelected);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtPuesto);
            this.panel3.Controls.Add(this.bttnSalir);
            this.panel3.Controls.Add(this.bttnGuardar);
            this.panel3.Controls.Add(this.bttnAdicionar);
            this.panel3.Location = new System.Drawing.Point(12, 310);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 45);
            this.panel3.TabIndex = 21;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Location = new System.Drawing.Point(16, 10);
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.Size = new System.Drawing.Size(66, 20);
            this.txtPuesto.TabIndex = 3;
            this.txtPuesto.Visible = false;
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(538, 4);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 2;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(457, 4);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 1;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(376, 4);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 0;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // frmRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 365);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.mcFecha);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgRuta);
            this.Name = "frmRuta";
            this.Text = "frmRuta";
            this.Load += new System.EventHandler(this.frmRuta_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRuta_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRuta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRuta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView DtgRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstampilla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtValorMin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MonthCalendar mcFecha;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.TextBox txtPuesto;
    }
}