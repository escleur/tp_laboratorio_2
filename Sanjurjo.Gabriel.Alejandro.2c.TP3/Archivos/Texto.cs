using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda datos en archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = null;
            bool guardo = false;
            try
            {
                writer = new StreamWriter(archivo);
                writer.Write(datos);
                guardo = true;
            }
            catch (Exception ex)
            {

                throw new ArchivosException("Error al escribir el archivo.", ex);
            }
            finally
            {
                writer.Close();
            }
            return guardo;
        }

        /// <summary>
        /// Lee datos desde archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = null;
            string texto = string.Empty;
            bool leyo = false;
            try
            {
                reader = new StreamReader(archivo);
                texto = reader.ReadToEnd();
                leyo = true;
            }
            catch (Exception ex)
            {

                throw new ArchivosException("Error al leer el archivo.", ex);
            }
            datos = texto;
            return leyo;
        }
    }
}
