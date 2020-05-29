using System;
using WhereAreTheAffordableGoodAreas.Models;
using WhereAreTheAffordableGoodAreas.Parser;

namespace WhereAreTheAffordableGoodAreas
{
    public class Bootstrap
    {
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;
        private readonly ILinearParser<HousePrice> _housePriceParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSupportOutputAreaCodeToWardCodeParser;

        public Bootstrap(string lowerLayerSuperOutputAreaPath, string housePricePath, string lowerLayerSuperOutputAreaToWardPath)
        {
            _lowerLayerSuperOutputAreaParser = new LowerLayerSuperOutputAreaParser(lowerLayerSuperOutputAreaPath);
            _housePriceParser = new HousePriceParser(housePricePath);
            _lowerLayerSupportOutputAreaCodeToWardCodeParser = new LowerLayerSuperOutputAreaCodeToWardCodeParser(lowerLayerSuperOutputAreaToWardPath);
        }

        public void Start()
        {
            var lowerLayerSuperOutputAreas = _lowerLayerSuperOutputAreaParser.Parse();
            foreach (var lowerLayerSuperOutputArea in lowerLayerSuperOutputAreas)
            {
                //Console.WriteLine(lowerLayerSuperOutputArea);
            }

            var housePrices = _housePriceParser.Parse();
            foreach (var housePrice in housePrices)
            {
                Console.WriteLine(housePrice);
            }

            var lowerLayerSupportOutputAreaCodesToWardCodes = _lowerLayerSupportOutputAreaCodeToWardCodeParser.KeyValueParse();
            foreach (var kv in lowerLayerSupportOutputAreaCodesToWardCodes)
            {
                //Console.WriteLine(kv);
            }
        }
    }
}