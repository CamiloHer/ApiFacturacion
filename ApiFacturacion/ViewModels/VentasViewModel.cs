using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFacturacion.ViewModels
{
    public class VentasViewModel
    {
        public int id { get; set; }

        public int idCliente { get; set; }

        public int netoTotal { get; set; }

        public DateTime fecha { get; set; }

        public  ClienteViewModel Cliente { get; set; }

        public VentasViewModel()
        {
            Cliente = new ClienteViewModel();
        }
    }
    public class detalleVenta
    {
        public int idVenta { get; set; }

        public int idProducto { get; set; }

        public int cantidad { get; set; }

        public int total { get; set; }

        public virtual ProductoViewModel Productos { get; set; }

        public virtual VentasViewModel Ventas { get; set; }

        public detalleVenta()
        {
            Productos = new ProductoViewModel();
            Ventas = new VentasViewModel();
        }
    }
}