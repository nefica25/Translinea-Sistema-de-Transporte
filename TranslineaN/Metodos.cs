using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TranslineaN
{
    class Metodos
    {
        Boolean Check;
        Boolean Estadofrm;

        public void LimpiarFormularioGeneral(Control Parent)
        {
            foreach (Control Control in Parent.Controls)
            {
                if (Control.HasChildren)
                {
                    foreach (Control Panel in Control.Controls)
                    {
                        if (Panel is TextBox)
                        {
                            Panel.Text = "";
                        }
                        else if (Control is TabControl)
                        {
                            LimpiarTabControl(Control);
                        }
                        else if (Panel is ComboBox)
                        {
                            LimpiarCombos(Control);
                        }
                        else if (Panel is CheckBox)
                        {
                            ((CheckBox)Panel).Checked = false;
                        }
                    }
                }
            }
        }

        public void LimpiarPanel(Panel Pnl) //Limpiamos Panel
        {
            foreach (Control Control in Pnl.Controls)
            {
                if (Control is TextBox)
                {
                    Control.Text = "";
                }
                else if (Control is ComboBox)
                {
                    ((ComboBox)Control).SelectedValue = 0;
                    Control.Text = "";
                }
                else if (Control is CheckBox)
                {
                    ((CheckBox)Control).Checked = false;
                }
            }
        }

        public void LimpiarTabControl(Control Tab)
        {
            foreach (Control TabControl in Tab.Controls)
            {
                if (TabControl is TextBox)
                {
                    TabControl.Text = "";
                }
                else if (TabControl.HasChildren)
                {
                    foreach (Control SubTabPage in TabControl.Controls)
                    {
                        if (SubTabPage is TextBox)
                        {
                            SubTabPage.Text = "";
                        }
                        else if (SubTabPage is ComboBox)
                        {
                            SubTabPage.Text = "";
                        }
                        else
                        {
                            //Limpiamos los Paneles que estan dentro del TabControl
                            foreach (Control SubPagePanel in SubTabPage.Controls)
                            {
                                if (SubPagePanel is TextBox)
                                {
                                    SubPagePanel.Text = "";
                                }
                                else if (SubPagePanel is ComboBox)
                                {
                                    SubPagePanel.Text = "";
                                    ((ComboBox)SubPagePanel).SelectedValue = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LimpiarCombos(Control Parent)
        {
            foreach (Control Cbo in Parent.Controls)
            {
                if (Cbo is ComboBox)
                {
                    Cbo.Text = "";
                    ((ComboBox)Cbo).SelectedValue = 0;
                }
                else if (Cbo.HasChildren)
                {
                    foreach (Control Subcbo in Cbo.Controls)
                    {
                        Subcbo.Text = "";
                        ((ComboBox)Subcbo).SelectedValue = 0;

                        foreach (Control SubcboTab in Subcbo.Controls)
                        {
                            Subcbo.Text = "";
                            ((ComboBox)Subcbo).SelectedValue = 0;
                        }
                    }
                }
            }
        }

        public void BloquearControles(Control Parent, Boolean onOf)
        {
            if (onOf == true)
            {
                Check = false;
            }
            else
            {
                Check = true;
            }

            foreach (Control Bloquear in Parent.Controls)
            {
                if (Bloquear is TextBox) //Bloqueamos cajas de texto normal
                {
                    ((TextBox)Bloquear).ReadOnly = onOf;
                    Bloquear.BackColor = System.Drawing.Color.White;
                }
                else if (Bloquear is ComboBox)
                {
                    BLoquearCombos(Bloquear, onOf);
                }
                else if (Bloquear is CheckBox)
                {
                    ((CheckBox)Bloquear).Enabled = onOf;
                }
                else if (Bloquear is TabControl) //Bloqueamo TabControls
                {
                    BloquearTabControl(Bloquear, onOf);
                }
                else if (Bloquear.HasChildren) //Si existen controles secundarios
                {
                    foreach (Control Pnl in Bloquear.Controls)
                    {
                        if (Pnl is TextBox)
                        {
                            ((TextBox)Pnl).ReadOnly = onOf;
                            Pnl.BackColor = System.Drawing.Color.White;
                        }
                        else if (Pnl is CheckBox)
                        {
                            ((CheckBox)Pnl).Enabled = Check;
                        }
                    }
                }
            }

            BLoquearCombos(Parent, onOf);
        }

        private void BloquearTabControl(Control Parent, Boolean onOf)
        {
            foreach (Control TabControl in Parent.Controls)
            {
                foreach (Control SubPage in TabControl.Controls)
                {
                    if (SubPage is TextBox)
                    {
                        ((TextBox)SubPage).ReadOnly = onOf;
                        SubPage.BackColor = System.Drawing.Color.White;
                    }
                    else if (SubPage.HasChildren)
                    {
                        //Bloqueamos los Paneles que estan dentro del TabControl
                        foreach (Control SubPagePanel in SubPage.Controls)
                        {
                            if (SubPagePanel is TextBox)
                            {
                                ((TextBox)SubPagePanel).ReadOnly = onOf;
                                SubPagePanel.BackColor = System.Drawing.Color.White;
                            }
                        }
                    }
                }
            }
        }

        public void BLoquearCombos(Control Parent, Boolean Estado)
        {
            Estadofrm = Estado;
            foreach (Control cbo in Parent.Controls)
            {
                if (Estado == true && cbo is ComboBox)
                {
                    ((ComboBox)cbo).DropDownStyle = ComboBoxStyle.Simple;
                    cbo.Text = "";
                    cbo.KeyPress += new KeyPressEventHandler(Press);
                    ((ComboBox)cbo).SelectedValue = 0;
                }
                else if (Estado == false && cbo is ComboBox)
                {
                    ((ComboBox)cbo).DropDownStyle = ComboBoxStyle.DropDown;
                    cbo.KeyPress += new KeyPressEventHandler(Press);
                }
                else if (cbo.HasChildren)
                {
                    foreach (Control cboSub in cbo.Controls)
                    {
                        if (Estado == true && cboSub is ComboBox)
                        {
                            ((ComboBox)cboSub).DropDownStyle = ComboBoxStyle.Simple;
                            cboSub.Text = "";
                            cboSub.KeyPress += new KeyPressEventHandler(Press);
                            ((ComboBox)cboSub).SelectedValue = 0;
                        }
                        else if (Estado == false && cboSub is ComboBox)
                        {
                            ((ComboBox)cboSub).DropDownStyle = ComboBoxStyle.DropDown;
                            cboSub.Text = "";
                            cboSub.KeyPress += new KeyPressEventHandler(Press);
                            ((ComboBox)cboSub).SelectedValue = 0;
                        }

                        foreach (Control cboSubTab in cboSub.Controls)//Recorremos Tab Control
                        {
                            if (Estado == true && cboSubTab is ComboBox)
                            {
                                ((ComboBox)cboSubTab).DropDownStyle = ComboBoxStyle.Simple;
                                cboSubTab.Text = "";
                                cboSubTab.KeyPress += new KeyPressEventHandler(Press);
                                ((ComboBox)cboSubTab).SelectedValue = 0;
                            }
                            else if (Estado == false && cboSubTab is ComboBox)
                            {
                                ((ComboBox)cboSubTab).DropDownStyle = ComboBoxStyle.DropDown;
                                cboSubTab.Text = "";
                                cboSubTab.KeyPress += new KeyPressEventHandler(Press);
                                ((ComboBox)cboSubTab).SelectedValue = 0;
                            }
                        }
                    }
                }
            }
        }

        private void Press(object sender, KeyPressEventArgs e)
        {
            if (Estadofrm == true)
            {
                e.Handled = true;
            }
            else if (Estadofrm == false)
            {
                e.Handled = false;
            }
        }

        //Metodo para Validar Correo electronico
        public  bool validarEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Cargamos un Combo desconectado por defecto
        public void CargarCombo(ComboBox cbo)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Descripcion");

            DataRow row = dt.NewRow();
            row["Id"] = 1;
            row["Descripcion"] = "Activo";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Id"] = 2;
            row["Descripcion"] = "Inactivo";
            dt.Rows.Add(row);

            cbo.DataSource = dt;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "Id";
        }

        //
        public void Cell_Formating()
        {

        }

        //Cargamos combo asignandole valores
        public void CargarComboValores()
        {

        }

        public void miEquipo()
        {

        }

        public void miUsuario()
        {

        }

        public void Empresa()
        {

        }
    }
}
