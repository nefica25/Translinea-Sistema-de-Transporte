using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace TranslineaN
{
    public partial class frmSucursal : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Tabla, Campos, Condicion;
        String Valores, ValoresActualizar;
        int miMax, miSucursal;
        long miProceso;
        Boolean TodoOk;
        DataTable DtSucursal;

        public frmSucursal()
        {
            InitializeComponent();
        }

        private void frmSucursal_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);

            ConfigurarGrilla();
            txtCodigo.Text = "0";
            miProceso = (int)Bandera.n;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Pintamos el formulario
        private void frmSucursal_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturamos teclas
        private void frmSucursal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["IdAgenciaSucursal"].Width = 50;
                Dtg.Columns["IdAgenciaSucursal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdAgenciaSucursal"].HeaderText = "Codigo";

                Dtg.Columns["Agencia"].Width = 215;
                Dtg.Columns["Agencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Agencia"].HeaderText = "Nombres";

                Dtg.Columns["Telefono"].Width = 90;
                Dtg.Columns["Telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Telefono"].HeaderText = "Telefono";

                Dtg.Columns["TipoAgenciaSucursal"].Width = 139;
                Dtg.Columns["TipoAgenciaSucursal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["TipoAgenciaSucursal"].HeaderText = "Tipo";

                Dtg.Columns["FechaDeSistema"].Width = 80;
                Dtg.Columns["FechaDeSistema"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["FechaDeSistema"].HeaderText = "Fecha";
                Dtg.Columns["FechaDeSistema"].ReadOnly = true;
                Dtg.Columns["FechaDeSistema"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Dtg.Columns["IdAgencia"].Visible = false;
                Dtg.Columns["IdSucursal"].Visible = false;
                Dtg.Columns["IdTipoAgenciaSucursal"].Visible = false;
                Dtg.Columns["Tipo"].Visible = false;
                Dtg.Columns["Abreviatura"].Visible = false;
                Dtg.Columns["IdPais"].Visible = false;
                Dtg.Columns["IdDepartamento"].Visible = false;
                Dtg.Columns["IdCiudad"].Visible = false;
                Dtg.Columns["Barrio"].Visible = false;
                Dtg.Columns["Direccion"].Visible = false;
                Dtg.Columns["Estado"].Visible = false;
                Dtg.Columns["IdUsuario"].Visible = false;

                //Dtg.Columns[""].SortMode = DataGridViewColumnSortMode.NotSortable;
                //  Dtg.Columns["CodigoAlterno"].DefaultCellStyle.Format = "dd/MM/yyyy"  or  "#,##0.00";

                Dtg.Dock = DockStyle.None;
                Dtg.BorderStyle = BorderStyle.FixedSingle;

                Dtg.AllowUserToAddRows = true;
                Dtg.AllowUserToDeleteRows = false;
                Dtg.AllowUserToOrderColumns = true;
                Dtg.ReadOnly = true;
                Dtg.RowHeadersVisible = false;
                Dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Dtg.MultiSelect = false;
                Dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                Dtg.AllowUserToResizeColumns = false;
                Dtg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                Dtg.AllowUserToResizeRows = false;
                Dtg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                //Quitar Scroll
                Dtg.ScrollBars = ScrollBars.None;

                // Seleccionamos color de las filas de las celdas  //LemonChiffon
                Dtg.DefaultCellStyle.SelectionBackColor = Color.LemonChiffon;
                Dtg.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Color encabezados de la grilla
                Dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
                Dtg.RowHeadersDefaultCellStyle.BackColor = Color.Black;//SlateGray,Teal
                Dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

                // Dtg.CellFormatting += new    DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            }
        }

        //Mostramos sucursales en la Grilla
        private void ConfigurarGrilla()
        {
            int IdAgencia = 0;
            if (cboAgencia.Text.Length > 0)
            {
                IdAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            }

            DtSucursal = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.AgenciaSucursal A INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.TipoAgenciaSucursal TAS ON A.IdTipoAgenciaSucursal=TAS.IdTipoAgenciaSucursal";
            Campos = "A.IdAgenciaSucursal,A.Agencia,A.Telefono,TAS.TipoAgenciaSucursal,A.FechaDeSistema,A.IdAgencia,A.IdSucursal, " +
                     "A.IdTipoAgenciaSucursal,A.Tipo,A.Abreviatura,A.IdPais,A.IdDepartamento,A.IdCiudad,A.Barrio,A.Direccion,A.Estado,A.IdUsuario";
            Condicion = "A.Estado=1 AND A.Tipo=2 AND IdAgencia=" + IdAgencia + "";
            DtSucursal = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            DtgSucursal.DataSource = DtSucursal;
            Conf_DtgRuta(DtgSucursal);
        }

        //Enlazamos las cajas con la Grilla
        private void DtgSucursal_SelectionChanged(object sender, EventArgs e)
        {
            if (miProceso == (int)Bandera.m)
            {
                txtCodigo.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["IdAgenciaSucursal"].Value);
                cboAgencia.SelectedValue = Convert.ToInt32(DtgSucursal.Rows[DtgSucursal.CurrentRow.Index].Cells["IdAgencia"].Value);
                cboTipoSucursal.SelectedValue = Convert.ToString(DtgSucursal.Rows[DtgSucursal.CurrentRow.Index].Cells["IdTipoAgenciaSucursal"].Value);
                txtSucursal.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["Agencia"].Value);
                txtAbrev.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["Abreviatura"].Value);
                cboPais.SelectedValue = Convert.ToInt32(DtgSucursal.Rows[DtgSucursal.CurrentRow.Index].Cells["IdPais"].Value);
                cboDepartamento.SelectedValue = Convert.ToInt32(DtgSucursal.Rows[DtgSucursal.CurrentRow.Index].Cells["IdDepartamento"].Value);
                cboCiudad.SelectedValue = Convert.ToInt32(DtgSucursal.Rows[DtgSucursal.CurrentRow.Index].Cells["IdCiudad"].Value);
                txtDireccion.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["Direccion"].Value);
                txtBarrio.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["Direccion"].Value);
                txtDireccion.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["Barrio"].Value);
                txtTelefono.Text = Convert.ToString(DtgSucursal.CurrentRow.Cells["Telefono"].Value);
            }
        }

        //Cargar Combos
        private void CargarCombos()
        {
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "Agencia", "IdAgencia", "Estado=1 AND Tipo=1",
                             "IdAgenciaSucursal", cboAgencia, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Pais", "Pais", "IdPais", "Estado=1", "IdPais", cboPais, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Departamento", "Departamento", "IdDepartamento", "Estado=1 AND IdPais=" + cboPais.SelectedValue + "",
                                 "IdDepartamento", cboDepartamento, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1 AND IdDepartamento=" + cboDepartamento.SelectedValue + "",
                                "IdCiudad", cboCiudad, (int)miCN.S);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.TipoAgenciaSucursal", "TipoAgenciaSucursal", "IdTipoAgenciaSucursal",
                              "Estado=1", "IdTipoAgenciaSucursal", cboTipoSucursal, (int)miCN.S);

            txtCodigo.Text = "0";
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
            }
            else
            {
                miMt.BloquearControles(pnlCajas, false);

            }
            txtCodigo.ReadOnly = true;
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
                    bttnGuardar.Text = "&Guardar";
                    bttnGuardar.Enabled = true;
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

        //Filtramos por Pais y cargamos los Departamentos
        private void cboDepartamento_Enter(object sender, EventArgs e)
        {
            if (Convert.ToDouble(cboPais.SelectedValue) != 0)
            {
                miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Departamento", "Departamento", "IdDepartamento", "Estado=1 AND IdPais=" + cboPais.SelectedValue + "",
                                 "IdDepartamento", cboDepartamento, (int)miCN.S);
            }
        }

        //Filtramos por Departamentoa y cargamos la Ciudad
        private void cboCiudad_Enter(object sender, EventArgs e)
        {
            if (Convert.ToDouble(cboDepartamento.SelectedValue) != 0)
            {
                miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1 AND IdDepartamento=" + cboDepartamento.SelectedValue + "",
                                 "IdCiudad", cboCiudad, (int)miCN.S);
            }
        }

        //Metodo Validar los datos
        private void ValidarDatos()
        {
            Valores = "";
            TodoOk = false;

            if (Convert.ToInt32(cboAgencia.SelectedValue) != 0)
            {
                ValoresActualizar = "IdAgencia=" + cboAgencia.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Por favor seleccione la Agencia", "<Translinea Software>",
                                                         System.Windows.Forms.MessageBoxButtons.OK,
                                                         System.Windows.Forms.MessageBoxIcon.Information);
                cboAgencia.Focus();
                return;
            }

            //Tipo de susucrsal 
            if (cboTipoSucursal.Text.Length != 0)
            {
                Valores = Valores + cboTipoSucursal.SelectedValue + ",";
                ValoresActualizar = ValoresActualizar + ",IdTipoAgenciaSucursal=" + cboTipoSucursal.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Porfavor seleccione tipo de Sucursal", "<Translinea Software>",
                                            System.Windows.Forms.MessageBoxButtons.OK,
                                            System.Windows.Forms.MessageBoxIcon.Information);
                cboTipoSucursal.Focus();
                return;
            }

            //Nombre sucursal
            if (txtSucursal.TextLength != 0)
            {
                Valores = Valores + "'" + txtSucursal.Text + "',";
                ValoresActualizar = ValoresActualizar + ",Agencia='" + txtSucursal.Text + "'";
            }
            else
            {
                MessageBox.Show("Porfavor ingrese nombre de la Sucursal", "<Translinea Software>",
                                              System.Windows.Forms.MessageBoxButtons.OK,
                                              System.Windows.Forms.MessageBoxIcon.Information);
                txtSucursal.Focus();
                return;
            }

            //Abreviatura
            if (txtAbrev.TextLength != 0)
            {
                Valores = Valores + "'" + txtAbrev.Text + "',";
                ValoresActualizar = ValoresActualizar + ",Abreviatura='" + txtAbrev.Text + "'";
            }
            else
            {
                MessageBox.Show("Porfavor ingrese la abreviatura de la sucursal", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                txtAbrev.Focus();
                return;
            }

            //Pais
            if (Convert.ToInt32(cboPais.SelectedValue) != 0)
            {
                Valores = Valores + cboPais.SelectedValue + ",";
                ValoresActualizar = ValoresActualizar + ",IdPais=" + cboPais.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Porfavor seleccione Pais", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                cboPais.Focus();
                return;
            }

            //Departamento
            if (Convert.ToInt32(cboDepartamento.SelectedValue) != 0)
            {
                Valores = Valores + cboDepartamento.SelectedValue + ",";
                ValoresActualizar = ValoresActualizar + ",IdDepartamento=" + cboDepartamento.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Porfavor seleccione Departamento", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                cboDepartamento.Focus();
                return;
            }

            //Ciudad
            if (Convert.ToInt32(cboCiudad.SelectedValue) != 0)
            {
                Valores = Valores + cboCiudad.SelectedValue + ",";
                ValoresActualizar = ValoresActualizar + ",IdCiudad=" + cboCiudad.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Porfavor seleccione Ciudad", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                cboCiudad.Focus();
                return;
            }

            //Barrio
            if (txtBarrio.TextLength != 0)
            {
                Valores = Valores + "'" + txtBarrio.Text + "',";
                ValoresActualizar = ValoresActualizar + ",Barrio='" + txtBarrio.Text + "'";
            }
            else
            {
                MessageBox.Show("Porfavor ingrese Barrio", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                txtBarrio.Focus();
                return;
            }

            //Dirección
            if (txtDireccion.TextLength != 0)
            {
                Valores = Valores + "'" + txtDireccion.Text + "',";
                ValoresActualizar = ValoresActualizar + ",Direccion='" + txtDireccion.Text + "'";
            }
            else
            {
                MessageBox.Show("Porfavor ingrese Dirección", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                txtDireccion.Focus();
                return;
            }

            //Telefono
            if (txtTelefono.TextLength != 0)
            {
                Valores = Valores + txtTelefono.Text + ",";
                ValoresActualizar = ValoresActualizar + ",Telefono=" + txtTelefono.Text + "";
            }
            else
            {
                MessageBox.Show("Porfavor ingrese Telefono", "<Translinea Software>",
                          System.Windows.Forms.MessageBoxButtons.OK,
                          System.Windows.Forms.MessageBoxIcon.Information);
                txtTelefono.Focus();
                return;
            }

            //Tipo 1:Agencia 2:Sucursal
            Valores = Valores + "2,";

            //Estado
            Valores = Valores + "1,";

            //Usuario
            Valores = Valores + GlobalVar.IdUsuario + ",";

            //Fecha de Sistema
            Valores = Valores + "GETDATE()";

            TodoOk = true;
        }

        #region Eventos

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBarrio_Leave(object sender, EventArgs e)
        {
            txtBarrio.Text = txtBarrio.Text.ToUpper();
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            txtDireccion.Text = txtDireccion.Text.ToUpper();
        }

        private void cboAgencia_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboAgencia.SelectedValue) == 0)
                {
                    cboAgencia.SelectedValue = 0;
                    cboAgencia.Text = "";
                }
                else if (Convert.ToInt32(cboAgencia.SelectedValue) > 0)
                {
                    ConfigurarGrilla();
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

        private void cboTipoSucursal_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboTipoSucursal.SelectedValue) == 0)
                {
                    cboTipoSucursal.SelectedValue = 0;
                    cboTipoSucursal.Text = "";
                }
            }
        }

        private void txtSucursal_Leave(object sender, EventArgs e)
        {
            txtSucursal.Text = txtSucursal.Text.ToUpper();
        }

        private void txtAbrev_Leave(object sender, EventArgs e)
        {
            txtAbrev.Text = txtAbrev.Text.ToUpper();
        }

        #endregion

        //Boton Adicionar una nueva sucursal
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.a;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
            miMt.LimpiarFormularioGeneral(this);
            txtCodigo.Text = "0";
            CargarCombos();
            ConfigurarGrilla();
        }

        //Boton ingresar la nueva sucursal o actualizar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            ValidarDatos();
            GlobalVar.TodoOk = true;
            if (TodoOk == true)
            {
                if (miProceso == (int)Bandera.a)
                {
                    miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "IdAgenciaSucursal", (int)miCN.S);
                    //Asignamos el siguiente numero sucursal que pertenece a la Agencia
                    miSucursal = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "IdSucursal",
                                "IdAgencia=" + cboAgencia.SelectedValue + "", (int)miCN.S);

                    Campos = "IdAgenciaSucursal,IdAgencia,IdSucursal,IdTipoAgenciaSucursal,Agencia,Abreviatura,IdPais,IdDepartamento, " +
                             "IdCiudad,Barrio,Direccion,Telefono,Tipo,Estado,IdUsuario,FechaDeSistema";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.AgenciaSucursal", Campos, miMax + "," + cboAgencia.SelectedValue + "," + miSucursal + "," + Valores,
                                 (int)miCN.S);

                    if (GlobalVar.TodoOk == true)
                    {
                        MessageBox.Show("Sucursal creada correctamente", "<Translinea Software>",
                                       System.Windows.Forms.MessageBoxButtons.OK,
                                       System.Windows.Forms.MessageBoxIcon.Information);
                        ConfigurarGrilla();
                        miMt.LimpiarFormularioGeneral(this);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al crear la sucursal", "<Translinea Software>",
                                     System.Windows.Forms.MessageBoxButtons.OK,
                                     System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else if (miProceso == (int)Bandera.m)
                {
                    miSucursal = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "IdSucursal",
                               "IdAgencia=" + cboAgencia.SelectedValue + "", (int)miCN.S);

                    miSql.Actualizar(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "IdSucursal=" + miSucursal + "," + ValoresActualizar,
                                    "IdAgenciaSucursal=" + txtCodigo.Text + " AND IdAgencia=" + cboAgencia.SelectedValue + "",
                                    (int)miCN.S);

                    if (GlobalVar.TodoOk == true)
                    {
                        MessageBox.Show("Sucursal actualizada correctamente", "<Translinea Software>",
                                       System.Windows.Forms.MessageBoxButtons.OK,
                                       System.Windows.Forms.MessageBoxIcon.Information);
                        ConfigurarGrilla();
                        miMt.LimpiarFormularioGeneral(this);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al crear la sucursal", "<Translinea Software>",
                                     System.Windows.Forms.MessageBoxButtons.OK,
                                     System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Boton cancelarlo coloca en modo Actualizar
        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.m;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton buscar registro para Actualizar
        private void bbtnBuscar_Click(object sender, EventArgs e)
        {

        }

        //Boton salir del formulario
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
