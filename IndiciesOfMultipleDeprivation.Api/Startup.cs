using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Features.AttributeFilters;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Parser;
using IndiciesOfMultipleDeprivation.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.FileIO;

namespace IndiciesOfMultipleDeprivation.Api
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
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var lowerLayerSuperOutputAreaDatasetPath = "../data/imd.csv";
            var housePriceDatasetPath = "../data/houseprices.csv";
            var lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath =
                "../data/llsoatoward.csv";

            // Register your own things directly with Autofac, like:
            builder.RegisterType<DatasetProvider>().As<IDatasetProvider>().SingleInstance();

            builder.Register((ctx) =>
                    new TextFieldParserWrapper(new TextFieldParser(lowerLayerSuperOutputAreaDatasetPath)))
                .Named<ITextFieldParser>(nameof(lowerLayerSuperOutputAreaDatasetPath));
            builder.Register((ctx) => new TextFieldParserWrapper(new TextFieldParser(housePriceDatasetPath)))
                .Named<ITextFieldParser>(nameof(housePriceDatasetPath));
            builder.Register((ctx) =>
                    new TextFieldParserWrapper(new TextFieldParser(lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath)))
                .Named<ITextFieldParser>(nameof(lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath));

            builder.RegisterType<LowerLayerSuperOutputAreaParser>().As<ILinearParser<LowerLayerSuperOutputArea>>().WithAttributeFiltering();
            builder.RegisterType<HousePriceParser>().As<ILinearParser<HousePrice>>().WithAttributeFiltering();
            builder.RegisterType<LowerLayerSuperOutputAreaCodeToWardCodeParser>().As<IKeyValueParser<string, string>>().WithAttributeFiltering();

            builder
                .RegisterAssemblyTypes(Assembly.Load(nameof(IndiciesOfMultipleDeprivation)))
                .Where((t) => t.Namespace != null && t.Namespace.Contains("Queries") && t.IsClass)
                .As((t) => t.GetInterfaces().FirstOrDefault((i) => i.Name == "I" + t.Name));

            builder.RegisterType<QueryChain>().As<IQueryChain>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
