using System.Data;

namespace QuesGenie.Domain.Repositories;

public interface IUnitOfWork
{
    IAnswersRepository Answers { get; }
    IApplicationUserRepository ApplicationUser { get; }
    IDocumentRepository Documents { get; }
    IMatchingPairsRepository MatchingPairs { get; }
    IMcqOptionsRepository McqOptions { get; }
    IQuestionsRepository Questions { get; }
    IQuestionSetRepository QuestionSet { get; }
    IQuizzesRepository Quizzes { get; }
    IQuizResponsesRepository QuizResponses { get; }
    ISubmissionRepository Submission { get; }
    Task SaveAsync();
    public IDbTransaction BeginTransaction();
}