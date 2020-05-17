using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalAccounting.Web.Areas.Identity;
using PersonalAccounting.Web.Handlers;
using PersonalAccounting.Web.Services;
using PersonalAccounting.Web.Services.Interfaces;
using System;

namespace PersonalAccounting.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCognitoIdentity();
            services.AddRazorPages();
            services.AddServerSideBlazor();            

            services.AddTransient<HttpClientMessageHandlers>();
            services.AddHttpClient(Constants.PersonalAccountingApi, c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("HttpClient:PersonalAccountingApi:Uri").Value);
            }).AddHttpMessageHandler<HttpClientMessageHandlers>();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<CognitoUser>>();
            services.AddTransient<IUsersServices, UsersServices>();
            services.AddTransient<IBudgetService, BudgetService>();
            services.AddTransient<ITransactionsService, TransactionsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();

            services.AddHealthChecks();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
