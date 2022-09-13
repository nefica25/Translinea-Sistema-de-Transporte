using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Common;

namespace TranslineaN
{
    class SQLConexion
    {
        public int Conexion;
        public SqlConnection ConS, ConL = new SqlConnection();
        public SqlCommand Sql = new SqlCommand();
        public SqlCeConnection ConCE = null;

       // String BDServidor = "Data Source=COL-PC\\PORTMOBILE; Initial Catalog=Translinea; User Id=Nestor; Password= 123...";
        String BDServidor = "Data Source=VOYMOVIL\\TECNOLOGIA; Initial Catalog=Translinea; Integrated Security=True";
       // String BDServidor = "Data Source=WIN-R8G2NCB4N72\\TECNISOFT2010; Initial Catalog=Translinea; Integrated Security=True";
        String BDLocal = "Data Source=COLPOMBOBACHILL\\SQLEXPRESS; Initial Catalog=TranslineaLocal; Integrated Security=True";
        //WIN-R8G2NCB4N72

        public void ConexionSQL()
        {
            Conexion = 0;
            ConS = new SqlConnection(BDServidor);
            ConL = new SqlConnection(BDLocal);


        }

        public void AbrirS()
        {
            ConS.Open();
        }

        public void CerrarS()
        {
            ConS.Close();
        }

        public void AbrirL()
        {
            ConL.Open();
        }

        public void CerrarL()
        {
            ConL.Close();
        }
           
        public SqlConnection cnnS()
        {
            ConS = new SqlConnection(BDServidor);
            return ConS;
        }

        public SqlConnection cnnL()
        {
            ConL = new SqlConnection(BDLocal);
            return ConL;
        }

        public int VerificarConexion()
        {
            if ((int)miCN.S == Conexion)
            {
                return 1;
            }
            else if ((int)miCN.L == Conexion)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        //Guardar
        public void Guardar(String Tabla, String Campos, String Valores, long Conexion)
        {
            try
            {
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    String vCriterio = "INSERT INTO " + Tabla + "(" + Campos + ") VALUES (" + Valores + ")";
                    Sql = new SqlCommand(vCriterio, ConS);
                    Sql.ExecuteNonQuery();

                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    AbrirL();
                    String vCriterio = "INSERT INTO " + Tabla + "(" + Campos + ") VALUES (" + Valores + ")";
                    Sql = new SqlCommand(vCriterio, ConL);
                    Sql.ExecuteNonQuery();

                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarL();
                    }
                }
            }
            catch (Exception err)
            {
                GlobalVar.TodoOk = false;
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
            }
        }

