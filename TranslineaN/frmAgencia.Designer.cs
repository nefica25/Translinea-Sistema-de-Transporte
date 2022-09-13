namespace TranslineaN
{
    partial class frmAgencia
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
            this.pnlCajas = new System.Windows.Forms.Panel();
            this.cboTipoSucursal = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAbrev = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.DtgAgencia = new System.Windows.Forms.DataGridView();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.pnlCajas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAgencia)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCajas
            // 
            this.pnlCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajas.Controls.Add(this.cboTipoSucursal);
            this.pnlCajas.Controls.Add(this.label11);
            this.pnlCajas.Controls.Add(this.txtTelefono);
            this.pnlCajas.Controls.Add(this.label10);
            this.pnlCajas.Controls.Add(this.txtDireccion);
            this.pnlCajas.Controls.Add(this.label9);
            this.pnlCajas.Controls.Add(this.cboDepartamento);
            this.pnlCajas.Controls.Add(this.label8);
            this.pnlCajas.Controls.Add(this.cboPais);
            this.pnlCajas.Controls.Add(this.label7);
            this.pnlCajas.Controls.Add(this.txtBarrio);
            this.pnlCajas.Controls.Add(this.label6);
            this.pnlCajas.Controls.Add(this.cboCiudad);
            this.pnlCajas.Controls.Add(this.label5);
            this.pnlCajas.Controls.Add(this.txtAbrev);
            this.pnlCajas.Controls.Add(this.label4);
            this.pnlCajas.Controls.Add(this.txtCodigo);
            this.pnlCajas.Controls.Add(this.label3);
            this.pnlCajas.Controls.Add(this.txtAgencia);
            this.pnlCajas.Controls.Add(this.label1);
            this.pnlCajas.Location = new System.Drawing.Point(13, 11);
            this.pnlCajas.Name = "pnlCajas";
            this.pnlCajas.Size = new System.Drawing.Size(576, 155);
            this.pnlCajas.TabIndex = 17;
            // 
            // cboTipoSucursal
            // 
            this.cboTipoSucursal.FormattingEnabled = true;
            this.cboTipoSucursal.Location = new System.Drawing.Point(74, 35);
            this.cboTipoSucursal.Name = "cboTipoSucursal";
            this.cboTipoSucursal.Size = new System.Drawing.Size(226, 21);
            this.cboTipoSucursal.TabIndex = 2;
            this.cboTipoSucursal.Leave += new System.EventHandler(this.cboTipoSucursal_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tipo ";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(382, 120);
            this.txtTelefono.MaxLength = 12;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(178, 20);
            this.txtTelefono.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Telefono";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(74, 120);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(226, 20);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Dirección";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(382, 64);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(178, 21);
            this.cboDepartamento.TabIndex = 6;
            this.cboDepartamento.Enter += new System.EventHandler(this.cboDepartamento_Enter);
            this.cboDepartamento.Leave += new System.EventHandler(this.cboDepartamento_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Departam.";
            // 
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(74, 62);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(226, 21);
            this.cboPais.TabIndex = 5;
            this.cboPais.Enter += new System.EventHandler(this.cboPais_Enter);
            this.cboPais.Leave += new System.EventHandler(this.cboPais_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pais";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Location = new System.Drawing.Point(382, 91);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(178, 20);
            this.txtBarrio.TabIndex = 8;
            this.txtBarrio.Leave += new System.EventHandler(this.txtBarrio_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Barrio";
            // 
            // cboCiudad
            // 
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(74, 91);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(226, 21);
            this.cboCiudad.TabIndex = 7;
            this.cboCiudad.Enter += new System.EventHandler(this.cboCiudad_Enter);
            this.cboCiudad.Leave += new System.EventHandler(this.cboCiudad_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ciudad";
            // 
            // txtAbrev
            // 
            this.txtAbrev.Location = new System.Drawing.Point(382, 38);
            this.txtAbrev.MaxLength = 12;
            this.txtAbrev.Name = "txtAbrev";
            this.txtAbrev.Size = new System.Drawing.Size(178, 20);
            this.txtAbrev.TabIndex = 4;
            this.txtAbrev.Leave += new System.EventHandler(this.txtAbrev_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Abreviatura";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(382, 7);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(178, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(315, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codigo";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(74, 9);
            this.txtAgencia.MaxLength = 70;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(226, 20);
            this.txtAgencia.TabIndex = 3;
            this.txtAgencia.Leave += new System.EventHandler(this.txtAgencia_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agencia";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bttnCancelar);
            this.panel1.Controls.Add(this.bttnBuscar);
            this.panel1.Controls.Add(this.bttnSalir);
            this.panel1.Controls.Add(this.bttnGuardar);
            this.panel1.Controls.Add(this.bttnAdicionar);
            this.panel1.Location = new System.Drawing.Point(13, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 43);
            this.panel1.TabIndex = 16;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(412, 4);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 6;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(493, 4);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 5;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(250, 5);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 4;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(169, 5);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 3;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // DtgAgencia
            // 
            this.DtgAgencia.BackgroundColor = System.Drawing.Color.White;
            this.DtgAgencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAgencia.Location = new System.Drawing.Point(13, 172);
            this.DtgAgencia.Name = "DtgAgencia";
            this.DtgAgencia.Size = new System.Drawing.Size(577, 175);
            this.DtgAgencia.TabIndex = 15;
            this.DtgAgencia.SelectionChanged += new System.EventHandler(this.DtgAgencia_SelectionChanged);
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(331, 5);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 33);
            this.bttnCancelar.TabIndex = 7;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // frmAgencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 406);
            this.Controls.Add(this.pnlCajas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgAgencia);
            this.Name = "frmAgencia";
            this.Text = "frmAgencia";
            this.Load += new System.EventHandler(this.frmAgencia_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAgencia_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAgencia_KeyDown);
            this.pnlCajas.ResumeLayout(false);
            this.pnlCajas.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAgencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCajas;
        private System.Windows.Forms.ComboBox cboTipoSucursal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAbrev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.DataGridView DtgAgencia;
        private System.Windows.Forms.Button bttnCancelar;
    }
}