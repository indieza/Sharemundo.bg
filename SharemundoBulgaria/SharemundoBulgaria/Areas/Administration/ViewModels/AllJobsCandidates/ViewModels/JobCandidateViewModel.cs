using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharemundoBulgaria.Areas.Administration.ViewModels.AllJobsCandidates.ViewModels
{
    public class JobCandidateViewModel
    {
        public string JobCandidateId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phonenumber { get; set; }

        public string Email { get; set; }

        public string CvUrl { get; set; }

        public string JobPositionId { get; set; }

        public string JobTitle { get; set; }
    }
}