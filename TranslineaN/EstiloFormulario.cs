using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace TranslineaN
{
    class EstiloFormulario
    {

        public void EstiloGeneralFormulario(Control Frm)
        {
            ((Form)Frm).MaximizeBox = false;
            ((Form)Frm).FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (Control Control in Frm.Controls)
            {
                if (Control is Panel)
                {
                    ((Panel)Control).BorderStyle = BorderStyle.Fixed3D;
                    ((Panel)Control).BackColor = Color.Transparent;
                }
            }
        }


        public void PintarFormulario()
        {

        }
    }
}
