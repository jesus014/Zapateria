using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Venta.GUI.Contrasenia2
{
    class Generar2
    {
        public bool Genrar2(string usuario, string contrasena)
        {

            try
            {
                StreamWriter archivo = new StreamWriter("UsuarioV.txt");
                StreamWriter archivo2 = new StreamWriter("ContrasenaV.txt");
                archivo.Write("{0}", usuario);
                archivo2.Write("{0}", contrasena);
                archivo.Close();
                archivo2.Close();
                return true;
            }



            catch (Exception)
            {
                return false;
            }

        }

    }
}
