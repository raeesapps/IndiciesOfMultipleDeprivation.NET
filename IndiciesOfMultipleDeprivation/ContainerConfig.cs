using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Features.AttributeFilters;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Parser;
using IndiciesOfMultipleDeprivation.Query;
using IndiciesOfMultipleDeprivation.Task;
using Microsoft.VisualBasic.FileIO;
using RegistrationExtensions = Autofac.Features.AttributeFilters.RegistrationExtensions;

namespace IndiciesOfMultipleDeprivation
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var lowerLayerSuperOutputAreaDatasetPath = "//Users/raees/Documents/area_data/imd.csv";
            var housePriceDatasetPath = "//Users/raees/Documents/area_data/houseprices.csv";
            var lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath =
                "//Users/raees/Documents/area_data/llsoatoward.csv";
            
            var builder = new ContainerBuilder();
            
            builder.RegisterType<Bootstrap>().As<IBootstrap>();
            
            builder.Register((ctx) => new TextFieldParser(lowerLayerSuperOutputAreaDatasetPath))
                .Named<TextFieldParser>(nameof(lowerLayerSuperOutputAreaDatasetPath));
            builder.Register((ctx) => new TextFieldParser(housePriceDatasetPath))
                .Named<TextFieldParser>(nameof(housePriceDatasetPath));
            builder.Register((ctx) => new TextFieldParser(lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath))
                .Named<TextFieldParser>(nameof(lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath));
            
            builder.RegisterType<LowerLayerSuperOutputAreaParser>().As<ILinearParser<LowerLayerSuperOutputArea>>().WithAttributeFiltering();
            builder.RegisterType<HousePriceParser>().As<ILinearParser<HousePrice>>().WithAttributeFiltering();
            builder.RegisterType<LowerLayerSuperOutputAreaCodeToWardCodeParser>().As<IKeyValueParser<string, string>>().WithAttributeFiltering();

            builder
                .RegisterAssemblyTypes(Assembly.Load(nameof(IndiciesOfMultipleDeprivation)))
                .Where((t) => t.Namespace != null && t.Namespace.Contains("Queries") && t.IsClass)
                .As((t) => t.GetInterfaces().FirstOrDefault((i) => i.Name == "I" + t.Name));
            
            builder
                .RegisterAssemblyTypes(Assembly.Load(nameof(IndiciesOfMultipleDeprivation)))
                .Where((t) => t.Namespace != null && t.Namespace.Contains("Tasks"))
                .As<ITask>();
            
            builder.RegisterType<QueryChain>().As<IQueryChain>();

            return builder.Build();
        }
    }
}
