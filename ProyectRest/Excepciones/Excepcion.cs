﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;

namespace ProjectRest.Excepciones
{
    [DataContract]
    public class Excepcion
    {
        [DataMember]
        public string Mensaje { get; set; }
    }
}
