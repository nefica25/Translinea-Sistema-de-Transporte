namespace TranslineaN
{
    partial class frmRutaProceso
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHora = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.bttnGuardar = new System.Windows.Forms.Button();
            this.bttnAdicionar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "En este formulario, vamos a actualizar Rutas o eliminarlas, o dejarlas en un esta" +
                "do suspendidas por tiempos o aplazado el viaje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IdRuta";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Destino";
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(288, 36);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(159, 21);
            this.cboDestino.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora";
            // 
            // cboHora
            // 
            this.cboHora.FormattingEnabled = true;
            this.cboHora.Location = new System.Drawing.Point(67, 62);
            this.cboHora.Name = "cboHora";
            this.cboHora.Size = new System.Drawing.Size(163, 21);
            this.cboHora.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cboOrigen);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboHora);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboEstado);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboDestino);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 98);
            this.panel1.TabIndex = 9;
            // 
            // cboOrigen
            // 
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(67, 35);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(163, 21);
            this.cboOrigen.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Origen";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(288, 62);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(159, 21);
            this.cboEstado.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Estado";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(69, 37);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(382, 20);
            this.txtObservacion.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Observ.";
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(69, 10);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(159, 21);
            this.cboVehiculo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Vehic.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(290, 10);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(159, 20);
            this.txtValor.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cboVehiculo);
            this.panel2.Controls.Add(this.txtValor);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtObservacion);
            this.panel2.Location = new System.Drawing.Point(10, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 69);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.bttnCancelar);
            this.panel3.Controls.Add(this.bttnBuscar);
            this.panel3.Controls.Add(this.bttnSalir);
            this.panel3.Controls.Add(this.bttnGuardar);
            this.panel3.Controls.Add(this.bttnAdicionar);
            this.panel3.Location = new System.Drawing.Point(10, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(464, 43);
            this.panel3.TabIndex = 26;
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(218, 4);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 33);
            this.bttnCancelar.TabIndex = 16;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(299, 3);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(75, 33);
            this.bttnBuscar.TabIndex = 15;
            this.bttnBuscar.Text = "Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(380, 3);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 33);
            this.bttnSalir.TabIndex = 14;
            this.bttnSalir.Text = "&Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            // 
            // bttnGuardar
            // 
            this.bttnGuardar.Location = new System.Drawing.Point(136, 3);
            this.bttnGuardar.Name = "bttnGuardar";
            this.bttnGuardar.Size = new System.Drawing.Size(75, 33);
            this.bttnGuardar.TabIndex = 0;
            this.bttnGuardar.Text = "&Guardar";
            this.bttnGuardar.UseVisualStyleBackColor = true;
            // 
            // bttnAdicionar
            // 
            this.bttnAdicionar.Location = new System.Drawing.Point(55, 3);
            this.bttnAdicionar.Name = "bttnAdicionar";
            this.bttnAdicionar.Size = new System.Drawing.Size(75, 33);
            this.bttnAdicionar.TabIndex = 12;
            this.bttnAdicionar.Text = "&Adicionar";
            this.bttnAdicionar.UseVisualStyleBackColor = true;
            // 
            // frmRutaProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 277);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmRutaProceso";
            this.Text = "RutaProceso";
            this.Load += new System.EventHandler(this.frmRutaProceso_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRutaProceso_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.Button bttnSalir;
        private System.Windows.Forms.Button bttnGuardar;
        private System.Windows.Forms.Button bttnAdicionar;
    }
}