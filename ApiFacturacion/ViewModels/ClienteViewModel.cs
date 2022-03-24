using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFacturacion.ViewModels
{
    public class ClienteViewModel
    {
        public int documento { get; set; }

        public int tipoDocumento { get; set; }

        public string nombre { get; set; }

        public short edad { get; set; }
        //public bool estado { get; set; }
        public TiposDocumento tiposDocumento { get; set; }

        public ClienteViewModel()
        {
            tiposDocumento = new TiposDocumento();
        }
    }
}