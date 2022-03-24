using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiFacturacion.ViewModels;
using ApiFacturacion.Models;
using AutoMapper;
using System.Data.Entity;

namespace ApiFacturacion.Repositorios
{
    public class RepositorioVentas : IVentas
    {
        private readonly conexion _db = new conexion();
        public Task<bool> DeleteVentas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VentasViewModel>> GetVentas()
        {
            List<Ventas> lista = await _db.Ventas.ToListAsync();
            var listaView = Mapper.Map<List<VentasViewModel>>(lista);
            return listaView;
        }

        public  async Task<VentasViewModel> GetVentasPorId(int id)
        {
            Ventas venta = await _db.Ventas.FindAsync(id);
            var ventaView = Mapper.Map<VentasViewModel>(venta);
            return ventaView;
        }

        public async Task<VentasViewModel> PostVentas(VentasViewModel venta)
        {
            Ventas ventaMap = Mapper.Map<VentasViewModel, Ventas>(venta);
            _db.Ventas.Add(ventaMap);
            await _db.SaveChangesAsync();
            var ventaView = Mapper.Map<Ventas, VentasViewModel>(ventaMap);
            return ventaView;
        }

        public async Task<VentasViewModel> PutVentas(int id, VentasViewModel venta)
        {
            Ventas ventaU = Mapper.Map<VentasViewModel, Ventas>(venta);
            _db.Entry(ventaU).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            var prodView = Mapper.Map<Ventas, VentasViewModel>(ventaU);
            return prodView;
        }


        public async Task<List<detalleVenta>> GetDetalleVentas()
        {
            List<DetalleVenta> detalle = await _db.DetalleVenta.ToListAsync();
            var detalleView = Mapper.Map<List<detalleVenta>>(detalle);
            return detalleView;
        }

        public async Task<List<ProductoViewModel>> GetProductos()
        {
            var productos =  _db.Productos.Where(p => p.estado != true);
            var productosView = Mapper.Map<List<ProductoViewModel>>(productos);
            return productosView;
        }

        public async Task<ProductoViewModel> GetProductoPorId(int id)
        {
            Productos producto = await _db.Productos.FindAsync(id);
            var productoView = Mapper.Map<ProductoViewModel>(producto);
            return productoView;
        }

        public async Task<ProductoViewModel> UpdateProducto(int id, ProductoViewModel producto)
        {
            Productos productoU = Mapper.Map<ProductoViewModel, Productos>(producto);
            _db.Entry(productoU).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            var prodView = Mapper.Map<Productos, ProductoViewModel>(productoU);
            return prodView;
            
        }

        public async Task<ProductoViewModel> PostProducto(ProductoViewModel producto)
        {
            Productos productoPost = Mapper.Map<ProductoViewModel, Productos>(producto);
            _db.Productos.Add(productoPost);
            await _db.SaveChangesAsync();
            var prodView = Mapper.Map<Productos, ProductoViewModel>(productoPost);
            return prodView;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await _db.Productos.FindAsync(id);

            if (producto != null)
            {
                producto.estado = true;

                _db.Entry(producto).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                //_db.Productos.Remove(producto);
                //await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ClienteViewModel>> GetClientes()
        {
            var cliente = _db.Clientes.Where(p => p.estado != true);
            var clienteView = Mapper.Map<List<ClienteViewModel>>(cliente);
            return clienteView;
        }
        public async Task<ClienteViewModel> GetCliente(int documento)
        {
            Clientes cliente = await _db.Clientes.FindAsync(documento);
            var clienteView = Mapper.Map<ClienteViewModel>(cliente);
            return clienteView;
        }

        public async Task<ClienteViewModel> UpdateCliente(int id, ClienteViewModel cliente)
        {
            Clientes clienteUp = Mapper.Map<ClienteViewModel, Clientes>(cliente);
            _db.Entry(clienteUp).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            var clienteView = Mapper.Map<Clientes, ClienteViewModel>(clienteUp);
            return clienteView;
        }

        public async Task<ClienteViewModel> PostCliente(ClienteViewModel cliente)
        {
            Clientes clientePost = Mapper.Map<ClienteViewModel, Clientes>(cliente);
            _db.Clientes.Add(clientePost);
            await _db.SaveChangesAsync();
            var clienteView = Mapper.Map<Clientes, ClienteViewModel>(clientePost);
            return clienteView;
        }

        public async Task<bool> DeleteCliente(int Id)
        {
            Clientes cliente = await _db.Clientes.FindAsync(Id);
            if (cliente != null)
            {
                cliente.estado = true;

                _db.Entry(cliente).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                //_db.Clientes.Remove(cliente);
                //await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<TiposDocumento>> GetTiposDocumento()
        {
            List<TiposDocumentos> tipo = await _db.TiposDocumentos.ToListAsync();
            var tipoView = Mapper.Map<List<TiposDocumento>>(tipo);
            return tipoView;
        }

        public async Task<List<detalleVenta>> GetDetalleVenta(int id)
        {
            var venta = _db.DetalleVenta.Where(x=>x.idVenta == id);
            var VentaView = Mapper.Map<List<detalleVenta>>(venta);
            return VentaView;
        }

        public async Task<detalleVenta> PostDetalleVenta( detalleVenta detalles)
        {
            DetalleVenta detalle = Mapper.Map<detalleVenta, DetalleVenta>(detalles);
            _db.DetalleVenta.Add(detalle);
            await _db.SaveChangesAsync();
            var detalleView = Mapper.Map<DetalleVenta, detalleVenta>(detalle);
            return detalleView;
        }

        public async Task<bool> DeleteDetalleVenta(int idVenta)
        {
            return true;
        }
    }
}