using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Existencia.GUI.Contrasenia3
{
    public class Generar3
    {
        public bool Genrar3(string usuario, string contrasena)
        {

            try
            {
                StreamWriter archivo = new StreamWriter("UsuarioE.txt");
                StreamWriter archivo2 = new StreamWriter("ContrasenaE.txt");
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
