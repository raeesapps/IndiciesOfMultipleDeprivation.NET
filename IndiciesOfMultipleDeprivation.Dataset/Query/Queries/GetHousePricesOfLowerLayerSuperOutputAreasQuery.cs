using System;
using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Query.Queries
{
    public class GetHousePricesOfLowerLayerSuperOutputAreasQuery : IQuery
    {
        private const string InputNotProvidedExceptionMessage = "No input enumerable provided!";

        private const string InputConsistsOfObjectOfTheWrongTypeError =
            "The input consists of objects of the wrong type";
        
        public IEnumerable<object> Compute(IEnumerable<object> input, Dataset dataset)
        {
            if (input == null)
            {
                throw new ArgumentException(InputNotProvidedExceptionMessage);
            }

            if (!input.All((x) => x is LowerLayerSuperOutputArea))
            {
                throw new ArgumentException(InputConsistsOfObjectOfTheWrongTypeError);
            }

            var lowerLayerSuperOutputAreas = input.Cast<LowerLayerSuperOutputArea>();
            
            foreach (var lowerLayerSuperOutputArea in lowerLayerSuperOutputAreas)
            {
                if (dataset.LowerLayerSuperOutputAreaCodeToWardCode.TryGetValue(lowerLayerSuperOutputArea.Code, out var wardCode))
                {
                    var housePrice =
                        dataset.HousePrices.FirstOrDefault((hp) => hp.Ward.Code == wardCode);

                    if (housePrice != null)
                    {
                        yield return housePrice;
                    }
                }
            }
        }
    }
}