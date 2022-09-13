namespace TranslineaN
{
    partial class frmCiudadRecorrido
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
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecorrido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorTiquete = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEstam = new System.Windows.Forms.CheckBox();
            this.DtgRecorrido = new System.Windows.Forms.DataGridView();
            this.pnlCajas = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.bttnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRecorrido)).BeginInit();
            this.pnlCajas.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciudad Origen";
            // 
            // cboOrigen
            // 
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(88, 13);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(175, 21);
            this.cboOrigen.TabIndex = 1;
            this.cboOrigen.SelectedValueChanged += new System.EventHandler(this.cboOrigen_SelectedValueChanged);
            this.cboOrigen.Leave += new System.EventHandler(this.cboOrigen_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciudad Destino";
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(361, 12);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(193, 21);
            this.cboDestino.TabIndex = 3;
            this.cboDestino.Enter += new System.EventHandler(this.cboDestino_Enter);
            this.cboDestino.Leave += new System.EventHandler(this.cboDestino_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Recorrido";
            // 
            // txtRecorrido
            // 
            this.txtRecorrido.Location = new System.Drawing.Point(88, 40);
            this.txtRecorrido.Name = "txtRecorrido";
            this.txtRecorrido.Size = new System.Drawing.Size(175, 20);
            this.txtRecorrido.TabIndex = 5;
            this.txtRecorrido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecorrido_KeyPress);
            this.txtRecorrido.Leave += new System.EventHandler(this.txtRecorrido_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Valor Tiquete";
            // 
            // txtValorTiquete
            // 
            this.txtValorTiquete.Location = new System.Drawing.Point(361, 39);
            this.txtValorTiquete.Name = "txtValorTiquete";
            this.txtValorTiquete.Size = new System.Drawing.Size(113, 20);
            this.txtValorTiquete.TabIndex = 7;
            this.txtValorTiquete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorTiquete_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estampilla";
            // 
            // chkEstam
            // 
            this.chkEstam.AutoSize = true;
            this.chkEstam.Location = new System.Drawing.Point(540, 43);
            this.chkEstam.Name = "chkEstam";
            this.chkEstam.Size = new System.Drawing.Size(15, 14);
            this.chkEstam.TabIndex = 9;
            this.chkEstam.UseVisualStyleBackColor = true;
            // 
            // DtgRecorrido
            // 
            this.DtgRecorrido.BackgroundColor = System.Drawing.Color.White;
            this.DtgRecorrido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRecorrido.Location = new System.Drawing.Point(12, 90);
            this.DtgRecorrido.Name = "DtgRecorrido";
            this.DtgRecorrido.Size = new System.Drawing.Size(565, 412);
            this.DtgRecorrido.TabIndex = 10;
            // 
            // pnlCajas
            // 
            this.pnlCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCajas.Controls.Add(this.chkEstam);
            this.pnlCajas.Controls.Add(this.label5);
            this.pnlCajas.Controls.Add(this.txtValorTiquete);
            this.pnlCajas.Controls.Add(this.label4);
            this.pnlCajas.Controls.Add(this.txtRecorrido);
            this.pnlCajas.Controls.Add(this.label3);
            this.pnlCajas.Controls.Add(this.cboDestino);
            this.pnlCajas.Controls.Add(this.label2);
            this.pnlCajas.Controls.Add(this.cboOrigen);
            this.pnlCajas.Controls.Add(this.label1);
            this.pnlCajas.Location = new System.Drawing.Point(12, 11);
            this.pnlCajas.Name = "pnlCajas";
            this.pnlCajas.Size = new System.Drawing.Size(565, 73);
            this.pnlCajas.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bttnCancelar);
            this.panel2.Controls.Add(this.bttnBuscar);
            this.panel2.Controls.Add(this.bttnSalir);
            this.panel2.Controls.Add(this.bttnGuardar);
            this.panel2.Controls.Add(this.bttnAdicionar);
            this.panel2.Location = new System.Drawing.Point(12, 508);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 43);
            this.panel2.TabIndex = 12;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(401, 4);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 10;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bbtnBuscar_Click);
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(482, 4);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 9;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            this.bttnSalir.Click += new System.EventHandler(this.bttnSalir_Click);
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(238, 4);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 8;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(157, 4);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 7;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(320, 5);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 33);
            this.bttnCancelar.TabIndex = 11;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // frmCiudadRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 563);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlCajas);
            this.Controls.Add(this.DtgRecorrido);
            this.Name = "frmCiudadRecorrido";
            this.Text = "frmRecorrido";
            this.Load += new System.EventHandler(this.frmCiudadRecorrido_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCiudadRecorrido_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCiudadRecorrido_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRecorrido)).EndInit();
            this.pnlCajas.ResumeLayout(false);
            this.pnlCajas.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecorrido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorTiquete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEstam;
        private System.Windows.Forms.DataGridView DtgRecorrido;
        private System.Windows.Forms.Panel pnlCajas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Button bttnCancelar;
    }
}