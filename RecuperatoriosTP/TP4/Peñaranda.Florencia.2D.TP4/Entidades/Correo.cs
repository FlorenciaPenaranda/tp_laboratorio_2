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
        #region Atributos
        private List<Thread> MockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve la lista de paquetes.
        /// </summary>
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
        #endregion

        #region Constructores
        /// <summary>
        /// Crea un nuevo correo.
        /// </summary>
        public Correo()
        {
            MockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>Todos los datos de un correo.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            Correo c = (Correo)elementos;

            foreach (Paquete p in c.Paquetes)
            {
                sb.AppendFormat("{0} ({1})\r\n", p.ToString(), p.Estado.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Interrumpe todas las entregas activas.
        /// </summary>
        public void FinDeEntragas()
        {
            foreach (Thread entregas in this.MockPaquetes)
            {
                entregas.Abort();
            }
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un paquete a la lista controlando que no esté. Si ya se encuentra en el correo, lanza una excepción.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>El correo donde agregó el paquete</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El Tracking ID {p.TrackingId} ya figura en la lista de envios");                    
                }
            }
            c.paquetes.Add(p);
            Thread cicloVida = new Thread(p.MockCicloDeVida);
            c.MockPaquetes.Add(cicloVida);
            cicloVida.Start();
            return c;
        }
        #endregion



    }
}