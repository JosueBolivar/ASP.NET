using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebLiga
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        static public IConfigurationRoot StrConexion { get; set; }

        public static class ConfigSite
        {
            public static string StatusSite { get; set; }
            public static string SendEmail { get; set; }
            public static string RutaLog { get; set; }
            public static string ArchivoLog { get; set; }
            public static string Modo { get; set; }
            public static string EmularUsuario { get; set; }
            public static string RedisHost { get; set; }
            public static string RedisPort { get; set; }
            public static string LigaLinchWeb { get; set; }
            public static string photos { get; set; }
            public static string logosClub { get; set; }
            public static string fotosJugadores { get; set; }
            public static string descargas { get; set; }
            public static string Cookiedomain { get; set; }
            public static string Unamesautorizados { get; set; }
            public static int PerfilAdmin { get; set; }
            public static string Dowloaddescargas { get; set; }
            public static string Error { get; set; }
            public static string Login { get; set; }
            public static string PerfilId { get; set; }
            public static string NombreCompleto { get; set; }
            public static string NombrePerfil { get; set; }
            public static string ClubId { get; set; }
        }

        public static class EmailService
        {
            public static string EmailFrom { get; set; }
            public static string EmailFromText { get; set; }
            public static string EmailTo { get; set; }
            public static string EmailToTex { get; set; }
            public static string Server { get; set; }
            public static string Username { get; set; }
            public static string Password { get; set; }
            public static int Puerto { get; set; }
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();
            Configuration = builder.Build();
            StrConexion = Configuration;

            ConfigSite.StatusSite = Configuration.GetSection("ConfigureSite").GetSection("StatusSite").Value;
            ConfigSite.SendEmail = Configuration.GetSection("ConfigureSite").GetSection("SendEmail").Value;
            ConfigSite.ArchivoLog = env.ContentRootPath.ToString() + "\\" + Configuration.GetSection("ConfigureSite").GetSection("RutaLog").Value + "\\" + Configuration.GetSection("ConfigureSite").GetSection("ArchivoLog").Value;
            ConfigSite.Modo = Configuration.GetSection("ConfigureSite").GetSection("Modo").Value;
            ConfigSite.EmularUsuario = Configuration.GetSection("ConfigureSite").GetSection("EmularUsuario").Value;
            ConfigSite.RedisHost = Configuration.GetSection("ConfigureSite").GetSection("RedisHost").Value;
            ConfigSite.RedisPort = Configuration.GetSection("ConfigureSite").GetSection("RedisPort").Value;
            ConfigSite.LigaLinchWeb = Configuration.GetSection("ConfigureSite").GetSection("docenciaWeb").Value;
            ConfigSite.photos = Configuration.GetSection("ConfigureSite").GetSection("photos").Value;
            ConfigSite.logosClub = Configuration.GetSection("ConfigureSite").GetSection("logosClub").Value;
            ConfigSite.fotosJugadores = Configuration.GetSection("ConfigureSite").GetSection("fotosJugadores").Value;
            ConfigSite.descargas = Configuration.GetSection("ConfigureSite").GetSection("descargas").Value;
            ConfigSite.Cookiedomain = Configuration.GetSection("ConfigureSite").GetSection("Cookiedomain").Value;
            ConfigSite.Unamesautorizados = Configuration.GetSection("ConfigureSite").GetSection("unamesautorizados").Value;
            ConfigSite.PerfilAdmin = Int32.Parse(Configuration.GetSection("ConfigureSite").GetSection("PerfilAdmin").Value);
            ConfigSite.Error = Configuration.GetSection("ConfigureSite").GetSection("Error").Value;
            ConfigSite.Login = Configuration.GetSection("ConfigureSite").GetSection("Login").Value;
            ConfigSite.PerfilId = Configuration.GetSection("ConfigureSite").GetSection("PerfilId").Value;
            ConfigSite.NombreCompleto = Configuration.GetSection("ConfigureSite").GetSection("NombreCompleto").Value;
            ConfigSite.NombrePerfil = Configuration.GetSection("ConfigureSite").GetSection("NombrePerfil").Value;
            ConfigSite.ClubId = Configuration.GetSection("ConfigureSite").GetSection("ClubId").Value;

            EmailService.EmailFrom = Configuration.GetSection("EmailService").GetSection("EmailFrom").Value;
            EmailService.EmailFromText = Configuration.GetSection("EmailService").GetSection("EmailFromText").Value;
            EmailService.EmailTo = Configuration.GetSection("EmailService").GetSection("EmailTo").Value;
            EmailService.EmailToTex = Configuration.GetSection("EmailService").GetSection("EmailToTex").Value;
            EmailService.Server = Configuration.GetSection("EmailService").GetSection("Server").Value;
            EmailService.Username = Configuration.GetSection("EmailService").GetSection("Username").Value;
            EmailService.Password = Configuration.GetSection("EmailService").GetSection("Password").Value;
            EmailService.Puerto = Int32.Parse(Configuration.GetSection("EmailService").GetSection("Puerto").Value);
        }

        //public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddMemoryCache(opt =>
            {
                opt.ExpirationScanFrequency = TimeSpan.FromMinutes(90);
            });

            services.AddSession();     // Add session services

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSession(new SessionOptions()
            {
                //se debe comentar en 
                CookieName = "LigaLinchWeb",
                CookieDomain = ConfigSite.Cookiedomain,
                IdleTimeout = TimeSpan.FromMinutes(3600),
                CookieHttpOnly = false
            });

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();


            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}");
            });
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            //Home/Index 
            //routeBuilder.MapRoute("Default", "{controller = Home}/{action = Index}/{id?}");
            routeBuilder.MapRoute("Default", "{controller = Home}/{action = Login}/{id?}");
            //routeBuilder.MapRoute("Administrar", "{controller = Home}/{action = Admin}/{id?}");
        }
    }
}
