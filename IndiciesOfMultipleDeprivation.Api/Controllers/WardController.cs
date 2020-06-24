using System.Collections.Generic;
using System.Linq;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Query;
using IndiciesOfMultipleDeprivation.Query.Queries;
using Microsoft.AspNetCore.Mvc;

namespace IndiciesOfMultipleDeprivation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WardController : ControllerBase
    {
        private readonly IDatasetProvider _datasetProvider;
        private readonly IQueryChain _queryChain;
        private readonly IFilterLowerLayerSuperOutputAreasByDecileQuery _filterLowerLayerSuperOutputAreasByDecileQuery;
        private readonly IGetHousePricesOfLowerLayerSuperOutputAreasQuery _getHousePricesOfLowerLayerSuperOutputAreasQuery;
        private readonly ISortHousePricesByAverageHousePricesQuery _sortHousePricesByAverageHousePricesQuery;

        public WardController(IDatasetProvider datasetProvider,
            IQueryChain queryChain,
            IFilterLowerLayerSuperOutputAreasByDecileQuery filterLowerLayerSuperOutputAreasByDecileQuery,
            IGetHousePricesOfLowerLayerSuperOutputAreasQuery getHousePricesOfLowerLayerSuperOutputAreasQuery,
            ISortHousePricesByAverageHousePricesQuery sortHousePricesByAverageHousePricesQuery)
        {
            _datasetProvider = datasetProvider;
            _queryChain = queryChain;
            _filterLowerLayerSuperOutputAreasByDecileQuery = filterLowerLayerSuperOutputAreasByDecileQuery;
            _getHousePricesOfLowerLayerSuperOutputAreasQuery = getHousePricesOfLowerLayerSuperOutputAreasQuery;
            _sortHousePricesByAverageHousePricesQuery = sortHousePricesByAverageHousePricesQuery;
        }

        [HttpGet]
        public IEnumerable<HousePrice> Get()
        {
            _queryChain.Queries.Add(_filterLowerLayerSuperOutputAreasByDecileQuery);
            _queryChain.Queries.Add(_getHousePricesOfLowerLayerSuperOutputAreasQuery);
            _queryChain.Queries.Add(_sortHousePricesByAverageHousePricesQuery);

            var result =
                _queryChain
                    .Execute(null, _datasetProvider.Dataset)
                    .Cast<HousePrice>()
                    .ToList();

            return result;
        }
    }
}
