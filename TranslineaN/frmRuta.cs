using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Transactions;
using System.Drawing.Drawing2D;

namespace TranslineaN
{
    public partial class frmRuta : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Campos,  Valores, CamposConValores;
        Boolean TodoOK;
        DataTable DtRuta, DtBus = new DataTable();
        int miMax, miMaxPuesto;

        public frmRuta()
        {
            InitializeComponent();
        }

        private void frmRuta_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);

            CargarCombos();
            txtCodigo.Text = Convert.ToString(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos", "Serie", "Id=1", (int)miCN.S));
            ConfiguracionGrilla();
        }

        //Pintamos formulario
        private void frmRuta_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        private void frmRuta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{Tab}");
                    break;

                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count > 0)
            {
                Dtg.Columns["IdRuta"].Width = 70;
                Dtg.Columns["IdRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdRuta"].HeaderText = "Codigo";

                Dtg.Columns["FechaRuta"].Width = 80;
                Dtg.Columns["FechaRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["FechaRuta"].HeaderText = "Fecha";
                Dtg.Columns["FechaRuta"].ReadOnly = true;
                Dtg.Columns["FechaRuta"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Dtg.Columns["IdOrigen"].Width = 110;
                Dtg.Columns["IdOrigen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdOrigen"].HeaderText = "Origen";

                Dtg.Columns["Destino"].Width = 110;
                Dtg.Columns["Destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Destino"].HeaderText = "Destino";

                Dtg.Columns["IdVehiculo"].Width = 80;
                Dtg.Columns["IdVehiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdVehiculo"].HeaderText = "Vehiculo";

                Dtg.Columns["HoraRuta"].Width = 80;
                Dtg.Columns["HoraRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["HoraRuta"].HeaderText = "Hora";

                Dtg.Columns["ValorTiquete"].Width = 98;
                Dtg.Columns["ValorTiquete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["ValorTiquete"].HeaderText = "Valor";
                Dtg.Columns["ValorTiquete"].DefaultCellStyle.Format = "#,##0.00";

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

        private void CargarCombos()
        {
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Hora", "Hora", "IdHora", "Estado=1", "IdHora", cboHora, (int)miCN.S);
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboOrigen, (int)miCN.S);
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboDestino, (int)miCN.S);
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Vehiculo", "Vehiculo", "IdVehiculo", "Estado=1 AND IdTipoVehiculo=1", "IdVehiculo", cboVehiculo, (int)miCN.S);
            cboVehiculo.SelectedValue = 0;
        }

        //Cargamos datos de la configuracion de la Grilla
        private void ConfiguracionGrilla()
        {
            DtRuta = new DataTable();
            DtRuta = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.Ruta", "IdRuta,FechaRuta,IdOrigen,Destino,IdVehiculo,HoraRuta,ValorTiquete",
                                    "Estado=1 AND FechaRuta='" + Convert.ToDateTime(mcFecha.SelectionStart).ToShortDateString() + "'", (int)miCN.S);
            DtgRuta.DataSource = DtRuta;
            Conf_DtgRuta(DtgRuta);
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

        //Validamos los datos antes de guardar
        private void ValidarDatos()
        {
            TodoOK = false;
            CamposConValores = "";
            Valores = "";

            if (Convert.ToUInt32(cboOrigen.SelectedValue) == Convert.ToInt32(cboDestino.SelectedValue))
            {
                MessageBox.Show("La ruta a crear el Destino no debe tener el mismo Origen", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            //Campos = "IdRuta";
            //Condicion = "IdEstado=1 AND IdRuta<>" + txtCodigo.Text + " AND Ruta<>'" + cboDestino.Text + "'";
            //DtRuta = new DataTable();
            //DtRuta = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.Ruta", Campos, Condicion, (int)miCN.S);

            //if (DtRuta.Rows.Count > 0)
            //{

            //}
            //else
            //{

            //}

            //Hora Ruta
            if (Convert.ToInt32(cboHora.SelectedValue) != 0)
            {
                Valores = Valores + "'" + cboHora.Text + "',";
                CamposConValores = CamposConValores + "HoraRuta='" + cboHora.Text + "'";
            }
            else
            {
                MessageBox.Show("Debes seleccionar la Hora", "Translinea Software",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOK = false;
                cboHora.Focus();
                return;
            }

            //Origen
            if (Convert.ToInt32(cboOrigen.SelectedValue) != 0)
            {
                Valores = Valores + cboOrigen.SelectedValue + ",";
                CamposConValores = CamposConValores + ",IdOrigen=" + cboOrigen.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Debes seleccionar el Origen de la Ruta", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOK = false;
                cboOrigen.Focus();
                return;
            }

            //Destino
            if (Convert.ToInt32(cboDestino.SelectedValue) != 0)
            {
                Valores = Valores + cboDestino.SelectedValue + ",";
                Valores = Valores + "'" + cboDestino.Text + "',";
                CamposConValores = CamposConValores + ",IdDestino='" + cboDestino.SelectedValue + "'";
                CamposConValores = CamposConValores + ",Destino='" + cboDestino.Text + "'";
            }
            else
            {
                MessageBox.Show("Debes seleccionar el Destino de la Ruta", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOK = false;
                cboDestino.Focus();
                return;
            }

            //Valor
            if (txtValor.Text.Length != 0)
            {
                Valores = Valores + txtValor.Text + ",";
                CamposConValores = CamposConValores + ",ValorTiquete=" + txtValor.Text + "";
            }
            else
            {
                MessageBox.Show("Debes ingresar el valor del Tiquete", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOK = false;
                txtValor.Focus();
                return;
            }

            //Bus
            if (Convert.ToInt32(cboVehiculo.SelectedValue) != 0)
            {
                Valores = Valores + cboVehiculo.SelectedValue + ",";
                CamposConValores = CamposConValores + ",IdVehiculo=" + cboVehiculo.SelectedValue + "";
            }
            else
            {
                MessageBox.Show("Debe seleccionar el Vehiculo", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOK = false;
                cboVehiculo.Focus();
                return;
            }

            //Reexpedicion
            if (txtReex.Text.Length != 0)
            {
                Valores = Valores + txtReex.Text + ",";
                CamposConValores = CamposConValores + ",Reexpedicion=" + txtReex.Text + "";
            }
            else
            {
                Valores = Valores + "0,";

            }

            //Valor minimo a vender el tiquete
            if (txtValorMin.Text.Length != 0)
            {
                Valores = Valores + txtValorMin.Text + ",";
                CamposConValores = CamposConValores + ",ValorMinimo=" + txtValorMin.Text + "";
            }
            else
            {
                Valores = Valores + "0,";
            }

            //Comision del revoleador
            if (txtComision.Text.Length != 0)
            {
                Valores = Valores + txtComision.Text + ",";
                CamposConValores = CamposConValores + ",Revolero=" + txtComision.Text + "";
            }
            else
            {
                Valores = Valores + "0,";
            }

            //Estampilla
            if (txtEstampilla.Text.Length != 0)
            {
                Valores = Valores + txtEstampilla.Text + ",";
                CamposConValores = CamposConValores + ",Estampilla=" + txtEstampilla.Text + "";
            }
            else
            {
                Valores = Valores + "0,";
            }

            //IdAgenciaSucursal
            Valores = Valores + GlobalVar.AgenciaSucursal + ",";

            //Fecha Ruta
            Valores = Valores + "'" + Convert.ToDateTime(mcFecha.SelectionStart).ToShortDateString() + "',";

            Valores = Valores + "0,0,0,0,0,0,1,GETDATE(),1";

            TodoOK = true;
        }

        private void bttnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            ValidarDatos();
            GlobalVar.TodoOk = true;

            try
            {
                using (TransactionScope Transaccion = new TransactionScope())
                {
                    if (TodoOK == true)
                    {
                        //Cargamos el consecutivo
                        miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Ruta", "IdRuta", (int)miCN.S);

                        //Guardamos la ruta creada
                        Campos = "IdRuta,HoraRuta,IdOrigen,IdDestino,Destino,ValorTiquete,IdVehiculo,Reexpedicion,ValorMinimo,Revolero, " +
                                 "Estampilla,IdAgenciaSucursal,FechaRuta,TotalTiquetes,TotalEncomiendas,TotalRT,TotalRE,TotalEfectivoT, " +
                                 "TotalEfectivoE,IdUsuario,FechDeSistema,Estado";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.Ruta", Campos, miMax + "," + Valores, (int)miCN.S);

                        //Creamos la ruta con los puestos activos para Vender
                        for (int i = 1; i <= Convert.ToInt32(txtPuesto.Text); i++)
                        {
                            miMaxPuesto = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", "IdRutaVehiculo", (int)miCN.S);
                            Campos = "IdRutaVehiculo,IdRuta,IdVehiculo,Puesto,Estado,FechaDeSistema";
                            miSql.Guardar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", Campos,
                                         miMaxPuesto + "," + miMax + "," + cboVehiculo.SelectedValue + "," + i + ",1,GETDATE()",
                                         (int)miCN.S);
                        }

                        //Actualizamos la Grilla con la nueva ruta creada
                        ConfiguracionGrilla();

                        if (GlobalVar.TodoOk == true)
                        {
                            MessageBox.Show("Ruta creada correctamente", "<Translinea Software>",
                                            System.Windows.Forms.MessageBoxButtons.OK,
                                            System.Windows.Forms.MessageBoxIcon.Information);
                            Transaccion.Complete();
                            TodoOK = false;
                            miMt.LimpiarFormularioGeneral(this);
                        }
                        else
                        {
                            Transaccion.Dispose();
                            MessageBox.Show("Ocurrio un Error al Crear la Ruta", "<Translinea Software>",
                                            System.Windows.Forms.MessageBoxButtons.OK,
                                            System.Windows.Forms.MessageBoxIcon.Error);
                            TodoOK = false;
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Region Validar solo numeros
        private void txtReex_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtValorMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtEstampilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }
        #endregion

        private void cboBus_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboVehiculo.SelectedValue) == 0)
            {
                cboVehiculo.SelectedValue = 0;
                cboVehiculo.Text = "";
            }
            else
            {
                DtBus = new DataTable();
                DtBus = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.Vehiculo", "Asientos", "IdVehiculo=" + cboVehiculo.SelectedValue +
                      "", (int)miCN.S);

                if (DtBus.Rows.Count > 0)
                {
                    txtPuesto.Text = Convert.ToString(DtBus.Rows[0][0]);
                }
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtValor.Text.Length != 0)
            {
                //txtValor.Text = Convert.ToDecimal(txtValor.Text).ToString("c");
            }
        }

        //Mostramos y convertimos las celdas origen y destino en campo Nombre de la Ciudad
        private void DtgRuta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        //Cargamos ruta creadas al Seleccionar fecha
        private void mcFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            ConfiguracionGrilla();
        }

        private void cboOrigen_Leave(object sender, EventArgs e)
        {
            if (cboOrigen.DropDownStyle != ComboBoxStyle.Simple)
            {
                if (Convert.ToInt32(cboOrigen.SelectedValue) == 0)
                {
                    cboOrigen.SelectedValue = 0;
                    cboOrigen.Text = "";
                }
            }
        }

        private void cboDestino_Leave(object sender, EventArgs e)
        {
            if (cboDestino.DropDownStyle != ComboBoxStyle.Simple)
            {
                if (Convert.ToInt32(cboDestino.SelectedValue) == 0)
                {
                    cboDestino.SelectedValue = 0;
                    cboDestino.Text = "";
                }
            }
        }

        private void cboHora_Leave(object sender, EventArgs e)
        {
            if (cboHora.DropDownStyle != ComboBoxStyle.Simple)
            {
                if (Convert.ToInt32(cboHora.SelectedValue) == 0)
                {
                    cboHora.SelectedValue = 0;
                    cboHora.Text = "";
                }
            }
        }

        private void mcFecha_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
             
    }
}
