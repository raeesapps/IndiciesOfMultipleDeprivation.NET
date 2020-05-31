using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Query
{
    public class QueryChain : IQueryChain
    {
        public IList<IQuery> Queries { get; set; }

        public QueryChain(IList<IQuery> queries)
        {
            Queries = queries;
        }
        
        public IEnumerable<object> Execute(IEnumerable<object> input, Dataset dataset)
        {
            IEnumerable<object> previousResult = null;
            foreach (var query in Queries)
            {
                var queryResult = query.Compute(previousResult, dataset);
                previousResult = queryResult;
            }

            return previousResult;
        }
    }
}