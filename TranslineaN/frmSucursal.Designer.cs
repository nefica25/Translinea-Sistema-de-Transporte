namespace TranslineaN
{
    partial class frmSucursal
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
            this.cboAgencia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.DtgSucursal = new System.Windows.Forms.DataGridView();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAbrev = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBarrio = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.DtgSucursal)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlCajas.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agencia";
            // 
            // cboAgencia
            // 
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(74, 35);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(226, 21);
            this.cboAgencia.TabIndex = 1;
            this.cboAgencia.Leave += new System.EventHandler(this.cboAgencia_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sucursal";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(74, 63);
            this.txtSucursal.MaxLength = 70;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(226, 20);
            this.txtSucursal.TabIndex = 3;
            this.txtSucursal.Leave += new System.EventHandler(this.txtSucursal_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(74, 9);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(226, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DtgSucursal
            // 
            this.DtgSucursal.BackgroundColor = System.Drawing.Color.White;
            this.DtgSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgSucursal.Location = new System.Drawing.Point(12, 192);
            this.DtgSucursal.Name = "DtgSucursal";
            this.DtgSucursal.Size = new System.Drawing.Size(577, 154);
            this.DtgSucursal.TabIndex = 6;
            this.DtgSucursal.SelectionChanged += new System.EventHandler(this.DtgSucursal_SelectionChanged);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.bttnCancelar);
            this.pnlBotones.Controls.Add(this.bttnBuscar);
            this.pnlBotones.Controls.Add(this.bttnSalir);
            this.pnlBotones.Controls.Add(this.bttnGuardar);
            this.pnlBotones.Controls.Add(this.bttnAdicionar);
            this.pnlBotones.Location = new System.Drawing.Point(12, 352);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(576, 43);
            this.pnlBotones.TabIndex = 7;
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(333, 4);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 33);
            this.bttnCancelar.TabIndex = 8;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(412, 4);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 6;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bbtnBuscar_Click);
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
            this.bttnGuardar.Location = new System.Drawing.Point(256, 4);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 4;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(175, 4);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 3;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Abreviatura";
            // 
            // txtAbrev
            // 
            this.txtAbrev.Location = new System.Drawing.Point(382, 63);
            this.txtAbrev.MaxLength = 12;
            this.txtAbrev.Name = "txtAbrev";
            this.txtAbrev.Size = new System.Drawing.Size(178, 20);
            this.txtAbrev.TabIndex = 4;
            this.txtAbrev.Leave += new System.EventHandler(this.txtAbrev_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ciudad";
            // 
            // cboCiudad
            // 
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(74, 118);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(226, 21);
            this.cboCiudad.TabIndex = 7;
            this.cboCiudad.Enter += new System.EventHandler(this.cboCiudad_Enter);
            this.cboCiudad.Leave += new System.EventHandler(this.cboCiudad_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Barrio";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Location = new System.Drawing.Point(382, 118);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(178, 20);
            this.txtBarrio.TabIndex = 8;
            this.txtBarrio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarrio_KeyPress);
            this.txtBarrio.Leave += new System.EventHandler(this.txtBarrio_Leave);
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
            this.pnlCajas.Controls.Add(this.txtSucursal);
            this.pnlCajas.Controls.Add(this.label2);
            this.pnlCajas.Controls.Add(this.cboAgencia);
            this.pnlCajas.Controls.Add(this.label1);
            this.pnlCajas.Location = new System.Drawing.Point(12, 10);
            this.pnlCajas.Name = "pnlCajas";
            this.pnlCajas.Size = new System.Drawing.Size(576, 176);
            this.pnlCajas.TabIndex = 14;
            // 
            // cboTipoSucursal
            // 
            this.cboTipoSucursal.FormattingEnabled = true;
            this.cboTipoSucursal.Location = new System.Drawing.Point(382, 35);
            this.cboTipoSucursal.Name = "cboTipoSucursal";
            this.cboTipoSucursal.Size = new System.Drawing.Size(178, 21);
            this.cboTipoSucursal.TabIndex = 2;
            this.cboTipoSucursal.Leave += new System.EventHandler(this.cboTipoSucursal_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tipo ";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(382, 147);
            this.txtTelefono.MaxLength = 12;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(178, 20);
            this.txtTelefono.TabIndex = 10;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Telefono";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(74, 147);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(226, 20);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Dirección";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(382, 91);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(178, 21);
            this.cboDepartamento.TabIndex = 6;
            this.cboDepartamento.Enter += new System.EventHandler(this.cboDepartamento_Enter);
            this.cboDepartamento.Leave += new System.EventHandler(this.cboDepartamento_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Departam.";
            // 
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(74, 89);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(226, 21);
            this.cboPais.TabIndex = 5;
            this.cboPais.Leave += new System.EventHandler(this.cboPais_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pais";
            // 
            // frmSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 406);
            this.Controls.Add(this.pnlCajas);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.DtgSucursal);
            this.Name = "frmSucursal";
            this.Text = "frmSucursal";
            this.Load += new System.EventHandler(this.frmSucursal_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSucursal_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSucursal_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgSucursal)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlCajas.ResumeLayout(false);
            this.pnlCajas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAgencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView DtgSucursal;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAbrev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Panel pnlCajas;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.ComboBox cboTipoSucursal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bttnCancelar;
    }
}