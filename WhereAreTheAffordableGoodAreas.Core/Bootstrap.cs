using System.Collections.Generic;
using WhereAreTheAffordableGoodAreas.Models;
using WhereAreTheAffordableGoodAreas.Parser;

namespace WhereAreTheAffordableGoodAreas
{
    public class Bootstrap
    {
        private readonly LowerLayerSuperOutputAreaParser _lowerLayerSuperOutputAreaParser;
        private readonly IEnumerable<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreas;

        public Bootstrap(string path)
        {
            _lowerLayerSuperOutputAreas = new List<LowerLayerSuperOutputArea>();
            _lowerLayerSuperOutputAreaParser = new LowerLayerSuperOutputAreaParser(path, _lowerLayerSuperOutputAreas);
        }

        public void Start()
        {
            _lowerLayerSuperOutputAreaParser.Parse();
            
            foreach (var lowerLayerSuperOutputArea in _lowerLayerSuperOutputAreas)
            {
                //Console.WriteLine(lowerLayerSuperOutputArea);
            }
        }
    }
}