using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public abstract class CsvParser<K, V> : ILinearParser<K>, IKeyValueParser<K, V>
    {
        private readonly string _path;

        public CsvParser(string path)
        {
            _path = path;
        }

        private void ReadCsvPath(IList<K> list, IDictionary<K, V> dictionary)
        {
            using var csvParser = new TextFieldParser(_path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                var fields = csvParser.ReadFields();

                if (list == null && dictionary != null)
                {
                    OnReadFields(dictionary, fields);
                } 
                else if (dictionary == null && list != null)
                {
                    OnReadFields(list, fields);
                }
            }
        }
        
        public IList<K> Parse()
        {
            var ks = new List<K>();
            ReadCsvPath(ks, null);
            return ks;
        }

        public IDictionary<K, V> KeyValueParse()
        {
            var kvs = new Dictionary<K, V>();
            ReadCsvPath(null, kvs);
            return kvs;
        }

        protected abstract void OnReadFields(IList<K> ks, string[] fields);
        protected abstract void OnReadFields(IDictionary<K, V> kvs, string[] fields);
    }
}