using AutoMapper;
using School.Application.Interfaces.IRepositories;
using School.Application.Mappers;
using School.Application.Services;
using School.Infrastructure.Config;
using School.Infrastructure.Repositories;

namespace School
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string environment { get; set; }

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            environment = env.EnvironmentName.ToLower();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            Config(services);
            DependencyInjection(services);
            Mappers(services);
            var assembly = AppDomain.CurrentDomain.Load("School.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(typeof(SchoolMapper));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            

            services.AddOpenApiDocument(conf =>
            {
                conf.Title = "School API";
            });
        }

        public void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ISchoolDbContextFactory, SchoolContextFactory>();
            services.AddSingleton<ISchoolRepository, SchoolRepository>();
        }

        public void Config(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{environment}.json").Build();
            services.AddSingleton(config.GetSection("ConnectionStrings").Get<ConnectionStrings>());
        }

        public void Mappers (IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SchoolMapper>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
