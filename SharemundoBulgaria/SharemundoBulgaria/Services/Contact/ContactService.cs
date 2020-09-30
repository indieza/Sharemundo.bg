namespace SharemundoBulgaria.Services.Contact
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using SharemundoBulgaria.ViewModels.Contact;

    public class ContactService : IContactService
    {
        private readonly IConfiguration configuration;

        public ContactService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendEmail(ContactInputModel model)
        {
            this.Execute(model).Wait();
        }

        private async Task Execute(ContactInputModel model)
        {
            var apiKey = this.configuration.GetSection("SendGrid:ApiKey").Value;
            var client = new SendGridClient(apiKey);

            var message = new SendGridMessage()
            {
                From = new EmailAddress(model.Email, model.Name),
                Subject = model.Subject,
                PlainTextContent = model.Message,
                HtmlContent = $"<strong>Hello, Sharemundo Bulgaria Administrators!</strong><br />{model.Message}",
            };

            message.AddTo(new EmailAddress("b.gerginchev@gmail.com", "Test User"));
            var response = await client.SendEmailAsync(message);
        }
    }
}