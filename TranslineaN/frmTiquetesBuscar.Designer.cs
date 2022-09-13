namespace TranslineaN
{
    partial class frmTiquetesBuscar
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
            this.DtgBuscarIda = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAgencia = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFechaIda = new System.Windows.Forms.DateTimePicker();
            this.bttnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBuscarIda)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgBuscarIda
            // 
            this.DtgBuscarIda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBuscarIda.Location = new System.Drawing.Point(9, 112);
            this.DtgBuscarIda.Name = "DtgBuscarIda";
            this.DtgBuscarIda.Size = new System.Drawing.Size(528, 165);
            this.DtgBuscarIda.TabIndex = 0;
            this.DtgBuscarIda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgBuscarIda_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Destino";
            // 
            // cboOrigen
            // 
            this.cboOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(8, 62);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(222, 21);
            this.cboOrigen.TabIndex = 3;
            this.cboOrigen.Leave += new System.EventHandler(this.cboOrigen_Leave);
            // 
            // cboDestino
            // 
            this.cboDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(236, 62);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(222, 21);
            this.cboDestino.TabIndex = 4;
            this.cboDestino.Leave += new System.EventHandler(this.cboDestino_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agencia";
            // 
            // cboAgencia
            // 
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(8, 22);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(222, 21);
            this.cboAgencia.TabIndex = 6;
            this.cboAgencia.Leave += new System.EventHandler(this.cboAgencia_Leave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bttnBuscar);
            this.panel1.Controls.Add(this.DtpFechaIda);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboAgencia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboDestino);
            this.panel1.Controls.Add(this.cboOrigen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 96);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha";
            // 
            // DtpFechaIda
            // 
            this.DtpFechaIda.Location = new System.Drawing.Point(236, 23);
            this.DtpFechaIda.Name = "DtpFechaIda";
            this.DtpFechaIda.Size = new System.Drawing.Size(222, 20);
            this.DtpFechaIda.TabIndex = 8;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(464, 23);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(56, 60);
            this.bttnBuscar.TabIndex = 8;
            this.bttnBuscar.Text = "&Buscar";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            this.bttnBuscar.Click += new System.EventHandler(this.bttnBuscar_Click);
            // 
            // frmTiquetesBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgBuscarIda);
            this.Name = "frmTiquetesBuscar";
            this.Text = "frmTiquetesBuscar";
            this.Load += new System.EventHandler(this.frmTiquetesBuscar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTiquetesBuscar_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTiquetesBuscar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBuscarIda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgBuscarIda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAgencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpFechaIda;
        private System.Windows.Forms.Button bttnBuscar;
    }
}