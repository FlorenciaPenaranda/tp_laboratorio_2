using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Interfaz generica mostrar datos
        /// </summary>
        /// <typeparam name="T">Tipo de datos a mostrar.</typeparam>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
