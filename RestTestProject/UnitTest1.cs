using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RestTestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ListaEspecialidadesTest()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7175/Especialidades.svc/ListarEspecialidades");
                req.Method = "GET";

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string consultaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Especialidad> especialidadLista = js.Deserialize<List<Especialidad>>(consultaJson);
                Assert.IsTrue(especialidadLista.Count == 46);
            }
            catch (WebException e)
            {
                HttpWebResponse resError = (HttpWebResponse)e.Response;
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string error = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Excepcion errorMessage = js2.Deserialize<Excepcion>(error);
                Assert.AreEqual("No hay especialidades registradas", errorMessage.Mensaje);
            }
        }

        [TestMethod]
        public void ObtenerEspecalidadTest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7175/Especialidades.svc/ObtenerEspecialidad/22");
            req.Method = "GET";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string consultaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Especialidad especialidad = js.Deserialize<Especialidad>(consultaJson);

            Assert.AreEqual(22, especialidad.Co_Especialidad);
            Assert.AreEqual("Medicina General", especialidad.No_Especialidad);
        }

    }
}
