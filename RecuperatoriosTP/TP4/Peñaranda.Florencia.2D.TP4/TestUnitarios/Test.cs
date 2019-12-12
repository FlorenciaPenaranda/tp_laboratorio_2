using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Prueba para saber si paquetes de un correo esta instanciado.
        /// </summary>
        [TestMethod]
        public void TestPaqueteDeCorreo()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Prueba que verifica que no se puedan cargar dos paquete con el mismo TrackingID.
        /// </summary>
        [TestMethod]
        public void TestPaqueteRepetido()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Wilde", "123456");
            Paquete p2 = new Paquete("La Plata", "123456");
            correo += p1;
            correo += p2;
        }
    }
}
