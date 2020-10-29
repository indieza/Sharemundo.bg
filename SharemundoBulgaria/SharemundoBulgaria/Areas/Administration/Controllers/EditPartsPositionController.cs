﻿namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.EditPartsPosition;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPartsPosition.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class EditPartsPositionController : Controller
    {
        private readonly IEditPartsPositionService editPartsPositionService;

        public EditPartsPositionController(IEditPartsPositionService editPartsPositionService)
        {
            this.editPartsPositionService = editPartsPositionService;
        }

        public IActionResult Index()
        {
            var model = new EditPartsPositionViewModel
            {
                AllSections = this.editPartsPositionService.GetAllSections(),
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult GetPartsPosition(string sectionId)
        {
            ICollection<GetPartsPositionViewModel> partsPosition =
                this.editPartsPositionService.GetPartsPosition(sectionId);
            return new JsonResult(partsPosition);
        }
    }
}