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
        public static bool guardar(this string texto, string archivo)
        {
            if (!string.IsNullOrEmpty(texto) && !string.IsNullOrEmpty(archivo))
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(archivo))
                    {
                        file.WriteLine(texto);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error al guardar el archivo", e);
                }
            }
            return true;
        }
    }
}
