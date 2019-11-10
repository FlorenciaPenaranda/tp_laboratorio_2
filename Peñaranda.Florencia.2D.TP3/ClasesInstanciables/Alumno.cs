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
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        public Alumno() : base()
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }


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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string ParticipaEnClase()
        {
            return String.Format($"TOMA CLASE DE: {this.claseQueToma}");
        }
    }

}