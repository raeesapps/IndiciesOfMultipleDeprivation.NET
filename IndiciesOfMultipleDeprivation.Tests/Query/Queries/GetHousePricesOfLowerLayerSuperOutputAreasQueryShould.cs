using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Query.Queries;
using NUnit.Framework;

namespace IndiciesOfMultipleDeprivation.Tests.Query.Queries
{
    public class GetHousePricesOfLowerLayerSuperOutputAreasQueryShould
    {
        private readonly IGetHousePricesOfLowerLayerSuperOutputAreasQuery _getHousePricesOfLowerLayerSuperOutputAreasQuery;

        public GetHousePricesOfLowerLayerSuperOutputAreasQueryShould()
        {
            _getHousePricesOfLowerLayerSuperOutputAreasQuery = new GetHousePricesOfLowerLayerSuperOutputAreasQuery();
        }

        [Test]
        public void ComputedEnumerableIsCorrect()
        {
            var lsoa1 = new LowerLayerSuperOutputArea
            {
                Code = "L1",
            };
            var lsoa2 = new LowerLayerSuperOutputArea
            {
                Code = "L2",
            };
            var lsoa3 = new LowerLayerSuperOutputArea
            {
                Code = "L3",
            };

            var ward1 = new Ward
            {
                Code = "W1",
            };
            var ward2 = new Ward
            {
                Code = "W2",
            };
            var ward3 = new Ward
            {
                Code = "W3",
            };


            var housePrice1 = new HousePrice
            {
                Ward = ward1,
            };
            var housePrice2 = new HousePrice
            {
                Ward = ward2,
            };
            var housePrice3 = new HousePrice
            {
                Ward = ward3,
            };

            var input = new List<LowerLayerSuperOutputArea> { lsoa2, lsoa3 };
            var dataset = new Dataset
            {
                LowerLayerSuperOutputAreaCodeToWardCode = new Dictionary<string, string>
                {
                    { lsoa1.Code, ward1.Code },
                    { lsoa2.Code, ward2.Code },
                    { lsoa3.Code, ward3.Code },
                },
                HousePrices = new List<HousePrice> { housePrice1, housePrice2, housePrice3 },
            };

            var expectedResult = new List<HousePrice> { housePrice2, housePrice3 };

            var actualResult = _getHousePricesOfLowerLayerSuperOutputAreasQuery
                .Compute(input, dataset)
                .Cast<HousePrice>()
                .ToList();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
