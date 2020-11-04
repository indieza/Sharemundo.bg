namespace SharemundoBulgaria.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Services.Company;
    using SharemundoBulgaria.Services.Home;
    using SharemundoBulgaria.ViewModels.Company;

    public class CompanyController : Controller
    {
        private readonly IHomeService homeServices;
        private readonly ICompanyService companyService;

        public CompanyController(IHomeService homeServices, ICompanyService companyService)
        {
            this.homeServices = homeServices;
            this.companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CompanyViewModel
            {
                HasAdmin = await this.homeServices.HasAdministrator(),
                AllSections = await this.companyService.GetAllCompanySections(),
            };

            return this.View(model);
        }
    }
}