using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;


namespace PruebasUnitarias
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Valida excepcion SinProfesorException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ValidarExcepcionSinProfesor()
        {
           ClasesInstanciables.Universidad universidad = new ClasesInstanciables.Universidad();
           ClasesInstanciables.Profesor profesor = universidad == ClasesInstanciables.Universidad.EClases.Programacion;
        }


        /// <summary>
        /// Valida excepcion DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarExcepcionDniInvalido()
        {
            ClasesInstanciables.Alumno alumno = new ClasesInstanciables.Alumno(1, "Florencia", "Peñaranda", "35947760", EntidadesAbstractas.Persona.ENacionalidad.Argentino, ClasesInstanciables.Universidad.EClases.Programacion);
            alumno.StringToDni = "asd123";
        }


        /// <summary>
        /// Contorla que el valor numerico sea el esperado
        /// </summary>
        [TestMethod]
        public void ValidarNumerico()
        {
            int valorEsperado = 35947760;
            ClasesInstanciables.Alumno alumno;
            alumno = new ClasesInstanciables.Alumno(1, "Florencia", "Peñaranda", "35947760", EntidadesAbstractas.Persona.ENacionalidad.Argentino, ClasesInstanciables.Universidad.EClases.Programacion);

            Assert.AreEqual(valorEsperado, alumno.Dni);
        }


        /// <summary>
        /// Controla que la lista de alumnos de una universidad no sea null.
        /// </summary>
        [TestMethod]
        public void ValidaAtributoNull()
        {
            ClasesInstanciables.Universidad universidad = new ClasesInstanciables.Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
    }

}

