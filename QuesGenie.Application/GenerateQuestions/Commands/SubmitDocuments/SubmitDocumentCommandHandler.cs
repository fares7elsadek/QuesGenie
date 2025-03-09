using MediatR;
using QuesGenie.Application.Services.Files;
using QuesGenie.Application.Services.User;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.GenerateQuestions.Commands.SubmitDocuments;

public class SubmitDocumentCommandHandler(IFileService fileService,
    IUnitOfWork unitOfWork,IUserContext userContext):IRequestHandler<SubmitDocumentCommand,string>
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

        var documentTasks = request.SubmissionDocuments.Select(async docs =>
        {
            var (url, filename) = await fileService.SaveFileAsync(docs.File);
            return new  Documents
            {
                DocumentType = GetDocumentType(docs.DocumentType),
                FileName = filename,
                FileUrl = url,
                Content = docs.Content ?? string.Empty,
                QuestionSet = new QuestionsSets
                {
                    Status = QuestionsStatus.PROCESSING,
                    SubmissionId = submissionId,
                },
            };
        });

        var documents = await Task.WhenAll(documentTasks);
        newSubmission.Documents.AddRange(documents);
        
        await unitOfWork.Submission.AddAsync(newSubmission);
        await unitOfWork.SaveAsync();
        
        // TODO: Publish documents to message queue for question generation (Ahemd Mubarak)

        return submissionId;
    }
    
    DocumentType GetDocumentType(string documentType) => documentType.ToLower() switch
    {
        "pdf" => DocumentType.PDF,
        "text" => DocumentType.TEXT,
        "ppt" => DocumentType.POWER_POINT,
        "audio" => DocumentType.AUDIO,
        _ => throw new ArgumentException("Invalid document type")
    };
}