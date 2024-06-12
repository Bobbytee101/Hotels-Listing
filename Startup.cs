using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using HotelListingAPI.Data;
using HotelListingAPI.Helpers;
using HotelListingAPI.Services;
using FluentValidation.AspNetCore;
using System;
using System.Text;
using HotelListingAPI.Validators;

namespace HotelListingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            // Database context configuration
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("HotelListingInMemoryDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }

            // Add controllers and FluentValidation
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<HotelValidator>());

            // Register application services
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IPaymentService, PaymentService>();

            // Configure JWT authentication
            var jwtSettingsSection = Configuration.GetSection("Jwt");
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            if (string.IsNullOrEmpty(jwtSettings?.SecretKey))
            {
                throw new InvalidOperationException("JWT SecretKey is missing or empty.");
            }
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization();

            // Add Swagger for API documentation
            services.AddSwaggerGen();

            // Configure CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelListingAPI v1");
                    c.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Initialize the database with seed data
            DbInitializer.Initialize(app, env.IsDevelopment());
        }
    }
}
