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
using System.Text.RegularExpressions;

namespace TranslineaN
{
    public partial class frmClientesAlterno : Form
    {
        public Clientes Opener { get; set; }
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        Boolean TodoOk;
        String Campos, Valores;
        int miMax;

        public frmClientesAlterno()
        {
            InitializeComponent();
        }

        private void frmClientesAlterno_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);

            miSql.CargarCombo(GlobalVar.BDServidor + "dbo.TipoDocumento", "TipoDocumento", "IdTipoDocumento", "Estado=1",
                             "IdTipoDocumento", cboTipoDocumento, (int)miCN.S);
        }

        //Pintar formulario
        private void frmClientesAlterno_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);

        }

        //Capturamos teclas con funciones
        private void frmClientesAlterno_KeyDown(object sender, KeyEventArgs e)
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

        //Metodo validamos datos al Ingrsar
        private void Validar()
        {
            TodoOk = false;

            if (cboTipoDocumento.Text.Length == 0)
            {
                MessageBox.Show("Seleccione tipo de Documento", "<Translinea Software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                cboTipoDocumento.Focus();
                return;
            }
            else if (txtDocumento.TextLength == 0)
            {
                MessageBox.Show("Ingrese el numero de Documento", "<Translinea Software>",
                             System.Windows.Forms.MessageBoxButtons.OK,
                             System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                txtDocumento.Focus();
                return;
            }
            else if (txtNombres.TextLength == 0)
            {
                MessageBox.Show("Ingrese el nombre del Cliente por Favor", "<Translinea Software>",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                txtNombres.Focus();
                return;
            }
            else if (txtCelular.TextLength == 0)
            {
                MessageBox.Show("Ingrese el numero de Celular", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                txtCelular.Focus();
                return;
            }
            else if (txtDireccion.TextLength == 0)
            {
                MessageBox.Show("Ingrese la Dirección", "<Translinea Software>",
                              System.Windows.Forms.MessageBoxButtons.OK,
                              System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                txtDireccion.Focus();
                return;
            }
            else if (txtEmail.TextLength == 0)
            {
                MessageBox.Show("Ingrese el Email", "<Translinea Software>",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                TodoOk = false;
                txtEmail.Focus();
                return;
            }

            //Metodo global ValidarEmail
            if (miMt.validarEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("El Email Ingresado no se encuentra en el Formato Correcto", this.Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                TodoOk = false;
                txtEmail.Focus();
                return;
            }


            TodoOk = true;
        }

        //Validamos si el documento existe nuevamente
        private void txtDocumento_Leave(object sender, EventArgs e)
        {

        }

        //Validamos tipo de odcumento
        private void cboTipoDocumento_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
            {
                cboTipoDocumento.SelectedValue = 0;
                cboTipoDocumento.Text = "";
            }
        }

        //Validamos solo Numeros
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        //Validamos que solo ingrese Letras
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        //Validamos correo electronico
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            miMt.validarEmail(txtEmail.Text);
        }

        private void bttnIngresar_Click(object sender, EventArgs e)
        {
            Validar();

            if (TodoOk == true)
            {
                
                GlobalVar.TodoOk = true;
                //Ingresamo Cliente al Servidor de manera Alterna
                miMax = Convert.ToInt32(miSql.Consecutivo(GlobalVar.BDServidor + "dbo.Clientes", "IdCliente", (int)miCN.S));
                Campos = "IdCliente,NroDocumento,IdTipo,TipoDocumento,NombreCompleto, " +
                         "Direccion,Telefono,Celular,email,SaldoActual";
                Valores = miMax + "," + txtDocumento.Text + ",1," + cboTipoDocumento.SelectedValue + ",'" +
                          txtNombres.Text + "','" + txtDireccion.Text + "',0," + txtCelular.Text + ",'" + txtEmail.Text +
                          "',0";
                miSql.Guardar(GlobalVar.BDServidor + "dbo.Clientes", Campos, Valores, (int)miCN.S);

                if (GlobalVar.TodoOk == true)
                {
                    MessageBox.Show("Cliente ingresado correctamente", "<Translinea Software>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Information);

                    //Enviamos datos mediante el comunicador Padre a hijo
                    Clientes formInterface = this.Opener as Clientes;

                    if (formInterface != null)
                        formInterface.Tiquetes(Convert.ToInt32(txtDocumento.Text));
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al tratar de ingresar un Cliente", "<Translinea Software>",
                                  System.Windows.Forms.MessageBoxButtons.OK,
                                  System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
        }

        private void txtNombres_Validated(object sender, EventArgs e)
        {
            txtNombres.Text = txtNombres.Text.ToUpper();
        }

        private void txtDireccion_Validated(object sender, EventArgs e)
        {
            txtDireccion.Text = txtDireccion.Text.ToUpper();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }
               
    }
}
