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
    public partial class frmClientesBuscar : Form
    {
        public ClientesBuscar Opener { get; set; }
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        DataTable DtBuscar;
        String Tabla, Campos, Condicion;
       
        public frmClientesBuscar()
        {
            InitializeComponent();
        }

        private void frmClientesBuscar_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            CargarCombo(cboOpcion);
            cboOpcion.SelectedValue = 0;

            ConfigurarGrilla();
        }

        //Pintar formulario
        private void frmClientesBuscar_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Cargamos un Combo desconectado por defecto
        public void CargarCombo(ComboBox cbo)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Descripcion");

            DataRow row = dt.NewRow();
            row["Id"] = 1;
            row["Descripcion"] = "Documento del Cliente";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Id"] = 2;
            row["Descripcion"] = "Nombre del Cliente";
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

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["IdCliente"].Width = 50;
                Dtg.Columns["IdCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdCliente"].HeaderText = "Codigo";

                Dtg.Columns["NroDocumento"].Width = 90;
                Dtg.Columns["NroDocumento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["NroDocumento"].HeaderText = "Documento";

                Dtg.Columns["NombreCompleto"].Width = 220;
                Dtg.Columns["NombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["NombreCompleto"].HeaderText = "Nombre Completo";

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

        //Validamos opcion para filtrar datos
        private void ValidarOpcion()
        {
            Condicion = "";
            if (Convert.ToInt32(cboOpcion.SelectedValue) == 1)
            {
                Condicion = "NroDocumento=" + Convert.ToInt32(txtBuscar.Text) + " AND Estado=1";
            }
            else if (Convert.ToInt32(cboOpcion.SelectedValue) == 2)
            {
                Condicion = "NombreCompleto LIKE '" + txtBuscar.Text + "%' AND Estado=1";
            }
            else
            {
                Condicion = "Estado=0";
            }
        }

        //Cargamos resultado en la grilla
        private void ConfigurarGrilla()
        {
            ValidarOpcion();
            DtBuscar = new DataTable();
            Tabla = GlobalVar.BDServidor + "dbo.Clientes";
            Campos = "IdCliente,NroDocumento,NombreCompleto";

            DtBuscar = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);
            DtgBuscar.DataSource = DtBuscar;
            Conf_DtgRuta(DtgBuscar);
        }

        //Boton salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton Buscar
        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            if (cboOpcion.Text.Length == 0)
            {
                MessageBox.Show("Seleccione opcion a buscar", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                cboOpcion.Focus();
                return;
            }
            if (txtBuscar.TextLength == 0)
            {
                MessageBox.Show("Digite el campo a buscar", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                txtBuscar.Focus();
                return;
            }

            ConfigurarGrilla();
        }

        //NO permite caracteres especiales
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(cboOpcion.SelectedValue) == 1)
            {
                LblBuscar.Text = "Codigo";
                ValidarSoloNumeros(e);
            }
            else if (Convert.ToInt32(cboOpcion.SelectedValue) == 2)
            {
                LblBuscar.Text = "Nombre";
                ValidarSoloLetras(e);
            }
        }

        private void cboOpcion_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboOpcion.SelectedValue) == 0)
            {
                cboOpcion.SelectedValue = 0;
                cboOpcion.Text = "";
            }
            else
            {
                txtBuscar.Clear();
                Condicion = "Estado=0";

                if (Convert.ToInt32(cboOpcion.SelectedValue) == 1)
                {
                    LblBuscar.Text = "Codigo";
                }
                else if (Convert.ToInt32(cboOpcion.SelectedValue) == 2)
                {
                    LblBuscar.Text = "Nombre";
                }
            }
        }

        private void DtgBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si hay datos
            if (DtgBuscar.Rows.Count > 0)
            {
                Double Var;
                Var = Convert.ToDouble(DtgBuscar.CurrentRow.Cells[0].Value);
                ClientesBuscar formInterface = this.Opener as ClientesBuscar;

                if (formInterface != null)
                    formInterface.ClientesBuscar(Convert.ToInt32(Var));
            }
        }
              
    }
}
