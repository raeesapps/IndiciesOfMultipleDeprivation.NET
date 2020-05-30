using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Query
{
    public class QueryChainBuilder : IQueryChainBuilder
    {
        public IList<IQuery> Queries { get; set; }

        public QueryChainBuilder(IList<IQuery> queries)
        {
            Queries = queries;
        }
        
        public IQueryChain Build()
        {
            return new QueryChain(this);
        }

        public IQueryChainBuilder Add(IQuery query)
        {
            Queries.Add(query);
            return this;
        }
    }
}