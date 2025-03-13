using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuesGenie.Application.GenerateQuestions.Commands.SubmitDocuments;
using QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsByQuestionSetId;
using QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsByQuestionSetIdWithAnswers;
using QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsBySubmissionId;
using QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsBySubmissionIdWithAnswers;
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
    
    [HttpPost("{questionsetId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> GetQuestionSet(string questionsetId)
    {
        var result = await _mediator.Send(new GetQuestionsByQuestionSetIdQuery(questionsetId));
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
    
    [HttpPost("{questionsetId}/answers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> GetQuestionSetAnswers(string questionsetId)
    {
        var result = await _mediator.Send(new GetQuestionsByQuestionSetIdWithAnswersQuery(questionsetId));
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
    
    [HttpPost("submission/{submissionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> GetQuestionsBySubmissionId(string submissionId)
    {
        var result = await _mediator.Send(new GetQuestionsBySubmissionIdQuery(submissionId));
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
    
    [HttpPost("submission/{submissionId}/answers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse>> GetQuestionsBySubmissionIdAnswers(string submissionId)
    {
        var result = await _mediator.Send(new GetQuestionsBySubmissionIdWithAnswersQuery(submissionId));
        apiResponse.IsSuccess = true;
        apiResponse.Errors = null;
        apiResponse.StatusCode = HttpStatusCode.OK;
        apiResponse.Result = result;
        return Ok(apiResponse);
    }
}