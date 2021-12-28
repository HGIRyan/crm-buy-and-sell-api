using System.Text;
using API.Extensions.DependancyInjection;
using API.Modules.App.Customer.Contact.Extensions;
using API.Modules.Base.Auth.Extensions;
using API.Modules.Base.Services.Mongo.MongoData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API
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
            //Configures MongoDb
            services.Configure<MongoSettings>(Configuration.GetSection(nameof(MongoSettings)));
            services.AddSingleton<IMongoSettings>(x => x.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.AddAuthenticationModule();
            services.AddCustomerModule();
            services.AddSampleCustomerModule();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
            });

            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCustomSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}