using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFacturacion.ViewModels
{
    public class RespuestaViewModel
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }
        public object data { get; set; }
    }
}