using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjectRest.Persistencia
{
    public class ConexionBD
    {
        public static string ObtenerCadena()
        {

            //return "Data Source=(local); Initial Catalog=PACIFICO;Integrated Security=SSPI;";
            //return "Data Source=LUIS-PC\\SQLEXPRESS; Initial Catalog=PACIFICO;Integrated Security=True;";
            //return "Data Source=f302b7cf-29c4-45f5-b69f-a23b000c589b.sqlserver.sequelizer.com; Initial Catalog=db062d1650ec8c48e3a46fa23c0157532e; User Id=ijizwiprkksbwozh; Password=wnjGXVh8xbah4sRMPg4Ui2JzXTqoWXUEJzk4KCzGouF2vBVfQevULjhDKRSeD2jG; ";
            return "Data Source=db26105f-6922-475e-9f5e-a3b8011a41a8.sqlserver.sequelizer.com; Initial Catalog=dbdb26105f6922475e9f5ea3b8011a41a8; User Id=pkmboetteghhnbnd; Password=adiqyVRyjoP5QM3orL5aFLGFhQqU2mz2EHeTU5vWQe2vCXeEudb4gEJwCJiRD6F7; ";
        
        }
    }
}
