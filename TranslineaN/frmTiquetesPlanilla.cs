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

namespace TranslineaN
{
    public partial class frmTiquetesPlanilla : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        DataTable DtRuta, DtParametrizar, DtAsiento;
        DataTable DtArqueo;
        String Tabla, Campos, Condicion, Valores;
        String TablaInsert, TablaSelect, CamposInsert, CamposSelect;
        Double Descuento, Otro, ValorNeto;
        int miMax;
        long numPlanilla;

        public frmTiquetesPlanilla()
        {
            InitializeComponent();
        }

        private void frmTiquetesPlanilla_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);

            //Cargamos consecutivo planilla temporalmente  //Pendiente filtrar el Id de la Agencia
            txtNumeroPlanilla.Text = Convert.ToString(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos", "Serie", "Id=1", (int)miCN.S));
        }

        //Pintamos formulario
        private void frmTiquetesPlanilla_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturamo teclas del formulario
        private void frmTiquetesPlanilla_KeyDown(object sender, KeyEventArgs e)
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
        private void Conf_DtgPlanilla(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {//  Campos = "TD.Puesto,TD.NombreCompleto,TD.Destino,TD.PrecioVenta,TD.CodigoTiquete";
                Dtg.Columns["Puesto"].Width = 50;
                Dtg.Columns["Puesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Puesto"].HeaderText = "Puesto";

                Dtg.Columns["CodigoTiquete"].Width = 89;
                Dtg.Columns["CodigoTiquete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["CodigoTiquete"].HeaderText = "Numero";

                Dtg.Columns["NombreCompleto"].Width = 215;
                Dtg.Columns["NombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["NombreCompleto"].HeaderText = "Nombres";

                Dtg.Columns["Recorrido"].Width = 125;
                Dtg.Columns["Recorrido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Recorrido"].HeaderText = "Destino";

                Dtg.Columns["PrecioVenta"].Width = 91;
                Dtg.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["PrecioVenta"].HeaderText = "Valor";
                Dtg.Columns["PrecioVenta"].DefaultCellStyle.Format = "#,##0.00";


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

        private void ConfigurarGrilla()  //Ojo pasar tabla a Local
        {
            DtAsiento = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.zTiquetesDetalle TD INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.zTiquetes T ON T.CodigoTiquete=TD.CodigoTiquete";
            Campos = "TD.Puesto,TD.NombreCompleto,TD.Recorrido,TD.PrecioVenta,TD.CodigoTiquete";
            Condicion = "T.IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + " AND T.IdVendedor=" + GlobalVar.IdUsuario + "";
            DtAsiento = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            DtgPlanilla.DataSource = DtAsiento;
            Conf_DtgPlanilla(DtgPlanilla);
        }

        //Sumar grilla - TotalEstam,TotalReex,Totalseguro,Total Bruto
        private void SumarGrilla()
        {
            DataTable DtSumar = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.zTiquetes T INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.zTiquetesDetalle TD ON T.CodigoTiquete=TD.CodigoTiquete";
            Campos = " SUM(Estampilla) AS TotalEstam,SUM(Reex) AS TotalReex,SUM(PrecioVenta) as TotalBruto, " +
                     " SUM(TotalPrecio)";
            Condicion = "T.IdRuta=" + txtNumRuta.Text + " AND T.IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "";

            DtSumar = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            if (DtSumar.Rows.Count > 0 && Convert.ToString(DtSumar.Rows[0]["TotalBruto"]).Length > 0)
            {
                txtTotalEstam.Text = Convert.ToString(DtSumar.Rows[0]["TotalEstam"]);
                txtTotalReex.Text = Convert.ToString(DtSumar.Rows[0]["TotalReex"]);

                //Llamamos las constantes de la Tabla Parametrizar agencia
                DtParametrizar = new DataTable();
                Tabla = GlobalVar.BDServidor + "dbo.ParametrizarAgencia";
                Campos = "Seguro,DescuentoTiquete,OtroTiquete";
                Condicion = "IdSucursal=" + GlobalVar.AgenciaSucursal + "";
                DtParametrizar = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

                if (DtParametrizar.Rows.Count > 0)
                {
                    txtTotalSeguro.Text = Convert.ToString(Convert.ToDouble(DtgPlanilla.RowCount) *
                                                           Convert.ToDouble(DtParametrizar.Rows[0]["Seguro"]));
                    txtTotalBruto.Text = Convert.ToString(Convert.ToDouble(DtSumar.Rows[0]["TotalBruto"]) -
                                                          Convert.ToDouble(txtTotalSeguro.Text));

                    //Hacemos los calculos para sacar el Valor Neto de la planilla
                    Descuento = Convert.ToDouble(txtTotalBruto.Text) *
                                Convert.ToDouble(DtParametrizar.Rows[0]["DescuentoTiquete"]) / 100;
                    txtTotalDesc.Text = Convert.ToString(Descuento);

                    Otro = Convert.ToDouble(txtTotalBruto.Text) *
                           Convert.ToDouble(DtParametrizar.Rows[0]["OtroTiquete"]) / 100;
                    txtOtro.Text = Convert.ToString(Otro);

                    ValorNeto = Convert.ToDouble(txtTotalBruto.Text) - Convert.ToDouble(txtTotalSeguro.Text) -
                              Descuento - Otro;
                    txtTotalNeto.Text = Convert.ToDecimal(ValorNeto).ToString("c");
                }
                else
                {
                    MessageBox.Show("Falta parametrizar Agencia Num " + GlobalVar.AgenciaSucursal + "", "<Translinea Software>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                miMt.LimpiarFormularioGeneral(this);
                MessageBox.Show("No puede generar planilla porque no ha realizado una Venta", "<Translinea Software>",
                                  System.Windows.Forms.MessageBoxButtons.OK,
                                  System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        private void CargarDatosGenerales()
        {
            DtRuta = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.Ruta R INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.Vehiculo V ON R.IdVehiculo=V.IdVehiculo";
            Campos = "R.IdRuta,R.FechaRuta,R.HoraRuta,V.Vehiculo,V.Placa";
            Condicion = "R.IdRuta=" + txtNumRuta.Text + "";
            DtRuta = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            if (DtRuta.Rows.Count > 0)
            {
                txtFecha.Text = Convert.ToString(Convert.ToDateTime(DtRuta.Rows[0]["FechaRuta"]).ToShortDateString());
                txtHora.Text = Convert.ToString(DtRuta.Rows[0]["HoraRuta"]);
                txtVehiculo.Text = Convert.ToString(DtRuta.Rows[0]["Vehiculo"]);
                txtPlaca.Text = Convert.ToString(DtRuta.Rows[0]["Placa"]);

                //Bajamos tiquetes vendido a la ruta correspondiente     //Ojo Cambiar a Modo Local
                miSql.EliminarTodo(GlobalVar.BDServidor + "dbo.zTiquetes", (int)miCN.S);
                miSql.EliminarTodo(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", (int)miCN.S);

                //Bajamos tiquetes del Servidor a zTiquetes
                TablaInsert = GlobalVar.BDServidor + "dbo.zTiquetes";
                TablaSelect = GlobalVar.BDServidor + "dbo.Tiquetes";
                CamposInsert = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor,FechaVenta,IdVendedor";
                CamposSelect = "0,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor,FechaVenta,IdVendedor";
                Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "";
                miSql.Guardar(TablaInsert, CamposInsert, CamposSelect, TablaSelect, Condicion, (int)miCN.S);

                //Bajamos tiquetesDetalle del Servidor a zTiquetesDetalle
                TablaInsert = GlobalVar.BDServidor + "dbo.zTiquetesDetalle";
                TablaSelect = GlobalVar.BDServidor + "dbo.TiquetesDetalle TD INNER JOIN " +
                              GlobalVar.BDServidor + "dbo.Tiquetes T ON TD.CodigoTiquete=T.CodigoTiquete";
                CamposInsert = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido,NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,TotalPrecio,FechaVenta,IdVendedor";
                CamposSelect = "T.IdRuta,TD.IdTiquete,TD.CodigoTiquete,TD.IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido,NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,TotalPrecio,GETDATE(),T.IdVendedor";
                Condicion = "T.IdRuta=" + txtNumRuta.Text + " AND T.IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "";
                miSql.Guardar(TablaInsert, CamposInsert, CamposSelect, TablaSelect, Condicion, (int)miCN.S);

                //Actualizamos grilla
                ConfigurarGrilla();
                SumarGrilla();
            }
        }

        private void txtObservacion_CursorChanged(object sender, EventArgs e)
        {

        }

        //Cargamos el Destino a generar planilla
        private void txtNumRuta_Leave(object sender, EventArgs e)
        {

            Tabla = GlobalVar.BDServidor + "dbo.Ruta ";
            Campos = "(Destino + ' / ' +  HoraRuta) as Nombre,IdRuta=" +
                     "(Select IdCiudad From " + GlobalVar.BDServidor + "dbo.Ciudad Where IdCiudad=Ruta.IdDestino)";
            Condicion = "IdRuta=" + txtNumRuta.Text + "";

            //Cargamos las Rutas existentes donde se Muestra concatenado el Destino y la Hora
            //Mostramos Destino disponibles 
            miSql.CargarCombo(Tabla, Campos, "Nombre", "IdRuta", Condicion, "IdRuta", cboDestino,
                             (int)miCN.S);

            //Si no existieron rutas asignadas
            if (Convert.ToInt32(cboDestino.SelectedValue) == 0)
            {
                miMt.LimpiarFormularioGeneral(this);
            }
            else
            {
                CargarDatosGenerales();
            }
        }

        private void txtNumeroPlanilla_Leave(object sender, EventArgs e)
        {

        }

        private void bbtnGenerar_Click(object sender, EventArgs e)
        {
            if (DtgPlanilla.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado datos a planillar", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                txtNumRuta.Focus();
                return;
            }
            else if (txtConductor.TextLength == 0)
            {
                MessageBox.Show("Por favor ingrese el nombre del Conductor", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtConductor.Focus();
                return;
            }
            else if (txtObservacion.TextLength == 0)
            {
                MessageBox.Show("Por favor ingrese alguna Observación", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                txtObservacion.Focus();
                return;
            }

            //Verificamos si ya se hizo arqueo y actualizamos
            DtArqueo = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.ArqueoTiRemesa";
            Campos = "IdArqueoTiRemesa,NumPlanillaT";
            Condicion = "IdRuta=" + txtNumRuta.Text + "";
            DtArqueo = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            GlobalVar.TodoOk = true;
            if (DtArqueo.Rows.Count > 0)
            {
                txtNumeroPlanilla.Text=Convert.ToString(DtArqueo.Rows[0]["NumPlanillaT"]);

                //Actualizamos ArqueoTiRemesa
                Valores = "TotalBrutoT=" + txtTotalBruto.Text + ",TotalEstampilla=" + txtTotalEstam.Text + ",TotalReexT=" + txtTotalReex.Text +
                          ",TotalSeguroT=" + txtTotalSeguro.Text + ",TotalNetoT=" + ValorNeto + ",Observacion='" + txtObservacion.Text + "'";
                Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "";
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.ArqueoTiRemesa", Valores, Condicion, (int)miCN.S);

                MessageBox.Show("La Ruta numero: " + txtNumRuta.Text + " Destino: " + cboDestino.Text +
                                "ya se encuentra generada la Planilla", "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);

                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Planilla actualizada Correctamente", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al actualizar", "<Translinea Software>",
                                  System.Windows.Forms.MessageBoxButtons.OK,
                                  System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            else
            {
                //Generamos arqueo Ingresamos Arque TiRemesa
                miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.ArqueoTiRemesa", "IdArqueoTiRemesa", (int)miCN.S);
                numPlanilla = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos", "Serie", "IdAGenciaSucursal=" + GlobalVar.AgenciaSucursal +
                              " AND Proceso='PLANILLA TIQUETES'", (int)miCN.S);
                Campos = "IdArqueoTiRemesa,IdRuta,IdAgenciaSucursal,NumPlanillaT,NumPlanillaR,TotalBrutoT,TotalEstampilla, " +
                         "TotalReexT,TotalReexR,TotalSeguroT,TotalSeguroR,TotalNetoT,TotalNetoR,Observacion";

                Valores = miMax + "," + txtNumRuta.Text + "," + GlobalVar.AgenciaSucursal + "," + numPlanilla + ",0," +
                          txtTotalBruto.Text + "," + txtTotalEstam.Text + "," + txtTotalReex.Text + ",0," +
                          txtTotalSeguro.Text + ",0," + ValorNeto + ",0,'" + txtObservacion.Text + "'";

                miSql.Guardar(GlobalVar.BDServidor + "dbo.ArqueoTiRemesa", Campos, Valores, (int)miCN.S);

                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Planilla generada Correctamente", "<Translinea Software>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Information);

                    txtNumeroPlanilla.Text = Convert.ToString(numPlanilla);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al Guardar", "<Translinea Software>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        //Metodo
        private void Imprimir()
        {

        }
    }
}
