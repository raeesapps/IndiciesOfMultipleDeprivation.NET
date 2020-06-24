using IndiciesOfMultipleDeprivation.Model;

namespace IndiciesOfMultipleDeprivation
{
    public interface IDatasetProvider
    {
        public Dataset Dataset { get; }
    }
}