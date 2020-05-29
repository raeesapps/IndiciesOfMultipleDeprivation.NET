using System.Collections.Generic;
using WhereAreTheAffordableGoodAreas.Models;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public class LowerLayerSuperOutputAreaParser : CsvParser<LowerLayerSuperOutputArea>
    {
        protected override void OnReadFields(string[] fields)
        {
            var lowerLayerSuperOutputAreaCode = fields[0];
            var lowerLayerSuperOutputAreaName = fields[1];

            var localAuthorityDistrictCode = fields[2];
            var localAuthorityDistrictName = fields[3];
            var localAuthorityDistrict = new LocalAuthorityDistrict
            {
                Code = localAuthorityDistrictCode,
                Name = localAuthorityDistrictName
            };

            var indexOfMultipleDeprivationRank = fields[4];
            var indexOfMultipleDeprivationDecile = fields[5];
            var indexOfMultipleDeprivation = new IndexOfMultipleDeprivation
            {
                Rank = indexOfMultipleDeprivationRank,
                Decile = indexOfMultipleDeprivationDecile,
            };

            var lowerLayerSuperOutputArea = new LowerLayerSuperOutputArea
            {
                Code = lowerLayerSuperOutputAreaCode,
                Name = lowerLayerSuperOutputAreaName,
                LocalAuthorityDistrict = localAuthorityDistrict,
                IndexOfMultipleDeprivation = indexOfMultipleDeprivation,
            };

            if (_ts is List<LowerLayerSuperOutputArea> tsAsList)
            {
                tsAsList.Add(lowerLayerSuperOutputArea);
            }
        }

        public LowerLayerSuperOutputAreaParser(string path, IEnumerable<LowerLayerSuperOutputArea> lowerLayerSuperOutputAreas) : base(path, lowerLayerSuperOutputAreas)
        {
        }
    }
}
