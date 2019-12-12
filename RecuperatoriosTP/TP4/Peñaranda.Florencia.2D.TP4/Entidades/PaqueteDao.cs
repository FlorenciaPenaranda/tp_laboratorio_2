using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    static class PaqueteDAO
    {
        #region Atributos
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa las variables a utilizarse  para conectarse a la base de datos.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = PaqueteDAO.conexion;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Inicia la coneccion con la base de datos y guarda la informacion del paquete que se envia como parametro
        /// </summary>
        /// <param name="p">Paquete que se guarda en la base de datos</param>
        /// <returns>true si el numero de filas afectadas es > 0 false si no pudo afectar ninguna fila</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            StringBuilder con = new StringBuilder();
            con.AppendFormat($"INSERT INTO Paquetes VALUES('{0}', '{1}', 'Peñaranda, Florencia')", p.DireccionEntrega, p.TrackingId);

            try
            {
                conexion.Open();
                if (comando.ExecuteNonQuery() > 0)//PREGUNTAR
                {
                    comando = new SqlCommand(con.ToString(), conexion);
                    retorno = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar en la base de datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }
        #endregion


    }
}
