using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Queries.SubQueries
{
    public class FilterLowerLayerSuperOutputAreasByDecileQuery : IQuery
    {
        public IEnumerable<object> Compute(IEnumerable<object> previousQueryResult, Dataset dataset)
        {
            var filteredLowerLayerSuperOutputAreas =
                dataset.LowerLayerSuperOutputAreas.Where((lowerLayerSuperOutputArea) =>
                    lowerLayerSuperOutputArea.IndexOfMultipleDeprivation.Decile == 10);

            return filteredLowerLayerSuperOutputAreas;
        }
    }
}