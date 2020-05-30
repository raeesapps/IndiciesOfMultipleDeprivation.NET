using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Algorithms;
using IndiciesOfMultipleDeprivation.Models;
using IndiciesOfMultipleDeprivation.Parser;

namespace IndiciesOfMultipleDeprivation
{
    public class Bootstrap : IBootstrap
    {
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;
        private readonly ILinearParser<HousePrice> _housePriceParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSupportOutputAreaCodeToWardCodeParser;
        private readonly IEnumerable<IAlgorithm> _algorithms;

        public Bootstrap(ILinearParser<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreaParser,
            ILinearParser<HousePrice> housePriceParser,
            IKeyValueParser<string, string> lowerLayerSupportOutputAreaCodeToWardCodeParser,
            IEnumerable<IAlgorithm> algorithms)
        {
            _lowerLayerSuperOutputAreaParser = lowerLayerSuperOutputAreaParser;
            _housePriceParser = housePriceParser;
            _lowerLayerSupportOutputAreaCodeToWardCodeParser = lowerLayerSupportOutputAreaCodeToWardCodeParser;
            _algorithms = algorithms;
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