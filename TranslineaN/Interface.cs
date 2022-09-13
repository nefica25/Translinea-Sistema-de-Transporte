using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslineaN
{
    public interface Clientes
    {
        //Interface crear Cliente Alterno
        void Tiquetes(int Documento);
        void TiquetesBuscar(int IdRuta);
    }

    public interface ClientesBuscar
    {
        void ClientesBuscar(int IdCliente);
    }
}
