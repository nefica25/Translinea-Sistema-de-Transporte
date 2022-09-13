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
    public partial class frmHora : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        String Tabla, Campos, Condicion;
        DataTable DtHora;
        long miProceso;
        int miMax;

        public frmHora()
        {
            InitializeComponent();
        }

        private void frmHora_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            miMt.CargarCombo(cboEstado);
            ConfigurarGrilla();
            miProceso = (int)Bandera.a;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Pintamos el formulario
        private void frmHora_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturamos teclas
        private void frmHora_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Configuracion de la grilla
        private void Conf_DtgRuta(DataGridView Dtg)
        {
            if (Dtg.Rows.Count >= 0)
            {
                Dtg.Columns["IdHora"].Width = 90;
                Dtg.Columns["IdHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dtg.Columns["IdHora"].HeaderText = "Codigo";

                Dtg.Columns["Hora"].Width = 140;
                Dtg.Columns["Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Hora"].HeaderText = "Hora de Ruta";

                Dtg.Columns["Estado"].Width = 108;
                Dtg.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg.Columns["Estado"].HeaderText = "Estado";


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

        //Cargamos nela grilla los horarios existrentes
        private void ConfigurarGrilla()
        {
            Tabla = GlobalVar.BDServidor + "dbo.Hora";
            Campos = "IdHora,Hora,Estado";
            Condicion = "Estado=1";

            DtHora = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);
            DtgHora.DataSource = DtHora;
            Conf_DtgRuta(DtgHora);
        }

        //Digitar solo letras
        private void ValidarSoloLetras(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar("/") || e.KeyChar == Convert.ToChar("-") || e.KeyChar == Convert.ToChar(":"))
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

        //Boton Adicionar
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {
            miMt.LimpiarFormularioGeneral(this);
            miProceso = (int)Bandera.a;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton guardar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            if (txtHora.TextLength == 0)
            {
                MessageBox.Show("Ingrese hora", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                txtHora.Focus();
                return;
            }
            else if (cboEstado.Text.Length == 0)
            {
                MessageBox.Show("Seleccione el Estado", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                txtHora.Focus();
                return;
            }
            GlobalVar.TodoOk = true;
            if (miProceso == (int)Bandera.a)
            {
                miMax = miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Hora", "IdHora", (int)miCN.S);
                Campos = "IdHora,Hora,Estado";
                miSql.Guardar(GlobalVar.BDServidor + "dbo.Hora", Campos, miMax + ",'" + txtHora.Text + "'," + cboEstado.SelectedValue + "",
                             (int)miCN.S);

                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Registro enviado correctamente", "<Translinea Software>",
                          System.Windows.Forms.MessageBoxButtons.OK,
                          System.Windows.Forms.MessageBoxIcon.Information);
                    ConfigurarGrilla();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al guardar", "<Translinea Software>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            else if (miProceso == (int)Bandera.m)
            {
                if (txtCodigo.TextLength==0)
                {
                     MessageBox.Show("Seleccione el registro a actualizar", "<Translinea Software>",
                                     System.Windows.Forms.MessageBoxButtons.OK,
                                     System.Windows.Forms.MessageBoxIcon.Information);
                     return;
                }
                miSql.Actualizar(GlobalVar.BDServidor + "dbo.Hora", "Hora='" + txtHora.Text + "',Estado=" + cboEstado.SelectedValue + "",
                                "IdHora=" + txtCodigo.Text + "", (int)miCN.S);

                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Registro actualizado correctamente", "<Translinea Software>",
                          System.Windows.Forms.MessageBoxButtons.OK,
                          System.Windows.Forms.MessageBoxIcon.Information);
                    ConfigurarGrilla();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al actualizar", "<Translinea Software>",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        //Boton cacelar
        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            miProceso = (int)Bandera.m;
            BloquearDesbloquear();
            BloquearDesbloquearBotones();
        }

        //Boton buscar
        private void bttnBuscar_Click(object sender, EventArgs e)
        {

        }

        //Boton salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHora_Leave(object sender, EventArgs e)
        {
            txtHora.Text = txtHora.Text.ToUpper();
        }

        private void cboEstado_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboEstado.SelectedValue) == 0)
            {
                cboEstado.SelectedValue = 0;
                cboEstado.Text = "";
            }
        }

        private void txtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        private void cboEstado_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboEstado.SelectedValue) == 0)
            {
                cboEstado.SelectedValue = 0;
                cboEstado.Text = "";
            }
        }

        //Evento enlaza grilla con las cajas
        private void DtgHora_SelectionChanged(object sender, EventArgs e)
        {
            if (miProceso == (int)Bandera.m)
            {
                txtCodigo.Text = Convert.ToString(DtgHora.CurrentRow.Cells["IdHora"].Value);
                txtHora.Text = Convert.ToString(DtgHora.CurrentRow.Cells["Hora"].Value);
                cboEstado.SelectedValue = Convert.ToString(DtgHora.Rows[DtgHora.CurrentRow.Index].Cells["Estado"].Value);
            }
        }
    }
}
