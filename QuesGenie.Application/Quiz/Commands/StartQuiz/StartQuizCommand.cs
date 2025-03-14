using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Application.Quiz.Dtos;

namespace QuesGenie.Application.Quiz.Commands.StartQuiz;

public record StartQuizCommand(string submissionId) : IRequest<QuizDto>;
