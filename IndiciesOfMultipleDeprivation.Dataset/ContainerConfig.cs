using Autofac;
using IndiciesOfMultipleDeprivation.Algorithms;
using IndiciesOfMultipleDeprivation.Models;
using IndiciesOfMultipleDeprivation.Parser;

namespace IndiciesOfMultipleDeprivation
{
    public class ContainerConfig
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

            builder.RegisterType<SelectTopDecileAndSortByPriceAlgorithm>().As<IAlgorithm>();
            builder.RegisterType<SelectByMeanDecileFilterLessThanOr7SortByMeanPriceAlgorithm>().As<IAlgorithm>();
            
            return builder.Build();
        }
    }
}
