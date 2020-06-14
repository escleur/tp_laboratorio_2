using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using EntidadesAbstractas;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPersona
    {
        /// <summary>
        /// Valida que los nombre se tomen cuando son correctos
        /// </summary>
        [TestMethod]
        public void ValidacionNombre()
        {
            Alumno a = new Alumno();
            a.Nombre = "Pedro Alvaro";
            Assert.AreEqual("Pedro Alvaro", a.Nombre);
            a.Nombre = "Ped4ro Diego";
            Assert.AreEqual("", a.Nombre);

        }

        /// <summary>
        /// Valida que tome correctos los numeros de dni
        /// </summary>
        [TestMethod]
        public void ValidacionNacionalidad()
        {
            Alumno a1 = new Alumno(1,"Pedro Alvaro", "Sneider", "90020000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(2,"Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            Assert.AreEqual(90020000, a1.DNI);
            Assert.AreEqual(70000000, a2.DNI);
        }

        /// <summary>
        /// Valida que se lance excepcion cuando se ingresa una nacionalidad mal
        /// </summary>
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        [TestMethod]
        public void ValidacionNacionalidadException1()
        {
            Profesor p1 = new Profesor(1, "Pedro Alvaro", "Sneider", "90020000", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        /// Valida que se lance excepcion cuando se ingresa una nacionalidad mal
        /// </summary>
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        [TestMethod]
        public void ValidacionNacionalidadException2()
        {
            Alumno a2 = new Alumno(1,"Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

        }

        /// <summary>
        /// Valida que se lance excepcion cuando se ingresa un dni mal
        /// </summary>
        [ExpectedException(typeof(DniInvalidoException))]
        [TestMethod]
        public void ValidacionDNIException1()
        {
            Alumno a = new Alumno(1, "Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            a.DNI = -10;
        }

        /// <summary>
        /// Valida que se lance excepcion cuando se ingresa un dni mal
        /// </summary>
        [ExpectedException(typeof(DniInvalidoException))]
        [TestMethod]
        public void ValidacionDNIException2()
        {
            Alumno a = new Alumno(1,"Pedro Alvaro", "Sneider", "70000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            a.StringToDNI = "g200";
        }

        /// <summary>
        /// Valida la inicializacion de lista sea distinto de null
        /// </summary>
        [TestMethod]
        public void UniversidadInicializacion()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Jornadas);
        }

    }
}
