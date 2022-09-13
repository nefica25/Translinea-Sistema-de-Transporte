namespace TranslineaN
{
    partial class frmVehiculo
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCajas = new System.Windows.Forms.Panel();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAsientos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DtgVehiculo = new System.Windows.Forms.DataGridView();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.pnlCajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgVehiculo)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Location = new System.Drawing.Point(60, 6);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(269, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(60, 30);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(269, 21);
            this.cboTipo.TabIndex = 3;
            this.cboTipo.Leave += new System.EventHandler(this.cboTipo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vehiculo";
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.Location = new System.Drawing.Point(60, 54);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.Size = new System.Drawing.Size(111, 20);
            this.txtVehiculo.TabIndex = 5;
            this.txtVehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehiculo_KeyPress);
            this.txtVehiculo.Leave += new System.EventHandler(this.txtVehiculo_Leave);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(216, 54);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(113, 20);
            this.txtPlaca.TabIndex = 7;
            this.txtPlaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlaca_KeyPress);
            this.txtPlaca.Leave += new System.EventHandler(this.txtPlaca_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Placa";
            // 
            // pnlCajas
            // 
            this.pnlCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajas.Controls.Add(this.cboMarca);
            this.pnlCajas.Controls.Add(this.cboEstado);
            this.pnlCajas.Controls.Add(this.label7);
            this.pnlCajas.Controls.Add(this.txtModelo);
            this.pnlCajas.Controls.Add(this.label8);
            this.pnlCajas.Controls.Add(this.label6);
            this.pnlCajas.Controls.Add(this.txtAsientos);
            this.pnlCajas.Controls.Add(this.label5);
            this.pnlCajas.Controls.Add(this.txtPlaca);
            this.pnlCajas.Controls.Add(this.label4);
            this.pnlCajas.Controls.Add(this.txtVehiculo);
            this.pnlCajas.Controls.Add(this.label3);
            this.pnlCajas.Controls.Add(this.cboTipo);
            this.pnlCajas.Controls.Add(this.label2);
            this.pnlCajas.Controls.Add(this.txtCodigo);
            this.pnlCajas.Controls.Add(this.label1);
            this.pnlCajas.Location = new System.Drawing.Point(9, 9);
            this.pnlCajas.Name = "pnlCajas";
            this.pnlCajas.Size = new System.Drawing.Size(341, 132);
            this.pnlCajas.TabIndex = 8;
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(216, 78);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(113, 21);
            this.cboMarca.TabIndex = 16;
            this.cboMarca.Leave += new System.EventHandler(this.cboMarca_Leave);
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(216, 102);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(113, 21);
            this.cboEstado.TabIndex = 15;
            this.cboEstado.Leave += new System.EventHandler(this.cboEstado_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estado";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(60, 102);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(111, 20);
            this.txtModelo.TabIndex = 13;
            this.txtModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelo_KeyPress);
            this.txtModelo.Leave += new System.EventHandler(this.txtModelo_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Modelo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Marca";
            // 
            // txtAsientos
            // 
            this.txtAsientos.Location = new System.Drawing.Point(60, 78);
            this.txtAsientos.Name = "txtAsientos";
            this.txtAsientos.Size = new System.Drawing.Size(111, 20);
            this.txtAsientos.TabIndex = 9;
            this.txtAsientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAsientos_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Asientos";
            // 
            // DtgVehiculo
            // 
            this.DtgVehiculo.BackgroundColor = System.Drawing.Color.White;
            this.DtgVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgVehiculo.Location = new System.Drawing.Point(9, 145);
            this.DtgVehiculo.Name = "DtgVehiculo";
            this.DtgVehiculo.Size = new System.Drawing.Size(341, 217);
            this.DtgVehiculo.TabIndex = 9;
            this.DtgVehiculo.SelectionChanged += new System.EventHandler(this.DtgVehiculo_SelectionChanged);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.bttnCancelar);
            this.pnlBotones.Controls.Add(this.bttnBuscar);
            this.pnlBotones.Controls.Add(this.bttnSalir);
            this.pnlBotones.Controls.Add(this.bttnGuardar);
            this.pnlBotones.Controls.Add(this.bttnAdicionar);
            this.pnlBotones.Location = new System.Drawing.Point(9, 365);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(341, 43);
            this.pnlBotones.TabIndex = 14;
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(140, 4);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(63, 33);
            this.bttnCancelar.TabIndex = 11;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(205, 4);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(63, 33);
            this.bttnBuscar.TabIndex = 10;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(271, 4);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(63, 33);
            this.bttnSalir.TabIndex = 9;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(74, 4);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(63, 33);
            this.bttnGuardar.TabIndex = 8;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(9, 4);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(63, 33);
            this.bttnAdicionar.TabIndex = 7;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // frmVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 417);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.DtgVehiculo);
            this.Controls.Add(this.pnlCajas);
            this.Name = "frmVehiculo";
            this.Text = "frmVehiculo";
            this.Load += new System.EventHandler(this.frmVehiculo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmVehiculo_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVehiculo_KeyDown);
            this.pnlCajas.ResumeLayout(false);
            this.pnlCajas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgVehiculo)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCajas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAsientos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DtgVehiculo;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.ComboBox cboMarca;
    }
}