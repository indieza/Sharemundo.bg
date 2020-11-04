namespace SharemundoBulgaria.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Services.Home;
    using SharemundoBulgaria.Services.Services;
    using SharemundoBulgaria.ViewModels.Services;

    public class ServicesController : Controller
    {
        private readonly IHomeService homeServices;
        private readonly IServicesService servicesService;

        public ServicesController(IHomeService homeServices, IServicesService servicesService)
        {
            this.homeServices = homeServices;
            this.servicesService = servicesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ServicesViewModel
            {
                HasAdmin = await this.homeServices.HasAdministrator(),
                AllSections = await this.servicesService.GetAllServicesSections(),
            };

            return this.View(model);
        }
    }
}