using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class Dataset
    {
        public IList<LowerLayerSuperOutputArea> LowerLayerSuperOutputAreas { get; set; }
        public IDictionary<string, string> LowerLayerSuperOutputAreaCodeToWardCode { get; set; }
        public IList<HousePrice> HousePrices { get; set; }
    }
}