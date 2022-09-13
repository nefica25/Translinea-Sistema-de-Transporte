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
    public partial class frmAsignarBus : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        DataTable DtDatos, DtGrilla, DtRuta;
        String Tabla, Campos, Condicion;
        String TablaInsert, TablaSelect, CamposInsert, CamposSelect, CamposConValores;
        int IdVehiculo, AsientosSinAsignar;
        int miMax = 0;

        public frmAsignarBus()
        {
            InitializeComponent();
        }

        private void frmAsignarBus_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);

            CargarCombo();
            ConfigurarGrilla();
            ConfigurarGrillaAsignar();
        }

        //Pintar formulario
        private void frmAsignarBus_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturar teclas
        private void frmAsignarBus_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["IdRutaVehiculo"].Width = 65;
                Dtg.Columns["IdRutaVehiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdRutaVehiculo"].HeaderText = "Id";

                Dtg.Columns["Puesto"].Width = 77;
                Dtg.Columns["Puesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Puesto"].HeaderText = "Puesto";

                Dtg.Columns["Estado"].Width = 90;
                Dtg.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Estado"].HeaderText = "Estado";

                Dtg.Columns["IdRuta"].Visible = false;
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

        //Cargamos datos configurar la grilla
        private void ConfigurarGrilla()
        {
            int IdRuta;
            if (txtNumRuta.TextLength == 0)
            {
                IdRuta = 0;
            }
            else
            {
                IdRuta = Convert.ToInt32(txtNumRuta.Text);
            }

            DtGrilla = new DataTable();  //Queda pendiente validar la Agencia y el usuario
            Tabla = GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle";
            Campos = "IdRutaVehiculo,IdRuta,Puesto,Estado";
            Condicion = "IdRuta=" + IdRuta + " AND IdUsuario=" + GlobalVar.IdUsuario + " AND Modo=1";
            DtGrilla = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);


            DtgPuestos.DataSource = DtGrilla;
            Conf_DtgRuta(DtgPuestos);
        }

        //Cargamso grilla a la grilla del vehiculo que voy asignar
        private void ConfigurarGrillaAsignar()
        {
            int IdRuta;
            if (txtNumRuta.TextLength == 0)
            {
                IdRuta = 0;
            }
            else
            {
                IdRuta = Convert.ToInt32(txtNumRuta.Text);
            }

            DtGrilla = new DataTable();  //Queda pendiente validar la Agencia y el usuario
            Tabla = GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle";
            Campos = "IdRutaVehiculo,IdRuta,Puesto,Estado";
            Condicion = "IdRuta=" + IdRuta + " AND IdUsuario=" + GlobalVar.IdUsuario + " AND Modo=2";
            DtGrilla = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);


            DtgPuestosAsignar.DataSource = DtGrilla;
            Conf_DtgRuta(DtgPuestosAsignar);
        }

        //Metodo Cargamos cajas de texto
        private void CargarDatosGenerales()
        {
            DtDatos = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.Ruta R INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.Vehiculo V ON R.IdVehiculo=V.IdVehiculo ";
            Campos = "(Destino + ' / ' +  HoraRuta) as Nombre,V.Vehiculo,R.FechaRuta,R.HoraRuta,V.IdVehiculo,V.Asientos";
            Condicion = "IdRuta=" + txtNumRuta.Text + "";

            //Cargamos las Rutas existentes donde se Muestra concatenado el Destino y la Hora
            DtRuta = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            if (DtRuta.Rows.Count > 0)
            {
                txtDestino.Text = Convert.ToString(DtRuta.Rows[0]["Nombre"]);
                txtVehiculo.Text = Convert.ToString(DtRuta.Rows[0]["Vehiculo"]);
                txtFecha.Text = Convert.ToDateTime(DtRuta.Rows[0]["FechaRuta"]).ToShortDateString();
                txtHora.Text = Convert.ToString(DtRuta.Rows[0]["HoraRuta"]);
                IdVehiculo = Convert.ToInt32(DtRuta.Rows[0]["IdVehiculo"]);
                AsientosSinAsignar = Convert.ToInt32(DtRuta.Rows[0]["Asientos"]);

                BajarDatos();
                ConfigurarGrilla();

                if (Convert.ToString(txtVehiculo.Text) != "SIN ASIGNAR")
                {
                    cboVehiculo.Enabled = false;
                }
                else
                {
                    cboVehiculo.Enabled = true;
                }
            }
            else
            {
                miMt.LimpiarFormularioGeneral(this);
            }
        }

        //Metodo cargar combo
        private void CargarCombo()
        {
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Vehiculo", "Vehiculo", "IdVehiculo", "Estado=1 AND IdTipoVehiculo=1", "IdVehiculo", cboVehiculo, (int)miCN.S);
        }

        //Bajamos datos RutaVehiculo servidor a la Local z  OJO: Hacer Procedemiento ALmacenado
        private void BajarDatos()
        {
            miSql.Eliminar(GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle", "IdUsuario=" + GlobalVar.IdUsuario + "",
                          (int)miCN.S);

            TablaInsert = GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle";
            CamposInsert = "IdRutaVehiculo,IdRuta,IdVehiculo,Puesto,Estado,FechaDeSistema,IdUsuario,Modo";
            TablaSelect = GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle";
            CamposSelect = "IdRutaVehiculo,IdRuta,IdVehiculo,Puesto,Estado,FechaDeSistema," +
                           GlobalVar.IdUsuario + ",1";
            Condicion = "IdRuta=" + txtNumRuta.Text + "";

            miSql.Guardar(TablaInsert, CamposInsert, CamposSelect, TablaSelect, Condicion, (int)miCN.S);

        }

        #region Eventos

        //Cargamos la Ruta Segun Numero de Ruta
        private void txtNumRuta_Leave(object sender, EventArgs e)
        {
            if (txtNumRuta.TextLength != 0)
            {
                CargarDatosGenerales();
            }
        }

        //Evento validamos si el Vehiculo actual tiene puestos Asignados
        private void cboVehiculo_Enter(object sender, EventArgs e)
        {
            if (DtgPuestosAsignar.Rows.Count > 0)
            {
                MessageBox.Show("No puede cambiar el vehiculo cuando ya ha asignado puestos", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                DtgPuestosAsignar.Focus();
            }
        }

        //Evento valido la selecciono del Vehiculo
        private void cboVehiculo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboVehiculo.SelectedValue) == 0)
            {
                cboVehiculo.SelectedValue = 0;
                cboVehiculo.Text = "";
            }
        }
        #endregion

        //Boton Adicionar
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miMt.LimpiarFormularioGeneral(this);
        }

        //Boton Asignamos Bus y enviamos datos al Servidor
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboVehiculo.SelectedValue) == 0 || Convert.ToString(cboVehiculo.Text) == "SIN ASIGNAR")
            {
                MessageBox.Show("Seleccione el Vehiculo Asignar", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                cboVehiculo.Focus();
                return;
            }
            else if (DtgPuestos.Rows.Count > 0)
            {
                MessageBox.Show("Por favor termine de asignar todos los Puestos al Vehiculo asignar", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                cboVehiculo.Focus();
                return;
            }

            //Falta validar que la Fecha que se le asigna al Bus no este vencida  OJO


            //Verificar si el bus del combo seleccionado tiene mas Puestos o menos
            DataTable DtVerificarAsientos = new DataTable();
            int AsientosAsignar, AsientosOcupados;
            DtVerificarAsientos = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.Vehiculo", "*", "IdVehiculo=" + cboVehiculo.SelectedValue + "",
                                (int)miCN.S);
            AsientosAsignar = Convert.ToInt32(DtVerificarAsientos.Rows[0]["Asientos"]);
            AsientosOcupados = DtgPuestosAsignar.Rows.Count;

            //Si los asientos asignar es inferior a los Vendidos
            if (AsientosOcupados > AsientosAsignar)
            {
                MessageBox.Show("No puede Asignar un Vehiculo donde los Asientos es inferior a los ASIENTOS VENDIDOS", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            //Si el Vehiculo sin Asignar tiene mas asientos al Vehiculo Asignado
            else if (AsientosSinAsignar > AsientosAsignar)
            {
                MessageBox.Show("No puede Asignar un Vehiculo con Asientos inferiores al Vehiculo sin Asignar", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            //Si los asientos sin asignar es inferior a los asientos del vehiculo asignar
            else if (AsientosSinAsignar <= AsientosAsignar)
            {

                //------------------------------------------------------------------------------------
                int Asientos = 0;
                GlobalVar.TodoOk = true;
                //Insertamos puestos faltantes ala Tabla Local   
                Asientos = AsientosSinAsignar;
                //Recorro desde total Asientos sinAsignar Hasta el total Asientos Asignar
                for (int i = AsientosSinAsignar; i < AsientosAsignar; i++)
                {
                    miMax = miMax + 1;
                    Asientos = Asientos + 1;
                    Campos = "IdRutaVehiculo,IdRuta,IdVehiculo,Puesto,Estado,FechaDeSistema,IdUsuario,Modo";
                    CamposConValores = miMax + "," + txtNumRuta.Text + "," + cboVehiculo.SelectedValue + "," +
                                       Asientos + ",1,GETDATE()," + GlobalVar.IdUsuario + ",2";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle", Campos, CamposConValores, (int)miCN.S);
                }

            }
            //Si tiene le mismo cupo de Asientos Solo Hacemos un Update al IdVehiculo
            else if (AsientosSinAsignar == AsientosAsignar)
            {
                //Actualizar Tabla Ruta el campo IdVehiculo por el Vehiculo del combo Seleccionado
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.Ruta", "IdVehiculo=" + cboVehiculo.SelectedValue + "", "IdRuta=" + txtNumRuta.Text + "", (int)miCN.S);
                //
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", "IdVehiculo=" + cboVehiculo.SelectedValue + "", "IdRuta=" + txtNumRuta.Text + "", (int)miCN.S);
                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Vehiculo Asignado Correctamente", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                }
               
                return;
            }

            using (TransactionScope Transaccion = new TransactionScope())
            {

                //Subir zRutaVehiculoDetalle
                DataTable DtRutaVehiculo = new DataTable();
                Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdUsuario=" + GlobalVar.IdUsuario +
                            " Order by Puesto asc";
                DtRutaVehiculo = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle", "*", Condicion,
                (int)miCN.S);

                //Eliminamos los registro de Tabla RutaVehiculoDetalle del Servidor
                miSql.Eliminar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", "IdRuta=" + txtNumRuta.Text + "", (int)miCN.S);

                for (int i = 0; i < DtRutaVehiculo.Rows.Count; i++)
                {
                    miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", "IdRutaVehiculo", (int)miCN.S);
                    Campos = "IdRutaVehiculo,IdRuta,IdVehiculo,Puesto,Estado,FechaDeSistema";
                    CamposConValores = miMax + "," + txtNumRuta.Text + "," + DtRutaVehiculo.Rows[i]["IdVehiculo"] +
                                       "," + DtRutaVehiculo.Rows[i]["Puesto"] + "," + DtRutaVehiculo.Rows[i]["Estado"] +
                                       ",GETDATE()";

                    miSql.Guardar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", Campos, CamposConValores, (int)miCN.S);
                }

                //Actualizar Tabla Ruta el campo IdVehiculo por el Vehiculo del combo Seleccionado
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.Ruta", "IdVehiculo=" + cboVehiculo.SelectedValue + "", "IdRuta=" + txtNumRuta.Text + "", (int)miCN.S);
                

                //Confirmamos transaccion
                Transaccion.Complete();
                

                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Vehiculo Asignado Correctamente", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    Transaccion.Dispose();
                }
            }
        }

        //Boton buscar Ruta a Asignar bus
        private void bttnBuscar_Click(object sender, EventArgs e)
        {

        }

        //Boton Imprimir de la Ruta cargada donde mostramos el Detalle de los Puestos
        private void bttnImprimir_Click(object sender, EventArgs e)
        {

        }

        //Boton Salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento damos formato celda estado Color
        private void DtgPuestos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex == DtgPuestos.Columns["Estado"].Index)
                {
                    // String s = Convert.ToString(DtgPuestos["Estado", e.RowIndex]);
                    String s = Convert.ToString(DtgPuestos["Estado", e.RowIndex]);

                    switch (s)
                    {
                        case "1":
                            e.CellStyle.BackColor = System.Drawing.Color.Green;

                            break;

                        case "2":
                            e.CellStyle.BackColor = System.Drawing.Color.Red;
                            break;

                        case "3":
                            e.CellStyle.BackColor = System.Drawing.Color.Orange;
                            break;

                    }
                }
            }
            catch (Exception)
            {
            }

        }

        //Boton pasamos todos los puestos
        private void bttnPasarTodos_Click(object sender, EventArgs e)
        {
            if (cboVehiculo.Text != "SIN ASIGNAR" && cboVehiculo.Text.Length > 0 && txtNumRuta.TextLength > 0)
            {
                CamposConValores = "IdVehiculo=" + cboVehiculo.SelectedValue + ",Modo=2";
                Condicion = "IdRuta=" + txtNumRuta.Text + "";
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle", CamposConValores, Condicion, (int)miCN.S);
                ConfigurarGrilla();
                ConfigurarGrillaAsignar();
            }
            else
            {
                MessageBox.Show("Seleccione el Vehiculo Asignar", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                cboVehiculo.Focus();
            }
        }

        //Boton donde pasamos uno por uno
        private void bttnPasar_Click(object sender, EventArgs e)
        {
            if (cboVehiculo.Text != "SIN ASIGNAR" && cboVehiculo.Text.Length > 0 && txtNumRuta.TextLength > 0)
            {
                CamposConValores = "IdVehiculo=" + cboVehiculo.SelectedValue + ",Modo=2";
                Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdRutaVehiculo=" + DtgPuestos.CurrentRow.Cells["IdRutaVehiculo"].Value + "";
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle", CamposConValores, Condicion, (int)miCN.S);
                ConfigurarGrilla();
                ConfigurarGrillaAsignar();
            }
            else
            {
                MessageBox.Show("Seleccione el Vehiculo Asignar", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                cboVehiculo.Focus();
            }
        }

        //Boton donde devolvemos todos
        private void btnDevolverTodos_Click(object sender, EventArgs e)
        {
            if (cboVehiculo.Text != "SIN ASIGNAR" && cboVehiculo.Text.Length > 0 && txtNumRuta.TextLength > 0)
            {
                CamposConValores = "IdVehiculo=" + IdVehiculo + ",Modo=1";
                Condicion = "IdRuta=" + txtNumRuta.Text + "";
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.zRutaVehiculoDetalle", CamposConValores, Condicion, (int)miCN.S);
                ConfigurarGrilla();
                ConfigurarGrillaAsignar();
            }
            else
            {
                MessageBox.Show("No hay puestos para DesAsignar", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

    }
}
