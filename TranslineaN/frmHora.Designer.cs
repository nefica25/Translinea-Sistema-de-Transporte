namespace TranslineaN
{
    partial class frmHora
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
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.DtgHora = new System.Windows.Forms.DataGridView();
            this.pnlCajas = new System.Windows.Forms.Panel();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgHora)).BeginInit();
            this.pnlCajas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotones.Controls.Add(this.bttnCancelar);
            this.pnlBotones.Controls.Add(this.bttnBuscar);
            this.pnlBotones.Controls.Add(this.bttnSalir);
            this.pnlBotones.Controls.Add(this.bttnGuardar);
            this.pnlBotones.Controls.Add(this.bttnAdicionar);
            this.pnlBotones.Location = new System.Drawing.Point(10, 365);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(341, 43);
            this.pnlBotones.TabIndex = 17;
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
            // DtgHora
            // 
            this.DtgHora.BackgroundColor = System.Drawing.Color.White;
            this.DtgHora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgHora.Location = new System.Drawing.Point(10, 101);
            this.DtgHora.Name = "DtgHora";
            this.DtgHora.Size = new System.Drawing.Size(341, 260);
            this.DtgHora.TabIndex = 16;
            this.DtgHora.SelectionChanged += new System.EventHandler(this.DtgHora_SelectionChanged);
            // 
            // pnlCajas
            // 
            this.pnlCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajas.Controls.Add(this.cboEstado);
            this.pnlCajas.Controls.Add(this.label7);
            this.pnlCajas.Controls.Add(this.txtHora);
            this.pnlCajas.Controls.Add(this.label8);
            this.pnlCajas.Controls.Add(this.txtCodigo);
            this.pnlCajas.Controls.Add(this.label1);
            this.pnlCajas.Location = new System.Drawing.Point(10, 9);
            this.pnlCajas.Name = "pnlCajas";
            this.pnlCajas.Size = new System.Drawing.Size(341, 88);
            this.pnlCajas.TabIndex = 15;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(58, 58);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(271, 21);
            this.cboEstado.TabIndex = 3;
            this.cboEstado.Enter += new System.EventHandler(this.cboEstado_Enter);
            this.cboEstado.Leave += new System.EventHandler(this.cboEstado_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estado";
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(58, 32);
            this.txtHora.MaxLength = 10;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(269, 20);
            this.txtHora.TabIndex = 2;
            this.txtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHora_KeyPress);
            this.txtHora.Leave += new System.EventHandler(this.txtHora_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Hora";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Location = new System.Drawing.Point(58, 6);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(269, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // frmHora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 417);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.DtgHora);
            this.Controls.Add(this.pnlCajas);
            this.Name = "frmHora";
            this.Text = "frmHora";
            this.Load += new System.EventHandler(this.frmHora_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHora_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHora_KeyDown);
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgHora)).EndInit();
            this.pnlCajas.ResumeLayout(false);
            this.pnlCajas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.DataGridView DtgHora;
        private System.Windows.Forms.Panel pnlCajas;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
    }
}