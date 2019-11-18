using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Lee los datos en un archivo de texto
        /// </summary>
        /// <param name="archivo">ruta de archivo/param>
        /// <param name="datos">datos recibidos</param>
        /// <returns> retorna true si logro leer los datos, caso contrario, lanza una excepcion</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
            return true;
        }

        /// <summary>
        /// Guarda todos los datos que se le pasan como parámetro en un narchivo de texto
        /// </summary>
        /// <param name="archivo">ruta de archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns> retorna true si logro guardar los datos, caso contrario, lanza una excepcion</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(archivo))
                {
                    file.WriteLine(datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
    }
}
