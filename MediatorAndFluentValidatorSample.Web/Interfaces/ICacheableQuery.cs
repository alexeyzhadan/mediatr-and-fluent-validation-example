namespace MediatrAndFluentValidationSample.Interfaces;

public interface ICacheableQuery
{
    string GetCacheKey();
}