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
        public bool Guardar(string archivo, string datos)
        {

            try
            {
                using (StreamWriter file = new StreamWriter(archivo))
                {
                    file.WriteLine(datos);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                    file.Close();
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
