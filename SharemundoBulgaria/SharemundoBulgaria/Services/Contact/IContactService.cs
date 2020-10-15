namespace SharemundoBulgaria.Services.Contact
{
    using SharemundoBulgaria.ViewModels.Contact;

    public interface IContactService
    {
        void SendEmail(ContactInputModel model);
    }
}