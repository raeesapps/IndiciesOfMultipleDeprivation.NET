using System.Collections.Generic;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public interface IKeyValueParser<K, V>
    {
        public IDictionary<K, V> KeyValueParse();
    }
}