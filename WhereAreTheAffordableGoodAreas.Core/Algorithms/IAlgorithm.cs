using System.Collections.Generic;
using WhereAreTheAffordableGoodAreas.Models;

namespace WhereAreTheAffordableGoodAreas.Algorithms
{
    public interface IAlgorithm
    {
        public void Execute(IList<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreas,
            IDictionary<string, string> lowerLayerSuperOutputAreaCodeToWardCode, IList<HousePrice> housePrices);
    }
}