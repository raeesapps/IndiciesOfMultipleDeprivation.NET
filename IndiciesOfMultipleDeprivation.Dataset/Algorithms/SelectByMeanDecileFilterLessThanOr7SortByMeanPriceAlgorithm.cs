using System;
using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Algorithms
{
    public class SelectByMeanDecileFilterLessThanOr7SortByMeanPriceAlgorithm : IAlgorithm
    {
        public void Execute(IList<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreas, IDictionary<string, string> lowerLayerSuperOutputAreaCodeToWardCode, IList<HousePrice> housePrices)
        {
            var lowerLayerSuperOutputAreasByLocalAuthorityDistrict = new Dictionary<LocalAuthorityDistrict, IList<LowerLayerSuperOutputArea>>();

            foreach (var lowerLayerSuperOutputArea in lowerLayerSuperOutputAreas)
            {
                if (lowerLayerSuperOutputAreasByLocalAuthorityDistrict.ContainsKey(lowerLayerSuperOutputArea
                    .LocalAuthorityDistrict))
                {
                    if (lowerLayerSuperOutputAreasByLocalAuthorityDistrict.TryGetValue(lowerLayerSuperOutputArea
                        .LocalAuthorityDistrict, out var lowerLayerSuperOutputAreasInLocalAuthorityDistrict))
                    {
                        lowerLayerSuperOutputAreasInLocalAuthorityDistrict.Add(lowerLayerSuperOutputArea);
                    }
                }
                else
                {
                    lowerLayerSuperOutputAreasByLocalAuthorityDistrict.Add(lowerLayerSuperOutputArea.LocalAuthorityDistrict, new List<LowerLayerSuperOutputArea>());
                }
            }
            
            var meanDecileAndMeanHousePriceOfLocalAuthorityDistrict = new Dictionary<LocalAuthorityDistrict, (double, double)>();
            foreach (var pair in lowerLayerSuperOutputAreasByLocalAuthorityDistrict)
            {
                var n = pair.Value.Count();

                if (n == 0)
                {
                    continue;
                }
                
                var sumOfAllLowerLayerSuperOutputAreaDeciles =
                    pair.Value.Select((lowerLayerSuperOutputArea) =>
                    lowerLayerSuperOutputArea.IndexOfMultipleDeprivation.Decile).Sum();

                var meanOfAllLowerLayerSuperOutputAreaDeciles =
                    ((double) sumOfAllLowerLayerSuperOutputAreaDeciles) / n;
                
                if (meanOfAllLowerLayerSuperOutputAreaDeciles < 7)
                {
                    continue;
                }
                
                var sumOfAverageHousePrices = 0.0;
                foreach (var lowerLayerSuperOutputArea in pair.Value)
                {
                    if (lowerLayerSuperOutputAreaCodeToWardCode.TryGetValue(lowerLayerSuperOutputArea.Code,
                        out var wardCode))
                    {
                        var housePrice = housePrices.FirstOrDefault((hp) => hp.Ward.Code == wardCode);

                        if (housePrice != null)
                        {
                            sumOfAverageHousePrices += housePrice.AverageHousePrice;
                        }
                    }
                }

                var tuple = (meanOfAllLowerLayerSuperOutputAreaDeciles, sumOfAverageHousePrices / n);
                meanDecileAndMeanHousePriceOfLocalAuthorityDistrict.Add(pair.Key, tuple);
            }

            var orderedByMeanHousePrice 
                = meanDecileAndMeanHousePriceOfLocalAuthorityDistrict.OrderBy((kv) =>
            {
                var (_, meanHousePrice) = kv.Value;
                return meanHousePrice;
            });

            var idx = 0;
            foreach (var kv in orderedByMeanHousePrice)
            {
                if (idx >= 100)
                {
                    continue;
                }
                
                Console.WriteLine(kv.Key);

                var (meanDecile, meanHousePrice) = kv.Value;
                Console.WriteLine("Mean house price " + meanHousePrice);
                Console.WriteLine("Mean decile " + meanDecile);

                idx++;
            }
        }
    }
}