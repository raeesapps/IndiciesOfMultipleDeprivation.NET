using System;
using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Query.Queries
{
    public class SortHousePricesByAverageHousePricesQuery : ISortHousePricesByAverageHousePricesQuery
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

            if (!input.All((x) => x is HousePrice))
            {
                throw new ArgumentException(InputConsistsOfObjectOfTheWrongTypeError);
            }

            var housePrices = input.Cast<HousePrice>();
            
            return housePrices.OrderBy((housePrice) => housePrice.AverageHousePrice);
        }
    }
}