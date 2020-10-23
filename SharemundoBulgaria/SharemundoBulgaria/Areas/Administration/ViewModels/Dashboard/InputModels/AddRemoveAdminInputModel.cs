namespace SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddRemoveAdminInputModel
    {
        [Required]
        public string Username { get; set; }
    }
}