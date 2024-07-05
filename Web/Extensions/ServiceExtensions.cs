using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using System.IO;
using System;
using Contracts.Repositories;
using Persistence.Repositories;
using Web.Middleware;
using Application.Behaviors;
using FluentValidation;
using MediatR;
using Application.Abstractions.Logging;
using Logging;

namespace Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(builder =>
            {
                var connectionString = configuration.GetConnectionString("Database");

                builder.UseNpgsql(connectionString);
            });
        }
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddSingleton<ILogger, Logger>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddTransient<ExceptionHandlingMiddleware>();
        }
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

            services.AddMediatR(applicationAssembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(applicationAssembly);
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILogger, Logger>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

            services.AddSwaggerGen(c =>
            {
                string presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

                string presentationDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

                c.IncludeXmlComments(presentationDocumentationFilePath);

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
            });
        }
    }
}
