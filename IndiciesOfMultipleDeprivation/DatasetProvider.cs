using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Parser;

namespace IndiciesOfMultipleDeprivation
{
    public class DatasetProvider : IDatasetProvider
    {
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;
        private readonly ILinearParser<HousePrice> _housePriceParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSupportOutputAreaCodeToWardCodeParser;

        public Dataset Dataset { get; }

        public DatasetProvider(ILinearParser<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreaParser,
            ILinearParser<HousePrice> housePriceParser,
            IKeyValueParser<string, string> lowerLayerSupportOutputAreaCodeToWardCodeParser)
        {
            _lowerLayerSuperOutputAreaParser = lowerLayerSuperOutputAreaParser;
            _housePriceParser = housePriceParser;
            _lowerLayerSupportOutputAreaCodeToWardCodeParser = lowerLayerSupportOutputAreaCodeToWardCodeParser;

            Dataset = Provide();
        }

        private Dataset Provide()
        {
            var lowerLayerSuperOutputAreas = _lowerLayerSuperOutputAreaParser.Parse();
            var housePrices = _housePriceParser.Parse();
            var lowerLayerSupportOutputAreaCodesToWardCodes = _lowerLayerSupportOutputAreaCodeToWardCodeParser.KeyValueParse();
            var dataset = new Dataset
            {
                LowerLayerSuperOutputAreas = lowerLayerSuperOutputAreas,
                LowerLayerSuperOutputAreaCodeToWardCode = lowerLayerSupportOutputAreaCodesToWardCodes,
                HousePrices = housePrices,
            };

            return dataset;
        }
    }
}