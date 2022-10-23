using System;
using System.Text;

namespace Patterns.Builder
{
    void Main()
    {
        QueryBuilder builder = new QueryBuilder();
        ConstructionProcess(builder);
        builder.Build().Dump();
    }

    public void ConstructionProcess(IKeyValueCollectionBuilder builder)
    {
        builder.Add("page", "1")
            .Add("size", "50")
            .Add("year", 2015.ToString());
    }

    public interface IKeyValueCollectionBuilder
    {
        IKeyValueCollectionBuilder Add(string key, string value);
    }

    public class QueryBuilder : IKeyValueCollectionBuilder
    {
        private StringBuilder _queryStringBuilder = new StringBuilder();

        public IKeyValueCollectionBuilder Add(string key, string value)
        {
            _queryStringBuilder.Append(_queryStringBuilder.Length == 0 ? "?" : "&");
            _queryStringBuilder.Append(key);
            _queryStringBuilder.Append("=");
            _queryStringBuilder.Append(Uri.EscapeDataString(value));
            return this;
        }

        public string Build()
        {
            return _queryStringBuilder.ToString();
        }
    }
}
