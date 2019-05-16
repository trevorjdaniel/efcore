using ICMASync.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICMASync.Data
{
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BaseContext>(
                options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        }

        /// <summary>
        /// Configures this instance.
        /// </summary>
        public void Configure(IServiceProvider serviceProvider)
        {
            //var context = serviceProvider.GetRequiredService<BaseContext>();
            //DbInitializer.Initialize(context);
        }
    }
}
