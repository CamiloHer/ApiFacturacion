using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiFacturacion.Models;
using ApiFacturacion.Repositorios;
using ApiFacturacion.ViewModels;

namespace ApiFacturacion.Controllers
{
    public class ProductosController : ApiController
    {
        private readonly RepositorioVentas _ir = new RepositorioVentas();
        protected RespuestaViewModel _respuesta;

        // GET: api/Productos
        public async Task<IHttpActionResult> GetProductos()
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var productos = await _ir.GetProductos();
                if (productos.Count == 0) {
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "no hay productos";
                }
                else
                {
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "listado de productos";
                }
                _respuesta.data = productos;
                return Ok(_respuesta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Productos/5
        [ResponseType(typeof(Productos))]
        public async Task<IHttpActionResult> GetProducto(int id)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var producto = await _ir.GetProductoPorId(id);
                _respuesta.codigo = 0;
                _respuesta.mensaje = "Producto encontrado";
                _respuesta.data = producto;
                return Ok(_respuesta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Productos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductos(int id, ProductoViewModel productos)
        {
            try
            {
                _respuesta = new RespuestaViewModel();

                if(id != productos.id)
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "Producto no coincide";
                }
                else
                {
                    var producto = await _ir.UpdateProducto(id, productos);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "Producto actualizado";
                    _respuesta.data = producto;
                }
                return Ok(_respuesta);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Productos
        [ResponseType(typeof(ProductoViewModel))]
        public async Task<IHttpActionResult> PostProductos(ProductoViewModel productos)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                if(productos.id > 0)
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "Producto no se pudo registrar";
                }
                else
                {
                    var producto = await _ir.PostProducto(productos);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "Producto registrado";
                    _respuesta.data = producto;
                }
                return Ok(_respuesta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Productos/5
        [ResponseType(typeof(ProductoViewModel))]
        public async Task<IHttpActionResult> DeleteProductos(int id)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                bool eliminado = await _ir.DeleteProducto(id);
                if (eliminado)
                {
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "Producto eliminado";
                    return Ok(_respuesta);
                }
                else
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "Producto se pudo eliminar";
                    return BadRequest(_respuesta.mensaje);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}