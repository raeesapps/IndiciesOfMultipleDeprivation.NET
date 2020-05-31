using System.Linq;
using System.Reflection;
using Autofac;
using IndiciesOfMultipleDeprivation.Models;
using IndiciesOfMultipleDeprivation.Parser;
using IndiciesOfMultipleDeprivation.Query;
using IndiciesOfMultipleDeprivation.Task;

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

            builder
                .Register((context) => new LowerLayerSuperOutputAreaParser(lowerLayerSuperOutputAreaDatasetPath))
                .As<ILinearParser<LowerLayerSuperOutputArea>>();
            builder
                .Register((context) => new HousePriceParser(housePriceDatasetPath))
                .As<ILinearParser<HousePrice>>();
            builder
                .Register((context) =>
                    new LowerLayerSuperOutputAreaCodeToWardCodeParser(
                        lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath))
                .As<IKeyValueParser<string, string>>();

            builder
                .RegisterAssemblyTypes(Assembly.Load(nameof(IndiciesOfMultipleDeprivation)))
                .Where((t) => t.Namespace != null && t.Namespace.Contains("Queries") && t.IsClass)
                .As((t) => t.GetInterfaces().FirstOrDefault((i) => i.Name == "I" + t.Name));
            
            builder
                .RegisterAssemblyTypes(Assembly.Load(nameof(IndiciesOfMultipleDeprivation)))
                .Where((t) => t.Namespace != null && t.Namespace.Contains("Tasks"))
                .As<ITask>();
            
            builder.RegisterType<QueryChainBuilder>().As<IQueryChainBuilder>();

            return builder.Build();
        }
    }
}
