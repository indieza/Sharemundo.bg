namespace SharemundoBulgaria.Services.Home
{
    using System.Threading.Tasks;
    using SharemundoBulgaria.Models.User;

    public interface IHomeServices
    {
        Task SubmitAllRoles();

        Task<bool> HasAdministrator();

        Task MakeYourselfAdmin(ApplicationUser currentUser);
    }
}