using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SharemundoBulgaria.Areas.Identity.IdentityHostingStartup))]

namespace SharemundoBulgaria.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}