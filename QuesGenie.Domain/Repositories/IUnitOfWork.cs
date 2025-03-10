using System.Data;

namespace QuesGenie.Domain.Repositories;

public interface IUnitOfWork
{
    IApplicationUserRepository ApplicationUser { get; }
    IDocumentRepository Documents { get; }
    IMatchingPairsRepository MatchingPairs { get; }
    IMcqOptionsRepository McqOptions { get; }
    IQuestionSetRepository QuestionSet { get; }
    IQuizzesRepository Quizzes { get; }
    IQuizResponsesRepository QuizResponses { get; }
    ISubmissionRepository Submission { get; }
    IMatchingQuestionsRepository MatchingQuestions { get; }
    IMcqQuestionsRepository McqQuestions { get; }
    IFillTheBlankQuestionsRepsitory FillTheBlankQuestions { get; }
    ITrueFalseRepository TrueFalse { get; }
    Task SaveAsync();
    public IDbTransaction BeginTransaction();
}