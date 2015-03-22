using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using ProjectRest.Dominio;
using ProjectRest.Persistencia;
using ProjectRest.Excepciones;

namespace ProyectRest
{
    
    public class Especialidades : IEspecialidades
    {

        private EspecialidadDAO dao = new EspecialidadDAO();

        public Especialidad CrearEspecialidad(string nombre)
        {
            Especialidad especialidadCreada = dao.Crear(nombre);

            if (especialidadCreada == null)
            {
                throw new WebFaultException<Excepcion>(new Excepcion() { Mensaje = "Error al crear" }, HttpStatusCode.InternalServerError);
            }
            else
            {
                return especialidadCreada;
            }
        }

        public Especialidad ObtenerEspecialidad(string cod)
        {
            return dao.Obtener(int.Parse(cod));
        }

        public string ObtenerNombreEspecialidad(string cod)
        {
            return dao.ObtenerNombre(int.Parse(cod));
        }

        public Especialidad ModificarEspecialidad(string cod, string nombre)
        {
            Especialidad especialidadModificada = dao.Modificar(int.Parse(cod), nombre);

            if (especialidadModificada == null)
            {
                throw new WebFaultException<Excepcion>(new Excepcion() { Mensaje = "Error al Modificar" }, HttpStatusCode.InternalServerError);
            }
            else
            {
                return especialidadModificada;
            }
        }

        public void EliminarEspecialidad(string cod)
        {
            dao.Eliminar(int.Parse(cod));
        }
        
        public List<Especialidad> ListarEspecialidades()
        {
            List<Especialidad> listaEspecialidades = dao.Listar();

            if (listaEspecialidades != null && listaEspecialidades.Count > 0)
                return listaEspecialidades;
            else
            {
                throw new WebFaultException<Excepcion>(new Excepcion() { Mensaje = "No hay especialidades registradas" }, HttpStatusCode.InternalServerError);
            }
        }

    }
}