using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListar()
        {
            EspecialidadService.EspecialidadesClient obj = new EspecialidadService.EspecialidadesClient();

            List<EspecialidadService.Especialidad> listaEspecialidad = obj.ListarEspecialidades().ToList();

            Assert.AreEqual(46, listaEspecialidad.Count());

        }

        [TestMethod]
        public void TestObtener()
        {
            EspecialidadService.EspecialidadesClient obj = new EspecialidadService.EspecialidadesClient();

            EspecialidadService.Especialidad especialidad = obj.ObtenerEspecialidad(22);

            Assert.AreEqual(22, especialidad.Co_Especialidad);
            Assert.AreEqual("Medicina General", especialidad.No_Especialidad);
        }


        [TestMethod]
        public void TestObtenerNombre()
        {
            EspecialidadService.EspecialidadesClient obj = new EspecialidadService.EspecialidadesClient();

            string noEspecialidad = obj.ObtenerNombreEspecialidad(23);

            Assert.AreEqual("Medicina Interna", noEspecialidad);
        }

        [TestMethod]
        public void TestCrear()
        {
            EspecialidadService.EspecialidadesClient obj = new EspecialidadService.EspecialidadesClient();

            EspecialidadService.Especialidad especialidad = obj.CrearEspecialidad("Especialidad SOAP");

            Assert.AreEqual(53, especialidad.Co_Especialidad);
            Assert.AreEqual("Especialidad SOAP", especialidad.No_Especialidad);
        }

        [TestMethod]
        public void TestModificar()
        {
            EspecialidadService.EspecialidadesClient obj = new EspecialidadService.EspecialidadesClient();

            EspecialidadService.Especialidad especialidad = obj.ModificarEspecialidad(51,"Modificado SOAP");

            Assert.AreEqual(51, especialidad.Co_Especialidad);
            Assert.AreEqual("Modificado SOAP", especialidad.No_Especialidad);
        }

        [TestMethod]
        public void TestEliminar()
        {
            EspecialidadService.EspecialidadesClient obj = new EspecialidadService.EspecialidadesClient();

            obj.EliminarEspecialidad(47);

            EspecialidadService.Especialidad especialidad = obj.ObtenerEspecialidad(48);

            Assert.AreEqual(0, especialidad.Co_Especialidad);
        }

    }
}