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
    public partial class frmTiquetesTraslados : Form
    {
        public frmTiquetesTraslados()
        {
            InitializeComponent();
        }

        private void frmTiquetesTraslados_Load(object sender, EventArgs e)
        {

        }

        private void frmTiquetesTraslados_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightSteelBlue,
            Color.Teal, LinearGradientMode.Horizontal);

            gr.FillRectangle(brocha, rectangulo);
        }

        private void frmTiquetesTraslados_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //Boton Adicionar
        private void bttnAdicionar_Click(object sender, EventArgs e)
        {

        }

        //Boton Guradar
        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            //Validar que la fecha no este vencida, a la salida del viaje maximo el mismo dia
            //antes del medio día y que no se halla generado la planilla



            //Validamos que la fecha a realizar el traslado no sea inferior a la actual.


            //Solo se pueden hacer traslado hacia el mismo Destino desde el mismo origen que
            //Compro el Tiquete hacia fechas o horas posteriores

        }

        //Boton Buscar
        private void bttnBuscar_Click(object sender, EventArgs e)
        {

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
