using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuesGenie.Application.Quiz.Commands.StartQuiz;
using QuesGenie.Application.Quiz.Commands.SubmitQuiz;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class QuizController:ControllerBase
{
    private readonly IMediator _mediator;
    private ApiResponse apiResponse;
    public QuizController(IMediator mediator)
    {
        _mediator = mediator;
        apiResponse = new ApiResponse();
    }
    
    [HttpPost("{submissionId}/start")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> StartQuiz(string submissionId)
    {
        var result = await _mediator.Send(new StartQuizCommand(submissionId));
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
    
    [HttpPost("submit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> SubmitQuiz([FromBody] SubmitQuizCommand command)
    {
        var result = await _mediator.Send(command);
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
}