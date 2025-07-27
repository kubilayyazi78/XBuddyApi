using Microsoft.EntityFrameworkCore;
using XBuddyModels.Paging;

namespace XBuddy.Application.Extensions;

public static class PagingExtensions
{
    public static async Task<PagedResponse<T>> GetPage<T>(this IQueryable<T> query, int? currentPage, int? pageSize) where T : class
    {
        var count = await query.CountAsync();
        Page paging = new Page(currentPage ?? 1, pageSize ?? 10, count);
        var data = await query
            .Skip(paging.Skip)
            .Take(paging.PageSize)
            .AsNoTracking()
            .ToListAsync();

        var result = new PagedResponse<T>(data, paging);

        return result;
    }
}
