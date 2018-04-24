using System;
using System.Reflection;
using AVStore.DataAccess;
using AVStore.Web.Core.Services.Abstract;
using AVStore.WebApp.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AVStore.WebApp
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
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.SwaggerDoc("v2", new Info { Title = "My API", Version = "v2" });
            });

            services.AddDbContext<StoreContext>();
            services.AddMediatR(typeof(StoreContext).GetTypeInfo().Assembly);

            services.AddTransient<IRepositoryProvider, RepositoryProvider>();
            services.AddClassesImplementingInterface(typeof(IRepository<>));
            services.AddClassesImplementingInterface(typeof(IService<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
            });

            var db = serviceProvider.GetService<StoreContext>();
            db.Database.Migrate();
            DbInitializer.Initialize(db);
        }
    }
}
