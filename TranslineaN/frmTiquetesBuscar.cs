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
    public partial class frmTiquetesBuscar : Form
    {
        public Clientes Opener { get; set; }
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        DataTable DtBuscar = new DataTable();
        String Tabla, Campos, Condicion;

        public frmTiquetesBuscar()
        {
            InitializeComponent();
        }

        private void frmTiquetesBuscar_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            CargarCombo();
            ConfigurarGrilla();
        }

        //Pintamos el formulario
        private void frmTiquetesBuscar_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturamos las teclas
        private void frmTiquetesBuscar_KeyDown(object sender, KeyEventArgs e)
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

        //Perfil grilla
        private void Conf_Buscar(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["IdRuta"].Width = 90;
                Dtg.Columns["IdRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdRuta"].HeaderText = "# Ruta";

                Dtg.Columns["Destino"].Width = 125;
                Dtg.Columns["Destino"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Destino"].HeaderText = "Destino";

                Dtg.Columns["FechaRuta"].Width = 80;
                Dtg.Columns["FechaRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["FechaRuta"].HeaderText = "Fecha";
                Dtg.Columns["FechaRuta"].ReadOnly = true;
                Dtg.Columns["FechaRuta"].DefaultCellStyle.Format = "dd/MM/yyyy";

                Dtg.Columns["HoraRuta"].Width = 70;
                Dtg.Columns["HoraRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["HoraRuta"].HeaderText = "Hora";
                Dtg.Columns["HoraRuta"].ReadOnly = true;
                Dtg.Columns["HoraRuta"].DefaultCellStyle.Format = "t";

                Dtg.Columns["ValorTiquete"].Width = 85;
                Dtg.Columns["ValorTiquete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dtg.Columns["ValorTiquete"].HeaderText = "Valor";
                Dtg.Columns["ValorTiquete"].DefaultCellStyle.Format = "#,##0.00";

                Dtg.Columns["Vehiculo"].Width = 75;
                Dtg.Columns["Vehiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["Vehiculo"].HeaderText = "Vehiculo";

                Dtg.Columns["IdDestino"].Visible = false;

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

        //Configurar Grilla
        private void ConfigurarGrilla()
        {
            Tabla = GlobalVar.BDServidor + "dbo.Ruta R INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.Vehiculo V ON R.IdVehiculo=V.IdVehiculo";
            Campos = "IdRuta,IdDestino,Destino,FechaRuta,HoraRuta,ValorTiquete,Vehiculo";
            Condicion = "R.Estado=1 AND R.IdOrigen=" + cboOrigen.SelectedValue + " AND R.IdDestino=" +
                        cboDestino.SelectedValue + " AND FechaRuta='" +
                        Convert.ToDateTime(DtpFechaIda.Value).ToShortDateString() + "'";
            DtBuscar = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            DtgBuscarIda.DataSource = DtBuscar;
            Conf_Buscar(DtgBuscarIda);
        }

        //Cargar combos
        private void CargarCombo()
        {
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboOrigen, (int)miCN.S);
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.Ciudad", "Ciudad", "IdCiudad", "Estado=1", "IdCiudad", cboDestino, (int)miCN.S);

            //Cargamos Agencia
            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.AgenciaSucursal", "Agencia", "IdAgenciaSucursal", "Estado=1", "IdAgencia", cboAgencia, (int)miCN.S);
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            //Validamos datos
            if (Convert.ToInt32(cboOrigen.SelectedValue)==0)
            {
                MessageBox.Show("Por favor Seleccione el Origen a buscar", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            else if (Convert.ToInt32(cboDestino.SelectedValue)==0)
            {
                  MessageBox.Show("Por favor Seleccione el Destino a buscar", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            //Si el orgien es diferente al destino
            if (Convert.ToInt32(cboOrigen.SelectedValue) != Convert.ToInt32(cboDestino.SelectedValue))
            {
                ConfigurarGrilla();
            }
            else
            {
                MessageBox.Show("El Destino no debe ser igual al origen", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                ConfigurarGrilla();
            }
        }

        //Validamos combo Origen
        private void cboOrigen_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboOrigen.SelectedValue) == 0)
            {
                cboOrigen.SelectedValue = 0;
                cboOrigen.Text = "";
            }
        }

        //Validamos combo Destino
        private void cboDestino_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDestino.SelectedValue) == 0)
            {
                cboDestino.SelectedValue = 0;
                cboDestino.Text = "";
            }
        }

        //Validamos combo Agencia
        private void cboAgencia_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgencia.SelectedValue) == 0)
            {
                cboAgencia.SelectedValue = 0;
                cboAgencia.Text = "";
            }
        }

        //Evento al dar double click selecciono y envio datos de la Ruta seleccionada
        private void DtgBuscarIda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si hay datos
            if (DtgBuscarIda.Rows.Count > 0)
            {
                Double Var;
                Var = Convert.ToDouble(DtgBuscarIda.CurrentRow.Cells[0].Value);
                Clientes formInterface = this.Opener as Clientes;

                if (formInterface != null)
                    formInterface.TiquetesBuscar(Convert.ToInt32(Var));
            }
        }
    }
}
