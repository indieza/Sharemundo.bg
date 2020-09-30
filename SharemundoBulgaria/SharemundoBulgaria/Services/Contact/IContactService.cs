using SharemundoBulgaria.ViewModels.Contact;

namespace SharemundoBulgaria.Services.Contact
{
    public interface IContactService
    {
        void SendEmail(ContactInputModel model);
    }
}