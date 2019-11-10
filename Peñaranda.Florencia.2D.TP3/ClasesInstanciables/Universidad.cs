using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                jornadas = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornadas = new List<Jornada>();
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    return item;
                }

            }
            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        public static bool operator ==(Universidad u, Profesor i)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.Alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada j = new Jornada(clase, (u == clase));
            foreach (Alumno a in u.Alumnos)
            {
                if (a == clase)
                {
                    j.Alumnos.Add(a);
                }
            }
            u.jornadas.Add(j);
            return u;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {

            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            if (!(uni is null))
            {
                Xml<Universidad> aux = new Xml<Universidad>();
                retorno = aux.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni);
            }
            return retorno;
        }
        public Universidad Leer()
        {
            Universidad retorno = null;
            Xml<Universidad> lector = new Xml<Universidad>();
            lector.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.txt", out retorno);
            return retorno;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni.jornadas)
            {
                sb.Append(item.ToString());
                sb.AppendLine("<------------------------------------------------------->");
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
