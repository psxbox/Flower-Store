using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Api.Controllers.v1.Flowers.Models;
using FlowerStore.Common.Responses;
using FlowerStore.Services.Flowers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FlowerStore.Context.Entities;
using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Api.Controllers.v1.Flowers
{
    /// <summary>
    /// Flowers controller
    /// </summary>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
    /// <response code="404">Not Found</response>
    [ApiController]
    [Route("api/v{version:apiVersion}/flowers")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Authorize(Roles = "SystemAdmin, Admin")]
    public class FlowersController : BaseController
    {
        private readonly IFlowerService flowerService;
        private readonly ILogger<FlowersController> logger;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="flowerService"></param>
        /// <param name="logger"></param>
        public FlowersController(IFlowerService flowerService, ILogger<FlowersController> logger)
        {
            this.flowerService = flowerService;
            this.logger = logger;
        }

        /// <summary>
        /// Get flowers
        /// </summary>
        /// <param name="page">The page</param>
        /// <param name="limit">Number of items in the page</param>
        /// <returns>List of FlowerResponse</returns>
        [ProducesResponseType(typeof(FlowersData), 200)]
        [HttpGet]
        public async Task<FlowersData?> GetFlowersAsync([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            string? userId = IsSystemAdmin ? null : GetUserId();

            var flowers = await flowerService.GetFlowers(page, limit, userId);
            var response = flowers.Select(f => (FlowerResponse)f!);
            var itemsCount = await flowerService.GetFlowersCount();
            var elementsResponse = new FlowersData(response, page, limit, itemsCount);

            return elementsResponse;
        }

        /// <summary>
        /// Get flower by Id
        /// </summary>
        /// <param name="id">Id of flower</param>
        /// <returns>Flower</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FlowerResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlowerResponse>> GetFlowerAsync([FromRoute] int id)
        {
            var flower = await flowerService.GetFlower(id);
            return flower == null ? NotFound() : Ok((FlowerResponse)flower);
        }

        /// <summary>
        /// Add new flower
        /// </summary>
        /// <param name="addFlowerRequest">Flower data</param>
        /// <returns>Added flower</returns>
        [HttpPost]
        public async Task<ActionResult<FlowerResponse>> AddFlowerAsync([FromBody] AddFlowerRequest addFlowerRequest)
        {
            string? userId = GetUserId();

            FlowerResponse flower = await flowerService.AddFlower(addFlowerRequest, userId);

            return Ok(flower);
        }

        /// <summary>
        /// Update the flower by Id
        /// </summary>
        /// <param name="id">Id of flower</param>
        /// <param name="updateFlowerRequest">Modified flower data</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlowerAsync([FromRoute] int id, [FromBody] UpdateFlowerRequest updateFlowerRequest)
        {
            await flowerService.UpdateFlower(id, updateFlowerRequest);
            return Ok();
        }

        /// <summary>
        /// Delete flower by Id
        /// </summary>
        /// <param name="id">Id of flower</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlowerAsync([FromRoute] int id)
        {
            await flowerService.DeleteFlower(id);
            return Ok();
        }
    }
}