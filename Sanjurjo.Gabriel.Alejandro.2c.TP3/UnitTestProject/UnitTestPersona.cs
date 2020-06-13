using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using EntidadesAbstractas;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPersona
    {
        [TestMethod]
        public void ValidacionNombre()
        {
            Alumno a = new Alumno();
            a.Nombre = "Pedro Alvaro";
            Assert.AreEqual("Pedro Alvaro", a.Nombre);
            a.Nombre = "Ped4ro Diego";
            Assert.AreEqual("", a.Nombre);

        }

        [TestMethod]
        public void ValidacionNacionalidad()
        {
            Alumno a1 = new Alumno(1,"Pedro Alvaro", "Sneider", "90020000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(2,"Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            Assert.AreEqual(90020000, a1.DNI);
            Assert.AreEqual(70000000, a2.DNI);
        }
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        [TestMethod]
        public void ValidacionNacionalidadException1()
        {
            Profesor p1 = new Profesor(1, "Pedro Alvaro", "Sneider", "90020000", Persona.ENacionalidad.Argentino);
        }
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        [TestMethod]
        public void ValidacionNacionalidadException2()
        {
            Alumno a2 = new Alumno(1,"Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

        }
        [ExpectedException(typeof(DniInvalidoException))]
        [TestMethod]
        public void ValidacionDNIException1()
        {
            Alumno a = new Alumno(1, "Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            a.DNI = -10;
        }
        [ExpectedException(typeof(DniInvalidoException))]
        [TestMethod]
        public void ValidacionDNIException2()
        {
            Alumno a = new Alumno(1,"Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            a.StringToDNI = "g200";
        }


    }
}
