using System;
using WhereAreTheAffordableGoodAreas.Models;
using WhereAreTheAffordableGoodAreas.Parser;

namespace WhereAreTheAffordableGoodAreas
{
    public class Bootstrap
    {
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSupportOutputAreaToWardParser;

        public Bootstrap(string lowerLayerSuperOutputAreaPath, string lowerLayerSuperOutputAreaToWardPath)
        {
            _lowerLayerSuperOutputAreaParser = new LowerLayerSuperOutputAreaParser(lowerLayerSuperOutputAreaPath);
            _lowerLayerSupportOutputAreaToWardParser = new LowerLayerSuperOutputAreaToWardParser(lowerLayerSuperOutputAreaToWardPath);
        }

        public void Start()
        {
            var lowerLayerSuperOutputAreas = _lowerLayerSuperOutputAreaParser.Parse();
            foreach (var lowerLayerSuperOutputArea in lowerLayerSuperOutputAreas)
            {
                //Console.WriteLine(lowerLayerSuperOutputArea);
            }

            var lowerLayerSupportOutputAreasToWards = _lowerLayerSupportOutputAreaToWardParser.KeyValueParse();
            foreach (var kv in lowerLayerSupportOutputAreasToWards)
            {
                Console.WriteLine(kv);
            }
        }
    }
}