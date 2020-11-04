namespace SharemundoBulgaria.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Services.Career;
    using SharemundoBulgaria.ViewModels.Career.ViewModels;
    using SharemundoBulgaria.ViewModels.JobPosition.ViewModels;

    public class CareerController : Controller
    {
        private readonly ICareerService careerService;

        public CareerController(ICareerService careerService)
        {
            this.careerService = careerService;
        }

        public IActionResult Index()
        {
            var model = new CareerViewModel
            {
                JobPositionViewModels = this.careerService.GetAllJobsPositions(),
            };

            return this.View(model);
        }

        [HttpGet]
        [Route("/Career/JobPosition/{id}")]
        public async Task<IActionResult> JobPosition(string id)
        {
            JobPositionViewModel model = await this.careerService.GetJobById(id);
            return this.View(model);
        }
    }
}