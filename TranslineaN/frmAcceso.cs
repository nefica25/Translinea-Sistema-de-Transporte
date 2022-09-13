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

namespace TranslineaN
{
    public partial class frmAcceso : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();
        DataTable DtAcceso;
        String Tabla, Campos, Condicion;

        public frmAcceso()
        {
            InitializeComponent();
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);

        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            //Validamos User y Paswword
            Tabla = GlobalVar.BDServidor + "dbo.Usuarios U INNER JOIN " +
                    GlobalVar.BDServidor + "dbo.AgenciaSucursal A ON U.IdAgenciaSucursal=A.IdAgenciaSucursal";
            Campos = "U.Usuario,U.Clave,U.Tipo,A.IdAgenciaSucursal,U.IdUsuario,A.IdCiudad";
            Condicion = "U.Usuario='" + txtUsuario.Text + "' AND U.Clave='" + txtClave.Text +
                        "' AND U.Estado=1";
            DtAcceso = miSql.Seleccionar(Tabla, Campos, Condicion, (int)miCN.S);

            if (DtAcceso.Rows.Count > 0)
            {
                //Tipo: 1:Agencia 2:Sucursal
                if (Convert.ToInt32(DtAcceso.Rows[0]["Tipo"]) == 1)
                {
                    GlobalVar.AgenciaSucursal = Convert.ToInt32(DtAcceso.Rows[0]["IdAgenciaSucursal"]);
                    GlobalVar.IdUsuario = Convert.ToInt32(DtAcceso.Rows[0]["IdUsuario"]);
                    GlobalVar.IdOrigen = Convert.ToInt32(DtAcceso.Rows[0]["IdCiudad"]);
                    frmMenu frm = new frmMenu();
                    frm.Show();
                }
                else if (Convert.ToInt32(DtAcceso.Rows[0]["Tipo"]) == 2) 
                {
                    GlobalVar.AgenciaSucursal = Convert.ToInt32(DtAcceso.Rows[0]["IdAgenciaSucursal"]);
                    GlobalVar.IdUsuario = Convert.ToInt32(DtAcceso.Rows[0]["IdUsuario"]);
                    GlobalVar.IdOrigen = Convert.ToInt32(DtAcceso.Rows[0]["IdCiudad"]);
                    frmMenu frm = new frmMenu();
                    frm.Show();
                }
                this.Hide();

                //Guardamos Variables Globales
                //IdAgencia y IdOrigen o IdSucursal
            }
            else
            {
                MessageBox.Show("El usuario o contraseña no son validos", "<Translinea software>",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}
