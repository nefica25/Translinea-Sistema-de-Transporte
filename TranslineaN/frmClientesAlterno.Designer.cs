namespace TranslineaN
{
    partial class frmClientesAlterno
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
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bttnIngresar = new System.Windows.Forms.Button();
            this.pnlContenido.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Doc.";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(88, 8);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(273, 21);
            this.cboTipoDocumento.TabIndex = 1;
            this.cboTipoDocumento.Leave += new System.EventHandler(this.cboTipoDocumento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(88, 35);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(273, 20);
            this.txtDocumento.TabIndex = 3;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(88, 61);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(273, 20);
            this.txtNombres.TabIndex = 5;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            this.txtNombres.Validated += new System.EventHandler(this.txtNombres_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(88, 87);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(273, 20);
            this.txtCelular.TabIndex = 7;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(88, 113);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(273, 20);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            this.txtDireccion.Validated += new System.EventHandler(this.txtDireccion_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 139);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 20);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.txtEmail);
            this.pnlContenido.Controls.Add(this.label6);
            this.pnlContenido.Controls.Add(this.txtDireccion);
            this.pnlContenido.Controls.Add(this.label5);
            this.pnlContenido.Controls.Add(this.txtCelular);
            this.pnlContenido.Controls.Add(this.label4);
            this.pnlContenido.Controls.Add(this.txtNombres);
            this.pnlContenido.Controls.Add(this.label3);
            this.pnlContenido.Controls.Add(this.txtDocumento);
            this.pnlContenido.Controls.Add(this.label2);
            this.pnlContenido.Controls.Add(this.cboTipoDocumento);
            this.pnlContenido.Controls.Add(this.label1);
            this.pnlContenido.Location = new System.Drawing.Point(8, 8);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(378, 170);
            this.pnlContenido.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bttnIngresar);
            this.panel2.Location = new System.Drawing.Point(8, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 44);
            this.panel2.TabIndex = 13;
            // 
            // bttnIngresar
            // 
            this.bttnIngresar.Location = new System.Drawing.Point(286, 9);
            this.bttnIngresar.Name = "bttnIngresar";
            this.bttnIngresar.Size = new System.Drawing.Size(75, 27);
            this.bttnIngresar.TabIndex = 0;
            this.bttnIngresar.Text = "&Ingresar";
            this.bttnIngresar.UseVisualStyleBackColor = true;
            this.bttnIngresar.Click += new System.EventHandler(this.bttnIngresar_Click);
            // 
            // frmClientesAlterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 236);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlContenido);
            this.Name = "frmClientesAlterno";
            this.Text = "frmClientesAlterno";
            this.Load += new System.EventHandler(this.frmClientesAlterno_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmClientesAlterno_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientesAlterno_KeyDown);
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bttnIngresar;
    }
}