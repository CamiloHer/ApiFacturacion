using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFacturacion.ViewModels
{
    public class ProductoViewModel
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public int stock { get; set; }

        public int precio { get; set; }
        //public bool estado { get; set; }
    }
}