using DataEntity;
using DataModel;
using IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using System;

namespace YunQiERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication("Cookieauth")
            .AddCookie("Cookieauth", options =>
            {
                options.LoginPath = new PathString("/Account/Login/");
                options.AccessDeniedPath = new PathString("/Account/Forbidden/");
                options.CookieHttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(300);
                options.SlidingExpiration = true;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(3000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Google Recaptcha
            services.AddRecaptcha(new RecaptchaOptions
            {
                SiteKey = "6LfzLSYTAAAAAPyffjuNrfi6yLGvFXufNWwLQovY",
                SecretKey = "6LfzLSYTAAAAAIrFJSmA7GN6h6QvLJOaQ9r9KTop"
                //  ControlSettings=new RecaptchaControlSettings { Type= RecaptchaType.Image  }
            });
            // 資料存取類別
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IEmployeeRepository>(new EmployeeRepository());
            services.AddSingleton<IProductRepository>(new ProductRepository());
            services.AddSingleton<IAccountingRepository>(new AccountingRepository());
            services.AddSingleton<IPurchaseRepository>(new PurchaseRepository());
            services.AddSingleton<ISalaryRepository>(new SalaryRepository());
            services.AddSingleton<IParameterRepository>(new ParameterRepository());
            services.AddSingleton<IMediaRepository>(new MediaRepository());
            services.AddSingleton<IMemberRepository>(new MemberRepository());
            services.AddSingleton<IOrderRepository>(new OrderRepository());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.UseCookieAuthentication(new CookieAuthenticationOptions()
            //{
            //    AuthenticationScheme = "MyCookieMiddlewareInstance",
            //    LoginPath = new PathString("/Account/Login/"),
            //    AccessDeniedPath = new PathString("/Account/Forbidden/"),
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    CookieHttpOnly = true,
            //    ExpireTimeSpan = TimeSpan.FromMinutes(30),
            //    SlidingExpiration = true
            //});

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}