using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Application.Services.Files;
using QuesGenie.Application.Services.SyncCommunication;
using QuesGenie.Application.Services.User;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.GenerateQuestions.Commands.SubmitDocuments;

public class SubmitDocumentCommandHandler(IFileService fileService,
    IUnitOfWork unitOfWork,IUserContext userContext,IQuestionHttpClient httpClient):IRequestHandler<SubmitDocumentCommand,string>
{
    public async Task<string> Handle(SubmitDocumentCommand request, CancellationToken cancellationToken)
    {
        var user  = userContext.GetCurrentUser();
        if (user is null) throw new ArgumentNullException(nameof(user));
        
        
        // Create Submission & documents
        var submissionId = Guid.NewGuid().ToString();
        var newSubmission = new Submissions
        {
            SubmissionId = submissionId,
            UserId = user.userId,
            SampleQuestions = request.SampleQuestions ?? string.Empty,
            Documents = new List<Documents>() 
        };

        var requestDto = new QuestionRequestDto();
        requestDto.submissionId= submissionId;
        var documentTasks = request.SubmissionDocuments.Select(async docs =>
        {
            var (url, filename) = await fileService.SaveFileAsync(docs.File);
            var documentId = Guid.NewGuid().ToString();
            var documentDto = new DocumentsDto(documentId, url, docs.DocumentType);
            requestDto.documents.Add(documentDto);
            return new  Documents
            {
                DocumentId = documentId,
                DocumentType = GetDocumentType(docs.DocumentType),
                FileName = filename,
                FileUrl = url,
                Content = docs.Content ?? string.Empty
            };
        });

        var documents = await Task.WhenAll(documentTasks);
        newSubmission.Documents.AddRange(documents);
        
        await unitOfWork.Submission.AddAsync(newSubmission);
        await unitOfWork.SaveAsync();
        await httpClient.GenerateQuestion(requestDto);
        return submissionId;
    }
    
    DocumentType GetDocumentType(string documentType) => documentType.ToLower() switch
    {
        "pdf" => DocumentType.PDF,
        "text" => DocumentType.TEXT,
        "ppt" => DocumentType.POWER_POINT,
        "mp3" => DocumentType.MP3,
        _ => throw new ArgumentException("Invalid document type")
    };
}