using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProjectRest.Dominio;

namespace ProyectRest
{
    [ServiceContract]
    public interface IEspecialidades
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CrearEspecialidad/{nombre}", ResponseFormat = WebMessageFormat.Json)]
        Especialidad CrearEspecialidad(string nombre);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerEspecialidad/{cod}", ResponseFormat = WebMessageFormat.Json)]
        Especialidad ObtenerEspecialidad(string cod);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerNombreEspecialidad/{cod}", ResponseFormat = WebMessageFormat.Json)]
        string ObtenerNombreEspecialidad(string cod);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ModificarEspecialidad/{id}+{nombre}", ResponseFormat = WebMessageFormat.Json)]
        Especialidad ModificarEspecialidad(string id, string nombre);

        //[OperationContract]
        //void EliminarEspecialidad(int cod);
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ListarEspecialidades", ResponseFormat = WebMessageFormat.Json)]
        List<Especialidad> ListarEspecialidades();
    }

}