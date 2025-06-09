using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuesGenie.Application.HumanFeedback.Commands.EvaluateQuestion;
using QuesGenie.Application.HumanFeedback.Commands.SubmitFeedback;
using QuesGenie.Application.HumanFeedback.Queries.GetAllRatedQuestions;
using QuesGenie.Application.Services.Pdf;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HumanFeedbackController:ControllerBase{
    
    private readonly IMediator _mediator;
    private ApiResponse apiResponse;
    public HumanFeedbackController(IMediator mediator)
    {
        _mediator = mediator;
        apiResponse = new ApiResponse();
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> SubmitRate(SubmitFeedbackCommand command)
    {
        await _mediator.Send(command);
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = null;
        return Ok(apiResponse);
    }
    
    [HttpPost("done")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> EvaluatedQuestions(EvaluateQuestionCommand command)
    {
        await _mediator.Send(command);
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = null;
        return Ok(apiResponse);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> GetRateQuestions()
    {
        var result  = await _mediator.Send(new GetAllRatedQuestionsQuery());
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
}