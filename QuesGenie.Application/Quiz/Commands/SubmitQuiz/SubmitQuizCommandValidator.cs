using FluentValidation;
using QuesGenie.Application.Quiz.Dtos;

namespace QuesGenie.Application.Quiz.Commands.SubmitQuiz;

public class SubmitQuizCommandValidator : AbstractValidator<SubmitQuizCommand>
{
    public SubmitQuizCommandValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Quiz ID is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Quiz ID must be a valid GUID.");

        RuleFor(x => x.McqQuizAnswers)
            .NotNull().WithMessage("MCQ answers list cannot be null.")
            .ForEach(answer => 
            {
                answer.NotNull().WithMessage("MCQ answer cannot be null.");
                answer.SetValidator(new McqQuizAnswerDtoValidator());
            });

        RuleFor(x => x.TrueFalseQuizAnswers)
            .NotNull().WithMessage("True/False answers list cannot be null.")
            .ForEach(answer => 
            {
                answer.NotNull().WithMessage("True/False answer cannot be null.");
                answer.SetValidator(new TrueFalseQuizAnswerDtoValidator());
            });

        RuleFor(x => x.MatchingQuizAnswers)
            .NotNull().WithMessage("Matching answers list cannot be null.")
            .ForEach(answer => 
            {
                answer.NotNull().WithMessage("Matching answer cannot be null.");
                answer.SetValidator(new MatchingQuizAnswerDtoValidator());
            });

        RuleFor(x => x.FillTheBlnakAnswers)
            .NotNull().WithMessage("Fill in the blank answers list cannot be null.")
            .ForEach(answer => 
            {
                answer.NotNull().WithMessage("Fill in the blank answer cannot be null.");
                answer.SetValidator(new FillTheBlankQuizAnswerDtoValidator());
            });
    }
}

// Validators for individual DTOs

public class McqQuizAnswerDtoValidator : AbstractValidator<McqQuizAnswerDto>
{
    public McqQuizAnswerDtoValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("Question ID is required.");

        RuleFor(x => x.OptionId)
            .NotEmpty().WithMessage("Option ID is required.");
    }
}

public class TrueFalseQuizAnswerDtoValidator : AbstractValidator<TrueFalseQuizAnswerDto>
{
    public TrueFalseQuizAnswerDtoValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("Question ID is required.");
    }
}

public class MatchingQuizAnswerDtoValidator : AbstractValidator<MatchingQuizAnswerDto>
{
    public MatchingQuizAnswerDtoValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("Question ID is required.");
    }
}

public class FillTheBlankQuizAnswerDtoValidator : AbstractValidator<FillTheBlankQuizAnswerDto>
{
    public FillTheBlankQuizAnswerDtoValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("Question ID is required.");

        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage("Answer cannot be empty.");
    }
}
