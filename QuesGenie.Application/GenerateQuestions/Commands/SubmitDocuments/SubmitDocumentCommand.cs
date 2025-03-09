using System.Reflection.Metadata;
using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;

namespace QuesGenie.Application.GenerateQuestions.Commands.SubmitDocuments;

public class SubmitDocumentCommand:IRequest<string>
{
    public List<SubmissionDocumentDto> SubmissionDocuments { get; set; } = new();
    public string? SampleQuestions { get; set; } = default!;
}