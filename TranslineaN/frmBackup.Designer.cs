namespace TranslineaN
{
    partial class frmBackup
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
            this.rdbLocal = new System.Windows.Forms.RadioButton();
            this.rdbRemoto = new System.Windows.Forms.RadioButton();
            this.txtNombreServidor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bttnGenerar = new System.Windows.Forms.Button();
            this.bttnSalir = new System.Windows.Forms.Button();
            this.RdbWindows = new System.Windows.Forms.RadioButton();
            this.rdbSqlServer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.RdbRestaurar = new System.Windows.Forms.RadioButton();
            this.RdbRespaldar = new System.Windows.Forms.RadioButton();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.bttnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbLocal
            // 
            this.rdbLocal.AutoSize = true;
            this.rdbLocal.Location = new System.Drawing.Point(23, 45);
            this.rdbLocal.Name = "rdbLocal";
            this.rdbLocal.Size = new System.Drawing.Size(51, 17);
            this.rdbLocal.TabIndex = 0;
            this.rdbLocal.TabStop = true;
            this.rdbLocal.Text = "Local";
            this.rdbLocal.UseVisualStyleBackColor = true;
            // 
            // rdbRemoto
            // 
            this.rdbRemoto.AutoSize = true;
            this.rdbRemoto.Location = new System.Drawing.Point(135, 45);
            this.rdbRemoto.Name = "rdbRemoto";
            this.rdbRemoto.Size = new System.Drawing.Size(62, 17);
            this.rdbRemoto.TabIndex = 1;
            this.rdbRemoto.TabStop = true;
            this.rdbRemoto.Text = "Remoto";
            this.rdbRemoto.UseVisualStyleBackColor = true;
            // 
            // txtNombreServidor
            // 
            this.txtNombreServidor.Location = new System.Drawing.Point(23, 19);
            this.txtNombreServidor.Name = "txtNombreServidor";
            this.txtNombreServidor.Size = new System.Drawing.Size(297, 20);
            this.txtNombreServidor.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreServidor);
            this.groupBox1.Controls.Add(this.rdbRemoto);
            this.groupBox1.Controls.Add(this.rdbLocal);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtContrasena);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.RdbWindows);
            this.groupBox2.Controls.Add(this.rdbSqlServer);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 139);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autenticación";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bttnBuscar);
            this.groupBox3.Controls.Add(this.txtUbicacion);
            this.groupBox3.Controls.Add(this.RdbRestaurar);
            this.groupBox3.Controls.Add(this.RdbRespaldar);
            this.groupBox3.Location = new System.Drawing.Point(12, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 99);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Base de Datos";
            // 
            // bttnGenerar
            // 
            this.bttnGenerar.Location = new System.Drawing.Point(196, 337);
            this.bttnGenerar.Name = "bttnGenerar";
            this.bttnGenerar.Size = new System.Drawing.Size(75, 35);
            this.bttnGenerar.TabIndex = 6;
            this.bttnGenerar.Text = "Generar";
            this.bttnGenerar.UseVisualStyleBackColor = true;
            // 
            // bttnSalir
            // 
            this.bttnSalir.Location = new System.Drawing.Point(275, 337);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(75, 35);
            this.bttnSalir.TabIndex = 7;
            this.bttnSalir.Text = "Salir";
            this.bttnSalir.UseVisualStyleBackColor = true;
            // 
            // RdbWindows
            // 
            this.RdbWindows.AutoSize = true;
            this.RdbWindows.Location = new System.Drawing.Point(134, 31);
            this.RdbWindows.Name = "RdbWindows";
            this.RdbWindows.Size = new System.Drawing.Size(69, 17);
            this.RdbWindows.TabIndex = 4;
            this.RdbWindows.TabStop = true;
            this.RdbWindows.Text = "Windows";
            this.RdbWindows.UseVisualStyleBackColor = true;
            // 
            // rdbSqlServer
            // 
            this.rdbSqlServer.AutoSize = true;
            this.rdbSqlServer.Location = new System.Drawing.Point(22, 31);
            this.rdbSqlServer.Name = "rdbSqlServer";
            this.rdbSqlServer.Size = new System.Drawing.Size(80, 17);
            this.rdbSqlServer.TabIndex = 3;
            this.rdbSqlServer.TabStop = true;
            this.rdbSqlServer.Text = "SQL Server";
            this.rdbSqlServer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(111, 65);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(207, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(111, 98);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(207, 20);
            this.txtContrasena.TabIndex = 8;
            // 
            // RdbRestaurar
            // 
            this.RdbRestaurar.AutoSize = true;
            this.RdbRestaurar.Location = new System.Drawing.Point(127, 29);
            this.RdbRestaurar.Name = "RdbRestaurar";
            this.RdbRestaurar.Size = new System.Drawing.Size(71, 17);
            this.RdbRestaurar.TabIndex = 10;
            this.RdbRestaurar.TabStop = true;
            this.RdbRestaurar.Text = "Restaurar";
            this.RdbRestaurar.UseVisualStyleBackColor = true;
            // 
            // RdbRespaldar
            // 
            this.RdbRespaldar.AutoSize = true;
            this.RdbRespaldar.Location = new System.Drawing.Point(15, 29);
            this.RdbRespaldar.Name = "RdbRespaldar";
            this.RdbRespaldar.Size = new System.Drawing.Size(73, 17);
            this.RdbRespaldar.TabIndex = 9;
            this.RdbRespaldar.TabStop = true;
            this.RdbRespaldar.Text = "Respaldar";
            this.RdbRespaldar.UseVisualStyleBackColor = true;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(15, 61);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(271, 20);
            this.txtUbicacion.TabIndex = 9;
            // 
            // bttnBuscar
            // 
            this.bttnBuscar.Location = new System.Drawing.Point(290, 59);
            this.bttnBuscar.Name = "bttnBuscar";
            this.bttnBuscar.Size = new System.Drawing.Size(42, 23);
            this.bttnBuscar.TabIndex = 11;
            this.bttnBuscar.Text = "...";
            this.bttnBuscar.UseVisualStyleBackColor = true;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 379);
            this.Controls.Add(this.bttnSalir);
            this.Controls.Add(this.bttnGenerar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBackup";
            this.Text = "frmBackup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbLocal;
        private System.Windows.Forms.RadioButton rdbRemoto;
        private System.Windows.Forms.TextBox txtNombreServidor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RdbWindows;
        private System.Windows.Forms.RadioButton rdbSqlServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bttnBuscar;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.RadioButton RdbRestaurar;
        private System.Windows.Forms.RadioButton RdbRespaldar;
        private System.Windows.Forms.Button bttnGenerar;
        private System.Windows.Forms.Button bttnSalir;
    }
}