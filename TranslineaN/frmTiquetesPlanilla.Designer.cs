namespace TranslineaN
{
    partial class frmTiquetesPlanilla
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNumeroPlanilla = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConductor = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumRuta = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtgPlanilla = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlCajas = new System.Windows.Forms.Panel();
            this.txtTotalNeto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalBruto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSaldosAntesDescuento = new System.Windows.Forms.Panel();
            this.txtTotalSeguro = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalReex = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalEstam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.bbtnGenerar = new System.Windows.Forms.Button();
            this.bttnImprimir = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlCajas.SuspendLayout();
            this.pnlSaldosAntesDescuento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtNumeroPlanilla);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPlaca);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtConductor);
            this.panel2.Controls.Add(this.txtFecha);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtNumRuta);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtHora);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtVehiculo);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cboDestino);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 99);
            this.panel2.TabIndex = 21;
            // 
            // txtNumeroPlanilla
            // 
            this.txtNumeroPlanilla.BackColor = System.Drawing.Color.White;
            this.txtNumeroPlanilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroPlanilla.Location = new System.Drawing.Point(346, 11);
            this.txtNumeroPlanilla.Name = "txtNumeroPlanilla";
            this.txtNumeroPlanilla.ReadOnly = true;
            this.txtNumeroPlanilla.Size = new System.Drawing.Size(209, 20);
            this.txtNumeroPlanilla.TabIndex = 31;
            this.txtNumeroPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumeroPlanilla.Leave += new System.EventHandler(this.txtNumeroPlanilla_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "# Planilla";
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.ForeColor = System.Drawing.Color.Red;
            this.txtPlaca.Location = new System.Drawing.Point(474, 66);
            this.txtPlaca.MaxLength = 8;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.ReadOnly = true;
            this.txtPlaca.Size = new System.Drawing.Size(81, 20);
            this.txtPlaca.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Placa";
            // 
            // txtConductor
            // 
            this.txtConductor.Location = new System.Drawing.Point(71, 66);
            this.txtConductor.Name = "txtConductor";
            this.txtConductor.Size = new System.Drawing.Size(200, 20);
            this.txtConductor.TabIndex = 27;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.Location = new System.Drawing.Point(346, 38);
            this.txtFecha.MaxLength = 10;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(81, 20);
            this.txtFecha.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Fecha";
            // 
            // txtNumRuta
            // 
            this.txtNumRuta.BackColor = System.Drawing.Color.White;
            this.txtNumRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRuta.Location = new System.Drawing.Point(71, 11);
            this.txtNumRuta.Name = "txtNumRuta";
            this.txtNumRuta.Size = new System.Drawing.Size(200, 21);
            this.txtNumRuta.TabIndex = 24;
            this.txtNumRuta.Leave += new System.EventHandler(this.txtNumRuta_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "# Ruta";
            // 
            // txtHora
            // 
            this.txtHora.ForeColor = System.Drawing.Color.Red;
            this.txtHora.Location = new System.Drawing.Point(474, 38);
            this.txtHora.MaxLength = 8;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(81, 20);
            this.txtHora.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Hora";
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.BackColor = System.Drawing.Color.White;
            this.txtVehiculo.Location = new System.Drawing.Point(346, 66);
            this.txtVehiculo.MaxLength = 10;
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.ReadOnly = true;
            this.txtVehiculo.Size = new System.Drawing.Size(81, 20);
            this.txtVehiculo.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Vehiculo";
            // 
            // cboDestino
            // 
            this.cboDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDestino.ForeColor = System.Drawing.Color.Navy;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(71, 38);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(200, 21);
            this.cboDestino.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Conductor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destino";
            // 
            // DtgPlanilla
            // 
            this.DtgPlanilla.BackgroundColor = System.Drawing.Color.White;
            this.DtgPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgPlanilla.Location = new System.Drawing.Point(12, 117);
            this.DtgPlanilla.Name = "DtgPlanilla";
            this.DtgPlanilla.Size = new System.Drawing.Size(573, 399);
            this.DtgPlanilla.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(591, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 99);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // PnlCajas
            // 
            this.PnlCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlCajas.Controls.Add(this.txtTotalNeto);
            this.PnlCajas.Controls.Add(this.label15);
            this.PnlCajas.Controls.Add(this.txtTotalBruto);
            this.PnlCajas.Controls.Add(this.label8);
            this.PnlCajas.Controls.Add(this.txtOtro);
            this.PnlCajas.Controls.Add(this.label7);
            this.PnlCajas.Controls.Add(this.txtTotalDesc);
            this.PnlCajas.Controls.Add(this.label5);
            this.PnlCajas.Location = new System.Drawing.Point(591, 290);
            this.PnlCajas.Name = "PnlCajas";
            this.PnlCajas.Size = new System.Drawing.Size(171, 226);
            this.PnlCajas.TabIndex = 24;
            // 
            // txtTotalNeto
            // 
            this.txtTotalNeto.BackColor = System.Drawing.Color.White;
            this.txtTotalNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNeto.ForeColor = System.Drawing.Color.Blue;
            this.txtTotalNeto.Location = new System.Drawing.Point(12, 172);
            this.txtTotalNeto.Name = "txtTotalNeto";
            this.txtTotalNeto.ReadOnly = true;
            this.txtTotalNeto.Size = new System.Drawing.Size(145, 20);
            this.txtTotalNeto.TabIndex = 13;
            this.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(40, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Total Neto";
            // 
            // txtTotalBruto
            // 
            this.txtTotalBruto.BackColor = System.Drawing.Color.White;
            this.txtTotalBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBruto.ForeColor = System.Drawing.Color.Red;
            this.txtTotalBruto.Location = new System.Drawing.Point(12, 35);
            this.txtTotalBruto.Name = "txtTotalBruto";
            this.txtTotalBruto.ReadOnly = true;
            this.txtTotalBruto.Size = new System.Drawing.Size(145, 20);
            this.txtTotalBruto.TabIndex = 11;
            this.txtTotalBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Total Bruto";
            // 
            // txtOtro
            // 
            this.txtOtro.BackColor = System.Drawing.Color.White;
            this.txtOtro.Location = new System.Drawing.Point(12, 128);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.ReadOnly = true;
            this.txtOtro.Size = new System.Drawing.Size(145, 20);
            this.txtOtro.TabIndex = 9;
            this.txtOtro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fondo ayuda mutua";
            // 
            // txtTotalDesc
            // 
            this.txtTotalDesc.BackColor = System.Drawing.Color.White;
            this.txtTotalDesc.Location = new System.Drawing.Point(12, 80);
            this.txtTotalDesc.Name = "txtTotalDesc";
            this.txtTotalDesc.ReadOnly = true;
            this.txtTotalDesc.Size = new System.Drawing.Size(145, 20);
            this.txtTotalDesc.TabIndex = 7;
            this.txtTotalDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Descuento";
            // 
            // pnlSaldosAntesDescuento
            // 
            this.pnlSaldosAntesDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSaldosAntesDescuento.Controls.Add(this.txtTotalSeguro);
            this.pnlSaldosAntesDescuento.Controls.Add(this.label14);
            this.pnlSaldosAntesDescuento.Controls.Add(this.txtTotalReex);
            this.pnlSaldosAntesDescuento.Controls.Add(this.label12);
            this.pnlSaldosAntesDescuento.Controls.Add(this.txtTotalEstam);
            this.pnlSaldosAntesDescuento.Controls.Add(this.label9);
            this.pnlSaldosAntesDescuento.Location = new System.Drawing.Point(591, 117);
            this.pnlSaldosAntesDescuento.Name = "pnlSaldosAntesDescuento";
            this.pnlSaldosAntesDescuento.Size = new System.Drawing.Size(171, 167);
            this.pnlSaldosAntesDescuento.TabIndex = 25;
            // 
            // txtTotalSeguro
            // 
            this.txtTotalSeguro.BackColor = System.Drawing.Color.White;
            this.txtTotalSeguro.Location = new System.Drawing.Point(12, 122);
            this.txtTotalSeguro.Name = "txtTotalSeguro";
            this.txtTotalSeguro.ReadOnly = true;
            this.txtTotalSeguro.Size = new System.Drawing.Size(145, 20);
            this.txtTotalSeguro.TabIndex = 16;
            this.txtTotalSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Total Seguro";
            // 
            // txtTotalReex
            // 
            this.txtTotalReex.BackColor = System.Drawing.Color.White;
            this.txtTotalReex.Location = new System.Drawing.Point(12, 78);
            this.txtTotalReex.Name = "txtTotalReex";
            this.txtTotalReex.ReadOnly = true;
            this.txtTotalReex.Size = new System.Drawing.Size(145, 20);
            this.txtTotalReex.TabIndex = 14;
            this.txtTotalReex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Total Reexpedicón";
            // 
            // txtTotalEstam
            // 
            this.txtTotalEstam.BackColor = System.Drawing.Color.White;
            this.txtTotalEstam.Location = new System.Drawing.Point(12, 34);
            this.txtTotalEstam.Name = "txtTotalEstam";
            this.txtTotalEstam.ReadOnly = true;
            this.txtTotalEstam.Size = new System.Drawing.Size(145, 20);
            this.txtTotalEstam.TabIndex = 12;
            this.txtTotalEstam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total Estampilla";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(12, 523);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(573, 37);
            this.txtObservacion.TabIndex = 26;
            this.txtObservacion.CursorChanged += new System.EventHandler(this.txtObservacion_CursorChanged);
            // 
            // bbtnGenerar
            // 
            this.bbtnGenerar.Location = new System.Drawing.Point(591, 524);
            this.bbtnGenerar.Name = "bbtnGenerar";
            this.bbtnGenerar.Size = new System.Drawing.Size(83, 35);
            this.bbtnGenerar.TabIndex = 27;
            this.bbtnGenerar.Text = "&Generar";
            this.bbtnGenerar.UseVisualStyleBackColor = true;
            this.bbtnGenerar.Click += new System.EventHandler(this.bbtnGenerar_Click);
            // 
            // bttnImprimir
            // 
            this.bttnImprimir.Location = new System.Drawing.Point(676, 524);
            this.bttnImprimir.Name = "bttnImprimir";
            this.bttnImprimir.Size = new System.Drawing.Size(86, 35);
            this.bttnImprimir.TabIndex = 28;
            this.bttnImprimir.Text = "&Imprimir";
            this.bttnImprimir.UseVisualStyleBackColor = true;
            // 
            // frmTiquetesPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 570);
            this.Controls.Add(this.bttnImprimir);
            this.Controls.Add(this.bbtnGenerar);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.pnlSaldosAntesDescuento);
            this.Controls.Add(this.PnlCajas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DtgPlanilla);
            this.Controls.Add(this.panel2);
            this.Name = "frmTiquetesPlanilla";
            this.Text = "frmTiquetesPlanilla";
            this.Load += new System.EventHandler(this.frmTiquetesPlanilla_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTiquetesPlanilla_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTiquetesPlanilla_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlCajas.ResumeLayout(false);
            this.PnlCajas.PerformLayout();
            this.pnlSaldosAntesDescuento.ResumeLayout(false);
            this.pnlSaldosAntesDescuento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtConductor;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumRuta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroPlanilla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DtgPlanilla;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PnlCajas;
        private System.Windows.Forms.TextBox txtTotalBruto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlSaldosAntesDescuento;
        private System.Windows.Forms.TextBox txtTotalSeguro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalReex;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalEstam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalNeto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button bbtnGenerar;
        private System.Windows.Forms.Button bttnImprimir;

    }
}