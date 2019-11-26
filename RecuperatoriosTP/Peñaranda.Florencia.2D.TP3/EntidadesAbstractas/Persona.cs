using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #endregion


        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion


        #region Propiedades

        /// <summary>
        /// Propiedad que valida, muestra o modifica el atributo nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }
            }
        }


        /// <summary>
        /// Propiedad que valida, muestra o modifica el atributo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }


        /// <summary>
        /// Propiedad que valida, muestra o modifica el atributo dni
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        /// <summary>
        /// Propiedad que muestra o modifica el atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }


        /// <summary>
        /// Propiedad que valida, muestra o modifica el atributo dni de tipo string
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);

            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto que inicializa una persona
        /// </summary>
        public Persona()        {

        }


        /// <summary>
        /// Hereda el constructor por defecto e inicializa una persona sin el atributo dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }


        /// <summary>
        /// Hereda el constructor e inicializa una persona agregando el atributo dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }


        /// <summary>
        ///  Hereda el constructor e inicializa una persona agregando el atributo dni de tipo string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = int.Parse(dni);
        }
        #endregion


        #region Métodos

        /// <summary>
        /// Sobrecarga el métododo toString haciendo públicos los datos de una persona
        /// </summary>
        /// <returns>Devuelve todos los datons de una persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + "," + this.Nombre);
            //sb.AppendLine("Dni: " + this.Dni);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }


        /// <summary>
        /// Valida el atributo dni del tipo int
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Si es valido retorna el atributo, caso contrario lanza una excepcion</returns>
        protected int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (this.nacionalidad == ENacionalidad.Argentino && (dato >= 1 || dato <= 89999999))// && (dato.ToString().Length == 7 || dato.ToString().Length == 8))
            {
                return dato;
            }
            else if (this.nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 || dato <= 99999999))// && (dato.ToString().Length == 7 || dato.ToString().Length == 8))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }


        /// <summary>
        /// Valida el atributo dni del tipo string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Si es valido retorna el atributo, caso contrario lanza una excepcion</returns>
        protected int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            if (int.TryParse(dato, out int dni))
            {
                return ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException();
            }

        }


        /// <summary>
        /// Valida los atributo nombre y apellido del tipo string
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Devuelve el atributo si es valido, caso contrario retorna null</returns>
        protected string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    return null;
                }
            }
            return dato;
        }

        #endregion
    }
}

