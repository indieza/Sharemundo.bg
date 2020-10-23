namespace SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.User;

    public class DashboardViewModel
    {
        public ICollection<ApplicationUser> AllUsers { get; set; }

        public ICollection<string> AllAdminsNames { get; set; }

        public ICollection<string> AllNotAdminsNames { get; set; }

        public int AllUsersCount { get; set; }

        public int AllAdminsCount { get; set; }
    }
}