        //Guardar multiples
        public void Guardar(String TablaInsert, String CamposInsert, String CamposSelect,
                            String TablaSelect, String Condicion, long Conexion)
        {
            try
            {
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    String vCriterio = "INSERT INTO " + TablaInsert + "(" + CamposInsert + ") Select " +
                                        CamposSelect + " From " + TablaSelect + " Where " + Condicion;
                    Sql = new SqlCommand(vCriterio, ConS);
                    Sql.ExecuteNonQuery();

                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    AbrirL();
                    String vCriterio = "INSERT INTO " + TablaInsert + "(" + CamposInsert + ") Select " +
                                     CamposSelect + " From " + TablaSelect + " Where " + Condicion;
                    Sql = new SqlCommand(vCriterio, ConL);
                    Sql.ExecuteNonQuery();

                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarL();
                    }
                }
            }
            catch (Exception err)
            {
                GlobalVar.TodoOk = false;
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
            }
        }

        //Actualizar
        public void Actualizar(String Tabla, String CamposConValores, String Condicion, long Conexion)
        {
            try
            {
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    String vCriterio = "Update " + Tabla + " Set " + CamposConValores + " Where " + Condicion;
                    Sql = new SqlCommand(vCriterio, ConS);
                    Sql.ExecuteNonQuery();

                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    AbrirL();
                    String vCriterio = "Update " + Tabla + " Set " + CamposConValores + " Where " + Condicion;
                    Sql = new SqlCommand(vCriterio, ConL);
                    Sql.ExecuteNonQuery();

                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarL();
                    }
                }
            }
            catch (Exception err)
            {
                GlobalVar.TodoOk = false;
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
            }
        }

        //Seleccionar Datos
        public DataTable Seleccionar(String Tabla, String Campos, String Condicion, long Conexion)
        {
            DataTable DtDatos = new DataTable();
            try
            {
                ConexionSQL();
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        String VCriterio = "Select " + Campos + " From " + Tabla + " Where " + Condicion;
                        SqlDataAdapter Adap = new SqlDataAdapter(VCriterio, ConS);
                        Adap.Fill(DtDatos);

                        if (ConS.State == System.Data.ConnectionState.Open)
                        {
                            CerrarS();
                        }
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    AbrirL();
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        String VCriterio = Tabla + Campos + Condicion;
                        SqlDataAdapter Adap = new SqlDataAdapter(VCriterio, ConL);
                        Adap.Fill(DtDatos);

                        if (ConL.State == System.Data.ConnectionState.Open)
                        {
                            CerrarL();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return DtDatos;
        }

        //Eliminar Todo
        public void EliminarTodo(String Tabla, long Conexion)
        {
            DataTable DtDatos = new DataTable();
            ConexionSQL();
            if (Conexion == (int)miCN.S)
            {
                AbrirS();
                String VCriterio = "TRUNCATE TABLE " + Tabla;
                Sql = new SqlCommand(VCriterio, ConS);
                Sql.ExecuteNonQuery();

                if (ConS.State == System.Data.ConnectionState.Open)
                {
                    CerrarS();
                }
            }
            else if (Conexion == (int)miCN.L)
            {
                AbrirL();
                if (ConL.State == System.Data.ConnectionState.Open)
                {
                    String VCriterio = "TRUNCATE TABLE " + Tabla;
                    Sql = new SqlCommand(VCriterio, ConL);
                    Sql.ExecuteNonQuery();

                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarL();
                    }
                }
            }
        }

        //Eliminar con condicion
        public void Eliminar(String Tabla, String Condicion, long Conexion)
        {
            DataTable DtDatos = new DataTable();
            ConexionSQL();
            if (Conexion == (int)miCN.S)
            {
                AbrirS();
                String VCriterio = "Delete " + " From " + Tabla + " Where " + Condicion;
                Sql = new SqlCommand(VCriterio, ConS);
                Sql.ExecuteNonQuery();

                if (ConS.State == System.Data.ConnectionState.Open)
                {
                    CerrarS();
                }
            }
            else if (Conexion == (int)miCN.L)
            {
                AbrirL();
                if (ConL.State == System.Data.ConnectionState.Open)
                {
                    String VCriterio = "Delete " + " From " + Tabla + " Where " + Condicion;
                    Sql = new SqlCommand(VCriterio, ConL);
                    Sql.ExecuteNonQuery();

                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarL();
                    }
                }
            }
        }

        //Consecutivo
        public int Consecutivo(String Tabla, String Campo, String Condicion, long Conexion)
        {
            int Consecutivo = 0;
            try
            {
                ConexionSQL();
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        String VCriterio = "Select MAX(" + Campo + ") From " + Tabla + " Where " + Condicion;
                        Sql = new SqlCommand(VCriterio, ConS);
                        SqlDataReader sqlReader = Sql.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            if (Convert.ToInt32(sqlReader[0]) > 0)
                            {
                                Consecutivo = Convert.ToInt32(sqlReader[0]) + 1;
                            }
                            else
                            {
                                Consecutivo = 1;
                            }
                        }
                        if (ConS.State == System.Data.ConnectionState.Open)
                        {
                            CerrarS();
                        }
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    AbrirL();
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        String VCriterio = "Select MAX(" + Campo + ") From " + Tabla + " Where " + Condicion;
                        Sql = new SqlCommand(VCriterio, ConL);
                        SqlDataReader sqlReader = Sql.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            if (Convert.ToInt32(sqlReader[0]) > 0)
                            {
                                Consecutivo = Convert.ToInt32(sqlReader[0]) + 1;
                            }
                            else
                            {
                                Consecutivo = 1;
                            }
                        }
                        if (ConL.State == System.Data.ConnectionState.Open)
                        {
                            CerrarL();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                GlobalVar.Verificar = false;
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
            }

            return Consecutivo;
        }

        //Consecutivo
        public int Consecutivo(String Tabla, String Campo, long Conexion)
        {
            int Consecutivo = 0;
            try
            {
                ConexionSQL();
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        String VCriterio = "Select MAX(" + Campo + ") From " + Tabla;
                        Sql = new SqlCommand(VCriterio, ConS);
                        SqlDataReader sqlReader = Sql.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            if (sqlReader[0].ToString().Length > 0)
                            {
                                Consecutivo = Convert.ToInt32(sqlReader[0]) + 1;
                            }
                            else
                            {
                                if (Tabla == "BDServidor.dbo.Productos")
                                {
                                    Consecutivo = 20001;
                                }
                                else
                                {
                                    Consecutivo = 1;
                                }
                            }
                        }
                        if (ConS.State == System.Data.ConnectionState.Open)
                        {
                            CerrarS();
                        }
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    AbrirL();
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        String VCriterio = "Select MAX(" + Campo + ") From " + Tabla;
                        Sql = new SqlCommand(VCriterio, ConL);
                        SqlDataReader sqlReader = Sql.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            if (sqlReader[0].ToString().Length > 0)
                            {
                                Consecutivo = Convert.ToInt32(sqlReader[0]) + 1;
                            }
                            else
                            {
                                Consecutivo = 1;
                            }
                        }
                        if (ConL.State == System.Data.ConnectionState.Open)
                        {
                            CerrarL();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                GlobalVar.TodoOk = false;
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
            }

            return Consecutivo;
        }

        //Cargar combo con BD
        public void CargarCombo(String Tabla, String CampoMostrar, String CampoValue, String Condicion, String Ordenar, ComboBox cbo, long Conexion)
        {
            try
            {
                ConexionSQL();
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        DataTable DtDatos = new DataTable();
                        String VCriterio = "Select *  From " + Tabla + " Where " + Condicion + " Order by " + Ordenar;
                        SqlDataAdapter Adap = new SqlDataAdapter(VCriterio, ConS);
                        Adap.Fill(DtDatos);

                        cbo.DataSource = DtDatos;
                        cbo.DisplayMember = CampoMostrar;
                        cbo.ValueMember = CampoValue;

                        if (ConS.State == System.Data.ConnectionState.Open)
                        {
                            CerrarS();
                        }
                    }
                    else if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        DataTable DtDatos = new DataTable();
                        String VCriterio = "Select *  From " + Tabla + " Where " + Condicion + " Order by " + Ordenar;
                        SqlDataAdapter Adap = new SqlDataAdapter(VCriterio, ConL);
                        Adap.Fill(DtDatos);

                        cbo.DataSource = DtDatos;
                        cbo.DisplayMember = CampoMostrar;
                        cbo.ValueMember = CampoValue;

                        if (ConL.State == System.Data.ConnectionState.Open)
                        {
                            CerrarL();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarL();
                    }
                }
            }

        }

        public void CargarCombo(String Tabla, String Campos, String CampoMostrar, String CampoValue, String Condicion, String Ordenar, ComboBox cbo, long Conexion)
        {
            try
            {
                ConexionSQL();
                if (Conexion == (int)miCN.S)
                {
                    AbrirS();
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        DataTable DtDatos = new DataTable();
                        String VCriterio = "Select " + Campos + "  From " + Tabla + " Where " + Condicion + " Order by " + Ordenar;
                        SqlDataAdapter Adap = new SqlDataAdapter(VCriterio, ConS);
                        Adap.Fill(DtDatos);

                        cbo.DataSource = DtDatos;
                        cbo.DisplayMember = CampoMostrar;
                        cbo.ValueMember = CampoValue;

                        if (ConS.State == System.Data.ConnectionState.Open)
                        {
                            CerrarS();
                        }
                    }
                    else if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        DataTable DtDatos = new DataTable();
                        String VCriterio = "Select *  From " + Tabla + " Where " + Condicion + " Order by " + Ordenar;
                        SqlDataAdapter Adap = new SqlDataAdapter(VCriterio, ConL);
                        Adap.Fill(DtDatos);

                        cbo.DataSource = DtDatos;
                        cbo.DisplayMember = CampoMostrar;
                        cbo.ValueMember = CampoValue;

                        if (ConL.State == System.Data.ConnectionState.Open)
                        {
                            CerrarL();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message + "Ocurrio un error", "<Proyecto>",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Error);

                if (Conexion == (int)miCN.S)
                {
                    if (ConS.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
                else if (Conexion == (int)miCN.L)
                {
                    if (ConL.State == System.Data.ConnectionState.Open)
                    {
                        CerrarS();
                    }
                }
            }

        }

        public void ProcesoActualizar()
        {

        }
    }
}
