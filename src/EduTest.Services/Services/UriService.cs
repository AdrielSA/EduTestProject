using EduTest.Domain.CustomEntities;
using EduTest.Services.Interfaces;
using EduTest.Services.QueryFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduTest.Services.Services
{
    public class UriService<T> : IUriService<T>
    {
        private readonly HttpContext _context;

        public UriService(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext;
        }

        public Uri GetPaginationUri(StudentQueryFilter filter, int numPag, string route)
        {
            var request = _context.Request;
            var baseUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            var endPoint = new Uri(string.Concat(baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endPoint.ToString(), "PageNumber", numPag.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "PageSize", filter.PageSize.ToString());
            return new(modifiedUri);
        }

        public PagedList<T> Create(IEnumerable<T> source, int pageSize, int pageNumber)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
