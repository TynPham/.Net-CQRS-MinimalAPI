namespace CQRS_MinimalAPI.Base;

public abstract class BaseInfoList<T> where T : class
{
    public IReadOnlyList<T> Data { get; protected set; } = [];
    public IDictionary<string, object> Info { get; } = new Dictionary<string, object>();

    public void AddInfo(string key, object value) => Info[key] = value;
}