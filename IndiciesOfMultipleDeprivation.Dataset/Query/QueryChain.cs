using System;
using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Queries
{
    public class QueryChain : IQueryChain
    {
        private readonly IEnumerable<IQuery> _queries;

        public QueryChain(IQueryChainBuilder builder)
        {
            _queries = builder.Queries;
        }
        
        public void Execute(IEnumerable<object> input, Dataset dataset)
        {
            IEnumerable<object> previousResult = null;
            foreach (var query in _queries)
            {
                var queryResult = query.Compute(previousResult, dataset);
                previousResult = queryResult;
            }
        }
    }
}