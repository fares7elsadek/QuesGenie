using System.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class UnitOfWork:IUnitOfWork
{
    
    public IAnswersRepository Answers { get; }
    public IApplicationUserRepository ApplicationUser { get; }
    public IDocumentRepository Documents { get; }
    public IMatchingPairsRepository MatchingPairs { get; }
    public IMcqOptionsRepository McqOptions { get; }
    public IQuestionsRepository Questions { get; }
    public IQuestionSetRepository QuestionSet { get; }
    public IQuizzesRepository Quizzes { get; }
    public IQuizResponsesRepository QuizResponses { get; }
    public ISubmissionRepository Submission { get; }
    private readonly AppDbContext _db;
    
    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Answers = new AnswersRepository(_db);
        ApplicationUser = new ApplicationUserRepository(_db);
        Documents = new DocumentRepository(_db);
        MatchingPairs = new MatchingPairsRepository(_db);
        McqOptions = new McqOptionsRepository(_db);
        Questions = new QuestionsRepository(_db);
        QuestionSet = new QuestionsSetRepository(_db);
        Quizzes = new QuizzesRepository(_db);
        QuizResponses = new QuizResponsesRepository(_db);
        Submission = new SubmissionRepository(_db);
    }


    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _db.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}