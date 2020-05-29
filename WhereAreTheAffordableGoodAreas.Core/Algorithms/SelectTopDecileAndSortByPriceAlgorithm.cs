using System;
using System.Collections.Generic;
using System.Linq;
using WhereAreTheAffordableGoodAreas.Models;

namespace WhereAreTheAffordableGoodAreas.Algorithms
{
    public class SelectTopDecileAndSortByPriceAlgorithm : IAlgorithm
    {
        public void Execute(IList<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreas, IDictionary<string, string> lowerLayerSuperOutputAreaCodeToWardCode, IList<HousePrice> housePrices)
        {
            var filteredLowerLayerSuperOutputAreas =
                lowerLayerSuperOutputAreas.Where((lowerLayerSuperOutputArea) =>
                lowerLayerSuperOutputArea.IndexOfMultipleDeprivation.Decile == 10);

            var housePricesOfDecileOneAreas = new List<HousePrice>();
            foreach (var lowerLayerSuperOutputArea in filteredLowerLayerSuperOutputAreas)
            {
                if (lowerLayerSuperOutputAreaCodeToWardCode.TryGetValue(lowerLayerSuperOutputArea.Code, out var wardCode))
                {
                    var housePrice =
                        housePrices.FirstOrDefault((hp) => hp.Ward.Code == wardCode);

                    if (housePrice != null)
                    {
                        housePricesOfDecileOneAreas.Add(housePrice);
                    }
                }
            }

            var sortedHousePricesOfDecileOneAreas =
                housePricesOfDecileOneAreas.OrderBy((housePrice) => housePrice.AverageHousePrice);

            var idx = 0;
            foreach (var housePrice in sortedHousePricesOfDecileOneAreas)
            {
                if (idx > 100)
                {
                    break;
                }
                Console.WriteLine(housePrice);
                idx++;
            }
        }
    }
}