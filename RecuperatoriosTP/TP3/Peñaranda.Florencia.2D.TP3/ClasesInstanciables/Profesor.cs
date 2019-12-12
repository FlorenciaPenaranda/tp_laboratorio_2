using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Threading;


namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        #endregion


        #region Constructores

        /// <summary>
        ///  Constructor estático que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }


        /// <summary>
        /// Sobrecarga constructor heredado e inicializa el objeto
        /// </summary>
        public Profesor()
            : base()
        {

        }


        /// <summary>
        /// Inicializa un objeto del tipo porfesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Asigna una clase a un porfesor
        /// </summary>
        private void _randomClases()
        {
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            Thread.Sleep(300);
        }


        /// <summary>
        /// Sobrecarga métododo y retorna en que clase participa un profesor
        /// </summary>
        /// <returns>En que clases participa un profesor</returns>
        protected override string ParticipaEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this.claseDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga métododo base, agrega los datos de un profesor y los muestra
        /// </summary>
        /// <returns>todos los datos de un profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticipaEnClase());
            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga el métododo toString haciendo públicos los datos de un profersor
        /// </summary>
        /// <returns>Todos los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Compara un profesor y una clase segun la clase que da
        /// </summary>
        /// <param name="i">un profesor</param>
        /// <param name="clase">una clase</param>
        /// <returns>si el profesor da la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Compara un profesor y una clase segun la clase que da
        /// </summary>
        /// <param name="i">un profesor</param>
        /// <param name="clase">una clase</param>
        /// <returns>si el profesor no da la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
