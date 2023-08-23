namespace HelloWorld.Services;

public interface IKeyValueStorage
{
    string Get(string key, string defaultValue);

    void Set(string key, string value);
}


public sealed class KeyValueStorage : IKeyValueStorage
{

    // 实现.NET CORE分布式缓存







    public string Get(string key, string defaultValue)
    {
        return Preferences.Get(key, defaultValue);
    }

    public void Set(string key, string value)
    {
        Preferences.Set(key, value);
    }
}