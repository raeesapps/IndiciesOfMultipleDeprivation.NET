using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Parser;
using IndiciesOfMultipleDeprivation.Task;

namespace IndiciesOfMultipleDeprivation
{
    public class Bootstrap : IBootstrap
    {
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;
        private readonly ILinearParser<HousePrice> _housePriceParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSupportOutputAreaCodeToWardCodeParser;
        private readonly IEnumerable<ITask> _tasks;

        public Bootstrap(ILinearParser<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreaParser,
            ILinearParser<HousePrice> housePriceParser,
            IKeyValueParser<string, string> lowerLayerSupportOutputAreaCodeToWardCodeParser,
            IEnumerable<ITask> tasks)
        {
            _lowerLayerSuperOutputAreaParser = lowerLayerSuperOutputAreaParser;
            _housePriceParser = housePriceParser;
            _lowerLayerSupportOutputAreaCodeToWardCodeParser = lowerLayerSupportOutputAreaCodeToWardCodeParser;
            _tasks = tasks;
        }

        public void Start()
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
            
            foreach (var task in _tasks)
            {
                task.Run(dataset);
            }
        }
    }
}