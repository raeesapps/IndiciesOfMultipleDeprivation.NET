using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Parser
{
    public interface IKeyValueParser<K, V>
    {
        public IDictionary<K, V> KeyValueParse();
    }
}