using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantCMS.Areas.Identity.Data;
using RestaurantCMS.Data;

[assembly: HostingStartup(typeof(RestaurantCMS.Areas.Identity.IdentityHostingStartup))]
namespace RestaurantCMS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RestaurantCMSContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RestaurantCMSContextConnection")));

                services.AddDefaultIdentity<RestaurantCMSUser>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        }
                    )
                    .AddEntityFrameworkStores<RestaurantCMSContext>();
            });
        }
    }
}