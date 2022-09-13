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
    public partial class frmTiquetes : Form, Clientes
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        DataTable DtDatos, DtTiquete, DtGrilla, DtDestino, DtSilla;
        String Tabla, Campos, Condicion, CamposValores, Valores;
        int miMax, CodigoTiquete;
        int miProceso, b;
        Double TotalPrecio;
        Boolean TodoOk, TodoOkG;

        public frmTiquetes()
        {
            InitializeComponent();
        }

        private void frmTiquetes_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            miProceso = (int)Bandera.n;

            //Cargamos consecutivo temporalmente
            txtCodigo.Text = Convert.ToString(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos",
                             "Serie", "Id=3", (int)miCN.S));

            //Cargamos las Rutas fecha actual
            CargarDatosGenerales();
            LimpiarPuestos();

            //Limpiamos Tabla Local tiquetes
            //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
            miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "IdVendedor=" + GlobalVar.IdUsuario + "",
                          (int)miCN.S);
            miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "IdVendedor=" + GlobalVar.IdUsuario + "",
                          (int)miCN.S);
        }

        #region Interfaces
        //Interface conexion hijo a Padre
        public void Tiquetes(int Documento)
        {
            txtDocumento.Text = Convert.ToString(Documento);

            DtDatos = new DataTable();
            DtDatos = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.Clientes", "NroDocumento,NombreCompleto,Direccion,IdCliente",
                                     "NroDocumento=" + txtDocumento.Text + "", (int)miCN.S);
            //Si existe el clientes Cargo los datos
            if (DtDatos.Rows.Count > 0)
            {
                txtNombres.Text = Convert.ToString(DtDatos.Rows[0]["NombreCompleto"]);
                txtIdCliente.Text = Convert.ToString(DtDatos.Rows[0]["IdCliente"]);
            }
        }

        public void TiquetesBuscar(int IdRuta)
        {
            txtNumRuta.Text = Convert.ToString(IdRuta);
            CargarDatosGenerales();
            ConfigurarGrilla();

            //Cargamos consecutivo temporalmente
            txtCodigo.Text = Convert.ToString(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos",
                             "Serie", "Id=3", (int)miCN.S));

            CargarPuestos();
        }
        #endregion

        //Pintamos formulario
        private void frmTiquetes_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);

        }

        //Tiene lugar cuando presionamos una tecla
        private void frmTiquetes_KeyDown(object sender, KeyEventArgs e)
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
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["Puesto"].Width = 50;
                Dtg.Columns["Puesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Puesto"].HeaderText = "Puesto";

                Dtg.Columns["FechaVenta"].Width = 80;
                Dtg.Columns["FechaVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["FechaVenta"].HeaderText = "Fecha";
                Dtg.Columns["FechaVenta"].ReadOnly = true;
                Dtg.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Dtg.Columns["Destino"].Width = 125;
                Dtg.Columns["Destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Destino"].HeaderText = "Destino";

                Dtg.Columns["NombreCompleto"].Width = 215;
                Dtg.Columns["NombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["NombreCompleto"].HeaderText = "Nombres";

                Dtg.Columns["TotalPrecio"].Width = 91;
                Dtg.Columns["TotalPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["TotalPrecio"].HeaderText = "Valor";
                Dtg.Columns["TotalPrecio"].DefaultCellStyle.Format = "#,##0.00";

                Dtg.Columns["IdTiquete"].Visible = false;
                Dtg.Columns["CodigoTiquete"].Visible = false;
                Dtg.Columns["IdCliente"].Visible = false;
                Dtg.Columns["IdOrigen"].Visible = false;
                Dtg.Columns["IdDestino"].Visible = false;
                Dtg.Columns["Cantidad"].Visible = false;

                Dtg.Columns["PrecioVenta"].Visible = false;
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
            Tabla = GlobalVar.BDServidor + "dbo.zTiquetesDetalle";
            Campos = "FechaVenta,Puesto,IdOrigen,IdDestino,NombreCompleto,Destino," +
                     "Cantidad,PrecioVenta,IdTiquete,CodigoTiquete,IdCliente,TotalPrecio";
            Condicion = "IdCliente>0 AND IdVendedor=" + GlobalVar.IdUsuario + "";
            DtGrilla = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            DtgPuestos.DataSource = DtGrilla;
            Conf_DtgRuta(DtgPuestos);
        }

        //Cargamos todos los combos por Clases
        private void CargarCombos()
        {

        }

        //Sumamos la columna total del tiquete
        private void SumarGrilla()
        {
            DataTable DtSumar = new DataTable();
            Double Total = 0;
            Campos = "PrecioVenta,TotalPrecio";
            Condicion = "IdVendedor=" + GlobalVar.IdUsuario + "";
            DtSumar = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos, Condicion,
                                     (int)miCN.S);
            if (DtSumar.Rows.Count > 0)
            {
                for (int i = 0; i < DtSumar.Rows.Count; i++)
                {
                    Total = Total + Convert.ToDouble(DtSumar.Rows[i]["TotalPrecio"]);
                    txtValorTotal.Text = "";
                    txtValorTotal.Text = Convert.ToString(Total);
                }
            }
            else
            {
                txtValorTotal.Text = "0";
            }
        }

        private void CargarDatosGenerales()
        {
            if (miProceso != (int)Bandera.n)
            {
                b = 0;
                DtDatos = new DataTable();
                Tabla = GlobalVar.BDServidor + "dbo.Ruta ";
                Campos = "(Destino + ' / ' +  HoraRuta) as Nombre,IdRuta=" +
                         "(Select IdCiudad From " + GlobalVar.BDServidor + "dbo.Ciudad Where IdCiudad=Ruta.IdDestino)";
                Condicion = "IdRuta=" + txtNumRuta.Text + "";

                //Cargamos las Rutas existentes donde se Muestra concatenado el Destino y la Hora
                //Mostramos Destino disponibles 
                miSql.CargarCombo(Tabla, Campos, "Nombre", "IdRuta", Condicion, "IdRuta", cboDestino,
                                 (int)miCN.S);
                b = 1;

                //Si no existieron rutas asignadas
                if (Convert.ToInt32(cboDestino.SelectedValue) == 0)
                {
                    miMt.LimpiarFormularioGeneral(this);
                }
                else if (Convert.ToInt32(cboDestino.SelectedValue) != 0)
                {
                    txtIdDestino.Text = Convert.ToString(cboDestino.SelectedValue);
                }
            }
        }

        //Validamos datos al Seleccionar Puesto
        private void ValidarPuesto()
        {
            if (txtDocumento.Text.Length == 0 || txtNombres.Text.Length == 0)
            {
                MessageBox.Show("Debe primero ingresar cliente antes de seleccionar un Puesto", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                return;
            }
            else if (Convert.ToInt32(cboRecorrido.SelectedValue) == 0)
            {
                MessageBox.Show("Seleccione el Recorrido", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                return;
            }
            else if (txtValorTiquete.TextLength == 0)
            {
                MessageBox.Show("Ingrese el valor del tiquete", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                return;
            }
            else if (txtReex.Text.Length == 0)
            {
                txtReex.Text = "0";
            }
            TodoOk = true;
        }

        //Cargamso los Puestos en los Botones se gun su Estado
        //1: Disponible  2:Vendido  3:Apartado  4:Utilizado
        private void CargarPuestos()
        {
            LimpiarPuestos();

            int cont = 0;

            DtSilla = new DataTable();
            DtSilla = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", "Puesto,Estado",
                                         "IdRuta=" + txtNumRuta.Text + "", (int)miCN.S);
            if (DtSilla.Rows.Count > 0)
            {
                //Recorro todos los Puestos
                for (int i = 0; i < DtSilla.Rows.Count; i++)
                {
                    //Inicio contador e incremento
                    cont = cont + 1;

                    //Recorro el panel donde se encuentran todos Checkbox Puestos
                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            if (Convert.ToInt32(ctrl.Text) == cont)
                            {
                                ctrl.Enabled = true;

                                //Disponible Color: Verde
                                if (Convert.ToInt32(DtSilla.Rows[i]["Estado"]) == 1)
                                {
                                    ((CheckBox)ctrl).BackColor = System.Drawing.Color.GreenYellow;

                                }//Vendido Color: Rojo
                                else if (Convert.ToInt32(DtSilla.Rows[i]["Estado"]) == 2)
                                {
                                    ctrl.BackColor = System.Drawing.Color.Red;
                                    ctrl.Enabled = false;

                                }//Apartado Color: Naranja
                                else if (Convert.ToInt32(DtSilla.Rows[i]["Estado"]) == 3)
                                {
                                    ctrl.BackColor = System.Drawing.Color.Orange;
                                    ctrl.Enabled = false;
                                }//Utilizado Color: Azul
                                else if (Convert.ToInt32(DtSilla.Rows[i]["Estado"]) == 4)
                                {
                                    ctrl.BackColor = System.Drawing.Color.Blue;
                                }
                            }
                            else
                            {
                                //De lo contrario Valido si es mayor al Total de puestos inabilito el Puesto
                                if (Convert.ToInt32(ctrl.Text) > Convert.ToInt32(DtSilla.Rows.Count))
                                {
                                    ctrl.Visible = false;
                                }
                            }
                        }
                    }
                }

            }
        }

        //Deshabilitamos y mostramos todos lo Puestos
        private void LimpiarPuestos()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ctrl.BackColor = System.Drawing.Color.LightGray;
                    ctrl.Enabled = false;
                    ctrl.Visible = true;
                }
            }
        }

        //Validamos los datos antes de guardar
        private void ValidarDatosGuardar()
        {
            TodoOkG = false;
            if (Convert.ToInt32(cboRecorrido.SelectedValue) == 0)
            {
                MessageBox.Show("Seleccione el recorrido",
                             "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                TodoOkG = false;
                cboRecorrido.Focus();
                return;
            }
            //Validamos datos que la cantidad sea igual al # tiquetes seleccionados
            else if (Convert.ToInt32(txtCantidad.Text) != Convert.ToInt32(DtgPuestos.Rows.Count - 1))
            {

                MessageBox.Show("El numero de Puestos a vender debe ser igual a la cantidad seleccionada",
                                "<Translinea Software>",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                txtCantidad.Focus();
                TodoOkG = false;
                return;
            }
            else if (txtDocumento.TextLength == 0 || txtNombres.TextLength == 0)  //Revalidamos nuevamente
            {
                MessageBox.Show("Ingrese los Datos del Cliente",
                               "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOkG = false;
                txtDocumento.Focus();
                return;
            }
            else if (txtReex.Text.Length == 0)
            {
                txtReex.Text = "0";
            }

            TodoOkG = true;
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

        //Cargar Puestos disponibles, Segun la fecha
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarDatosGenerales();
            ConfigurarGrilla();

            //Cargamos consecutivo temporalmente
            txtCodigo.Text = Convert.ToString(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos",
                             "Serie", "Id=3", (int)miCN.S));

            CargarPuestos();
        }

        //Boton Vender nuevo Tiquete
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.a;

            //Limpiamos Tabla Local tiquetes
            //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
            miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "IdVendedor=" + GlobalVar.IdUsuario + "",
                          (int)miCN.S);
            miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "IdVendedor=" + GlobalVar.IdUsuario + "",
                          (int)miCN.S);
            ConfigurarGrilla();
            SumarGrilla();
            miMt.LimpiarFormularioGeneral(this);
            LimpiarPuestos();
        }

        //Vender tiquetes
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            //Validamos datos
            ValidarDatosGuardar();
            GlobalVar.TodoOk = true;

            if (TodoOkG == true)
            {
                //----------------------------------Subimos zTiquetes al Servidor----------------------------------------
                DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", "*", "IdVendedor=" + GlobalVar.IdUsuario + "",
                                           (int)miCN.S);
                if (DtTiquete.Rows.Count > 0)
                {
                    for (int t = 0; t < DtTiquete.Rows.Count; t++)
                    {
                        miMax = Convert.ToInt32(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Tiquetes", "IdTiquete",
                                     (int)miCN.S));
                        CodigoTiquete = Convert.ToInt32(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos",
                                "Serie", "Id=3", (int)miCN.S));

                        Campos = "IdTiquete,CodigoTiquete,IdCliente,IdRuta,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "Fecha,FechaVenta,IdVendedor";
                        Valores = miMax + "," + CodigoTiquete + "," + DtTiquete.Rows[t]["IdCliente"] + "," +
                                  DtTiquete.Rows[t]["IdRuta"] + ",'" + DtTiquete.Rows[t]["Hora"] + "'," +
                                  DtTiquete.Rows[t]["IdVehiculo"] + "," + DtTiquete.Rows[t]["IdAgenciaSucursal"] +
                                  "," + DtTiquete.Rows[t]["IdConductor"] + ",GETDATE(),'" +
                                  Convert.ToDateTime(DtTiquete.Rows[t]["FechaVenta"]).ToShortDateString() +
                                  "'," + DtTiquete.Rows[t]["IdVendedor"] + "";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.Tiquetes", Campos, Valores, (int)miCN.S);

                        //-----
                        DataTable DtEstado;
                        Tabla = GlobalVar.BDServidor + "dbo.zTiquetesDetalle"; //Tabla Local
                        Campos = "*";
                        Condicion = "IdVendedor=" + GlobalVar.IdUsuario + " AND IdRuta=" + DtTiquete.Rows[t]["IdRuta"] + "";
                        DtDestino = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

                        if (DtDestino.Rows.Count > 0)
                        {
                            //Recorreemos Datable
                            for (int i = 0; i < DtDestino.Rows.Count; i++)
                            {
                                miMax = Convert.ToInt32(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.TiquetesDetalle", "IdTiquete",
                                   (int)miCN.S));

                                //-------------------------------------------------------------------------------------------
                                Campos = "Puesto,Estado";
                                Condicion = "IdRuta=" + DtTiquete.Rows[t]["IdRuta"] + " AND Puesto=" + DtDestino.Rows[i]["Puesto"] +
                                            " AND Estado=1";
                                DtEstado = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", Campos, Condicion,
                                           (int)miCN.S);
                                if (DtEstado.Rows.Count > 0)
                                {
                                    //Vendemos puesto --Actualizamoa a estado=2 Vendido
                                    CamposValores = "Estado=2";
                                    Condicion = "IdRuta=" + DtDestino.Rows[i]["IdRuta"] + " AND Puesto=" + DtDestino.Rows[i]["Puesto"] + "";
                                    miSql.Actualizar(GlobalVar.BDServidor + "dbo.RutaVehiculoDetalle", CamposValores, Condicion,
                                                    (int)miCN.S);

                                    //----------------------------------Subimos zTiquetesDetalle al Servidor---------------------------------

                                    Campos = "IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido," +
                                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,TotalPrecio";
                                    Valores = miMax + "," + CodigoTiquete + "," + DtDestino.Rows[i]["IdCliente"] + "," +
                                              DtDestino.Rows[i]["IdOrigen"] + "," + DtDestino.Rows[i]["IdDestino"] + ",'" +
                                              DtDestino.Rows[i]["Destino"] + "'," + DtDestino.Rows[i]["IdRecorrido"] + ",'" +
                                              DtDestino.Rows[i]["Recorrido"] + "','" + DtDestino.Rows[i]["NombreCompleto"] + "'," +
                                              DtDestino.Rows[i]["Puesto"] + "," + DtDestino.Rows[i]["Cantidad"] + "," +
                                              DtDestino.Rows[i]["PrecioVenta"] + "," + DtDestino.Rows[i]["Reex"] + "," +
                                              DtDestino.Rows[i]["Estampilla"] + "," + DtDestino.Rows[i]["TotalPrecio"];
                                    miSql.Guardar(GlobalVar.BDServidor + "dbo.TiquetesDetalle", Campos, Valores, (int)miCN.S);


                                    //------------------------------------Agregar Kardex-------------------------------------------

                                }
                                else
                                { //No encontro datos en la consulta Datos incossitentes o Puesto vendido
                                    MessageBox.Show("La Ruta " + DtDestino.Rows[i]["IdRuta"] + "  " +
                                                    DtDestino.Rows[i]["Destino"] + " Puesto " + DtDestino.Rows[i]["Puesto"] +
                                                    " no se pudo Actualizar del Servidor por que no Existe o ya fue Vendido", "<Translinea Software>",
                                      System.Windows.Forms.MessageBoxButtons.OK,
                                      System.Windows.Forms.MessageBoxIcon.Information);
                                    //Actualizamos los Puestos para mirar si otra Agnecia vendio tiquetes
                                    CargarPuestos();
                                    return;
                                }
                            }

                            //Actualizar consecutivo CodigoTiquete
                            miSql.Actualizar(GlobalVar.BDServidor + "dbo.Procesos", "Serie=" + CodigoTiquete + "",
                                            "Id=3", (int)miCN.S);

                            if (GlobalVar.TodoOk == true)
                            {
                                MessageBox.Show("Venta realizada exitosamente", "<Translinea Software>",
                                               System.Windows.Forms.MessageBoxButtons.OK,
                                               System.Windows.Forms.MessageBoxIcon.Information);
                                CargarPuestos();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error", "<Translinea Software>",
                                            System.Windows.Forms.MessageBoxButtons.OK,
                                            System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        //Salir de la pantalla de ventas
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtReex_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtHora_Leave(object sender, EventArgs e)
        {
            txtHora.Text = txtHora.Text.ToUpper();
        }

        //Cargamos Recorrido
        private void cboDestino_SelectedValueChanged(object sender, EventArgs e) //Pilas falta validsar Agencia
        {
            if (cboDestino.Text.Length == 0)
            {
                return;
            }
            if (cboDestino.DropDownStyle != ComboBoxStyle.Simple && cboDestino.Text.Length != 0 && miProceso != (int)Bandera.n && b == 1)
            {

                //Cargamos combo Recorrido
                miSql.CargarCombo(GlobalVar.BDServidor + "dbo.CiudadRecorrido", "Recorrido", "IdRecorrido",
                                 "Estado=1 AND IdDestino=" + txtIdDestino.Text + " AND IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "",
                                 "IdRecorrido", cboRecorrido, (int)miCN.S);

                //Si no cargo recorrido la Ruta se Limpian las Cajas
                if (Convert.ToInt32(cboRecorrido.SelectedValue) == 0)
                {
                    cboRecorrido.SelectedValue = 0;
                    cboRecorrido.Text = "";
                    txtHora.Text = "";
                    txtBus.Text = "";
                    txtValorTiquete.Text = "";
                    txtCantidad.Text = "";
                    txtValorTotal.Text = "";
                    txtEstam.Text = "";
                }
            }
        }

        // Cargamos datos complementarios de la Ruta
        private void cboRecorrido_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboRecorrido.DropDownStyle != ComboBoxStyle.Simple && cboRecorrido.Text.Length != 0)
            {
                Tabla = GlobalVar.BDServidor + "dbo.Ruta R INNER JOIN " +
                        GlobalVar.BDServidor + "dbo.Vehiculo V ON R.IdVehiculo=V.IdVehiculo INNER JOIN " +
                        GlobalVar.BDServidor + "dbo.CiudadRecorrido CR ON CR.IdDestino=R.IdDestino";
                Condicion = "R.IdRuta=" + txtNumRuta.Text +
                            " AND R.Estado=1" +
                            " AND CR.IdRecorrido=" + cboRecorrido.SelectedValue + "";
                DtDatos = new DataTable();
                DtDatos = miSql.Seleccionar(Tabla, "R.HoraRuta,V.Vehiculo,CR.ValorTiquete,R.FechaRuta,R.Reexpedicion,R.Estampilla,CR.Estampilla",
                          Condicion, (int)miCN.S);

                if (DtDatos.Rows.Count > 0)
                {

                    txtFecha.Text = Convert.ToString(Convert.ToDateTime(DtDatos.Rows[0]["FechaRuta"]).ToShortDateString());
                    txtHora.Text = Convert.ToString(DtDatos.Rows[0]["HoraRuta"]);
                    txtBus.Text = Convert.ToString(DtDatos.Rows[0]["Vehiculo"]);
                    txtValorTiquete.Text = Convert.ToString(DtDatos.Rows[0]["ValorTiquete"]);
                    txtReex.Text = Convert.ToString(DtDatos.Rows[0]["Reexpedicion"]);
                    txtCantidad.Text = "1";
                    txtValorTotal.Text = Convert.ToString(Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtValorTiquete.Text));

                    //Verificamos si el Recorrido aplica estampilla
                    if (Convert.ToInt32(DtDatos.Rows[0][6]) == 1)
                    {
                        txtEstam.Text = Convert.ToString(DtDatos.Rows[0]["Estampilla"]);
                    }
                    else
                    {
                        txtEstam.Text = "00";
                    }
                }
            }
        }

        //Actualizamos el combo si han Agregado mas Recorrido con ese Destino
        private void cboRecorrido_Enter(object sender, EventArgs e)
        {
            if (cboDestino.Text.Length != 0)
            {
                //Cargamos combo Recorrido
                miSql.CargarCombo(GlobalVar.BDServidor + "dbo.CiudadRecorrido", "Recorrido", "IdRecorrido",
                                 "Estado=1 AND IdDestino=" + txtIdDestino.Text + " AND IdAgenciaSucursal=" + GlobalVar.AgenciaSucursal + "",
                                 "IdRecorrido", cboRecorrido, (int)miCN.S);
            }
        }

        //Valido datos al perdr el foco
        private void cboRecorrido_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboRecorrido.SelectedValue) == 0)
            {
                cboRecorrido.SelectedValue = 0;
                cboRecorrido.Text = "";
                txtHora.Text = "";
                txtBus.Text = "";
                txtValorTiquete.Text = "";
                txtCantidad.Text = "";
                txtValorTotal.Text = "";
                txtEstam.Text = "";
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (miProceso == (int)Bandera.a)
            {
                if (txtCantidad.Text.Length == 0 || Convert.ToInt32(txtCantidad.Text) == 0)
                {
                    MessageBox.Show("La cantidad no puede ser valor 0", "<TRANSLINEA Software>",
                                       System.Windows.Forms.MessageBoxButtons.OK,
                                       System.Windows.Forms.MessageBoxIcon.Information);
                    txtCantidad.Focus();
                }
            }
        }

        private void txtValorTiquete_Leave(object sender, EventArgs e)
        {
            //Si el proceso es adicionar y existen recorridos cargados en el combo
            if (miProceso == (int)Bandera.a && cboRecorrido.Text.Length != 0)
            {
                if (txtValorTiquete.Text.Length == 0)
                {
                    MessageBox.Show("Digite el Valor del Tiquete", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                    txtValorTiquete.Focus();
                }
            }
        }

        //Validamos y cargamos el Cliente de la Base de Datos.
        private void txtDocumento_Validated(object sender, EventArgs e)
        {
            if (miProceso == (int)Bandera.a)
            {
                if (cboRecorrido.Text.Length == 0)
                {
                    MessageBox.Show("Seleccione Recorrido", "<Translinea Software>",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Information);
                    cboRecorrido.Focus();
                    return;
                }

                if (txtDocumento.Text.Length != 0)
                {
                    DtDatos = new DataTable();
                    DtDatos = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.Clientes", "NroDocumento,NombreCompleto,Direccion,IdCliente",
                                             "NroDocumento=" + txtDocumento.Text + "", (int)miCN.S);
                    //Si existe el clientes Cargo los datos
                    if (DtDatos.Rows.Count > 0)
                    {
                        txtNombres.Text = Convert.ToString(DtDatos.Rows[0]["NombreCompleto"]);
                        txtIdCliente.Text = Convert.ToString(DtDatos.Rows[0]["IdCliente"]);
                    }
                    else
                    {
                        //De lo contrario se abre pantalla emeregente y agrego CLiente a la Base de Datos
                        MessageBox.Show("El Cliente no existe", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                        txtNombres.Text = "";

                        frmClientesAlterno frm = new frmClientesAlterno();
                        frm.MdiParent = this.MdiParent;
                        frm.Opener = this;
                        frm.Show();
                    }
                }
            }
        }

        private void bttnImprimir_Click(object sender, EventArgs e)
        {

            chk1.BackColor = System.Drawing.Color.Red;
        }

        #region Botones Puestos
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk1.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk1.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk2.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", '" +
                                 cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "',1,1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk1.Checked == false)
                {
                    chk1.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=1 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=1 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk1.Checked == true)
                {
                    chk1.Checked = false;
                }
            }

        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk2.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk2.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk2.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "',2,1," + txtValorTiquete.Text + "," +
                                 txtReex.Text + "," + txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk2.Checked == false)
                {
                    chk2.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=2 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=2 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk2.Checked == true)
                {
                    chk2.Checked = false;
                }
            }
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk3.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk3.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk2.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "',3,1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk3.Checked == false)
                {
                    chk3.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=3 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=3 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk3.Checked == true)
                {
                    chk3.Checked = false;
                }
            }
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk4.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk4.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk4.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk4.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk4.Checked == false)
                {
                    chk4.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=4 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=4 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk4.Checked == true)
                {
                    chk4.Checked = false;
                }
            }
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk5.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk5.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk5.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", '" +
                                 cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk5.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk5.Checked == false)
                {
                    chk5.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=5 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=5 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk5.Checked == true)
                {
                    chk5.Checked = false;
                }
            }
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk6.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk6.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk6.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk6.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk6.Checked == false)
                {
                    chk6.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=6 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=6 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk6.Checked == true)
                {
                    chk6.Checked = false;
                }
            }
        }

        private void chk7_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk7.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk7.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk7.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk7.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk7.Checked == false)
                {
                    chk7.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=7 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=7 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk7.Checked == true)
                {
                    chk7.Checked = false;
                }
            }
        }

        private void chk8_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk8.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk8.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk8.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk8.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk8.Checked == false)
                {
                    chk8.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=8 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=8 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk8.Checked == true)
                {
                    chk8.Checked = false;
                }
            }
        }

        private void chk9_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk9.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk9.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk9.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk9.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk9.Checked == false)
                {
                    chk9.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=9 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=9 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk9.Checked == true)
                {
                    chk9.Checked = false;
                }
            }
        }

        private void chk10_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk10.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk10.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk10.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk10.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk10.Checked == false)
                {
                    chk10.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=10 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=10 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk10.Checked == true)
                {
                    chk10.Checked = false;
                }
            }
        }

        private void chk11_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk11.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk11.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk11.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk11.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk11.Checked == false)
                {
                    chk11.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=11 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=11 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk11.Checked == true)
                {
                    chk11.Checked = false;
                }
            }
        }

        private void chk12_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk12.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk12.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk12.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk12.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk12.Checked == false)
                {
                    chk12.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=12 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=12 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk12.Checked == true)
                {
                    chk12.Checked = false;
                }
            }
        }

        private void chk13_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk13.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk13.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk13.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk13.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk13.Checked == false)
                {
                    chk13.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=13 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=13 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk13.Checked == true)
                {
                    chk13.Checked = false;
                }
            }
        }

        private void chk14_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk14.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk14.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk14.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk14.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk14.Checked == false)
                {
                    chk14.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=14 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=14 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk14.Checked == true)
                {
                    chk14.Checked = false;
                }
            }
        }

        private void chk15_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk15.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk15.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk15.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk15.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk15.Checked == false)
                {
                    chk15.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=15 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=15 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk15.Checked == true)
                {
                    chk15.Checked = false;
                }
            }
        }

        private void chk16_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk16.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk16.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk16.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk16.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk16.Checked == false)
                {
                    chk16.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=16 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=16 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk16.Checked == true)
                {
                    chk16.Checked = false;
                }
            }
        }

        private void chk17_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk17.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk17.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk17.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk17.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk17.Checked == false)
                {
                    chk17.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=17 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=17 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk17.Checked == true)
                {
                    chk17.Checked = false;
                }
            }
        }

        private void chk18_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk18.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk18.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk18.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk18.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk18.Checked == false)
                {
                    chk18.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=18 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=18 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk18.Checked == true)
                {
                    chk18.Checked = false;
                }
            }
        }

        private void chk19_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk19.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk19.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk19.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk19.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk19.Checked == false)
                {
                    chk19.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=19 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=19 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk19.Checked == true)
                {
                    chk19.Checked = false;
                }
            }
        }

        private void chk20_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk20.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk20.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk20.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk20.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk20.Checked == false)
                {
                    chk20.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=20 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=20 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk20.Checked == true)
                {
                    chk20.Checked = false;
                }
            }
        }

        private void chk21_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk21.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk21.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk21.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk21.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk21.Checked == false)
                {
                    chk21.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=21 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=21 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk21.Checked == true)
                {
                    chk21.Checked = false;
                }
            }
        }

        private void chk22_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk22.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk22.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk22.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk22.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk22.Checked == false)
                {
                    chk22.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=22 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=22 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk22.Checked == true)
                {
                    chk22.Checked = false;
                }
            }
        }

        private void chk23_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk23.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk23.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk23.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk23.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk23.Checked == false)
                {
                    chk23.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=23 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=23 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk23.Checked == true)
                {
                    chk23.Checked = false;
                }
            }
        }

        private void chk24_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk24.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk24.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk24.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk24.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk24.Checked == false)
                {
                    chk24.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=24 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=24 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk24.Checked == true)
                {
                    chk24.Checked = false;
                }
            }
        }

        private void chk25_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk25.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk25.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk25.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk25.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk25.Checked == false)
                {
                    chk25.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=25 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=25 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk25.Checked == true)
                {
                    chk25.Checked = false;
                }
            }
        }

        private void chk26_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk26.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk26.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk26.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk26.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk26.Checked == false)
                {
                    chk26.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=26 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=26 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk26.Checked == true)
                {
                    chk26.Checked = false;
                }
            }
        }

        private void chk27_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk27.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk27.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk27.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk27.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk27.Checked == false)
                {
                    chk27.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=27 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=27 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk27.Checked == true)
                {
                    chk27.Checked = false;
                }
            }
        }

        private void chk28_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk28.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk28.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk28.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk28.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk28.Checked == false)
                {
                    chk28.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=28 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=28 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk28.Checked == true)
                {
                    chk28.Checked = false;
                }
            }
        }

        private void chk29_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk29.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk29.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk29.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk29.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk29.Checked == false)
                {
                    chk29.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=29 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=29 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk29.Checked == true)
                {
                    chk29.Checked = false;
                }
            }
        }

        private void chk30_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk30.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk30.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk30.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk30.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk30.Checked == false)
                {
                    chk30.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=30 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=30 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk30.Checked == true)
                {
                    chk30.Checked = false;
                }
            }
        }

        private void chk31_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk31.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk31.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk31.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk31.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk31.Checked == false)
                {
                    chk31.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=31 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=31 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk31.Checked == true)
                {
                    chk31.Checked = false;
                }
            }
        }

        private void chk32_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk32.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk32.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk32.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk32.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk32.Checked == false)
                {
                    chk32.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=32 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=32 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk32.Checked == true)
                {
                    chk32.Checked = false;
                }
            }
        }

        private void chk33_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk33.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk33.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk33.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk33.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk33.Checked == false)
                {
                    chk33.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=33 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=33 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk33.Checked == true)
                {
                    chk33.Checked = false;
                }
            }
        }

        private void chk34_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk34.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk34.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk34.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk34.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk34.Checked == false)
                {
                    chk34.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=34 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=34 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk34.Checked == true)
                {
                    chk34.Checked = false;
                }
            }
        }

        private void chk35_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk35.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk35.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk35.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk35.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk35.Checked == false)
                {
                    chk35.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=35 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=35 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk35.Checked == true)
                {
                    chk35.Checked = false;
                }
            }
        }

        private void chk36_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk36.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk36.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk36.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk36.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk36.Checked == false)
                {
                    chk36.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=36 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=36 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk36.Checked == true)
                {
                    chk36.Checked = false;
                }
            }
        }

        private void chk37_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk37.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk37.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk37.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk37.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk37.Checked == false)
                {
                    chk37.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=37 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=37 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk37.Checked == true)
                {
                    chk37.Checked = false;
                }
            }
        }

        private void chk38_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk38.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk38.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk38.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk38.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk38.Checked == false)
                {
                    chk38.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=38 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=38 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk38.Checked == true)
                {
                    chk38.Checked = false;
                }
            }
        }

        private void chk39_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk39.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk39.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk39.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk39.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk39.Checked == false)
                {
                    chk39.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=39 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=39 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk39.Checked == true)
                {
                    chk39.Checked = false;
                }
            }
        }

        private void chk40_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk40.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk40.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk40.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk40.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk40.Checked == false)
                {
                    chk40.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=40 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=40 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk40.Checked == true)
                {
                    chk40.Checked = false;
                }
            }
        }

        private void chk41_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk41.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk41.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk41.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk41.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk41.Checked == false)
                {
                    chk41.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=41 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=41 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk41.Checked == true)
                {
                    chk41.Checked = false;
                }
            }
        }

        private void chk42_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPuesto();

            if (TodoOk == true)
            {
                if (chk42.Checked == true)
                {
                    //Cambiamos el estado del boton suprimido
                    chk42.BackColor = System.Drawing.Color.Blue;

                    Campos = "IdRuta,IdVendedor";
                    Condicion = "IdRuta=" + txtNumRuta.Text + " AND IdVendedor=" + GlobalVar.IdUsuario + "";
                    //Consultamos si el puesto existe
                    DtTiquete = miSql.Seleccionar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos, Condicion, (int)miCN.S);
                    if (DtTiquete.Rows.Count == 0)
                    {
                        //Ingresamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                        Campos = "Id,IdRuta,IdTiquete,CodigoTiquete,IdCliente,Hora,IdVehiculo,IdAgenciaSucursal,IdConductor, " +
                                 "FechaVenta,IdVendedor";
                        miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetes", Campos,
                                      chk42.Text + "," + txtNumRuta.Text + ",0,1," + txtIdCliente.Text + ",'" + txtHora.Text + "',0,1,0,'" +
                                      Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," + GlobalVar.IdUsuario + "",
                                      (int)miCN.S);
                    }

                    //Total por tiquete que el cliente debe pagar
                    TotalPrecio = Convert.ToDouble(txtValorTiquete.Text) + Convert.ToDouble(txtReex.Text) +
                                  Convert.ToDouble(txtEstam.Text);
                    Campos = "IdRuta,IdTiquete,CodigoTiquete,IdCliente,IdOrigen,IdDestino,Destino,IdRecorrido,Recorrido, " +  //Falta IdOrigen
                             "NombreCompleto,Puesto,Cantidad,PrecioVenta,Reex,Estampilla,FechaVenta,IdVendedor,TotalPrecio";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", Campos,
                                 txtNumRuta.Text + ",0,1," + txtIdCliente.Text + "," + GlobalVar.IdOrigen + "," + txtIdDestino.Text + ", " +
                                 "'" + cboDestino.Text + "'," + cboRecorrido.SelectedValue + ",'" + cboRecorrido.Text + "','" +
                                 txtNombres.Text + "'," + chk42.Text + ",1," + txtValorTiquete.Text + "," + txtReex.Text + "," +
                                 txtEstam.Text + ",'" + Convert.ToDateTime(txtFecha.Text).ToShortDateString() + "'," +
                                 GlobalVar.IdUsuario + "," + TotalPrecio + "",
                                 (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
                else if (chk42.Checked == false)
                {
                    chk42.BackColor = System.Drawing.Color.GreenYellow;

                    //Eliminamos Puesto a la Tabla zTiquetes y zTiquetesDetalle
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetes", "Id=42 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);
                    miSql.Eliminar(GlobalVar.BDServidor + "dbo.zTiquetesDetalle", "Puesto=42 AND IdRuta=" + txtNumRuta.Text + "",
                                  (int)miCN.S);

                    //Actualizamo la grilla
                    ConfigurarGrilla();
                    SumarGrilla();
                }
            }
            else
            {
                if (chk42.Checked == true)
                {
                    chk42.Checked = false;
                }
            }
        }
        #endregion

        private void txtNumRuta_Leave(object sender, EventArgs e)
        {
            if (txtNumRuta.TextLength > 0)
            {
                CargarDatosGenerales();
                ConfigurarGrilla();

                //Cargamos consecutivo temporalmente
                txtCodigo.Text = Convert.ToString(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Procesos",
                                 "Serie", "Id=3", (int)miCN.S));

                CargarPuestos();
            }
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            if (miProceso == (int)Bandera.a)
            {
                frmTiquetesBuscar frm = new frmTiquetesBuscar();
                frm.MdiParent = this.MdiParent;
                frm.Opener = this;
                frm.Show();
            }
        }

        private void cboDestino_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDestino.SelectedValue) == 0)
            {
                cboDestino.SelectedValue = 0;
                cboDestino.Text = "";
                cboRecorrido.SelectedValue = 0;
                cboRecorrido.Text = "";
                txtFecha.Text = "";
                txtHora.Text = "";
                txtBus.Text = "";
                txtValorTiquete.Text = "";
                txtCantidad.Text = "";
                txtValorTotal.Text = "";
                txtEstam.Text = "";
            }
        }

    }
}
