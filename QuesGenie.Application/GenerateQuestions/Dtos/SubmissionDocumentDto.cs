using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;

namespace QuesGenie.Application.GenerateQuestions.Dtos;

public class SubmissionDocumentDto
{
    public string DocumentType { get; set; } = default!;
    public string? Content { get; set; }
    [FromForm]
    public IFormFile File { get; set; } = default!;
}