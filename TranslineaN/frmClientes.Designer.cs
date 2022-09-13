namespace TranslineaN
{
    partial class frmClientes
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
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoCliente = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlCajasEncabezado = new System.Windows.Forms.Panel();
            this.pnlCajas = new System.Windows.Forms.Panel();
            this.cboAgenciaSucursal = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.pnlCajasEncabezado.SuspendLayout();
            this.pnlCajas.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(72, 11);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(177, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(72, 65);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(419, 20);
            this.txtNombres.TabIndex = 3;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            this.txtNombres.Leave += new System.EventHandler(this.txtNombres_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Celular";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tipo Doc";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(72, 37);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(177, 21);
            this.cboTipoDocumento.TabIndex = 1;
            this.cboTipoDocumento.Leave += new System.EventHandler(this.cboTipoDocumento_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(314, 40);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(177, 20);
            this.txtDocumento.TabIndex = 2;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(72, 91);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(177, 20);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(314, 94);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(177, 20);
            this.txtCelular.TabIndex = 5;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tipo Cliente";
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.FormattingEnabled = true;
            this.cboTipoCliente.Location = new System.Drawing.Point(314, 11);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Size = new System.Drawing.Size(177, 21);
            this.cboTipoCliente.TabIndex = 0;
            this.cboTipoCliente.Enter += new System.EventHandler(this.cboTipoCliente_Enter);
            this.cboTipoCliente.Leave += new System.EventHandler(this.cboTipoCliente_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(314, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(72, 3);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(177, 20);
            this.txtDireccion.TabIndex = 1;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Direccion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Pais";
            // 
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(72, 29);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(177, 21);
            this.cboPais.TabIndex = 2;
            this.cboPais.Leave += new System.EventHandler(this.cboPais_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Depart";
            // 
            // pnlCajasEncabezado
            // 
            this.pnlCajasEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajasEncabezado.Controls.Add(this.cboTipoCliente);
            this.pnlCajasEncabezado.Controls.Add(this.label8);
            this.pnlCajasEncabezado.Controls.Add(this.txtCelular);
            this.pnlCajasEncabezado.Controls.Add(this.txtTelefono);
            this.pnlCajasEncabezado.Controls.Add(this.txtDocumento);
            this.pnlCajasEncabezado.Controls.Add(this.label7);
            this.pnlCajasEncabezado.Controls.Add(this.cboTipoDocumento);
            this.pnlCajasEncabezado.Controls.Add(this.label6);
            this.pnlCajasEncabezado.Controls.Add(this.label5);
            this.pnlCajasEncabezado.Controls.Add(this.label4);
            this.pnlCajasEncabezado.Controls.Add(this.txtNombres);
            this.pnlCajasEncabezado.Controls.Add(this.label2);
            this.pnlCajasEncabezado.Controls.Add(this.txtCodigo);
            this.pnlCajasEncabezado.Controls.Add(this.label1);
            this.pnlCajasEncabezado.Location = new System.Drawing.Point(11, 11);
            this.pnlCajasEncabezado.Name = "pnlCajasEncabezado";
            this.pnlCajasEncabezado.Size = new System.Drawing.Size(507, 125);
            this.pnlCajasEncabezado.TabIndex = 23;
            // 
            // pnlCajas
            // 
            this.pnlCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajas.Controls.Add(this.cboEstado);
            this.pnlCajas.Controls.Add(this.cboAgenciaSucursal);
            this.pnlCajas.Controls.Add(this.label15);
            this.pnlCajas.Controls.Add(this.label14);
            this.pnlCajas.Controls.Add(this.txtBarrio);
            this.pnlCajas.Controls.Add(this.label13);
            this.pnlCajas.Controls.Add(this.cboCiudad);
            this.pnlCajas.Controls.Add(this.label12);
            this.pnlCajas.Controls.Add(this.txtEmail);
            this.pnlCajas.Controls.Add(this.label9);
            this.pnlCajas.Controls.Add(this.cboDepartamento);
            this.pnlCajas.Controls.Add(this.label11);
            this.pnlCajas.Controls.Add(this.cboPais);
            this.pnlCajas.Controls.Add(this.label10);
            this.pnlCajas.Controls.Add(this.txtDireccion);
            this.pnlCajas.Controls.Add(this.label3);
            this.pnlCajas.Location = new System.Drawing.Point(11, 142);
            this.pnlCajas.Name = "pnlCajas";
            this.pnlCajas.Size = new System.Drawing.Size(506, 118);
            this.pnlCajas.TabIndex = 24;
            // 
            // cboAgenciaSucursal
            // 
            this.cboAgenciaSucursal.FormattingEnabled = true;
            this.cboAgenciaSucursal.Location = new System.Drawing.Point(314, 57);
            this.cboAgenciaSucursal.Name = "cboAgenciaSucursal";
            this.cboAgenciaSucursal.Size = new System.Drawing.Size(177, 21);
            this.cboAgenciaSucursal.TabIndex = 7;
            this.cboAgenciaSucursal.Leave += new System.EventHandler(this.cboAgenciaSucursal_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(264, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Agencia";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Estado";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Location = new System.Drawing.Point(314, 3);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(177, 20);
            this.txtBarrio.TabIndex = 5;
            this.txtBarrio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarrio_KeyPress);
            this.txtBarrio.Leave += new System.EventHandler(this.txtBarrio_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(264, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Barrio";
            // 
            // cboCiudad
            // 
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(72, 83);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(177, 21);
            this.cboCiudad.TabIndex = 4;
            this.cboCiudad.Enter += new System.EventHandler(this.cboCiudad_Enter);
            this.cboCiudad.Leave += new System.EventHandler(this.cboCiudad_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Ciudad";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(72, 56);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(177, 21);
            this.cboDepartamento.TabIndex = 3;
            this.cboDepartamento.Enter += new System.EventHandler(this.cboDepartamento_Enter);
            this.cboDepartamento.Leave += new System.EventHandler(this.cboDepartamento_Leave);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.bttnCancelar);
            this.panel3.Controls.Add(this.bttnBuscar);
            this.panel3.Controls.Add(this.bttnSalir);
            this.panel3.Controls.Add(this.bttnGuardar);
            this.panel3.Controls.Add(this.bttnAdicionar);
            this.panel3.Location = new System.Drawing.Point(11, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 43);
            this.panel3.TabIndex = 25;
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(254, 4);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 33);
            this.bttnCancelar.TabIndex = 16;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(335, 3);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 15;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(416, 3);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 14;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(172, 3);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 0;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(91, 3);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 12;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(314, 84);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(177, 21);
            this.cboEstado.TabIndex = 31;
            this.cboEstado.Leave += new System.EventHandler(this.cboEstado_Leave);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 319);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlCajas);
            this.Controls.Add(this.pnlCajasEncabezado);
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmClientes_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientes_KeyDown);
            this.pnlCajasEncabezado.ResumeLayout(false);
            this.pnlCajasEncabezado.PerformLayout();
            this.pnlCajas.ResumeLayout(false);
            this.pnlCajas.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlCajasEncabezado;
        private System.Windows.Forms.Panel pnlCajas;
        private System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.ComboBox cboAgenciaSucursal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboEstado;
    }
}