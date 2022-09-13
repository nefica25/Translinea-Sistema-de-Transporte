namespace TranslineaN
{
    partial class frmAsignarBus
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
            this.DtgPuestos = new System.Windows.Forms.DataGridView();
            this.DtgPuestosAsignar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumRuta = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnImprimir = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.bttnPasarTodos = new System.Windows.Forms.Button();
            this.bttnPasar = new System.Windows.Forms.Button();
            this.btnDevolverTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPuestosAsignar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgPuestos
            // 
            this.DtgPuestos.BackgroundColor = System.Drawing.Color.White;
            this.DtgPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgPuestos.Location = new System.Drawing.Point(12, 112);
            this.DtgPuestos.Name = "DtgPuestos";
            this.DtgPuestos.Size = new System.Drawing.Size(235, 332);
            this.DtgPuestos.TabIndex = 0;
            this.DtgPuestos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DtgPuestos_CellFormatting);
            // 
            // DtgPuestosAsignar
            // 
            this.DtgPuestosAsignar.BackgroundColor = System.Drawing.Color.White;
            this.DtgPuestosAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgPuestosAsignar.Location = new System.Drawing.Point(297, 112);
            this.DtgPuestosAsignar.Name = "DtgPuestosAsignar";
            this.DtgPuestosAsignar.Size = new System.Drawing.Size(235, 335);
            this.DtgPuestosAsignar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id Ruta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vehiculo";
            // 
            // txtNumRuta
            // 
            this.txtNumRuta.Location = new System.Drawing.Point(56, 10);
            this.txtNumRuta.Name = "txtNumRuta";
            this.txtNumRuta.Size = new System.Drawing.Size(176, 20);
            this.txtNumRuta.TabIndex = 5;
            this.txtNumRuta.Leave += new System.EventHandler(this.txtNumRuta_Leave);
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.Location = new System.Drawing.Point(329, 9);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(179, 20);
            this.txtFecha.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vehiculo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hora";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fecha";
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.Color.White;
            this.txtHora.Location = new System.Drawing.Point(330, 35);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(178, 20);
            this.txtHora.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtDestino);
            this.panel1.Controls.Add(this.cboVehiculo);
            this.panel1.Controls.Add(this.txtHora);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtVehiculo);
            this.panel1.Controls.Add(this.txtNumRuta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 94);
            this.panel1.TabIndex = 15;
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.White;
            this.txtDestino.Location = new System.Drawing.Point(57, 35);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(176, 20);
            this.txtDestino.TabIndex = 16;
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(330, 61);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(178, 21);
            this.cboVehiculo.TabIndex = 15;
            this.cboVehiculo.Enter += new System.EventHandler(this.cboVehiculo_Enter);
            this.cboVehiculo.Leave += new System.EventHandler(this.cboVehiculo_Leave);
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.BackColor = System.Drawing.Color.White;
            this.txtVehiculo.Location = new System.Drawing.Point(57, 61);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.ReadOnly = true;
            this.txtVehiculo.Size = new System.Drawing.Size(176, 20);
            this.txtVehiculo.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.bttnBuscar);
            this.panel7.Controls.Add(this.bttnImprimir);
            this.panel7.Controls.Add(this.bttnSalir);
            this.panel7.Controls.Add(this.bttnGuardar);
            this.panel7.Controls.Add(this.bttnAdicionar);
            this.panel7.Location = new System.Drawing.Point(12, 453);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(521, 49);
            this.panel7.TabIndex = 24;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(273, 7);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 15;
            this.bttnBuscar.Text = "&Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
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
            this.bttnGuardar.Location = new System.Drawing.Point(192, 7);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 12;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            this.bttnGuardar.Click += new System.EventHandler(this.bttnGuardar_Click);
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(111, 7);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 11;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            this.bttnAdicionar.Click += new System.EventHandler(this.bttnAdicionar_Click);
            // 
            // bttnPasarTodos
            // 
            this.bttnPasarTodos.Location = new System.Drawing.Point(253, 193);
            this.bttnPasarTodos.Name = "bttnPasarTodos";
            this.bttnPasarTodos.Size = new System.Drawing.Size(38, 23);
            this.bttnPasarTodos.TabIndex = 25;
            this.bttnPasarTodos.Text = ">>";
            this.bttnPasarTodos.UseVisualStyleBackColor = true;
            this.bttnPasarTodos.Click += new System.EventHandler(this.bttnPasarTodos_Click);
            // 
            // bttnPasar
            // 
            this.bttnPasar.Location = new System.Drawing.Point(253, 222);
            this.bttnPasar.Name = "bttnPasar";
            this.bttnPasar.Size = new System.Drawing.Size(38, 23);
            this.bttnPasar.TabIndex = 26;
            this.bttnPasar.Text = ">";
            this.bttnPasar.UseVisualStyleBackColor = true;
            this.bttnPasar.Click += new System.EventHandler(this.bttnPasar_Click);
            // 
            // btnDevolverTodos
            // 
            this.btnDevolverTodos.Location = new System.Drawing.Point(253, 251);
            this.btnDevolverTodos.Name = "btnDevolverTodos";
            this.btnDevolverTodos.Size = new System.Drawing.Size(38, 23);
            this.btnDevolverTodos.TabIndex = 27;
            this.btnDevolverTodos.Text = "<<";
            this.btnDevolverTodos.UseVisualStyleBackColor = true;
            this.btnDevolverTodos.Click += new System.EventHandler(this.btnDevolverTodos_Click);
            // 
            // frmAsignarBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 508);
            this.Controls.Add(this.btnDevolverTodos);
            this.Controls.Add(this.bttnPasar);
            this.Controls.Add(this.bttnPasarTodos);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgPuestosAsignar);
            this.Controls.Add(this.DtgPuestos);
            this.Name = "frmAsignarBus";
            this.Text = "Parque Automotor";
            this.Load += new System.EventHandler(this.frmAsignarBus_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAsignarBus_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmAsignarBus_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.DtgPuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPuestosAsignar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgPuestos;
        private System.Windows.Forms.DataGridView DtgPuestosAsignar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumRuta;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnImprimir;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
        private System.Windows.Forms.Button bttnPasarTodos;
        private System.Windows.Forms.Button bttnPasar;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnDevolverTodos;
        private System.Windows.Forms.TextBox txtVehiculo;
    }
}