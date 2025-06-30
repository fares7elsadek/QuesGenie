using FluentValidation;

namespace QuesGenie.Application.GenerateQuestions.Commands.SubmitDocuments;

public class SubmitDocumentCommandValidator:AbstractValidator<SubmitDocumentCommand>
{
    private static readonly string[] AllowedDocumentTypes = { "text", "pdf", "ppt", "audio" };
    private static readonly string[] AllowedFileExtensions = { ".txt", ".pdf", ".ppt", ".pptx", ".mp3", ".wav" };
    private static readonly long MaxFileSize = 20 * 1024 * 1024; // 20 MB
    
    public SubmitDocumentCommandValidator()
    {
        RuleFor(x => x.SubmissionDocuments)
            .NotEmpty().WithMessage("At least one document must be submitted.");

        RuleForEach(x => x.SubmissionDocuments).ChildRules(docs =>
        {
            // DocumentType must be valid
            //docs.RuleFor(d => d.DocumentType)
                //.NotEmpty().WithMessage("Document type is required.")
               // .Must(type => AllowedDocumentTypes.Contains(type))
               // .WithMessage($"Invalid document type. Allowed types: {string.Join(", ", AllowedDocumentTypes)}");
            
            // File must not be null, valid extension, and within size limit
            docs.RuleFor(d => d.File)
                .NotNull().WithMessage("File is required.")
                .Must(file => file.Length > 0).WithMessage("Uploaded file cannot be empty.")
                .Must(file => AllowedFileExtensions.Contains(System.IO.Path.GetExtension(file.FileName).ToLower()))
                .WithMessage($"Invalid file format. Allowed extensions: {string.Join(", ", AllowedFileExtensions)}")
                .Must(file => file.Length <= MaxFileSize)
                .WithMessage($"File size must not exceed {MaxFileSize / (1024 * 1024)} MB.");
            
            // Content validation: Required only for 'text' document type
            docs.RuleFor(d => d.Content)
                .NotEmpty().WithMessage("Content is required when document type is 'text'.")
                .When(d => d.DocumentType == "text");
            
            docs.RuleFor(d => d.Content)
                .Must(content => string.IsNullOrEmpty(content))
                .WithMessage("Content should only be provided for 'text' document type.")
                .When(d => d.DocumentType != "text");
        });
    }
}