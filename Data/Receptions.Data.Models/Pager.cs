namespace Receptions.Data.Models
{
    using System;

    public class Pager(int totalItems, int? page, int pageSize = 10)
    {
        public int TotalItems { get; private set; } = totalItems;

        public int CurrentPage { get; private set; } = page == null || page < 1 ? 1 : (int)page;

        public int PageSize { get; private set; } = pageSize;

        public int TotalPages { get; private set; } = (int)Math.Ceiling((decimal)totalItems / pageSize);
    }
}
