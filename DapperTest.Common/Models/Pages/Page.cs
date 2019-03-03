using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperTest.Common.Models.Pages
{
    public class Page<T> where T : class
    {
        public int PageCount { get; }
        public int TotalCount { get; }
        public IList<T> Items { get; }

        public Page(int pageCount, int totalCount, IList<T> items)
        {
            PageCount = pageCount;
            TotalCount = totalCount;
            Items = items;
        }

        public Page<TReturn> Convert<TReturn>(Func<T, TReturn> selector) where TReturn : class
        {
            return new Page<TReturn>(PageCount, TotalCount, Items.Select(selector).ToList());
        }
    }
}