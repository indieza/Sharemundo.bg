namespace SharemundoBulgaria.Controllers.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;

    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IStringLocalizer<LanguageController> localizer;

        public LanguageController(IStringLocalizer<LanguageController> localizer)
        {
            this.localizer = localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var guid = Guid.NewGuid();
            return this.Ok(this.localizer["RandomGUID", guid.ToString()].Value);
        }
    }
}