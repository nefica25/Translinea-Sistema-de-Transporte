using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Transactions;

namespace TranslineaN
{
    public partial class frmClientes : Form, ClientesBuscar
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Valores, Actualizar, Campos;
        DataTable DtClientes;
        Boolean TodoOk;
        long miProceso;
        int miMax;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            CargarCombo();
            miProceso = (int)Bandera.n;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Interface, conectamos formulario hijo a padre
        public void ClientesBuscar(int IdCliente)
        {
            MessageBox.Show(Convert.ToString(IdCliente));
            DtClientes = new DataTable();
            String Tabla, Campos, Condicion;

            Tabla = GlobalVar.BDServidor + "dbo.Clientes";
            Campos = "IdTipoCliente,TipoDocumento,NroDocumento,NombreCompleto,Telefono,Celular,Direccion,IdPais,IdDepartamento,IdCiudad, " +
                     "Barrio,Email,Estado,IdAgenciaSucursal";
            Condicion = "IdCliente=" + IdCliente + " AND Estado=1";
            DtClientes = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            //Cargamos datos del formulario
            if (DtClientes.Rows.Count > 0)
            {
                txtCodigo.Text = Convert.ToString(IdCliente);
                cboTipoCliente.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdTipoCliente"]);
                cboTipoDocumento.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["TipoDocumento"]);
                txtDocumento.Text = Convert.ToString(DtClientes.Rows[0]["NroDocumento"]);
                txtNombres.Text = Convert.ToString(DtClientes.Rows[0]["NombreCompleto"]);
                txtTelefono.Text = Convert.ToString(DtClientes.Rows[0]["Telefono"]);
                txtCelular.Text = Convert.ToString(DtClientes.Rows[0]["Celular"]);
                txtDireccion.Text = Convert.ToString(DtClientes.Rows[0]["Direccion"]);
                cboPais.SelectedValue = Convert.ToString(DtClientes.Rows[0]["IdPais"]);
                cboDepartamento.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdDepartamento"]);
                cboCiudad.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdCiudad"]);
                txtBarrio.Text = Convert.ToString(DtClientes.Rows[0]["Barrio"]);
                txtEmail.Text = Convert.ToString(DtClientes.Rows[0]["Email"]);
                cboAgenciaSucursal.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdAgenciaSucursal"]);
                cboEstado.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["Estado"]);
            }
        }

        //Pintar formulario
        private void frmClientes_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturar teclas
        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CargarCombo()
        {
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.TipoCliente", "TipoCliente", "IdTipoCliente", "Id>0", "Id",
                              cboTipoCliente, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.TipoDocumento", "TipoDocumento", "IdTipoDocumento", "Estado=1", "IdTipoDocumento",
                             cboTipoDocumento, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Pais", "Pais", "IdPais", "Estado=1", "IdPais", cboPais, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Departamento", "Departamento", "IdDepartamento", "Estado=1 AND IdPais=" + cboPais.SelectedValue + "",
                                "IdDepartamento", cboDepartamento, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1 AND IdDepartamento=" + cboDepartamento.SelectedValue + "",
                               "IdCiudad", cboCiudad, (int)miCN.S);

            //Agencia
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "Agencia", "IdAgenciaSucursal", "Estado=1", "IdAgenciaSucursal",
                             cboAgenciaSucursal, (int)miCN.S);

            //Estado
            miMt.CargarCombo(cboEstado);
        }

        //Validamos datos antes de Guardar
        private void Validar()
        {
            TodoOk = false;
            Valores = "";
            Actualizar = "";

            if (txtCodigo.TextLength == 0)
            {
                MessageBox.Show("Seleccione un cliente a actualizar", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            //Tipo Cliente
            if (cboTipoCliente.Text.Length != 0)
            {
                Valores = Valores + cboTipoCliente.SelectedValue + ",";
                Actualizar = Actualizar + "IdTipoCliente=" + cboTipoCliente.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione tipo de Cliente", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                cboTipoCliente.Focus();
                return;
            }

            //Tipo Documento
            if (cboTipoDocumento.Text.Length != 0)
            {
                Valores = Valores + cboTipoDocumento.SelectedValue + ",";
                Actualizar = Actualizar + ",TipoDocumento=" + cboTipoDocumento.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione tipo de Documento", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                cboTipoDocumento.Focus();
                return;
            }

            //Documento
            if (txtDocumento.TextLength != 0)
            {
                Valores = Valores + txtDocumento.Text + ",";
                Actualizar = Actualizar + ",NroDocumento=" + txtDocumento.Text + "";
            }
            else
            {
                MessageBox.Show("Ingrese el numero de Documento", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                txtDocumento.Focus();
                return;
            }

            //Nombres
            if (txtNombres.TextLength > 9)
            {
                Valores = Valores + "'" + txtNombres.Text + "',";
                Actualizar = Actualizar + ",NombreCompleto='" + txtNombres.Text + "'";
            }
            else
            {
                MessageBox.Show("Ingrese el Nombre completo del Cliente", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                txtNombres.Focus();
                return;
            }

            //Telefono
            if (txtTelefono.TextLength != 0)
            {
                Valores = Valores + txtTelefono.Text + ",";
                Actualizar = Actualizar + ",Telefono=" + txtTelefono.Text + "";
            }
            else
            {
                MessageBox.Show("Ingrese numero del Telefono", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                txtTelefono.Focus();
                return;
            }

            //Celular
            if (txtCelular.TextLength != 0)
            {
                Valores = Valores + txtCelular.Text + ",";
                Actualizar = Actualizar + ",Celular=" + txtCelular.Text + "";
            }
            else
            {
                MessageBox.Show("Ingresre el numero del Celular", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                txtCelular.Focus();
                return;
            }

            //Direccion
            if (txtDireccion.TextLength != 0)
            {
                Valores = Valores + "'" + txtDireccion.Text + "',";
                Actualizar = Actualizar + ",Direccion='" + txtDireccion.Text + "'";
            }
            else
            {
                MessageBox.Show("Ingrese Direccion", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                txtDireccion.Focus();
                return;
            }

            //Pais
            if (cboPais.Text.Length != 0)
            {
                Valores = Valores + cboPais.SelectedValue + ",";
                Actualizar = Actualizar + ",IdPais=" + cboPais.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione el Pais", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                cboPais.Focus();
                return;
            }

            //Departamento
            if (cboDepartamento.Text.Length != 0)
            {
                Valores = Valores + cboPais.SelectedValue + ",";
                Actualizar = Actualizar + ",IdDepartamento=" + cboDepartamento.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione Departamento", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                cboDepartamento.Focus();
                return;
            }

            //Ciudad
            if (cboCiudad.Text.Length != 0)
            {
                Valores = Valores + cboCiudad.SelectedValue + ",";
                Actualizar = Actualizar + ",IdCiudad=" + cboCiudad.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione Ciudad", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                cboCiudad.Focus();
                return;
            }

            //Barrio
            if (txtBarrio.TextLength != 0)
            {
                Valores = Valores + "'" + txtBarrio.Text + "',";
                Actualizar = Actualizar + ",Barrio='" + txtBarrio.Text + "'";
            }
            else
            {
                Valores = Valores + "'0',";
                Actualizar = Actualizar + ",Barrio='0'";
            }

            //Email
            if (miMt.validarEmail(txtEmail.Text) != false)
            {
                Valores = Valores + "'" + txtEmail.Text + "',";
                Actualizar = Actualizar + ",email='" + txtEmail.Text + "'";
            }
            else
            {
                MessageBox.Show("El Email Ingresado no se encuentra en el Formato Correcto", this.Text,
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1);
                txtEmail.Focus();
                return;
            }

            //Saldo actual

            Valores = Valores + 0 + ",";
            Actualizar = Actualizar + ",SaldoActual=0";

            //Agencia que registra el cliente o pertenece el Empleado o/u Usuario
            if (cboAgenciaSucursal.Text.Length != 0)
            {
                Valores = Valores + cboAgenciaSucursal.SelectedValue + ",";
                Actualizar = Actualizar + ",IdAgenciaSucursal=" + cboAgenciaSucursal.SelectedValue + "";
            }
            else
            {

            }

            //Usuario
            Valores = Valores + GlobalVar.IdUsuario + ",";
            Actualizar = Actualizar + ",IdUsuario=" + GlobalVar.IdUsuario + "";

            //Fecha sistema
            Valores = Valores + "GETDATE(),";

            //Estado
            if (cboEstado.Text.Length != 0)
            {
                Valores = Valores + cboEstado.SelectedValue + "";
                Actualizar = Actualizar + ",Estado=" + cboEstado.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione Estado", this.Text,
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                              MessageBoxDefaultButton.Button1);
                cboEstado.Focus();
                return;
            }

            TodoOk = true;
        }

        //Digitar Solo Numeros
        private void ValidarSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Digitar solo letras
        private void ValidarSoloLetras(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar("/") || e.KeyChar == Convert.ToChar("-"))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {

                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

        }

        //Bloqueamos cajas
        private void BloquearDesbloquear()
        {
            if (miProceso == (int)Bandera.n)
            {
                miMt.BloquearControles(pnlCajas, true);
                miMt.BloquearControles(pnlCajasEncabezado, true);
            }
            else
            {
                miMt.BloquearControles(pnlCajas, false);
                miMt.BloquearControles(pnlCajasEncabezado, false);

            }
        }

        //bloqueamos botones
        private void BloquearDesbloquearBotones()
        {
            if (miProceso == (int)Bandera.n)
            {
                bttnGuardar.Enabled = false;
                bttnCancelar.Enabled = false;
                bttnBuscar.Enabled = false;
            }
            else
            {
                if (miProceso == (int)Bandera.a)
                {
                    bttnGuardar.Enabled = true;
                    bttnGuardar.Text = "&Guardar";
                    bttnAdicionar.Enabled = false;
                    bttnCancelar.Enabled = true;
                    bttnBuscar.Enabled = false;
                    txtCodigo.Text = "0";
                }
                else if (miProceso == (int)Bandera.m)
                {
                    bttnGuardar.Text = "&Actualizar";
                    bttnCancelar.Enabled = false;
                    bttnAdicionar.Enabled = true;
                    bttnBuscar.Enabled = true;
                    txtCodigo.Text = "";
                }
            }
        }

        //Boton adicionar
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miMt.LimpiarFormularioGeneral(this);
            miProceso = (int)Bandera.a;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton Guardar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            Validar();

            if (TodoOk == true)
            {
                GlobalVar.TodoOk = true;
                if (miProceso == (int)Bandera.a)
                {
                    Campos = "IdCliente,IdTipoCliente,TipoDocumento,NroDocumento,NombreCompleto,Telefono,Celular, " +
                             "Direccion,IdPais,IdDepartamento,IdCiudad,Barrio,email,SaldoActual,IdAgenciaSucursal,IdUsuario,FechaDeSistema,Estado";
                    miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Clientes", "IdCliente", (int)miCN.S);

                    miSql.Guardar(GlobalVar.BDServidor + "dbo.Clientes", Campos, miMax + "," + Valores, (int)miCN.S);

                    //Si es usuario del sistema creamos el perfil de usuario
                    if (Convert.ToInt32(cboTipoCliente.SelectedValue) == 4)
                    {
                        //Creamos perfil
                    }

                    //Si ingreso algun valor en saldo Creamos la cartera al Cliente

                    if (GlobalVar.TodoOk == true)
                    {
                        MessageBox.Show("Registro enviado correctamente", "<Translinea Software>",
                                       System.Windows.Forms.MessageBoxButtons.OK,
                                       System.Windows.Forms.MessageBoxIcon.Information);
                        txtCodigo.Text = Convert.ToString(miMax);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al intentar guardar", "<Translinea Software>",
                                     System.Windows.Forms.MessageBoxButtons.OK,
                                     System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else if (miProceso == (int)Bandera.m)
                {
                    miSql.Actualizar(GlobalVar.BDServidor + "dbo.Clientes", Actualizar, "IdCliente=" + txtCodigo.Text + "", (int)miCN.S);

                    if (GlobalVar.TodoOk == true)
                    {
                        MessageBox.Show("Registro actualizado correctamente", "<Translinea Software>",
                                        System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al intentar actualizar", "<Translinea Software>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Boton cancelar
        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.m;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton buscar
        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            frmClientesBuscar frm = new frmClientesBuscar();
            frm.Opener = this;
            frm.Show();
        }

        //Boton salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Eventos

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            txtNombres.Text = txtNombres.Text.ToUpper();
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            txtDireccion.Text = txtDireccion.Text.ToUpper();
        }

        private void cboTipoCliente_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboTipoCliente.SelectedValue) == 0)
                {
                    cboTipoCliente.SelectedValue = 0;
                    cboTipoCliente.Text = "";
                }
            }
        }

        private void cboTipoDocumento_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
                {
                    cboTipoDocumento.SelectedValue = 0;
                    cboTipoDocumento.Text = "";
                }
            }
        }

        private void cboPais_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboPais.SelectedValue) == 0)
                {
                    cboPais.SelectedValue = 0;
                    cboPais.Text = "";
                }
            }
        }

        private void cboDepartamento_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboDepartamento.SelectedValue) == 0)
                {
                    cboDepartamento.SelectedValue = 0;
                    cboDepartamento.Text = "";
                }
            }
        }

        private void cboCiudad_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboCiudad.SelectedValue) == 0)
                {
                    cboCiudad.SelectedValue = 0;
                    cboCiudad.Text = "";
                }
            }
        }

        private void txtBarrio_Leave(object sender, EventArgs e)
        {
            txtBarrio.Text = txtBarrio.Text.ToUpper();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            miMt.validarEmail(txtEmail.Text);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        private void txtBarrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void cboDepartamento_Enter(object sender, EventArgs e)
        {
            if (Convert.ToDouble(cboPais.SelectedValue) != 0)
            {
                miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Departamento", "Departamento", "IdDepartamento", "Estado=1 AND IdPais=" + cboPais.SelectedValue + "",
                                 "IdDepartamento", cboDepartamento, (int)miCN.S);
            }
        }

        private void cboCiudad_Enter(object sender, EventArgs e)
        {
            if (Convert.ToDouble(cboDepartamento.SelectedValue) != 0)
            {
                miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1 AND IdDepartamento=" + cboDepartamento.SelectedValue + "",
                                 "IdCiudad", cboCiudad, (int)miCN.S);
            }
        }

        //Agencia Sucursal
        private void cboAgenciaSucursal_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgenciaSucursal.SelectedValue) == 0)
            {
                cboAgenciaSucursal.SelectedValue = 0;
                cboAgenciaSucursal.Text = "";
            }
        }

        //Estado
        private void cboEstado_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboEstado.SelectedValue) == 0)
            {
                cboEstado.SelectedValue = 0;
                cboEstado.Text = "";
            }
        }
        #endregion

        private void cboTipoCliente_Enter(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                cboAgenciaSucursal.SelectedValue = 0;
                cboAgenciaSucursal.SelectedValue = 0;
            }
        }

        //Validamos si el CLiente ya existe
        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n && txtDocumento.TextLength != 0)
            {
                bttnGuardar.Enabled = true;
                DtClientes = new DataTable();
                String Tabla, Campos, Condicion;

                Tabla = GlobalVar.BDServidor + "dbo.Clientes";
                Campos = "TipoDocumento,IdCliente,IdTipoCliente,NombreCompleto,Telefono,Celular,Direccion,IdPais,IdDepartamento,IdCiudad, " +
                         "Barrio,Email,Estado,IdAgenciaSucursal";
                Condicion = "NroDocumento=" + txtDocumento.Text + " AND Estado=1";
                DtClientes = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

                //Cargamos datos del formulario
                if (DtClientes.Rows.Count > 0)
                {
                    cboTipoCliente.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdTipoCliente"]);
                    cboTipoDocumento.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["TipoDocumento"]);
                    txtCodigo.Text = Convert.ToString(DtClientes.Rows[0]["IdCliente"]);
                    txtNombres.Text = Convert.ToString(DtClientes.Rows[0]["NombreCompleto"]);
                    txtTelefono.Text = Convert.ToString(DtClientes.Rows[0]["Telefono"]);
                    txtCelular.Text = Convert.ToString(DtClientes.Rows[0]["Celular"]);
                    txtDireccion.Text = Convert.ToString(DtClientes.Rows[0]["Direccion"]);
                    cboPais.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdPais"]);
                    cboDepartamento.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdDepartamento"]);
                    cboCiudad.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdCiudad"]);
                    txtBarrio.Text = Convert.ToString(DtClientes.Rows[0]["Barrio"]);
                    txtEmail.Text = Convert.ToString(DtClientes.Rows[0]["Email"]);
                    cboAgenciaSucursal.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["IdAgenciaSucursal"]);
                    cboEstado.SelectedValue = Convert.ToInt32(DtClientes.Rows[0]["Estado"]);

                    if (miProceso == (int)Bandera.a)
                    {
                        MessageBox.Show("El cliente ya existe", "<Translinea Software>",
                                       System.Windows.Forms.MessageBoxButtons.OK,
                                       System.Windows.Forms.MessageBoxIcon.Information);
                        txtDocumento.Focus();
                        bttnGuardar.Enabled = false;
                    }
                }
                else
                {
                    txtNombres.Clear();
                    txtTelefono.Clear();
                    txtCelular.Clear();
                    miMt.LimpiarPanel(pnlCajas);
                }
            }
        }

     
    }
}
