using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer ser = null;
            bool guardo = false;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer,datos);
                guardo = true;
            }
            catch (Exception ex)
            {

                throw new ArchivosException("Error al escribir el archivo XML.", ex);
            }
            finally
            {
                if(!(writer is null))
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
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer ser = null;
            bool leyo = false;
            try
            {
                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                leyo = true;
            }
            catch (Exception ex)
            {

                throw new ArchivosException("Error al leer el archivo XML.", ex);
            }
            return leyo;
        }
    }
}
