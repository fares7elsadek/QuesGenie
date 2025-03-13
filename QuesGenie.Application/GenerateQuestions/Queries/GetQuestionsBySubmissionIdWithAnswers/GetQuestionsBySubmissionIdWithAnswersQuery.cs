using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsBySubmissionIdWithAnswers;

public record GetQuestionsBySubmissionIdWithAnswersQuery(string submissionId)
    :IRequest<GetQuestionsBySubmissionIdWithAnswerDto>;