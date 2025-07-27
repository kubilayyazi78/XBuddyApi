﻿using Mediator;

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
