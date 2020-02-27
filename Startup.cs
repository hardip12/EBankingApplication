using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDomain.Concrete;
using BusinessDomain.Interface;
using InfraStructure.EBankingUnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models.Context;
using Simple.Data.SqlServer;

namespace EBankingApp
{
    public class Startup
    {
       // private KeyVaultConfig keyVaultConfig;
        public Startup(IConfiguration configuration)
        {
            string environment = string.Empty;
            Configuration = configuration;
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicyAllowAll",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials() commented this as allowanyorigin and allowcredentials cant coexist
                    ));
            services.AddControllers();
            //services.AddDbContext<EBankingContext>(options =>
            //{

            //    options.UseSqlServer(SqlConnectionProvider.GetConnection(keyVaultConfig.GetDBConnectionString("DBConnection"), Configuration["KeyVals:MSIIdentityEndpoint"], Configuration["KeyVals:Environment"]));

            //}, ServiceLifetime.Scoped);
            services.AddTransient<EbankingUnitOfWork>();
            services.AddTransient<EBankingContext, EBankingContext>();
            services.AddTransient<ICustomerDetails, CustomerDetailsConcrete>();
            
            //services.AddMvc();
            //services.AddMvcCore();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicyAllowAll");

            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseHttpsRedirection();
            //app.UseMvc();
        }
    }
}
