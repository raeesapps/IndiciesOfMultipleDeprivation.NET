using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Query.Queries;
using NUnit.Framework;

namespace IndiciesOfMultipleDeprivation.Tests.Query.Queries
{
    public class FilterLowerLayerSuperOutputAreasByDecileQueryShould
    {
        private readonly IFilterLowerLayerSuperOutputAreasByDecileQuery _filterLowerLayerSuperOutputAreasByDecileQuery;

        public FilterLowerLayerSuperOutputAreasByDecileQueryShould()
        {
            _filterLowerLayerSuperOutputAreasByDecileQuery = new FilterLowerLayerSuperOutputAreasByDecileQuery();
        }

        [Test]
        public void ComputedEnumerableIsCorrect()
        {
            var lsoa1 = new LowerLayerSuperOutputArea
            {
                IndexOfMultipleDeprivation = new IndexOfMultipleDeprivation
                {
                    Decile = 1,
                    Rank = 23,
                },
                LocalAuthorityDistrict = new LocalAuthorityDistrict
                {
                    Code = "1",
                    Name = "L1",
                },
            };
            var lsoa2 = new LowerLayerSuperOutputArea
            {
                IndexOfMultipleDeprivation = new IndexOfMultipleDeprivation
                {
                    Decile = 6,
                    Rank = 230,
                },
                LocalAuthorityDistrict = new LocalAuthorityDistrict
                {
                    Code = "2",
                    Name = "L2",
                },
            };
            var lsoa3 = new LowerLayerSuperOutputArea
            {
                IndexOfMultipleDeprivation = new IndexOfMultipleDeprivation
                {
                    Decile = 8,
                    Rank = 330,
                },
                LocalAuthorityDistrict = new LocalAuthorityDistrict
                {
                    Code = "3",
                    Name = "L3",
                },
            };
            var dataset = new Dataset
            {
                LowerLayerSuperOutputAreas = new List<LowerLayerSuperOutputArea>{ lsoa1, lsoa2, lsoa3 },
            };

            var result = _filterLowerLayerSuperOutputAreasByDecileQuery
                .Compute(null, dataset)
                .Cast<LowerLayerSuperOutputArea>()
                .ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(lsoa3, result[0]);
        }
    }
}
