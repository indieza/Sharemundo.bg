namespace SharemundoBulgaria.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Localization;
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
            IRequestCultureFeature requestCulture = this.Request
                .HttpContext
                .Features
                .Get<IRequestCultureFeature>();
            var culture = requestCulture
                .RequestCulture
                .Culture
                .Name;

            var model = new CareerViewModel
            {
                JobPositionViewModels = this.careerService.GetAllJobsPositions(culture),
            };

            return this.View(model);
        }

        [HttpGet]
        [Route("/Career/JobPosition/{id}")]
        public async Task<IActionResult> JobPosition(string id)
        {
            IRequestCultureFeature requestCulture = this.Request
                .HttpContext
                .Features
                .Get<IRequestCultureFeature>();
            var culture = requestCulture
                .RequestCulture
                .Culture
                .Name;

            JobPositionViewModel viewModel = await this.careerService.GetJobById(id, culture);
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
                await this.careerService.ApplyForJob(model.JobCandidateInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyApplyFoJob;
                return this.RedirectToAction("JobPosition", "Career", new { Id = model.JobCandidateInputModel.JobPositionId });
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("JobPosition", "Career", new { Id = model.JobCandidateInputModel.JobPositionId });
            }
        }
    }
}