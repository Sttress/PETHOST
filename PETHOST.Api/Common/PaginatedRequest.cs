﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using PETHOST.Common.Repositories.Pagination;
using FluentValidation;

namespace PETHOST.Api.Common
{
    public class PaginatedRequest
    {
        [FromQuery(Name = "_page")]
        public int? Page { get; init; } = 1;

        [FromQuery(Name = "_size")]
        public int? Size { get; init; } = 10;

        [FromQuery(Name = "_order")]
        public string? Order { get; init; }

        [BindNever]
        public IEnumerable<KeyValuePair<string, SortDirection>> Orders => ParseOrders(Order);

        private static IEnumerable<KeyValuePair<string, SortDirection>> ParseOrders(string? order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return [];
            }

            return order.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(p =>
                {
                    var parts = p.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var propertyName = parts[0];
                    var direction = parts.Length == 1 ? SortDirection.Ascending : ParseOrderDirection(parts[1]);
                    return new KeyValuePair<string, SortDirection>(propertyName, direction);
                });
        }

        private static SortDirection ParseOrderDirection(string direction)
        {
            return direction.ToLower() switch
            {
                "asc" => SortDirection.Ascending,
                "desc" => SortDirection.Descending,
                _ => throw new ValidationException(
                    [
                        new(string.Empty, $"Invalid direction '{direction}' in ordering, accepted asc or desc."),
                ])
            };
        }
    }
}
