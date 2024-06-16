using System.Collections;

namespace EverythingCli.API;

public class ResultSet(string query) : IEnumerable<ResultItem>
{
    private readonly List<ResultItem> _results = [];

    public string Query { get;  } = query;
    public int Count => _results.Count;
    public void Add(ResultItem resultItemItem) => _results.Add(resultItemItem);
    public IEnumerator<ResultItem> GetEnumerator() => _results.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}