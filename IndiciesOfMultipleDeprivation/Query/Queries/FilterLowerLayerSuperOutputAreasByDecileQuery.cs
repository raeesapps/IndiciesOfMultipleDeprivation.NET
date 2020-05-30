using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Query.Queries
{
    public class FilterLowerLayerSuperOutputAreasByDecileQuery : IQuery
    {
        public IEnumerable<object> Compute(IEnumerable<object> input, Dataset dataset)
        {
            var filteredLowerLayerSuperOutputAreas =
                dataset.LowerLayerSuperOutputAreas.Where((lowerLayerSuperOutputArea) =>
                    lowerLayerSuperOutputArea.IndexOfMultipleDeprivation.Decile >= 7 && lowerLayerSuperOutputArea.IndexOfMultipleDeprivation.Decile <= 10);

            return filteredLowerLayerSuperOutputAreas;
        }
    }
}