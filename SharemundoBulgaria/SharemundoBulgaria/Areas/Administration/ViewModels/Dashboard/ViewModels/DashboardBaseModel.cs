namespace SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.InputModels;

    public class DashboardBaseModel
    {
        public DashboardViewModel DashboardViewModel { get; set; } = new DashboardViewModel();

        public AddRemoveAdminInputModel AddRemoveAdminInputModel { get; set; } = new AddRemoveAdminInputModel();
    }
}