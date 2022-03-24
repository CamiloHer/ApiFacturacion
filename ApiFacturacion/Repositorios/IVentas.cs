using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFacturacion.Models;
using ApiFacturacion.ViewModels;

namespace ApiFacturacion.Repositorios
{
    interface IVentas
    {
        Task<List<VentasViewModel>> GetVentas();
        Task<VentasViewModel> GetVentasPorId(int id);
        Task<VentasViewModel> PutVentas(int id, VentasViewModel venta);
        Task<VentasViewModel> PostVentas(VentasViewModel venta);
        Task<bool> DeleteVentas();
        Task<List<detalleVenta>> GetDetalleVentas();
        Task<List<ClienteViewModel>> GetClientes();
        Task<ClienteViewModel> GetCliente(int docuemto);
        Task<ClienteViewModel> UpdateCliente(int id, ClienteViewModel cliente);
        Task<ClienteViewModel> PostCliente(ClienteViewModel cliente);
        Task<bool> DeleteCliente(int Id);
        Task<List<ProductoViewModel>> GetProductos();
        Task<ProductoViewModel> GetProductoPorId(int id);
        Task<ProductoViewModel> UpdateProducto(int id, ProductoViewModel producto);
        Task<ProductoViewModel> PostProducto(ProductoViewModel producto);
        Task<bool> DeleteProducto(int id);
        Task<List<TiposDocumento>> GetTiposDocumento();
        Task<List<detalleVenta>> GetDetalleVenta(int id);
        Task<detalleVenta> PostDetalleVenta(detalleVenta detalles);
        Task<bool> DeleteDetalleVenta(int idVenta);

    }
}
