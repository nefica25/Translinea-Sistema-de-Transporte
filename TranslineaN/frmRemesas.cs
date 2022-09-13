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
using System.Transactions;

namespace TranslineaN
{
    public partial class frmRemesas : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Tabla, Campos, Condicion;
        String Valores, CamposActualizar;
        DataTable DtCliente, DtRemesa;
        Boolean TodoOk;
        int miMax, miMaxDetalle, CodigoRemesa;
        int IdCliente, IdClienteDest;

        long miProceso;

        public frmRemesas()
        {
            InitializeComponent();
        }

        private void frmRemesas_Load(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.n;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Pintar formulario
        private void frmRemesas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturar teclas
        private void frmRemesas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["CodigoRemesa"].Width = 90;
                Dtg.Columns["CodigoRemesa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["CodigoRemesa"].HeaderText = "Codigo";

                Dtg.Columns["ClienteDestino"].Width = 200;
                Dtg.Columns["ClienteDestino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["ClienteDestino"].HeaderText = "Cliente";

                Dtg.Columns["Recorrido"].Width = 176;
                Dtg.Columns["Recorrido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Recorrido"].HeaderText = "Destino";

                Dtg.Columns["NumPiezas"].Width = 91;
                Dtg.Columns["NumPiezas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["NumPiezas"].HeaderText = "Num Piezas";

                Dtg.Columns["PrecioFlete"].Width = 100;
                Dtg.Columns["PrecioFlete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["PrecioFlete"].HeaderText = "Valor Flete";
                Dtg.Columns["PrecioFlete"].DefaultCellStyle.Format = "#,##0.00";

                Dtg.Columns["TotalPrecio"].Width = 100;
                Dtg.Columns["TotalPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["TotalPrecio"].HeaderText = "Total Precio";
                Dtg.Columns["TotalPrecio"].DefaultCellStyle.Format = "#,##0.00";

                //Dtg.Columns["FechaVenta"].Width = 80;
                //Dtg.Columns["FechaVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //Dtg.Columns["FechaVenta"].HeaderText = "Fecha";
                //Dtg.Columns["FechaVenta"].ReadOnly = true;
                //Dtg.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";

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

        //Cargarmos informacion de la grilla
        private void ConfigurarGrilla()
        {
            DtRemesa = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.zRemesasDetalle";
            Campos = "CodigoRemesa,ClienteDestino,Recorrido,NumPiezas,PrecioFlete,TotalPrecio";
            Condicion = "IdRemesaDetalle=0";

            DtRemesa = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            DtgRemesas.DataSource = DtRemesa;
            Conf_DtgRuta(DtgRemesas);
        }

        //Cargar combos
        private void CargarCombos()
        {
            //Cargamos ciudad origen
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboOrigen, (int)miCN.S);
            //Cargamos Ciudad Destino
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboDestino, (int)miCN.S);

            //Cargamos tipo remesa, sobre,caja,paquete
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.TipoRemesa", "TipoRemesa", "IdTipoRemesa", "Estado=1", "IdTipoRemesa", cboTipoRemesa, (int)miCN.S);

            CargarCombo(cboTipo);
        }

        //Cargamos un Combo desconectado Tipo remesa a realizar
        public void CargarCombo(ComboBox cbo)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Descripcion");

            DataRow row = dt.NewRow();
            row["Id"] = 1;
            row["Descripcion"] = "REMESA";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Id"] = 2;
            row["Descripcion"] = "FURGON";
            dt.Rows.Add(row);

            cbo.DataSource = dt;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "Id";
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
                miMt.BloquearControles(pnlCajas1, true);
                miMt.BloquearControles(pnlContenido, true);
                miMt.BloquearControles(pnlDestino, true);
                miMt.BloquearControles(pnlOrigen, true);
                miMt.BloquearControles(pnlPrecios, true);
            }
            else
            {
                miMt.BloquearControles(pnlCajas1, false);
                miMt.BloquearControles(pnlContenido, false);
                miMt.BloquearControles(pnlDestino, false);
                miMt.BloquearControles(pnlOrigen, false);
                miMt.BloquearControles(pnlPrecios, false);
            }
            txtCodigo.ReadOnly = true;
            txtNombresOrig.ReadOnly = true;
            txtTelOrig.ReadOnly = true;
            txtDireccionOrig.ReadOnly = true;
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

        //Validamos datos antes de Guardar
        private void ValidarDatos()
        {
            TodoOk = false;

            if (cboOrigen.Text.Length == 0)
            {
                MessageBox.Show("Seleccione la Ciudad origen de la Agencia", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                cboOrigen.Focus();
                return;
            }
            else if (cboDestino.Text.Length == 0)
            {
                MessageBox.Show("Seleccione el Destino", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                cboDestino.Focus();
                return;
            }
            else if (cboRecorrido.Text.Length == 0)
            {
                MessageBox.Show("Seleccione el Recorrido", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                cboRecorrido.Focus();
                return;
            }
            if (txtDocumentoOrig.TextLength == 0)
            {
                MessageBox.Show("Ingrese el número de Documento del Remitente", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                txtDocumentoOrig.Focus();
                return;
            }
            else if (txtDocumentoDest.TextLength == 0)
            {
                MessageBox.Show("Ingrese el número del documento del Destinatario", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                txtDocumentoDest.Focus();
                return;
            }
            else if (txtNombresDest.TextLength == 0)
            {
                MessageBox.Show("Ingrese el nombre del Destinatario", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                txtNombresDest.Focus();
                return;
            }
            else if (txtTelDest.TextLength == 0)
            {

                MessageBox.Show("Ingrese el Telefono del Destinatario", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                txtTelDest.Focus();
                return;
            }
            else if (cboTipoRemesa.Text.Length == 0)
            {
                MessageBox.Show("Seleccione el tipo de Encomienda a Enviar", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                cboTipoRemesa.Focus();
                return;
            }
            else if (txtContenido.TextLength == 0)
            {
                MessageBox.Show("Ingrese el contenido de la Remesa", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtContenido.Focus();
                return;
            }
            else if (cboTipo.Text.Length == 0)
            {
                MessageBox.Show("Seleccione el Tipo a facturar", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                cboTipo.Focus();
                return;
            }

            //Valores
            if (txtPeso.TextLength == 0)
            {
                txtPeso.Text = "0";
            }

            //Valor Seguro
            if (txtValorSeguro.TextLength == 0)
            {
                MessageBox.Show("Ingrese el Valor a segurar", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtValorSeguro.Focus();
                return;
            }

            //Seguro
            if (txtSeguro.TextLength == 0)
            {
                MessageBox.Show("Por favor Calcule el total del Seguro", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtValorSeguro.Focus();
                return;
            }

            //Numero de Piezas
            if (txtNumPiezas.TextLength == 0)
            {
                MessageBox.Show("Ingrese el número de Piezas", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtNumPiezas.Focus();
                return;
            }

            //Reexpedicón
            if (txtReex.TextLength == 0)
            {
                txtReex.Text = "0";
            }

            //Valor Flete
            if (txtValorFlete.TextLength == 0)
            {
                MessageBox.Show("Ingreser por favor el Valor del Flete", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtValorFlete.Focus();
                return;
            }

            //Valor total
            if (txtValorTotal.TextLength == 0)
            {
                MessageBox.Show("No se puede enviar una encomienda si no se ha generado un Valor Total", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtValorFlete.Focus();
                return;
            }
            else if (txtValorTotal.Text=="0")
            {
                  MessageBox.Show("Estas seguro de Enviar una Remesas con Valor de Cero", "<Translinea Software>",
                                 System.Windows.Forms.MessageBoxButtons.YesNo,
                                 System.Windows.Forms.MessageBoxIcon.Exclamation);
            }

            TodoOk = true;
        }

        //Boton adicionar
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miMt.LimpiarFormularioGeneral(this);
            CargarCombos();
            miProceso = (int)Bandera.a;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();

            ConfigurarGrilla();

            //Cargamos el combo en Value se encuentra dependiendo de la Sucursal donde esta Ubicada en la Ciudad

        }

        //boton Guradar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            ValidarDatos();

            if (TodoOk == true)
            {
                using (TransactionScope miTransaccion = new TransactionScope())
                {
                    try
                    {
                        GlobalVar.TodoOk = true;

                        if (miProceso == (int)Bandera.a)
                        {
                            //Si solo ingreso un solo Registro
                            if (DtgRemesas.Rows.Count == 0)
                            {
                                //Ingresamos Remesas
                                CodigoRemesa = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos", "Serie", "IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal +
                                               " AND Proceso='ENCOMIENDAS'", (int)miCN.S);

                                miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Remesas", "IdRemesa", (int)miCN.S);
                                Campos = "IdRemesa,CodigoRemesa,IdCliente,Tipo,IdTipoRemesa,IdAgenciaSucursal, " +
                                         "FechaVenta,HoraVenta,FechaDeSistema,IdUsuario,Estado";
                                Valores = miMax + "," + CodigoRemesa + "," + IdCliente + "," + cboTipo.SelectedValue + "," + cboTipoRemesa.SelectedValue +
                                          "," + GlobalVar.AgenciaSucursal + ",GETDATE(),'" + DateTime.Now.Hour + "',GETDATE()," + GlobalVar.IdUsuario +
                                          ",1";

                                miSql.Guardar(GlobalVar.BDServidor + "dbo.Remesas", Campos, Valores, (int)miCN.S);

                                //Ingresamos Remesas Detalle
                                Campos = "IdRemesaDetalle,CodigoRemesa,IdCliente,IdClienteDestino,IdDomicilio,IdOrigen,IdDestino, " +
                                         "IdRecorrido,Recorrido,ClienteDestino,NumPiezas,ValorSeguro,Seguro,Reex,Domicilio,PrecioFlete, " +
                                         "TotalPrecio,Contenido,Peso,Ubicacion";
                                Valores = miMaxDetalle + "," + CodigoRemesa + "," + IdCliente + "," + IdClienteDest + ",0," + cboOrigen.SelectedValue +
                                          "," + cboDestino.SelectedValue + "," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" + txtNombresDest.Text +
                                          "'," + txtNumPiezas.Text + "," + txtValorSeguro.Text + "," + txtSeguro.Text + "," + txtReex.Text + "," + 0 +
                                          "," + txtValorFlete.Text + "," + txtValorTotal.Text + ",'" + txtContenido.Text + "'," + txtPeso.Text + ",0";
                                miMaxDetalle = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.RemesasDetalle", "IdRemesaDetalle", (int)miCN.S);

                                miSql.Guardar(GlobalVar.BDServidor + "dbo.RemesasDetalle", Campos, Valores, (int)miCN.S);

                            }
                            //Si adiciono mas de un Registro que se encuentra Aidcionado en la Grilla
                            else if (DtgRemesas.Rows.Count > 0)
                            {

                            }

                            if (GlobalVar.TodoOk == true)
                            {
                                miTransaccion.Complete();
                                MessageBox.Show("Registro ingresado Correctamente", "<Translinea Software>",
                                               System.Windows.Forms.MessageBoxButtons.OK,
                                               System.Windows.Forms.MessageBoxIcon.Information);
                            }
                        }
                        else if (miProceso == (int)Bandera.m)
                        {
                            CamposActualizar = ".";

                            if (GlobalVar.TodoOk == true)
                            {
                                miTransaccion.Complete();
                                MessageBox.Show("Registro actualizado Correctamente", "<Translinea Software>",
                                               System.Windows.Forms.MessageBoxButtons.OK,
                                               System.Windows.Forms.MessageBoxIcon.Information);
                            }
                        }

                        if (GlobalVar.TodoOk == false)
                        {
                            MessageBox.Show("Ocurrio un error al tratar de enviar los datos", "<Translinea Software>",
                                           System.Windows.Forms.MessageBoxButtons.OK,
                                           System.Windows.Forms.MessageBoxIcon.Error);
                            miTransaccion.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        miTransaccion.Dispose();
                        throw;
                    }
                }
            }
        }

        //Boton Cancelar
        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.m;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton Cancelar
        private void bttnBuscar_Click(object sender, EventArgs e)
        {

        }

        //Boton Imprimir
        private void bttnImprimir_Click(object sender, EventArgs e)
        {

        }

        //Boton Salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Eventos

        //Validamos tipo Remesa a generar
        private void cboTipo_Leave(object sender, EventArgs e)
        {

        }

        //Ciudad Origen
        private void cboOrigen_Leave(object sender, EventArgs e)
        {
            if (cboOrigen.Text.Length == 0)
            {
                cboOrigen.SelectedValue = 0;
                cboOrigen.Text = "";
            }
        }

        //Ciudad Destino
        private void cboDestino_Leave(object sender, EventArgs e)
        {
            if (cboDestino.Text.Length == 0)
            {
                cboDestino.SelectedValue = 0;
                cboDestino.Text = "";
            }
        }

        //Tipo de Remesa o producto a enviar
        private void cboTipoRemesa_Leave(object sender, EventArgs e)
        {
            if (cboTipoRemesa.Text.Length == 0)
            {
                cboTipoRemesa.SelectedValue = 0;
                cboTipoRemesa.Text = "";
            }
        }

        //Validar Nombres Destino
        private void txtNombresDest_Leave(object sender, EventArgs e)
        {
            txtNombresDest.Text = txtNombresDest.Text.ToUpper();
        }

        //Validar solo numeros Documento Origen
        private void txtDocumentoOrig_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar solo numero Documento Destino
        private void txtDocumentoDest_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar mayusculas Dirección destino
        private void txtDireccionDest_Leave(object sender, EventArgs e)
        {
            txtDireccionDest.Text = txtDireccionDest.Text.ToUpper();
        }

        //Validar solo números telefono destino
        private void txtTelDest_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar mayusculas contenido remesa
        private void txtContenido_Leave(object sender, EventArgs e)
        {
            txtContenido.Text = txtContenido.Text.ToUpper();
        }

        //Validar solo letras y no permitir caracteres alfanuméricos
        private void txtContenido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        //Validar solo numeros peso
        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar solo numero seguro
        private void txtSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar solo números numero de piezas a enviar
        private void txtNumPiezas_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar solo numeros Reexpedición
        private void txtReex_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar solo numeros Flete
        private void txtValorFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validar solo numero Valor Total
        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        #endregion

        //Cargamos el recorrido segun el Destino
        private void cboDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n)
            {
                if (cboDestino.DropDownStyle != ComboBoxStyle.Simple && cboDestino.Text.Length != 0)
                {

                    //Cargamos combo Recorrido
                    miSql.CargarCombo(GlobalVar.BDServidor + "dbo.CiudadRecorrido", "Recorrido", "IdRecorrido",
                                     "Estado=1 AND IdDestino=" + cboDestino.SelectedValue + " AND IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "",
                                     "IdRecorrido", cboRecorrido, (int)miCN.S);

                    //Si no cargo recorrido la Ruta se Limpian las Cajas
                    if (Convert.ToInt32(cboRecorrido.SelectedValue) == 0)
                    {
                        MessageBox.Show("No se encontraron Recorrido Desde " + cboOrigen.Text + " hacia " + cboDestino.Text + "", "<Translinea Software>",
                                        System.Windows.Forms.MessageBoxButtons.OK,
                                        System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
            }
        }

        //Validamos si es cliente lo Cargamos
        private void txtDocumentoOrig_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n && txtDocumentoOrig.TextLength != 0)
            {
                DtCliente = new DataTable();
                Tabla = GlobalVar.BDServidor + "dbo.Clientes"; ;
                Campos = "IdCliente,NombreCompleto,Direccion,Celular";
                Condicion = "NroDocumento=" + txtDocumentoOrig.Text + "";

                DtCliente = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

                if (DtCliente.Rows.Count > 0)
                {
                    IdCliente = Convert.ToInt32(DtCliente.Rows[0]["IdCliente"]);
                    txtNombresOrig.Text = Convert.ToString(DtCliente.Rows[0]["NombreCompleto"]);
                    txtDireccionOrig.Text = Convert.ToString(DtCliente.Rows[0]["Direccion"]);
                    txtTelOrig.Text = Convert.ToString(DtCliente.Rows[0]["Celular"]);
                }
                else
                {
                    txtDocumentoOrig.Clear();
                }
            }
        }

        //Validamos si es cliente y cargamos datos
        private void txtDocumentoDest_Leave(object sender, EventArgs e)
        {
            if (miProceso != (int)Bandera.n && txtDocumentoOrig.TextLength != 0)
            {
                DtCliente = new DataTable();
                Tabla = GlobalVar.BDServidor + "dbo.Clientes"; ;
                Campos = "IdCliente,NombreCompleto,Direccion,Celular";
                Condicion = "NroDocumento=" + txtDocumentoDest.Text + "";

                DtCliente = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

                if (DtCliente.Rows.Count > 0)
                {
                    IdClienteDest = Convert.ToInt32(DtCliente.Rows[0]["IdCliente"]);
                    txtNombresDest.Text = Convert.ToString(DtCliente.Rows[0]["NombreCompleto"]);
                    txtDireccionDest.Text = Convert.ToString(DtCliente.Rows[0]["Direccion"]);
                    txtTelDest.Text = Convert.ToString(DtCliente.Rows[0]["Celular"]);
                }
            }
        }
    }
}
