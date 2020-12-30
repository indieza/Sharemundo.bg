namespace SharemundoBulgaria
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using SharemundoBulgaria.Areas.Administration.Services.AddJobPosition;
    using SharemundoBulgaria.Areas.Administration.Services.AddPartToSection;
    using SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage;
    using SharemundoBulgaria.Areas.Administration.Services.AllJobsCandidates;
    using SharemundoBulgaria.Areas.Administration.Services.Dashboard;
    using SharemundoBulgaria.Areas.Administration.Services.EditJobPosition;
    using SharemundoBulgaria.Areas.Administration.Services.EditPart;
    using SharemundoBulgaria.Areas.Administration.Services.EditPartsPosition;
    using SharemundoBulgaria.Areas.Administration.Services.EditSection;
    using SharemundoBulgaria.Areas.Administration.Services.EditSectionsPosition;
    using SharemundoBulgaria.Areas.Administration.Services.RemoveJobPosition;
    using SharemundoBulgaria.Areas.Administration.Services.RemovePart;
    using SharemundoBulgaria.Areas.Administration.Services.RemoveSection;
    using SharemundoBulgaria.Constraints;
    using SharemundoBulgaria.Data;
    using SharemundoBulgaria.Models.User;
    using SharemundoBulgaria.Services.Career;
    using SharemundoBulgaria.Services.Cloud;
    using SharemundoBulgaria.Services.Company;
    using SharemundoBulgaria.Services.Contact;
    using SharemundoBulgaria.Services.Home;
    using SharemundoBulgaria.Services.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = Constants.PasswordRequiredLength;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders().AddDefaultUI();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Identity/Account/Login";
                options.SlidingExpiration = true;
            });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            // Configuration for update cookies when user is added in Role!!!
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(0);
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("bg"),
                };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            // Cloudinary Authentication
            var cloudinaryAccount = new Account(
                this.Configuration["Cloudinary:CloudName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]);
            var cloudinary = new Cloudinary(cloudinaryAccount);
            services.AddSingleton(cloudinary);

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<ICareerService, CareerService>();

            // Register Administration Services
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IAddSectionToPageService, AddSectionToPageService>();
            services.AddTransient<IAddPartToSectionService, AddPartToSectionService>();
            services.AddTransient<IRemoveSectionService, RemoveSectionService>();
            services.AddTransient<IRemovePartService, RemovePartService>();
            services.AddTransient<IEditSectionService, EditSectionService>();
            services.AddTransient<IEditPartService, EditPartService>();
            services.AddTransient<IEditSectionsPositionService, EditSectionsPositionService>();
            services.AddTransient<IEditPartsPositionService, EditPartsPositionService>();
            services.AddTransient<IAddJobPositionService, AddJobPositionService>();
            services.AddTransient<IAllJobsCandidates, AllJobsCandidates>();
            services.AddTransient<IRemoveJobService, RemoveJobService>();
            services.AddTransient<IEditJobPositionService, EditJobPositionService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                         name: "areas",
                         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}