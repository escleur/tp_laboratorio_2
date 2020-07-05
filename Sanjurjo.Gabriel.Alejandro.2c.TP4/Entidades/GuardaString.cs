using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        /// <summary>
        /// Metodo de extension que guarda el texto en un archivo
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter writer = null;
            bool guardo = false;
            try
            {
                writer = new StreamWriter(archivo, true);
                writer.WriteLine($"{texto}");
                guardo = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                writer.Close();
            }
            return guardo;
        }
    }
}
