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
    public class ClientesController : ApiController
    {
        private readonly RepositorioVentas _ir = new RepositorioVentas();
        protected RespuestaViewModel _respuesta;
        // GET: api/Clientes
        public async Task<IHttpActionResult> GetClientes()
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var clientes = await _ir.GetClientes();
                _respuesta.codigo = 0;
                _respuesta.mensaje = "listado clientes";
                _respuesta.data = clientes;
                return Ok(_respuesta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> GetClientes(int id)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var cliente = await _ir.GetCliente(id);
                _respuesta.codigo = 0;
                _respuesta.mensaje = "Se encontro cliente";
                _respuesta.data = cliente;
                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientes(int id, ClienteViewModel clientes)
        {
            try {
                _respuesta = new RespuestaViewModel();
                if (id == clientes.documento)
                {
                    var cliente = await _ir.UpdateCliente(id, clientes);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "cliente actualizado";
                    _respuesta.data = cliente;
                    return Ok(_respuesta);
                }
                else
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "cliente no se ha podido actualizar";
                    return BadRequest(_respuesta.mensaje);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Clientes
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> PostClientes(ClienteViewModel clientes)
        {
            try
            {
                _respuesta = new RespuestaViewModel();

                var busca = await _ir.GetCliente(clientes.documento);

                if(busca != null)
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "ya se encuentra registrado";
                    return BadRequest(_respuesta.mensaje);
                }
                else
                {
                    var cliente = await _ir.PostCliente(clientes);
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "Cliente registrado";
                    _respuesta.data = cliente;
                    return Ok(_respuesta);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> DeleteClientes(int id)
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                bool eliminado = await _ir.DeleteCliente(id);
                if (eliminado)
                {
                    _respuesta.codigo = 0;
                    _respuesta.mensaje = "Cliente Eliminado";
                    return Ok(_respuesta);
                }
                else
                {
                    _respuesta.codigo = 1;
                    _respuesta.mensaje = "Cliente no se pudo eliminar";
                    return BadRequest(_respuesta.mensaje);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IHttpActionResult> GetTipos()
        {
            try
            {
                _respuesta = new RespuestaViewModel();
                var Tipos = await _ir.GetTiposDocumento();
                _respuesta.codigo = 0;
                _respuesta.mensaje = "listado Tipos de documento";
                _respuesta.data = Tipos;
                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}