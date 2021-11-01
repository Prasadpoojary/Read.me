using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ReadME.Database;
using ReadME.Repository;

namespace ReadME
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataConnection")));

            services.AddControllersWithViews();
            services.AddSession(options => {options.IdleTimeout = TimeSpan.FromMinutes(60); });

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IBookRepo, BookRepo>();
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<ISpecificationRepo, SpecificationRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<ISavedRepo, SavedRepo>();
            services.AddScoped<IAdminRepo, AdminRepo>();
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<IReportRepo, ReportRepo>();
            services.AddScoped<ITicketRepo, TicketRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/error/{0}");
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            
    
            
        }
    }
}
