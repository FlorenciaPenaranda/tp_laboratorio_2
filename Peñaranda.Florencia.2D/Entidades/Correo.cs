using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> MockPaquetes;
        private List<Paquete> paquetes;


        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            MockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            Correo c = (Correo)elementos;

            foreach (Paquete p in c.Paquetes)
            {
                sb.AppendFormat($"{0} ", p.ToString());
            }
            return sb.ToString();
        }

        public string Guardar(IMostrar<List<Paquete>> elemento)
        {
            throw new NotImplementedException();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item != p)
                {
                    c.paquetes.Add(p);
                    return c;
                }
                throw new TrackingIdRepetidoException($"El Tracking ID {p.TrackingId} ya figura en la lista de envios");
            }
            return c;
        }


    }
}