namespace SharemundoBulgaria.ViewModels.JobPosition.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class JobPositionViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}