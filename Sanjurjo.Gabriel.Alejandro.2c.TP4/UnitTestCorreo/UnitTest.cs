using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestCorreo
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Testea que en correo, paquetes este instanciada
        /// </summary>
        [TestMethod]
        public void PaqueteInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Testea que cuando se agregan dos paquetes iguales se lanze la excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Entidades.TrackingIdRepetidoException))]
        public void VerificacionPaquetesIguales()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("9 de julio", "111-111-111");
            Paquete p2 = new Paquete("chacabuco", "111-111-111");

            correo += p1;
            correo += p2;
        }

    }
}
