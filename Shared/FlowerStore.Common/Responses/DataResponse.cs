using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FlowerStore.Common.Responses;

/// <summary>
/// <c>DataResponse</c> model 
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataResponse<T>
{
    public IEnumerable<T>? Data { get; set; }
    public int TotalPages { get; set; }
    public int TotalElements { get; set; }
    public bool HasNext { get; set; }

    public DataResponse(IEnumerable<T> data, int page, int limit, int totalElements)
    {
        Data = data;
        TotalPages = (int)Math.Ceiling(totalElements / (float)limit);
        TotalElements = totalElements;
        HasNext = (page + 1) * limit < totalElements;
    }
}