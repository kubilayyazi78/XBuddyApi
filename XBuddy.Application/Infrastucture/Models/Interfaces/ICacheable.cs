namespace XBuddy.Application.Infrastucture.Models.Interfaces;

public interface ICacheable
{
    public string CacheKey { get;  }
    public bool? IgnoreCacheRead { get; set; }
    public bool? IgnoreCacheWrite { get; set; }
}
