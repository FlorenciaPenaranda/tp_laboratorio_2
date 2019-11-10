using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }


        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE: " + this.clase);
            sb.Append(" POR " + this.instructor + "ALUMNOS: ");
            //sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public static bool Guardar(Jornada j)
        {
            Texto txt = new Texto();
            bool ret = false;
            if (!(txt is null && j is null))
            {
                ret = txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", j.ToString());
            }
            return ret;
        }
        public static string Leer()
        {
            Texto txt = new Texto();
            string ret = "";
            if (!(txt is null))
            {
                txt.Leer(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", out ret);
            }
            return ret;
        }

    }
}
