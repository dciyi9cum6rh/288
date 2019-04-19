using DataEntity;
using DataModel;
using IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebEssentials.AspNetCore.Pwa;

namespace YunQiWholesale
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

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(3000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //20181224-- - 棋
            //Google Recaptcha
            services.AddMvc();
            //services.AddRecaptcha(new RecaptchaOptions
            //{
            //    SiteKey = "6LfzLSYTAAAAAPyffjuNrfi6yLGvFXufNWwLQovY",
            //    SecretKey = "6LfzLSYTAAAAAIrFJSmA7GN6h6QvLJOaQ9r9KTop"
            //    //ValidationMessage = "Are you a robot?",
            //    //ControlSettings=new RecaptchaControlSettings { Type= RecaptchaType.Image  }
            //});

            //20190108  ---棋
            //WebEssentials.AspNetCore.PWA
            services.AddProgressiveWebApp();
            //Specify which caching strategy you want to use if you want a different one than the default (CacheFirstSafe):
            //services.AddServiceWorker(new PwaOptions
            //{
            //    Strategy = ServiceWorkerStrategy.CacheFirst
            //});
            //自定義 Cache storage
            services.AddServiceWorker(new PwaOptions
            {
                CacheId = "v20190108",
                RoutesToPreCache = "images/icon512x512.png"
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

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
