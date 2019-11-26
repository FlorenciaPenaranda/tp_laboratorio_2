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
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #endregion


        #region Enumerado      
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion


        #region Propiedades

        /// <summary>
        ///  Propiedad que muestra o modifica la lista de alummnos
        /// </summary>
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


        /// <summary>
        ///  Propiedad que muestra o modifica la lista de profesores
        /// </summary>
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


        /// <summary>
        /// Propiedad que muestra o modifica la lista de Jornadas
        /// </summary>
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


        /// <summary>
        /// Propiedad que muestra o modifica la jornada en el indice indicado.
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>La jornada de ese indice</returns>
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

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor que instancia la lista de alumnos, de jornada y de profesores.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornadas = new List<Jornada>();
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Iguala una universidad con una clase, para saber que profesor da la clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve el profesor que da la clase si la encuentra en la universidad, si no encuentra uno lanza una excepcion</returns>
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


        /// <summary>
        /// Iguala una universidad con una clase, para saber que profesor no da la clase
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve el primer profesor que no da la clase si la encuentra en la universidad, si no encuentra ninguno lanza una excepcion</returns>
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


        /// <summary>
        /// Iguala una universidad y un profesor para saber si el mismo da clases en el.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve true si el profesor da clases en la universidad, caso contrario retorna false</returns>
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


        /// <summary>
        /// Iguala una universidad y un profesor para saber si el mismo no da clases en el.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve true si el profesor no da clases en la universidad, caso contrario retorna false</returns>
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }


        /// <summary>
        /// Iguala una universidad y un alumno para saber si el mismo esta inscripto
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno esta inscripto en la universidad, caso contrario retorna false</returns>
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


        /// <summary>
        /// Iguala una universidad y un alumno para saber si el mismo no esta inscripto
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno no esta inscripto en la universidad, caso contrario retorna false</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }


        /// <summary>
        ///  Agrega una clase a una universidad, generando una nueva jornada indicando el profesor que puede darla y los alunmos que toman la clase.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve la universidad</returns>
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


        /// <summary>
        /// Agrega un alumno a una universidad, verificando que no este cargado previamente
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si lo puedo agregar, caso contrario, lanza una excepcion</returns>
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


        /// <summary>
        /// Agrega un profesor a una universidad, verificanod que no este cargado previamente
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve la universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {

            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Invoca al metodo Guardar de la clase XML, serializando una universidad en un xml
        /// </summary>
        /// <param name="uni">Univesidad</param>
        /// <returns>Retorna true si la pudo guardar, caso contrario retorna false</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            if (!(uni is null))
            {
                Xml<Universidad> aux = new Xml<Universidad>();
                retorno = aux.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.txt", uni);
            }
            return retorno;
        }


        /// <summary>
        /// Lee un archivo serializado xml
        /// </summary>
        /// <returns>Retorna true si la pudo leer, caso contrario retorna null</returns>
        public Universidad Leer()
        {
            Universidad retorno = null;
            Xml<Universidad> lector = new Xml<Universidad>();
            lector.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.txt", out retorno);
            return retorno;
        }


        /// <summary>
        /// Muestra todos los datos de la universidad
        /// </summary>
        /// <param name="uni">Univesidad</param>
        /// <returns></returns>
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


        /// <summary>
        /// Sobrecarga el métododo toString haciendo públicos los datos de universidad
        /// </summary>
        /// <returns>Todos los datos de universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion
    }
}
