﻿using Mediator;
using XBuddy.Application.Infrastucture.Models.Interfaces;
using XBuddyModels.Paging;

namespace XBuddy.Application.Features.Base;

public class BasePagedQuery<T>(int PageNumber, int PageSize)
    : BasePagedQuery(PageNumber, PageSize), IRequest<T> where T : class
{
    public BasePagedQuery() : this(1, 10)
    {

    }
}

public class BasePagedQuery(int pageNumber, int pageSize)
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}
public class CacheablePagedQuery<T> : CacheablePagedQuery, IRequest<PagedResponse<T>> where T : class
{
    
}
public class CacheablePagedQuery : BasePagedQuery, ITenantCacheable
{
    public string TenantId { get; set; }

    public virtual string CacheKey { get; }
    public bool? IgnoreCacheRead { get; set; }
    public bool? IgnoreCacheWrite { get; set; }

    public CacheablePagedQuery(int pageNumber, int pageSize) : base(pageNumber, pageSize)
    {
    }
    public CacheablePagedQuery() : this(1, 10)
    {
    }

}