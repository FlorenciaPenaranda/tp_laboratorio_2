using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;




namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion


        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Sobrecarga constructor heredado e inicializa el objeto
        /// </summary>
        public Alumno() : base()
        {
        }


        /// <summary>
        /// Sobrecarga de constructor agregando el atributo claseQueTOma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        /// <summary>
        ///  Sobrecarga de constructor agregando el atributo estadoDeCuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Compara un alumno y una clase segun la clase que toma y el estado de su cuenta
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>si el alunmo toma la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Compara un alumno y una clase segun la clase que toma
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Si el alumno no toma la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Sobrecarga métododo base, agrega los datos de un alumno y los muestra
        /// </summary>
        /// <returns>Todosl os datos de un alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            string auxiliar = "";
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    auxiliar = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    auxiliar = "Becado";
                    break;
                case EEstadoCuenta.Deudor:
                    auxiliar = "Deudor";
                    break;
            }
            sb.AppendLine("ESTADO DE CUENTA: " + auxiliar);
            sb.AppendLine(this.ParticipaEnClase());
            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga el métododo toString haciendo públicos los datos de un alumno
        /// </summary>
        /// <returns>Todos los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Sobrecarga métododo y retorna en que clase participa un alumno
        /// </summary>
        /// <returns>En que clase participa un alumno</returns>
        protected override string ParticipaEnClase()
        {
            return String.Format($"TOMA CLASE DE: {this.claseQueToma}");
        }

        #endregion       
    }

}