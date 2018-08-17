using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.DashboardAspNetCore;
using DevExpress.AspNetCore;
using DevExpress.DashboardWeb;
using System.IO;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Sql;
using SaveDashboardDB.Code;
using System.Configuration;

namespace SaveDashboardDB {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services
                .AddMvc()
                .AddDefaultDashboardController((configurator, serviceProvider) => {
                    configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));

                    DataBaseEditaleDashboardStorage dataBaseDashboardStorage = new DataBaseEditaleDashboardStorage(Configuration.GetConnectionString("DashboardStorageConnection"));
                    configurator.SetDashboardStorage(dataBaseDashboardStorage);
                });
            services.AddDevExpressControls(settings => settings.Resources = ResourcesType.ThirdParty | ResourcesType.DevExtreme);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseDevExpressControls();

            app.UseMvc(routes => {
                routes.MapDashboardRoute();
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}