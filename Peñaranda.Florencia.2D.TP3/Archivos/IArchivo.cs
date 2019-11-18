using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T> 
    {
        /// <summary>
        /// Método de interfaz para implementar al leer un archivo
        /// </summary>
        /// <param name="archivo">ruta de archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>bool</returns>
        bool Leer(string archivo, out T datos);

        /// <summary>
        /// Método de interfaz para implementar al guardar un archivo
        /// </summary>
        /// <param name="archivo">ruta de archivo</param>
        /// <param name="datos">dats a leer</param>
        /// <returns>bool</returns>
        bool Guardar(string archivo, T datos);
    }
}
