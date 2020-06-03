using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Parser;
using NSubstitute;
using NUnit.Framework;

namespace IndiciesOfMultipleDeprivation.Tests.Parser
{
    public class HousePriceParserShould
    {
        private readonly ITextFieldParser _textFieldParser;
        private readonly ILinearParser<HousePrice> _housePriceParser;

        public HousePriceParserShould()
        {
            _textFieldParser = Substitute.For<ITextFieldParser>();
            _housePriceParser = new HousePriceParser(_textFieldParser);
        }

        [Test]
        public void ParseHousePriceCsvRowMatchesExpectedHousePriceDao()
        {
            var housePriceFields =
                "E06000001,Hartlepool,E05008943,De Bruce,38000,38000,37000,30500,30000,30500,29500,31500,37000,39950,40000,42000,32000,32000,34750,35750,35750,35000,32450,34975,36650,43500,53372.5,52875,54995,57500,50497.5,48997.5,49475,48750,58187,62995,62995,60000,58475,57500,57500,59500,62575,72000,79000,79000,83000,86500,86000,90000,92500,97500,100000,112000,119500,108000,96500,92500,90000,85000,98000,98000,99997.5,99997.5,90000,98942.5,90000,81250,79975,76000,72412.5,68000,80000,85000,100000,90000,83000,75000,72500,82000,81000,82250,81000,78000,80000,80000,87000,100975,107225,115000,118250,124950,130000,126500,127975,124950,121375,128000,135000,131475,,,,,"
                    .Split(",");
            var expectedHousePrice = new HousePrice
            {
                AverageHousePrice = 131475,
                LocalAuthorityDistrict = new LocalAuthorityDistrict
                {
                    Code = "E06000001",
                    Name = "Hartlepool"
                },
                Ward = new Ward
                {
                    Code = "E05008943",
                    Name = "De Bruce"
                }
            };
            var expectedList = new List<HousePrice> {expectedHousePrice};
            _textFieldParser.ReadFields().Returns(housePriceFields)
                .AndDoes((action) => _textFieldParser.EndOfData.Returns(true));

            var actualList = _housePriceParser.Parse();
            
            Assert.AreEqual(expectedList, actualList);
        }
    }
}