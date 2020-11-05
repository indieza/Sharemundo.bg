namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.AllJobsCandidates;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AllJobsCandidates.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class AllJobsCandidatesController : Controller
    {
        private readonly IAllJobsCandidates allJobsCandidatesService;

        public AllJobsCandidatesController(IAllJobsCandidates allJobsCandidatesService)
        {
            this.allJobsCandidatesService = allJobsCandidatesService;
        }

        public IActionResult Index()
        {
            ICollection<JobCandidateViewModel> model = this.allJobsCandidatesService.GetAllCandidates();
            return this.View(model);
        }
    }
}