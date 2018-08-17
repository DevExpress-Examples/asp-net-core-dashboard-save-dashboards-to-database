Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports DevExpress.DashboardAspNetCore
Imports DevExpress.AspNetCore
Imports DevExpress.DashboardWeb
Imports System.IO
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.Sql
Imports SaveDashboardDB.Code
Imports System.Configuration

Namespace SaveDashboardDB
    Public Class Startup
        Public Sub New(ByVal configuration As IConfiguration)
            Me.Configuration = configuration
        End Sub

        Public ReadOnly Property Configuration() As IConfiguration

        ' This method gets called by the runtime. Use this method to add services to the container.
        Public Sub ConfigureServices(ByVal services As IServiceCollection)
            services.AddMvc().AddDefaultDashboardController(Sub(configurator, serviceProvider)
                configurator.SetConnectionStringsProvider(New DashboardConnectionStringsProvider(Configuration))
                Dim dataBaseDashboardStorage As New DataBaseEditaleDashboardStorage(Configuration.GetConnectionString("DashboardStorageConnection"))
                configurator.SetDashboardStorage(dataBaseDashboardStorage)
            End Sub)
            services.AddDevExpressControls(Sub(settings) settings.Resources = ResourcesType.ThirdParty Or ResourcesType.DevExtreme)
        End Sub

        ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment)
            If env.IsDevelopment() Then
                app.UseBrowserLink()
                app.UseDeveloperExceptionPage()
            Else
                app.UseExceptionHandler("/Home/Error")
            End If

            app.UseStaticFiles()
            app.UseDevExpressControls()

            app.UseMvc(Sub(routes)
                routes.MapDashboardRoute()
                routes.MapRoute(name:= "default", template:= "{controller=Home}/{action=Index}/{id?}")
            End Sub)
        End Sub
    End Class
End Namespace