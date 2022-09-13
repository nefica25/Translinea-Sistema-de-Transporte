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
    public partial class frmVehiculo : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Tabla, Campos, Condicion;
        String Valores, Actualizar;
        DataTable DtVehiculo;
        Boolean TodoOk = true;
        long miProceso;
        int miMax;

        public frmVehiculo()
        {
            InitializeComponent();
        }

        private void frmVehiculo_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            ConfigurarGrilla();

            CargarCombos();
            TodoOk = false;
            miProceso = (int)Bandera.a;

            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Pintar formulario
        private void frmVehiculo_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturar teclas
        private void frmVehiculo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["IdVehiculo"].Width = 50;
                Dtg.Columns["IdVehiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdVehiculo"].HeaderText = "Codigo";

                Dtg.Columns["Vehiculo"].Width = 98;
                Dtg.Columns["Vehiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Vehiculo"].HeaderText = "Vehiculo";

                Dtg.Columns["Placa"].Width = 70;
                Dtg.Columns["Placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Placa"].HeaderText = "Placa";

                Dtg.Columns["Asientos"].Width = 50;
                Dtg.Columns["Asientos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Asientos"].HeaderText = "Asien";

                Dtg.Columns["TipoVehiculo"].Width = 70;
                Dtg.Columns["TipoVehiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["TipoVehiculo"].HeaderText = "Tipo";

                Dtg.Columns["IdTipoVehiculo"].Visible = false;
                Dtg.Columns["IdMarca"].Visible = false;
                Dtg.Columns["Modelo"].Visible = false;
                Dtg.Columns["Estado"].Visible = false;
                Dtg.Columns["IdUsuario"].Visible = false;

                //Dtg.Columns[""].SortMode = DataGridViewColumnSortMode.NotSortable;
                //  Dtg.Columns["CodigoAlterno"].DefaultCellStyle.Format = "dd/MM/yyyy"  or  "#,##0.00";

                Dtg.Dock = DockStyle.None;
                Dtg.BorderStyle = BorderStyle.FixedSingle;

                Dtg.AllowUserToAddRows = false;
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

        //Cargamos los vehiculos existentes
        private void ConfigurarGrilla()
        {
            DtVehiculo = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.Vehiculo V INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.TipoVehiculo TP ON V.IdTipoVehiculo=TP.IdTipoVehiculo";
            Campos = "IdVehiculo,Vehiculo,Placa,V.IdTipoVehiculo,TP.TipoVehiculo,Asientos,IdMarca,Modelo,V.Estado,IdUsuario";
            Condicion = "V.Estado=1";
            DtVehiculo = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            DtgVehiculo.DataSource = DtVehiculo;
            Conf_DtgRuta(DtgVehiculo);
        }

        //Cargamos todo los combos del formulario
        private void CargarCombos()
        {
            miMt.CargarCombo(cboEstado);

            //Tipo vehiculo
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.TipoVehiculo", "TipoVehiculo", "IdTipoVehiculo", "Estado=1",
                             "IdTipoVehiculo", cboTipo, (int)miCN.S);

            //Marcas
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Marca", "Marca", "IdMarca", "Estado=1",
                          "IdMarca", cboMarca, (int)miCN.S);
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

        //Validamos datos antes de ingresar o actualizar datos
        private void Validar()
        {
            TodoOk = false;
            Valores = "";
            if (txtCodigo.TextLength == 0)
            {
                MessageBox.Show("No ha seleccionado el Vehiculo a modificar", "<Translinea Software>",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(txtAsientos.Text)>42)
            {
                MessageBox.Show("No puede ingresar vehiculos con mayor de 42 Puestos", "<Translinea Software>",
                  System.Windows.Forms.MessageBoxButtons.OK,
                  System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            //Tipo
            if (cboTipo.Text.Length != 0)
            {
                Valores = Valores + cboTipo.SelectedValue + ",";
                Actualizar = "IdTipoVehiculo=" + cboTipo.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de Vehiculo", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                cboTipo.Focus();
                return;
            }

            //Vehiculo
            if (txtVehiculo.TextLength != 0)
            {
                Valores = Valores + "'" + txtVehiculo.Text + "',";
                Actualizar = Actualizar + ",Vehiculo='" + txtVehiculo.Text + "'";
            }
            else
            {
                MessageBox.Show("Ingrese el nombre Vehiculo", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                txtVehiculo.Focus();
                return;
            }

            //Placa
            if (txtPlaca.TextLength != 0)
            {
                Valores = Valores + "'" + txtPlaca.Text + "',";
                Actualizar = Actualizar + ",Placa='" + txtVehiculo.Text + "'";
            }
            else
            {
                MessageBox.Show("Ingrese la Placa", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                txtPlaca.Focus();
                return;
            }

            //Asientos
            if (txtAsientos.TextLength != 0)
            {
                Valores = Valores + txtAsientos.Text + ",";
                Actualizar = Actualizar + ",Asientos=" + txtAsientos.Text + "";
            }
            else
            {
                MessageBox.Show("Ingrese el numero de asientos del Vehiculo", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                txtAsientos.Focus();
                return;
            }

            //Marca
            if (cboMarca.Text.Length != 0)
            {
                Valores = Valores + cboMarca.SelectedValue + ",";
                Actualizar = Actualizar + ",IdMarca=" + cboMarca.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione la marca del Vehiculo", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                cboMarca.Focus();
                return;
            }

            //Modelo
            if (txtModelo.Text.Length != 0)
            {
                Valores = Valores + "" + txtModelo.Text + ",";
                Actualizar = Actualizar + ",Modelo='" + txtModelo.Text + "'";
            }
            else
            {
                MessageBox.Show("Ingrese el modelo del Vehiculo", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                txtModelo.Focus();
                return;
            }

            //Estado
            if (cboEstado.Text.Length != 0)
            {
                Valores = Valores + cboEstado.SelectedValue + ",";
                Actualizar = Actualizar + ",Estado=" + cboEstado.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Seleccione el Estado", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                cboEstado.Focus();
                return;
            }

            //Usuario
            Valores = Valores + GlobalVar.IdUsuario + ",";
            Actualizar = Actualizar + ",IdUsuario=" + GlobalVar.IdUsuario + "";

            //Fecha sistema
            Valores = Valores + "GETDATE()";
            Actualizar = Actualizar + ",FechaDeSistema=GETDATE()";

            TodoOk = true;
        }

        //Bloqueamos botones
        private void BloquearDesbloquear()
        {
            if (miProceso == (int)Bandera.n)
            {
                miMt.BloquearControles(pnlCajas, true);
                miMt.BloquearControles(pnlCajas, true);
            }
            else
            {
                miMt.BloquearControles(pnlCajas, false);
                miMt.BloquearControles(pnlCajas, false);
            }
            txtCodigo.ReadOnly = true;
        }

        private void BloquearDesbloquearBotones()
        {
            if (miProceso == (int)Bandera.n)
            {

            }
            else
            {
                if (miProceso == (int)Bandera.a)
                {
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

        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.a;
            miMt.LimpiarFormularioGeneral(this);
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton guardar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            Validar();
            if (TodoOk == true)
            {
                try
                {
                    GlobalVar.TodoOk = true;
                    if (miProceso == (int)Bandera.a)
                    {
                        miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Vehiculo", "IdVehiculo", (int)miCN.S);
                        txtCodigo.Text = Convert.ToString(miMax);
                        Campos = "IdVehiculo,IdTipoVehiculo,Vehiculo,Placa,Asientos,IdMarca,Modelo,Estado,IdUsuario,FechaDeSistema";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.Vehiculo", Campos, miMax + "," + Valores, (int)miCN.S);

                        if (GlobalVar.TodoOk == true)
                        {
                            MessageBox.Show("Vehiculo creado correctamente", "<Translinea Software>",
                                  System.Windows.Forms.MessageBoxButtons.OK,
                                  System.Windows.Forms.MessageBoxIcon.Information);
                            ConfigurarGrilla();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al tratar de guardar el Registro", "<Translinea Software>",
                                 System.Windows.Forms.MessageBoxButtons.OK,
                                 System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                    else if (miProceso == (int)Bandera.m)
                    {
                        miSql.Actualizar(GlobalVar.BDServidor + "dbo.Vehiculo", Actualizar, "IdVehiculo=" + txtCodigo.Text + "",
                                        (int)miCN.S);
                        if (GlobalVar.TodoOk == true)
                        {
                            MessageBox.Show("Vehiculo actualizado correctamente", "<Translinea Software>",
                                  System.Windows.Forms.MessageBoxButtons.OK,
                                  System.Windows.Forms.MessageBoxIcon.Information);
                            ConfigurarGrilla();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al tratar de actualizar el Registro", "<Translinea Software>",
                                 System.Windows.Forms.MessageBoxButtons.OK,
                                 System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error " + ex + "", "<Translinea Software>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        //Boton buscar
        private void bttnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {

            miProceso = (int)Bandera.m;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton Salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Eventos
        //Valido si el valor corresponde al item del combo
        private void cboTipo_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboTipo.SelectedValue) == 0)
                {
                    cboTipo.SelectedValue = 0;
                    cboTipo.Text = "";
                }
            }
        }
        //Convierto letras a Mayusculas
        private void txtVehiculo_Leave(object sender, EventArgs e)
        {
            txtVehiculo.Text = txtVehiculo.Text.ToUpper();
        }
        //Convierto letras a Mayusculas
        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            txtPlaca.Text = txtPlaca.Text.ToUpper();
        }
        //Convierto letras a Mayusculas
        private void txtModelo_Leave(object sender, EventArgs e)
        {
            txtModelo.Text = txtModelo.Text.ToUpper();
        }
        //Valido si el valor corresponde al item del combo
        private void cboEstado_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboEstado.SelectedValue) == 0)
                {
                    cboEstado.SelectedValue = 0;
                    cboEstado.Text = "";
                }
            }
        }
        //Valido si el valor corresponde al item del combo
        private void cboMarca_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (Convert.ToInt32(cboMarca.SelectedValue) == 0)
                {
                    cboMarca.SelectedValue = 0;
                    cboMarca.Text = "";
                }
            }
        }
        //Valido solo Letras y no permito caracteres especiales
        private void txtVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }
        //Valido solo Letras y no permito caracteres especiales
        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }
        //Valido solo numeros
        private void txtAsientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }
        //Valido solo Letras y no permito caracteres especiales
        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }
        #endregion

        //Evento enlaza grilla con las cajas
        private void DtgVehiculo_SelectionChanged(object sender, EventArgs e)
        {
            if (miProceso == (int)Bandera.m)
            {
                txtCodigo.Text = Convert.ToString(DtgVehiculo.CurrentRow.Cells["IdVehiculo"].Value);
                cboTipo.SelectedValue = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["IdTipoVehiculo"].Value);
                txtVehiculo.Text = Convert.ToString(DtgVehiculo.CurrentRow.Cells["Vehiculo"].Value);
                txtPlaca.Text = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["Placa"].Value);
                txtPlaca.Text = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["Placa"].Value);
                txtAsientos.Text = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["Asientos"].Value);
                cboMarca.SelectedValue = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["IdMarca"].Value);
                txtModelo.Text = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["Modelo"].Value);
                cboEstado.SelectedValue = Convert.ToString(DtgVehiculo.Rows[DtgVehiculo.CurrentRow.Index].Cells["Estado"].Value);
            }
        }
    }
}
