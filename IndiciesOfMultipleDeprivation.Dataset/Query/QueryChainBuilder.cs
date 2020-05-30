using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Queries
{
    public class QueryChainBuilder : IQueryChainBuilder
    {
        public IList<IQuery> Queries { get; set; }
        
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