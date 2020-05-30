using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Algorithms;
using IndiciesOfMultipleDeprivation.Models;
using IndiciesOfMultipleDeprivation.Parser;

namespace IndiciesOfMultipleDeprivation
{
    public class Bootstrap
    {
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;
        private readonly ILinearParser<HousePrice> _housePriceParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSupportOutputAreaCodeToWardCodeParser;
        private readonly IEnumerable<IAlgorithm> _algorithms;

        public Bootstrap(string lowerLayerSuperOutputAreaPath, string housePricePath, string lowerLayerSuperOutputAreaToWardPath)
        {
            _lowerLayerSuperOutputAreaParser = new LowerLayerSuperOutputAreaParser(lowerLayerSuperOutputAreaPath);
            _housePriceParser = new HousePriceParser(housePricePath);
            _lowerLayerSupportOutputAreaCodeToWardCodeParser = new LowerLayerSuperOutputAreaCodeToWardCodeParser(lowerLayerSuperOutputAreaToWardPath);
            _algorithms = new List<IAlgorithm>
            {
                new SelectByMeanDecileFilterLessThanOr7SortByMeanPriceAlgorithm(),
            };
        }

        public void Start()
        {
            var lowerLayerSuperOutputAreas = _lowerLayerSuperOutputAreaParser.Parse();
            var housePrices = _housePriceParser.Parse();
            var lowerLayerSupportOutputAreaCodesToWardCodes = _lowerLayerSupportOutputAreaCodeToWardCodeParser.KeyValueParse();
            
            foreach (var algorithm in _algorithms)
            {
                algorithm.Execute(lowerLayerSuperOutputAreas, lowerLayerSupportOutputAreaCodesToWardCodes, housePrices);
            }
        }
    }
}