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
using System.Data.SqlServerCe;

using System.Transactions;

namespace TranslineaN
{

    public partial class frmCiudadRecorrido : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Tabla, Campos, Condicion, Valores;
        String TablaInsert, TablaSelect, CamposInsert, CamposSelect;
        DataTable DtRecorrido, DtPais;
        Boolean TodoOk;
        long miProceso;
        int miMax;

        public frmCiudadRecorrido()
        {
            InitializeComponent();
        }

        private void frmCiudadRecorrido_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            CargarCombo();
            ConfigurarGrilla();
            miProceso = (int)Bandera.n;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Pintamos formulario
        private void frmCiudadRecorrido_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturamos teclas
        private void frmCiudadRecorrido_KeyDown(object sender, KeyEventArgs e)
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
                Dtg.Columns["IdRecorrido"].Width = 50;
                Dtg.Columns["IdRecorrido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdRecorrido"].HeaderText = "Codigo";

                Dtg.Columns["Recorrido"].Width = 130;
                Dtg.Columns["Recorrido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Recorrido"].HeaderText = "Recorrido";

                Dtg.Columns["IdOrigen"].Width = 125;
                Dtg.Columns["IdOrigen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["IdOrigen"].HeaderText = "Origen";

                Dtg.Columns["Destino"].Width = 125;
                Dtg.Columns["Destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Destino"].HeaderText = "Destino";

                Dtg.Columns["ValorTiquete"].Width = 82;
                Dtg.Columns["ValorTiquete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["ValorTiquete"].HeaderText = "Valor";
                Dtg.Columns["ValorTiquete"].DefaultCellStyle.Format = "#,##0.00";

                Dtg.Columns["Estampilla"].Width = 50;
                Dtg.Columns["Estampilla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Estampilla"].HeaderText = "Estamp";

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

        //Mostramos los datos en la Grilla de las Rutas filtradas por recorrido
        private void ConfigurarGrilla()
        {
            if (miProceso != (int)Bandera.n)
            {
                DtRecorrido = new DataTable();
                Tabla = GlobalVar.BDServidor + "dbo.CiudadRecorrido";
                Campos = "IdRecorrido,IdOrigen,Recorrido,Destino,ValorTiquete,Estampilla";
                Condicion = "IdOrigen=" + GlobalVar.IdOrigen + " AND IdDestino=" + cboDestino.SelectedValue + "";

                DtRecorrido = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

                DtgRecorrido.DataSource = DtRecorrido;
                Conf_DtgRuta(DtgRecorrido);
            }
        }

        private void CargarCombo()
        {
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboOrigen, (int)miCN.S);
            cboOrigen.SelectedValue = 0;
        }

        //Bajamos registros del servidor a BD Local 
        private void BajarDatos()
        {
            miSql.Eliminar(GlobalVar.BDLocal + "dbo.zCiudadRecorrido", "IdUsuario=" + GlobalVar.IdUsuario + "", (int)miCN.L);

            TablaInsert = GlobalVar.BDLocal + "dbo.zCiudadRecorrido";
            CamposInsert = "IdRecorrido,IdAgenciaSucursal,IdOrigen,Recorrido,Destino,IdDestino,ValorTiquete,Estampilla,Estado," + GlobalVar.IdUsuario + "";
            TablaSelect = GlobalVar.BDServidor + "dbo.CiudadRecorrido";
            CamposSelect = "IdRecorrido,IdAgenciaSucursal,IdOrigen,Recorrido,Destino,IdDestino,ValorTiquete,Estampilla,Estado,IdUsuario";
            Condicion = "IdRecorrido>0";
            miSql.Guardar(TablaInsert, CamposInsert, CamposSelect, TablaSelect, Condicion, (int)miCN.L);

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

        //Metodo validar antes dek guardar
        private void Validar()
        {
            TodoOk = false;
            if (cboOrigen.Text.Length == 0)
            {
                MessageBox.Show("Seleccione el Origen", "<Translinea Software>",
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
            else if (txtRecorrido.TextLength == 0)
            {
                MessageBox.Show("Ingrese el nombre del Recorrido", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                txtRecorrido.Focus();
                return;
            }
            else if (txtValorTiquete.TextLength == 0)
            {
                MessageBox.Show("Ingrese el Valor", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                txtValorTiquete.Focus();
                return;
            }

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
                    // txtCodigo.Text = "0";
                }
                else if (miProceso == (int)Bandera.m)
                {
                    bttnGuardar.Text = "&Actualizar";
                    bttnCancelar.Enabled = false;
                    bttnAdicionar.Enabled = true;
                    bttnBuscar.Enabled = true;
                    // txtCodigo.Text = "";
                }
            }
        }

        #region Eventos

        private void cboOrigen_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboOrigen.SelectedValue) == 0)
            {
                cboOrigen.SelectedValue = 0;
                cboOrigen.Text = "";
            }
        }

        private void cboDestino_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDestino.SelectedValue) == 0)
            {
                cboDestino.SelectedValue = 0;
                cboDestino.Text = "";
            }
            else
            {
                ConfigurarGrilla();
            }
        }

        private void txtRecorrido_Leave(object sender, EventArgs e)
        {
            txtRecorrido.Text = txtRecorrido.Text.ToUpper();
        }

        private void cboDestino_Enter(object sender, EventArgs e)
        {
            if (cboOrigen.Text.Length == 0)
            {
                MessageBox.Show("Seleccione  el Origen", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                cboOrigen.Focus();
            }
        }

        //Validamos solo numeros
        private void txtValorTiquete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //validamos solo Letras
        private void txtRecorrido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        #endregion

        //Evento se desencadena al seleccionar o cambia el valor
        private void cboOrigen_SelectedValueChanged(object sender, EventArgs e)
        {

            //Cargamos la Ciudad filtrando por pais
            Tabla = GlobalVar.BDServidor + "dbo.Pais P INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.Departamento D ON P.IdPais=D.IdPais INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.Ciudad C ON D.IdDepartamento=C.IdDepartamento";

            DtPais = new DataTable();
            DtPais = miSql.Seleccionar(Tabla, "P.IdPais", "C.Estado=1 AND C.IdCiudad=" + cboOrigen.SelectedValue + "",
                     (int)miCN.S);
            if (DtPais.Rows.Count > 0) //Si la ciudad seleccionada tiene pais
            {
                Condicion = "C.Estado=1 AND P.IdPais=" + DtPais.Rows[0]["IdPais"] + " ";
                //cargamso la respectiva ciudades por Pais
                miSql.CargarCombo(Tabla, "Ciudad", "IdCiudad", Condicion, "IdCiudad", cboDestino, (int)miCN.S);
                cboDestino.SelectedValue = 0;
            }
        }

        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.a;
            miMt.LimpiarFormularioGeneral(this);
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            Validar();
            if (TodoOk == true)
            {
                GlobalVar.TodoOk = true;
                if (miProceso == (int)Bandera.a)
                {
                    miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.CiudadRecorrido", "IdRecorrido", (int)miCN.S);
                    Campos = "IdRecorrido,IdAgenciaSucursal,IdOrigen,Recorrido,Destino,IdDestino,ValorTiquete,Estampilla,Estado";
                    Valores = miMax + "," + GlobalVar.AgenciaSucursal + "," + cboOrigen.SelectedValue + ",'" + txtRecorrido.Text +
                              "','" + cboDestino.Text + "'," + cboDestino.SelectedValue + "," + txtValorTiquete.Text + ",'" + chkEstam.Checked +
                              "',1";
                    miSql.Guardar(GlobalVar.BDServidor + "dbo.CiudadRecorrido", Campos, Valores, (int)miCN.S);

                    if (GlobalVar.TodoOk == true)
                    {
                        MessageBox.Show("Registro enviado correctamente", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                        ConfigurarGrilla();
                    }
                }
                else if (miProceso == (int)Bandera.m)
                {

                }
            }
        }

        private void bbtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.m;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }
    }
}
