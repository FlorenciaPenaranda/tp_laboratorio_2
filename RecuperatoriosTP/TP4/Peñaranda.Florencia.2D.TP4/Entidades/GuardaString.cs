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
        /// Metodo de extension a la clase string que guarda texto en el archivo ubicado en el escritorio, si ya existe agrega en el si no lo crea
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>True si pudo agregar el texto, false si no pudo o se lanzo una excepcion</returns>
        public static bool guardar(this string texto, string archivo)
        {
            bool retorno = false;

            if (!string.IsNullOrEmpty(texto) && !string.IsNullOrEmpty(archivo))
            {
                string escritorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo);               
                try
                {
                    using (StreamWriter file = new StreamWriter(escritorio, File.Exists(escritorio)))
                    {
                        file.WriteLine(texto);
                        retorno = true;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error al guardar el archivo", e);
                }
            }
   
            return retorno;
        }
    }
}


//  StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true);
//  file.Write(texto);
//  file.Close();
//  return true;
