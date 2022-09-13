using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TranslineaN
{

    //Variables banderas
    public enum Bandera : int
    {
        n = 0, a = 1, m = 2
    };

    public enum Estado : int
    {
        Activo = 1,
        Inactivo = 2
    }

    enum miCN : int
    {
        S = 1,
        L = 2
    };

    //Variables globales
    public static class GlobalVar
    {
        public static Boolean TodoOk;
        public static Int32 IdUsuario=0;
        public static Int32 AgenciaSucursal;
        public static Int32 IdOrigen;
        public static Boolean Verificar;
        public static String BDServidor = "Translinea.";
        public static String BDLocal = "TranslineaLocal.";
    }
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAcceso());
        }
    }
}
