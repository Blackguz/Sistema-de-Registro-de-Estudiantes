using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sistema_de_Registro_de_Estudiantes.Data;

[assembly: HostingStartup(typeof(Sistema_de_Registro_de_Estudiantes.Areas.Identity.IdentityHostingStartup))]
namespace Sistema_de_Registro_de_Estudiantes.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuyhDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuyhDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AuyhDbContext>();
            });
        }
    }
}