using EduTest.Domain.CustomEntities;
using EduTest.Services.QueryFilters;
using System;
using System.Collections.Generic;

namespace EduTest.Services.Interfaces
{
    public interface IUriService<T>
    {
        PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize);
        Uri GetPaginationUri(StudentQueryFilter filter, int numPag, string route);
    }
}