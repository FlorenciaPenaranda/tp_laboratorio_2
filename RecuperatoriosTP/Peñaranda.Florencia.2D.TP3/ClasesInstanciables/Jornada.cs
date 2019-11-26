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
        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion


        #region Propiedades

        /// <summary>
        /// Propiedad que muestra o modifica la lista de alummnos
        /// </summary>
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


        /// <summary>
        /// Propiedad que muestra o modifica las clases dentro de una jornada
        /// </summary>
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


        /// <summary>
        /// Propiedad que muestra o modifica un profesor de la jornada
        /// </summary>
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

        #endregion


        #region Constructores

        /// <summary>
        /// Construcctor por defecto que inicializa la lista de alumnos 
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }


        /// <summary>
        /// Sobrecarga al constructor por defecto e inicializa atributos clase e instructor 
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Compara una jornada con un alumno, para saber si el mismo participa en la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno participa en la clase, caso contrario, devuelve false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.clase)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        ///  Conpara una jornada con un alumno, para saber si el mismo no participa en la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno no participa en la clase, caso contrario, devuelve false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Agrega un alumno a una jornada, validando que no este previamente cargado
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve la jornada del alumno</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Sobrecarga el métododo toString haciendo públicos los datos de la jornada
        /// </summary>
        /// <returns>Todos los datos de una jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE: " + this.clase);
            sb.Append(" POR " + this.instructor);
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }


        /// <summary>
        /// Invoca al método guardar de la clase Texto
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <returns>Retorna true si logro guardarse la jornada, caso contrario, retorna false</returns>
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


        /// <summary>
        /// Invoca al método leer de la clase Texto
        /// </summary>
        /// <returns>Retorna un string con datos, un string vacio si no logra leer.</returns>
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

        #endregion        
    }
}
