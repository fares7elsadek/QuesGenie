using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuesGenie.Application.GenerateQuestions.Commands.SubmitDocuments;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController:ControllerBase
{
    private readonly IMediator _mediator;
    private ApiResponse apiResponse;
    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
        apiResponse = new ApiResponse();
    }
    
    [HttpPost("generate")]
    [Authorize]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> RegisterUser([FromForm] SubmitDocumentCommand command)
    {
        var submissionId = await _mediator.Send(command);
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = new
        {
            Status = "Done",
            SubmissionId = submissionId
        };
        return Ok(apiResponse);
    }
}