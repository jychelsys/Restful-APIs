using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace QuotesApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<QuotesDbContext>(option => option.UseSqlServer(@"Data Source=DESKTOP-DHV2H31\SQLEXPRESS;Initial Catalog=QuotesDb;"));
        }       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, QuotesDbContext quotesDbContext)
        {
            if (env.IsDevelopment())
             {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                           app.UseHsts();
            }

            app.UseHttpsRedirection();
            quotesDbContext.Datbase.EnsureCreated();
            app.UseMvc();

            
        }
    }
}
