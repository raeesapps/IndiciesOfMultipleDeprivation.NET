using System.Collections.Generic;
using WhereAreTheAffordableGoodAreas.Models;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public class LowerLayerSuperOutputAreaParser : CsvParser<LowerLayerSuperOutputArea>
    {
        protected override void OnReadFields(IList<LowerLayerSuperOutputArea> ts, string[] fields)
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
                    
            ts.Add(lowerLayerSuperOutputArea);
        }

        public LowerLayerSuperOutputAreaParser(string path) : base(path)
        {
        }
    }
}
