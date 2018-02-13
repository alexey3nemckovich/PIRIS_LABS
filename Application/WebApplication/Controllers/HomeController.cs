using System.Web.Mvc;
using AutoMapper;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();
        public ActionResult Index()
        {
            return View();
        }
    }
}
