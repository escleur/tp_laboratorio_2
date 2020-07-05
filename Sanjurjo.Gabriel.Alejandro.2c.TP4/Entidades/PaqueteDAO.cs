using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public delegate void DelegadoDAO();
        public static event DelegadoDAO ErrorDAO;

        /// <summary>
        /// Inserta en la db un paquete, si hay error lanza evento ErrorDAO
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {

                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno)" +
                    " VALUES (@direccionEntrega, @trackingID, @alumno) ";

                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("direccionEntrega", p.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("trackingID", p.TrackingID));
                comando.Parameters.Add(new SqlParameter("alumno", "Sanjurjo Gabriel Alejandro"));
                conexion.Open();

                int n = comando.ExecuteNonQuery();
                if (n == 1)
                {
                    retorno = true;
                }

            }
            catch (Exception e)
            {
                PaqueteDAO.ErrorDAO();
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Constructor, establece la conexion
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data source = .\\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = True");
            comando = new SqlCommand();

        }
    }
}
