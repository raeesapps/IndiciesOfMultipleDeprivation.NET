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

        public GetGoodAreasTask(IQueryChainBuilder queryChainBuilder)
        {
            _queryChainBuilder = queryChainBuilder;
        }
        
        public void Run(Dataset dataset)
        {
            var result =
                _queryChainBuilder
                    .Add(new FilterLowerLayerSuperOutputAreasByDecileQuery())
                    .Add(new GetHousePricesOfLowerLayerSuperOutputAreasQuery())
                    .Add(new SortHousePricesByAverageHousePricesQuery())
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