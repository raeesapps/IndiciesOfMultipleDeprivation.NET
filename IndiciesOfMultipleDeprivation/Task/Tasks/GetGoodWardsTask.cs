using System;
using System.Linq;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Query;
using IndiciesOfMultipleDeprivation.Query.Queries;

namespace IndiciesOfMultipleDeprivation.Task.Tasks
{
    public class GetGoodAreasTask : ITask
    {
        private readonly IQueryChain _queryChain;
        
        private readonly IFilterLowerLayerSuperOutputAreasByDecileQuery _filterLowerLayerSuperOutputAreasByDecileQuery;
        
        private readonly IGetHousePricesOfLowerLayerSuperOutputAreasQuery
            _getHousePricesOfLowerLayerSuperOutputAreasQuery;

        private readonly ISortHousePricesByAverageHousePricesQuery _sortHousePricesByAverageHousePricesQuery;

        public GetGoodAreasTask(IQueryChain queryChain,
            IFilterLowerLayerSuperOutputAreasByDecileQuery filterLowerLayerSuperOutputAreasByDecileQuery,
            IGetHousePricesOfLowerLayerSuperOutputAreasQuery getHousePricesOfLowerLayerSuperOutputAreasQuery,
            ISortHousePricesByAverageHousePricesQuery sortHousePricesByAverageHousePricesQuery)
        {
            _queryChain = queryChain;
            _filterLowerLayerSuperOutputAreasByDecileQuery = filterLowerLayerSuperOutputAreasByDecileQuery;
            _getHousePricesOfLowerLayerSuperOutputAreasQuery = getHousePricesOfLowerLayerSuperOutputAreasQuery;
            _sortHousePricesByAverageHousePricesQuery = sortHousePricesByAverageHousePricesQuery;
        }

        public void Run(Dataset dataset)
        {
            _queryChain.Queries.Add(_filterLowerLayerSuperOutputAreasByDecileQuery);
            _queryChain.Queries.Add(_getHousePricesOfLowerLayerSuperOutputAreasQuery);
            _queryChain.Queries.Add(_sortHousePricesByAverageHousePricesQuery);

            var result =
                _queryChain
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