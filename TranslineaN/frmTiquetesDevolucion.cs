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
    public partial class frmTiquetesDevolucion : Form
    {
        Metodos miMt = new Metodos();
        EstiloFormulario miEstilo = new EstiloFormulario();
        SQLConexion miSql = new SQLConexion();

        public frmTiquetesDevolucion()
        {
            InitializeComponent();
        }

        private void frmTiquetesDevolucion_Load(object sender, EventArgs e)
        {
            miEstilo.EstiloGeneralFormulario(this);
            CargarCombo(cboTipoDevolucion);
        }

        //Cargamos un Combo desconectado por defecto
        public void CargarCombo(ComboBox cbo)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Descripcion");

            DataRow row = dt.NewRow();
            row["Id"] = 1;
            row["Descripcion"] = "INDIVIDUAL";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Id"] = 2;
            row["Descripcion"] = "COMPLETA";
            dt.Rows.Add(row);

            cbo.DataSource = dt;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "Id";
        }

        //Pintar fomrulario
        private void frmTiquetesDevolucion_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        //Capturar Teclas
        private void frmTiquetesDevolucion_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //Boton Adicionar
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {

        }

        //Boton guardar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            //Validar que no halla generado planilla

            //Validar que la fecha no este vencida
        }

        //Boton Imprimir
        private void bttnImprimir_Click(object sender, EventArgs e)
        {

        }

        //Boton Salir
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }     
    }
}
