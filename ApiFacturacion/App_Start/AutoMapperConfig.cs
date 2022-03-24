using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiFacturacion.ViewModels;
using ApiFacturacion.Models;
using AutoMapper;

namespace ApiFacturacion.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(config =>
            {
                config.CreateMap<VentasViewModel, Ventas>();
                config.CreateMap<Ventas, VentasViewModel>();

                config.CreateMap<DetalleVenta, detalleVenta>();
                config.CreateMap<detalleVenta, DetalleVenta>();

                config.CreateMap<Clientes, ClienteViewModel>();
                config.CreateMap<ClienteViewModel, Clientes>();

                config.CreateMap<Productos, ProductoViewModel>();
                config.CreateMap<ProductoViewModel, Productos>();
            });
        }
    }
}