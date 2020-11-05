namespace SharemundoBulgaria.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
    using SharemundoBulgaria.Constraints;
    using SharemundoBulgaria.Services.Career;
    using SharemundoBulgaria.ViewModels.Career.ViewModels;
    using SharemundoBulgaria.ViewModels.JobPosition.InputModels;
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
            JobPositionViewModel viewModel = await this.careerService.GetJobById(id);
            var model = new JobPositionBaseModel
            {
                JobPositionViewModel = viewModel,
                JobCandidateInputModel = new JobCandidateInputModel(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForJob(JobPositionBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("JobPosition", "Career", new { id = model.JobPositionViewModel.Id });
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("JobPosition", "Career");
            }
        }
    }
}