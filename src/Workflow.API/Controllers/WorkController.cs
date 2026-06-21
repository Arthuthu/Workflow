using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Security.Principal;
using Workflow.API.DTOs.Requests;
using Workflow.API.DTOs.Responses;
using Workflow.API.Mapper;
using Workflow.Application.Interfaces.Services;
using Workflow.Domain.Entities;

namespace Workflow.API.Controllers
{
	public class WorkController : Controller
    {
        private readonly IWorkService _service;

        public WorkController(IWorkService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("work/{id:guid}")]
        [ProducesResponseType(typeof(WorkResponse), 200), ProducesResponseType(404), ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
				Work? entity = await _service.Get(id, cancellationToken);

                if (entity is null)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }

                return Ok(entity.ToWorkResponse());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("work")]
		[ProducesResponseType(typeof(List<WorkResponse>), 200), ProducesResponseType(404), ProducesResponseType(500)]
		public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                List<Work> entities = await _service.Get(cancellationToken);

                if (entities.Count == 0)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }

                return Ok(entities.ToWorkResponse());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("work")]
        [ProducesResponseType(typeof(WorkResponse), 200), ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] WorkRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Work entity = request.ToWork();
                await _service.Create(entity, cancellationToken);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,  ex.Message);
            }
        }

        [HttpPut]
        [Route("work/{id:guid}")]
        [ProducesResponseType(typeof(WorkResponse), 200), ProducesResponseType(404), ProducesResponseType(500)]
        public async Task<IActionResult> Update(Guid id, [FromBody] WorkRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Work entity = request.ToWork();
                Work? result = await _service.Update(id, entity, cancellationToken);

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result.ToWorkResponse());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("work/{id}")]
		[ProducesResponseType(200), ProducesResponseType(404), ProducesResponseType(500)]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _service.Delete(id, cancellationToken);

                if (result is false)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
	}
}
