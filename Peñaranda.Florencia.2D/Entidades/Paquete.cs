using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {

        private string direccionEntrega;
        private EEstado estado;
        private string trackingId;

        public enum EEstado
        {
            Enviado,
            EnViaje,
            Entregao
        }

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingId
        {
            get
            {
                return this.trackingId;
            }
            set
            {
                this.trackingId = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingId = trackingId;
        }

        public void MockCicloDeVida()
        {
            int estadoAux = (int)this.Estado;
            while (estadoAux == 0 || estadoAux ==1)
            {
                Thread.Sleep(4000);
                estadoAux++;
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            if (elemento is Paquete)
            {
                Paquete p = (Paquete)elemento;
                return string.Format($"{0} para {1}", p.TrackingId, p.DireccionEntrega);
            }
            return string.Format($"{0} para {1}");
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.MostrarDatos(this));
            sb.AppendFormat($"({0})", this.Estado); 
            return sb.ToString();
        }

        public string Guardar(IMostrar<Paquete> elemento)
        {
            throw new NotImplementedException();
        }


        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (!(p1 is null) && !(p2 is null))
            {
                if (p1.TrackingId == p2.TrackingId)
                {
                    return true;
                }

            }
            return false;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


    }
}
