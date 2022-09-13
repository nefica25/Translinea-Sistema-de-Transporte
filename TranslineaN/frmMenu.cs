using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TranslineaN
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiquetes frm = new frmTiquetes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void crearRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRuta frm = new frmRuta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cierreCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CierreCaja frm = new CierreCaja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void devolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiquetesDevolucion frm = new frmTiquetesDevolucion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCiudadRecorrido frm = new frmCiudadRecorrido();
            frm.MdiParent = this;
            frm.Show();
        }

        private void PlanillatoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmTiquetesPlanilla frm = new frmTiquetesPlanilla();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agenciaSubmenu_Click(object sender, EventArgs e)
        {
            frmAgencia frm = new frmAgencia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sucursalSubMenu_Click(object sender, EventArgs e)
        {
            frmSucursal frm = new frmSucursal();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vehiculoSubMenuItem_Click(object sender, EventArgs e)
        {
            frmVehiculo frm = new frmVehiculo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void horaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHora frm = new frmHora();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemesas frm = new frmRemesas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void asignarBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignarBus frm = new frmAsignarBus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void modificarRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRutaProceso frm = new frmRutaProceso();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trasladosDeTiquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiquetesTraslados frm = new frmTiquetesTraslados();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
