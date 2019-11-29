namespace IreckonuAssignment
{
    using AutoMapper;
    using IreckonuAssignment.BusinessLogic;
    using IreckonuAssignment.DataAccess;
    using IreckonuAssignment.DataAccess.Db;
    using IreckonuAssignment.DataAccess.Json;
    using IreckonuAssignment.Utilities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DataAccess.Db.Models.Mappers.ArticleDataModelProfile());
                mc.AddProfile(new DataAccess.Json.Models.Mappers.ArticleDataModelProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

            var databaseConnectionString = this.Configuration["ConnectionStrings:IreckonuAssignmentDatabase"];
            services.AddDbContext<IreckonuAssigmentDbContext>();
            services.AddScoped<IIreckonuAssigmentDbContext>(x =>
                                new IreckonuAssigmentDbContext(databaseConnectionString));

            services.AddScoped(x => new IreckonuAssigmentDbContext(databaseConnectionString));

            services.AddScoped<IFormFileStringReader, FormFileStringReader>();
            services.AddScoped<IFormFileStringArticleParser, FormFileStringArticleParser>();

            services.AddScoped<IArticlesNormalizer, ArticlesNormalizer>();
            services.AddScoped<IArticlesHandler, ArticlesHandler>();

            services.AddScoped<IArticleSaver, DatabaseArticleSaver>();
            services.AddScoped<IArticleSaver, JsonArticleSaver>();
            services.AddScoped<IFileWrapper>(x => new FileWrapper(this.Configuration["JsonFilePath"]));

            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Url = string.Empty };
                swagger.SwaggerDoc(
                    SwaggerConfiguration.DocNameV1,
                    new Info
                    {
                        Title = SwaggerConfiguration.DocInfoTitle,
                        Version = SwaggerConfiguration.DocInfoVersion,
                        Description = SwaggerConfiguration.DocInfoDescription,
                        Contact = contact
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Delete and recreated DB when application is started
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IreckonuAssigmentDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}