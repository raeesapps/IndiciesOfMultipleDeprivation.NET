using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace WhereAreTheAffordableGoodAreas.Dataset
{
    public abstract class CsvParser<T> : IParser<T>
    {
        private readonly string _path;

        public CsvParser(string path)
        {
            _path = path;
        }
        
        public IEnumerable<T> Parse()
        {
            var ts = new List<T>();
            
            using var csvParser = new TextFieldParser(_path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                var fields = csvParser.ReadFields();
                OnReadFields(ts, fields);
            }

            return ts;
        }

        protected abstract void OnReadFields(IList<T> ts, string[] fields);
    }
}