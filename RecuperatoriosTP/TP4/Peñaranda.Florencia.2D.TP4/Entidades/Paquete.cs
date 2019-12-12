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
        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingId;

        public delegate void DelegadoEstado(object sender, EventArgs estado);
        public event DelegadoEstado InformarEstado;
        #endregion


        /// <summary>
        /// Enumerable para los estados de un paquete.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }


        #region Propiedades

        /// <summary>
        /// Devuelve la dirección de entrega del paquete.
        /// </summary>
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

        /// <summary>
        /// Devuelve el estado del paquete.
        /// </summary>
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

        /// <summary>
        /// Devuelve el Tracking ID del paquete.
        /// </summary>
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
        #endregion


        #region Constructores

        /// <summary>
        /// Crea un nuevo paquete.
        /// </summary>
        /// <param name="direccionEntrega">Dirección de entrega del paquete.</param>
        /// <param name="trackingID">Tracking ID del paquete.</param>
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingId = trackingId;
            this.estado = EEstado.Ingresado;
        }
        #endregion


        #region Metodos

        /// <summary>
        /// Mientras que el estado del objeto no sea "entregado" va a iterar cada cuatro segundos cambiando el estado
        /// invocar el evento para informar y cuando finaliza lo guarda en la base de datos con el estado entregado.
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                InformarEstado.Invoke(this.estado, EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elemento"> elemento a mostrar</param>
        /// <returns>Los datos del elemento</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingId, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Sobrecarga el métododo toString haciendo públicos los datos de un paquete
        /// </summary>
        /// <returns>Datos del un paquete</returns>
        public override string ToString()
        {
            return MostrarDatos(this).ToString();
        }
        #endregion


        #region Operadores

        /// <summary>
        /// compara dos paquetes por el tracking id como para determinar que son igual
        /// </summary>
        /// <param name="p1">primer paquete</param>
        /// <param name="p2">segundo paquete</param>
        /// <returns>true si son igual false si no</returns>
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

        /// <summary>
        /// compara dos paquetes por el tracking id como para determinar si son distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son igual false si no</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion


    }
}
