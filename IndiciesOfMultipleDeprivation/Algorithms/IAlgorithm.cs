using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Model;

namespace IndiciesOfMultipleDeprivation.Algorithms
{
    public interface IAlgorithm
    {
        public void Execute(IList<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreas,
            IDictionary<string, string> lowerLayerSuperOutputAreaCodeToWardCode, IList<HousePrice> housePrices);
    }
}