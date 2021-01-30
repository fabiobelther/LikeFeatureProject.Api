using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Swashbuckle.Swagger.Annotations;
using Microsoft.AspNetCore.Http;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Host.Translate.LikeTranslate.Response;
using LikeFeatureProject.Api.Host.Models.Like.Response;

namespace LikeFeatureProject.Api.Host.Controllers.Like.v1
{
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILogger<LikeController> _logger;
        private readonly IGetFindLikeFlow _getFindLikeFlow;
        private readonly IInsertLikeFlow _insertLikeFlow;

        public LikeController(ILogger<LikeController> logger,
                              IGetFindLikeFlow getFindLikeFlow,
                              IInsertLikeFlow insertLikeFlow)
        {
            _logger = logger;
            _insertLikeFlow = insertLikeFlow;
            _getFindLikeFlow = getFindLikeFlow;
        }

        /// <summary>
        /// Get the quantity of likes from article
        /// </summary>
        [HttpGet("v1/like")]
        [Consumes("application/json")]
        [SwaggerResponse(200, Description = "The likes was found.")]
        [SwaggerResponse(204, Description = "The likes was not found.")]
        [SwaggerResponse(400, Description = "Bad Request")]
        [SwaggerResponse(500, Description = "Internal server error")]
        [SwaggerResponse(404, Description = "It was no possible to find the count")]
        [ProducesResponseType(typeof(LikeResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(operationId: "Like_Get")]
        public async Task<ActionResult> Get(int articleId)
        {
            var response = await _getFindLikeFlow.Execute(articleId);
            var translateResponse = LikeToLikeResponse.Translate(response);

            return Ok(translateResponse);
        }


        /// <summary>
        /// Post a new like to article
        /// </summary>
        [HttpPost("v1/like")]
        [Consumes("application/json")]
        [SwaggerResponse(201, Description = "The likes was inserted.")]
        [SwaggerResponse(400, Description = "Bad Request")]
        [SwaggerResponse(500, Description = "Internal server error")]
        [ProducesResponseType(typeof(LikeResponse), StatusCodes.Status201Created)]
        [SwaggerOperation(operationId: "Like_Post")]
        public async Task<ActionResult> Post([FromQuery] int articleId)
        {
            var response = await _insertLikeFlow.Execute(articleId);
            var translateResponse = LikeToLikeResponse.Translate(response);

            return Created("Likes", translateResponse);
        }
    }
}
