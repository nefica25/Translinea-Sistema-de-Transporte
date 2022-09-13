namespace TranslineaN
{
    partial class frmRemesas
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
            this.DtgRemesas = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecorrido = new System.Windows.Forms.ComboBox();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCajas1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnImprimir = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.pnlOrigen = new System.Windows.Forms.Panel();
            this.txtTelOrig = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDireccionOrig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombresOrig = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocumentoOrig = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlDestino = new System.Windows.Forms.Panel();
            this.txtTelDest = new System.Windows.Forms.TextBox();
            this.txtNombresDest = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDireccionDest = new System.Windows.Forms.TextBox();
            this.txtDocumentoDest = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.cboTipoRemesa = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlPrecios = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtValorFlete = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtReex = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumPiezas = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bttnAgregar = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtValorSeguro = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRemesas)).BeginInit();
            this.pnlCajas1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlOrigen.SuspendLayout();
            this.pnlDestino.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlPrecios.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // DtgRemesas
            // 
            this.DtgRemesas.BackgroundColor = System.Drawing.Color.White;
            this.DtgRemesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRemesas.Location = new System.Drawing.Point(12, 270);
            this.DtgRemesas.Name = "DtgRemesas";
            this.DtgRemesas.Size = new System.Drawing.Size(760, 143);
            this.DtgRemesas.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(70, 11);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(253, 20);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.Text = "0";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destino";
            // 
            // cboRecorrido
            // 
            this.cboRecorrido.FormattingEnabled = true;
            this.cboRecorrido.Location = new System.Drawing.Point(396, 38);
            this.cboRecorrido.Name = "cboRecorrido";
            this.cboRecorrido.Size = new System.Drawing.Size(234, 21);
            this.cboRecorrido.TabIndex = 4;
            this.cboRecorrido.Leave += new System.EventHandler(this.cboTipo_Leave);
            // 
            // cboOrigen
            // 
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(70, 37);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(253, 21);
            this.cboOrigen.TabIndex = 6;
            this.cboOrigen.Leave += new System.EventHandler(this.cboOrigen_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Origen";
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(396, 11);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(234, 21);
            this.cboDestino.TabIndex = 8;
            this.cboDestino.SelectedValueChanged += new System.EventHandler(this.cboDestino_SelectedValueChanged);
            this.cboDestino.Leave += new System.EventHandler(this.cboDestino_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Recorrido";
            // 
            // pnlCajas1
            // 
            this.pnlCajas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajas1.Controls.Add(this.cboDestino);
            this.pnlCajas1.Controls.Add(this.label4);
            this.pnlCajas1.Controls.Add(this.cboOrigen);
            this.pnlCajas1.Controls.Add(this.label3);
            this.pnlCajas1.Controls.Add(this.cboRecorrido);
            this.pnlCajas1.Controls.Add(this.label2);
            this.pnlCajas1.Controls.Add(this.txtCodigo);
            this.pnlCajas1.Controls.Add(this.label1);
            this.pnlCajas1.Location = new System.Drawing.Point(12, 10);
            this.pnlCajas1.Name = "pnlCajas1";
            this.pnlCajas1.Size = new System.Drawing.Size(652, 69);
            this.pnlCajas1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.bttnCancelar);
            this.panel3.Controls.Add(this.bttnBuscar);
            this.panel3.Controls.Add(this.bttnImprimir);
            this.panel3.Controls.Add(this.bttnSalir);
            this.panel3.Controls.Add(this.bttnGuardar);
            this.panel3.Controls.Add(this.bttnAdicionar);
            this.panel3.Location = new System.Drawing.Point(12, 417);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 49);
            this.panel3.TabIndex = 22;
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(433, 7);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 33);
            this.bttnCancelar.TabIndex = 11;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(514, 7);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 10;
            this.bttnBuscar.Text = "&Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // bttnImprimir
            // 
            this.bttnImprimir.Location = new System.Drawing.Point(593, 7);
            this.bttnImprimir.Name = "bttnImprimir";
            this.bttnImprimir.Size = new System.Drawing.Size(75, 33);
            this.bttnImprimir.TabIndex = 6;
            this.bttnImprimir.Text = "&Imprimir";
            this.bttnImprimir.UseVisualStyleBackColor = true;
            this.bttnImprimir.Click += new System.EventHandler(this.bttnImprimir_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(674, 7);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 5;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(352, 7);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 4;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(271, 7);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 3;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // pnlOrigen
            // 
            this.pnlOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrigen.Controls.Add(this.txtTelOrig);
            this.pnlOrigen.Controls.Add(this.label8);
            this.pnlOrigen.Controls.Add(this.txtDireccionOrig);
            this.pnlOrigen.Controls.Add(this.label7);
            this.pnlOrigen.Controls.Add(this.txtNombresOrig);
            this.pnlOrigen.Controls.Add(this.label6);
            this.pnlOrigen.Controls.Add(this.txtDocumentoOrig);
            this.pnlOrigen.Controls.Add(this.label5);
            this.pnlOrigen.Location = new System.Drawing.Point(12, 85);
            this.pnlOrigen.Name = "pnlOrigen";
            this.pnlOrigen.Size = new System.Drawing.Size(328, 115);
            this.pnlOrigen.TabIndex = 23;
            // 
            // txtTelOrig
            // 
            this.txtTelOrig.Location = new System.Drawing.Point(70, 82);
            this.txtTelOrig.Name = "txtTelOrig";
            this.txtTelOrig.Size = new System.Drawing.Size(241, 20);
            this.txtTelOrig.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Telefono";
            // 
            // txtDireccionOrig
            // 
            this.txtDireccionOrig.Location = new System.Drawing.Point(70, 56);
            this.txtDireccionOrig.Name = "txtDireccionOrig";
            this.txtDireccionOrig.Size = new System.Drawing.Size(241, 20);
            this.txtDireccionOrig.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Direccion";
            // 
            // txtNombresOrig
            // 
            this.txtNombresOrig.Location = new System.Drawing.Point(70, 30);
            this.txtNombresOrig.Name = "txtNombresOrig";
            this.txtNombresOrig.Size = new System.Drawing.Size(241, 20);
            this.txtNombresOrig.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombres";
            // 
            // txtDocumentoOrig
            // 
            this.txtDocumentoOrig.Location = new System.Drawing.Point(70, 4);
            this.txtDocumentoOrig.Name = "txtDocumentoOrig";
            this.txtDocumentoOrig.Size = new System.Drawing.Size(241, 20);
            this.txtDocumentoOrig.TabIndex = 10;
            this.txtDocumentoOrig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumentoOrig_KeyPress);
            this.txtDocumentoOrig.Leave += new System.EventHandler(this.txtDocumentoOrig_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Documento";
            // 
            // pnlDestino
            // 
            this.pnlDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDestino.Controls.Add(this.txtTelDest);
            this.pnlDestino.Controls.Add(this.txtNombresDest);
            this.pnlDestino.Controls.Add(this.label9);
            this.pnlDestino.Controls.Add(this.label12);
            this.pnlDestino.Controls.Add(this.txtDireccionDest);
            this.pnlDestino.Controls.Add(this.txtDocumentoDest);
            this.pnlDestino.Controls.Add(this.label10);
            this.pnlDestino.Controls.Add(this.label11);
            this.pnlDestino.Location = new System.Drawing.Point(345, 85);
            this.pnlDestino.Name = "pnlDestino";
            this.pnlDestino.Size = new System.Drawing.Size(320, 115);
            this.pnlDestino.TabIndex = 24;
            // 
            // txtTelDest
            // 
            this.txtTelDest.Location = new System.Drawing.Point(69, 85);
            this.txtTelDest.Name = "txtTelDest";
            this.txtTelDest.Size = new System.Drawing.Size(241, 20);
            this.txtTelDest.TabIndex = 24;
            this.txtTelDest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelDest_KeyPress);
            // 
            // txtNombresDest
            // 
            this.txtNombresDest.Location = new System.Drawing.Point(69, 33);
            this.txtNombresDest.Name = "txtNombresDest";
            this.txtNombresDest.Size = new System.Drawing.Size(241, 20);
            this.txtNombresDest.TabIndex = 20;
            this.txtNombresDest.Leave += new System.EventHandler(this.txtNombresDest_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Telefono";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Documento";
            // 
            // txtDireccionDest
            // 
            this.txtDireccionDest.Location = new System.Drawing.Point(69, 59);
            this.txtDireccionDest.Name = "txtDireccionDest";
            this.txtDireccionDest.Size = new System.Drawing.Size(241, 20);
            this.txtDireccionDest.TabIndex = 22;
            this.txtDireccionDest.Leave += new System.EventHandler(this.txtDireccionDest_Leave);
            // 
            // txtDocumentoDest
            // 
            this.txtDocumentoDest.Location = new System.Drawing.Point(69, 7);
            this.txtDocumentoDest.Name = "txtDocumentoDest";
            this.txtDocumentoDest.Size = new System.Drawing.Size(241, 20);
            this.txtDocumentoDest.TabIndex = 18;
            this.txtDocumentoDest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumentoDest_KeyPress);
            this.txtDocumentoDest.Leave += new System.EventHandler(this.txtDocumentoDest_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Direccion";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Nombres";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenido.Controls.Add(this.bttnAgregar);
            this.pnlContenido.Controls.Add(this.DtpFecha);
            this.pnlContenido.Controls.Add(this.label22);
            this.pnlContenido.Controls.Add(this.cboTipo);
            this.pnlContenido.Controls.Add(this.label21);
            this.pnlContenido.Controls.Add(this.cboTipoRemesa);
            this.pnlContenido.Controls.Add(this.label14);
            this.pnlContenido.Controls.Add(this.txtContenido);
            this.pnlContenido.Controls.Add(this.label13);
            this.pnlContenido.Location = new System.Drawing.Point(12, 205);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(653, 61);
            this.pnlContenido.TabIndex = 25;
            // 
            // cboTipoRemesa
            // 
            this.cboTipoRemesa.FormattingEnabled = true;
            this.cboTipoRemesa.Location = new System.Drawing.Point(68, 5);
            this.cboTipoRemesa.Name = "cboTipoRemesa";
            this.cboTipoRemesa.Size = new System.Drawing.Size(243, 21);
            this.cboTipoRemesa.TabIndex = 10;
            this.cboTipoRemesa.Leave += new System.EventHandler(this.cboTipoRemesa_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Tipo Rem.";
            // 
            // txtContenido
            // 
            this.txtContenido.Location = new System.Drawing.Point(402, 5);
            this.txtContenido.MaxLength = 80;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(241, 20);
            this.txtContenido.TabIndex = 18;
            this.txtContenido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContenido_KeyPress);
            this.txtContenido.Leave += new System.EventHandler(this.txtContenido_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(337, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Contenido";
            // 
            // pnlPrecios
            // 
            this.pnlPrecios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPrecios.Controls.Add(this.txtValorSeguro);
            this.pnlPrecios.Controls.Add(this.label23);
            this.pnlPrecios.Controls.Add(this.label20);
            this.pnlPrecios.Controls.Add(this.txtValorTotal);
            this.pnlPrecios.Controls.Add(this.txtValorFlete);
            this.pnlPrecios.Controls.Add(this.label19);
            this.pnlPrecios.Controls.Add(this.txtReex);
            this.pnlPrecios.Controls.Add(this.label17);
            this.pnlPrecios.Controls.Add(this.txtPeso);
            this.pnlPrecios.Controls.Add(this.label18);
            this.pnlPrecios.Controls.Add(this.txtNumPiezas);
            this.pnlPrecios.Controls.Add(this.label16);
            this.pnlPrecios.Controls.Add(this.txtSeguro);
            this.pnlPrecios.Controls.Add(this.label15);
            this.pnlPrecios.Location = new System.Drawing.Point(670, 10);
            this.pnlPrecios.Name = "pnlPrecios";
            this.pnlPrecios.Size = new System.Drawing.Size(102, 256);
            this.pnlPrecios.TabIndex = 41;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(15, 216);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "Valor Total";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(9, 229);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(81, 20);
            this.txtValorTotal.TabIndex = 51;
            this.txtValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorTotal_KeyPress);
            // 
            // txtValorFlete
            // 
            this.txtValorFlete.Location = new System.Drawing.Point(9, 192);
            this.txtValorFlete.Name = "txtValorFlete";
            this.txtValorFlete.Size = new System.Drawing.Size(81, 20);
            this.txtValorFlete.TabIndex = 50;
            this.txtValorFlete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorFlete_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 180);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "Valor Flete";
            // 
            // txtReex
            // 
            this.txtReex.Location = new System.Drawing.Point(9, 156);
            this.txtReex.Name = "txtReex";
            this.txtReex.Size = new System.Drawing.Size(81, 20);
            this.txtReex.TabIndex = 46;
            this.txtReex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReex_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(34, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Reex";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(8, 17);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(81, 20);
            this.txtPeso.TabIndex = 48;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 47;
            this.label18.Text = "Peso";
            // 
            // txtNumPiezas
            // 
            this.txtNumPiezas.Location = new System.Drawing.Point(10, 121);
            this.txtNumPiezas.Name = "txtNumPiezas";
            this.txtNumPiezas.Size = new System.Drawing.Size(80, 20);
            this.txtNumPiezas.TabIndex = 44;
            this.txtNumPiezas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPiezas_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Piezas";
            // 
            // txtSeguro
            // 
            this.txtSeguro.Location = new System.Drawing.Point(9, 86);
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(81, 20);
            this.txtSeguro.TabIndex = 42;
            this.txtSeguro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguro_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Seguro";
            // 
            // bttnAgregar
            // 
            this.bttnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnAgregar.ForeColor = System.Drawing.Color.Blue;
            this.bttnAgregar.Location = new System.Drawing.Point(567, 30);
            this.bttnAgregar.Name = "bttnAgregar";
            this.bttnAgregar.Size = new System.Drawing.Size(76, 23);
            this.bttnAgregar.TabIndex = 53;
            this.bttnAgregar.Text = "Agregar";
            this.bttnAgregar.UseVisualStyleBackColor = true;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(68, 32);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(243, 21);
            this.cboTipo.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "Tipo";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(337, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 13);
            this.label22.TabIndex = 21;
            this.label22.Text = "Fecha";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(402, 32);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(159, 20);
            this.DtpFecha.TabIndex = 22;
            // 
            // txtValorSeguro
            // 
            this.txtValorSeguro.Location = new System.Drawing.Point(9, 52);
            this.txtValorSeguro.Name = "txtValorSeguro";
            this.txtValorSeguro.Size = new System.Drawing.Size(81, 20);
            this.txtValorSeguro.TabIndex = 54;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 13);
            this.label23.TabIndex = 53;
            this.label23.Text = "Valor Seguro";
            // 
            // frmRemesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 474);
            this.Controls.Add(this.pnlPrecios);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlDestino);
            this.Controls.Add(this.pnlOrigen);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlCajas1);
            this.Controls.Add(this.DtgRemesas);
            this.Name = "frmRemesas";
            this.Text = "frmRemesas";
            this.Load += new System.EventHandler(this.frmRemesas_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRemesas_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRemesas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRemesas)).EndInit();
            this.pnlCajas1.ResumeLayout(false);
            this.pnlCajas1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlOrigen.ResumeLayout(false);
            this.pnlOrigen.PerformLayout();
            this.pnlDestino.ResumeLayout(false);
            this.pnlDestino.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlPrecios.ResumeLayout(false);
            this.pnlPrecios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtgRemesas;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecorrido;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCajas1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnImprimir;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Panel pnlOrigen;
        private System.Windows.Forms.Panel pnlDestino;
        private System.Windows.Forms.TextBox txtNombresOrig;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDocumentoOrig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelOrig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDireccionOrig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelDest;
        private System.Windows.Forms.TextBox txtNombresDest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDireccionDest;
        private System.Windows.Forms.TextBox txtDocumentoDest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTipoRemesa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlPrecios;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.TextBox txtValorFlete;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtReex;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNumPiezas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button bttnAgregar;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtValorSeguro;
        private System.Windows.Forms.Label label23;
    }
}