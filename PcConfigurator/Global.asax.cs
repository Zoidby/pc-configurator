using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PcConfigurator.Entities.Mongo;
using PcConfigurator.Models;

namespace PcConfigurator
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.CreateMap<Cpu, CpuDto>().ReverseMap();
            Mapper.CreateMap<Gpu, GpuDto>().ReverseMap();
            Mapper.CreateMap<Psu, PsuDto>().ReverseMap();
            Mapper.CreateMap<Motherboard, MotherboardDto>().ReverseMap();
            Mapper.CreateMap<Memory, MemoryDto>().ReverseMap();
            Mapper.CreateMap<Case, CaseDto>().ReverseMap();
        }
    }
}