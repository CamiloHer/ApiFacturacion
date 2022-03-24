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
using AutoMapper;

namespace ApiFacturacion.Controllers
{
    public class VentasController : ApiController
    {
        private readonly RepositorioVentas _ir = new RepositorioVentas();
        protected RespuestaViewModel _respuesta;
        
        // GET: api/Ventas
        public async Task<IHttpActionResult> GetVentas()
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var lista = await _ir.GetVentas();
                ClienteViewModel cliente;
                foreach (VentasViewModel item in lista)
                {
                    cliente = await _ir.GetCliente(item.idCliente);
                    if (cliente != null)
                    {
                        item.Cliente = cliente;
                    }
                }
                _respuesta.codigo = 0;
                _respuesta.data = lista;
                _respuesta.mensaje = "Listado de factura-ventas";
                return Ok(_respuesta);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/Ventas/5
        [ResponseType(typeof(Ventas))]
        public async Task<IHttpActionResult> GetVenta(int id)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var venta = await _ir.GetVentasPorId(id);

                if (venta != null)
                {
                    venta.Cliente = await _ir.GetCliente(venta.idCliente);

                }
                _respuesta.codigo = 0;
                _respuesta.mensaje = "factura-venta encontrada";
                _respuesta.data = venta;
                return Ok(_respuesta); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IHttpActionResult> GetDetalles()
        {
                _respuesta = new RespuestaViewModel();
            try
            {
                var listaDetalles = await _ir.GetDetalleVentas();
                //ClienteViewModel cliente;
                //foreach (VentasViewModel item in lista)
                //{
                //    cliente = await _ir.GetCliente(item.idCliente);
                //    if (cliente != null)
                //    {
                //        item.Cliente = cliente;
                //    }
                //}
                _respuesta.codigo = 0;
                _respuesta.data = listaDetalles;
                _respuesta.mensaje = "Listado de factura-ventas";
                 return Ok(_respuesta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IHttpActionResult> GetDetalleVenta(int id)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var venta = await _ir.GetDetalleVenta(id);

                _respuesta.codigo = 0;
                _respuesta.mensaje = "detalle de venta encontrada";
                _respuesta.data = venta;
                return Ok(_respuesta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVentas(int id, VentasViewModel ventas)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                if(id == ventas.id)
                {
                    var venta = await _ir.PutVentas(id, ventas);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "factura-venta actualizada";
                    _respuesta.data = venta;
                    return Ok(_respuesta);
                }
                _respuesta.mensaje = "los id no coinciden";
                return BadRequest(_respuesta.mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Ventas
        [ResponseType(typeof(Ventas))]
        public async Task<IHttpActionResult> PostVentas(VentasViewModel ventas)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                if (ventas.id > 0)
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "factura-venta no se pudo registrar";
                }
                else
                {
                    var venta = await _ir.PostVentas(ventas);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "factura-venta registrado";
                    _respuesta.data = venta;
                }
                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IHttpActionResult> PostDetalleVentas( detalleVenta detalles)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                if (detalles.idVenta > 0)
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "detalle-venta no se pudo registrar";
                }
                else
                {
                    var venta = await _ir.PostDetalleVenta(detalles);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "detalle-venta registrado";
                    _respuesta.data = venta;
                }
                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //    // DELETE: api/Ventas/5
        //    [ResponseType(typeof(Ventas))]
        //    public async Task<IHttpActionResult> DeleteVentas(int id)
        //    {
        //        Ventas ventas = await db.Ventas.FindAsync(id);
        //        if (ventas == null)
        //        {
        //            return NotFound();
        //        }

        //        db.Ventas.Remove(ventas);
        //        await db.SaveChangesAsync();

        //        return Ok(ventas);
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        //    private bool VentasExists(int id)
        //    {
        //        return db.Ventas.Count(e => e.id == id) > 0;
        //    }
    }
}