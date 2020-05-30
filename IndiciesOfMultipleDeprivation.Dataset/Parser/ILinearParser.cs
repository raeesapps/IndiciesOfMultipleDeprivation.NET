using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Parser
{
    public interface ILinearParser<T>
    {
        public IList<T> Parse();
    }
}
