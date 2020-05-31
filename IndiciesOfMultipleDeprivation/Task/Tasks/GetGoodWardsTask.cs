using System;
using System.Linq;
using IndiciesOfMultipleDeprivation.Models;
using IndiciesOfMultipleDeprivation.Query;
using IndiciesOfMultipleDeprivation.Query.Queries;

namespace IndiciesOfMultipleDeprivation.Task.Tasks
{
    public class GetGoodAreasTask : ITask
    {
        private readonly IQueryChainBuilder _queryChainBuilder;
        
        private readonly IFilterLowerLayerSuperOutputAreasByDecileQuery _filterLowerLayerSuperOutputAreasByDecileQuery;
        
        private readonly IGetHousePricesOfLowerLayerSuperOutputAreasQuery
            _getHousePricesOfLowerLayerSuperOutputAreasQuery;

        private readonly ISortHousePricesByAverageHousePricesQuery _sortHousePricesByAverageHousePricesQuery;

        public GetGoodAreasTask(IQueryChainBuilder queryChainBuilder,
            IFilterLowerLayerSuperOutputAreasByDecileQuery filterLowerLayerSuperOutputAreasByDecileQuery,
            IGetHousePricesOfLowerLayerSuperOutputAreasQuery getHousePricesOfLowerLayerSuperOutputAreasQuery,
            ISortHousePricesByAverageHousePricesQuery sortHousePricesByAverageHousePricesQuery)
        {
            _queryChainBuilder = queryChainBuilder;
            _filterLowerLayerSuperOutputAreasByDecileQuery = filterLowerLayerSuperOutputAreasByDecileQuery;
            _getHousePricesOfLowerLayerSuperOutputAreasQuery = getHousePricesOfLowerLayerSuperOutputAreasQuery;
            _sortHousePricesByAverageHousePricesQuery = sortHousePricesByAverageHousePricesQuery;
        }

        public void Run(Dataset dataset)
        {
            var result =
                _queryChainBuilder
                    .Add(_filterLowerLayerSuperOutputAreasByDecileQuery)
                    .Add(_getHousePricesOfLowerLayerSuperOutputAreasQuery)
                    .Add(_sortHousePricesByAverageHousePricesQuery)
                    .Build()
                    .Execute(null, dataset)
                    .ToList();

            var n = result.Count;

            for (var i = 0; i < Math.Min(100, n); i++)
            {
                var entry = result[i];
                Console.WriteLine(entry);
            }
        }
    }
}