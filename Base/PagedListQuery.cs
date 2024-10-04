using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MinimalAPI.Base;

public abstract record PagedListQuery
{
    [FromQuery(Name = "page")]
    [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0.")]
    public int Page { get; init; } = 1;

    [FromQuery(Name = "pageSize")]
    [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
    public int PageSize { get; init; } = 10;

    public int Skip => (Page - 1) * PageSize;
}