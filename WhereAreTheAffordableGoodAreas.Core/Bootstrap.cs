using System;
using WhereAreTheAffordableGoodAreas.Parser;

namespace WhereAreTheAffordableGoodAreas
{
    public class Bootstrap
    {
        private readonly LowerLayerSuperOutputAreaParser _lowerLayerSuperOutputAreaParser;

        public Bootstrap(string path)
        {
            _lowerLayerSuperOutputAreaParser = new LowerLayerSuperOutputAreaParser(path);
        }

        public void Start()
        {
            var lowerLayerSuperOutputAreas = _lowerLayerSuperOutputAreaParser.Parse();
            
            foreach (var lowerLayerSuperOutputArea in lowerLayerSuperOutputAreas)
            {
                //Console.WriteLine(lowerLayerSuperOutputArea);
            }
        }
    }
}