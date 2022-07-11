namespace MediatrAndFluentValidationSample.Interfaces;

public interface ICacheService
{
    void SaveCache<T>(string key, T data);
    void SaveCache<T>(string key, T data, double ttl);
    bool GetCache<T>(string key, out T rtn) where T : new();
    bool KeyExists(string key);
}