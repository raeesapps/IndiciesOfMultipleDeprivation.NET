using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public abstract class CsvParser<T> : IParser<T>
    {
        private readonly string _path;
        protected readonly IEnumerable<T> _ts;

        public CsvParser(string path, IEnumerable<T> ts)
        {
            _path = path;
            _ts = ts;
        }
        
        public void Parse()
        {
            using var csvParser = new TextFieldParser(_path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                var fields = csvParser.ReadFields();
                OnReadFields(fields);
            }
        }

        protected abstract void OnReadFields(string[] fields);
    }
}