using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Query.Queries;
using NUnit.Framework;

namespace IndiciesOfMultipleDeprivation.Tests.Query.Queries
{
    public class SortHousePricesByAverageHousePricesQueryShould
    {
        private readonly ISortHousePricesByAverageHousePricesQuery _sortHousePricesByAverageHousePricesQuery;

        public SortHousePricesByAverageHousePricesQueryShould()
        {
            _sortHousePricesByAverageHousePricesQuery = new SortHousePricesByAverageHousePricesQuery();
        }

        [Test]
        public void ComputedEnumerableIsCorrect()
        {
            var housePrice1 = new HousePrice
            {
                AverageHousePrice = 100.00,
            };
            var housePrice2 = new HousePrice
            {
                AverageHousePrice = 200.00,
            };
            var housePrice3 = new HousePrice
            {
                AverageHousePrice = 300.00,
            };
            var housePrice4 = new HousePrice
            {
                AverageHousePrice = 400.00,
            };

            var housePrices = new List<HousePrice> { housePrice2, housePrice4, housePrice1, housePrice3 };

            var expectedResult = new List<HousePrice> { housePrice1, housePrice2, housePrice3, housePrice4 };

            var result = _sortHousePricesByAverageHousePricesQuery
                .Compute(housePrices, null)
                .Cast<HousePrice>()
                .ToList();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
