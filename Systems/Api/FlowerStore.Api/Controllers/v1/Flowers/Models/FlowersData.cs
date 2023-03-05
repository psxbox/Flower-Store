using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Common.Responses;

namespace FlowerStore.Api.Controllers.v1.Flowers.Models
{
    /// <summary>
    /// Flowers data
    /// </summary>
    public class FlowersData : DataResponse<FlowerResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="totalElements"></param>
        /// <returns></returns>
        public FlowersData(IEnumerable<FlowerResponse> data,
                           int page,
                           int limit,
                           int totalElements) : base(data, page, limit, totalElements)
        {
        }
    }
}