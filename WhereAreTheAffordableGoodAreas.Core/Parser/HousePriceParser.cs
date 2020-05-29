using System;
using System.Collections.Generic;
using WhereAreTheAffordableGoodAreas.Models;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public class HousePriceParser : CsvParser<HousePrice, object>
    {
        public HousePriceParser(string path) : base(path)
        {
        }

        protected override void OnReadFields(IList<HousePrice> ks, string[] fields)
        {
            var localAuthorityDistrictCode = fields[0];
            var localAuthorityDistrictName = fields[1];
            var localAuthorityDistrict = new LocalAuthorityDistrict
            {
                Code = localAuthorityDistrictCode,
                Name = localAuthorityDistrictName,
            };

            var wardCode = fields[2];
            var wardName = fields[3];
            var ward = new Ward
            {
                Code = wardCode,
                Name = wardName,
            };

            var priceEndingSept2019 = fields[99];

            if (priceEndingSept2019 == ":")
            {
                return;
            }

            var housePrice = new HousePrice
            {
                LocalAuthorityDistrict = localAuthorityDistrict,
                Ward = ward,
                AverageHousePrice = double.Parse(priceEndingSept2019.Replace(",", "")),
            };

            ks.Add(housePrice);
        }

        protected override void OnReadFields(IDictionary<HousePrice, object> kvs, string[] fields)
        {
            throw new System.NotImplementedException();
        }
    }
}