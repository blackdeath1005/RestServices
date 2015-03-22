using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;

namespace ProjectRest.Dominio
{
    [DataContract]
    public class Especialidad
    {
        [DataMember]
        public int Co_Especialidad { get; set; }
        [DataMember]
        public string No_Especialidad { get; set; }
    }
}