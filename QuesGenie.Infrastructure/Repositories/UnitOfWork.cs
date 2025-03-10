using System.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class UnitOfWork:IUnitOfWork
{
    public IApplicationUserRepository ApplicationUser { get; }
    public IDocumentRepository Documents { get; }
    public IMatchingPairsRepository MatchingPairs { get; }
    public IMcqOptionsRepository McqOptions { get; }
    public IQuestionSetRepository QuestionSet { get; }
    public IQuizzesRepository Quizzes { get; }
    public IQuizResponsesRepository QuizResponses { get; }
    public ISubmissionRepository Submission { get; }
    public IMatchingQuestionsRepository MatchingQuestions { get; }
    public IMcqQuestionsRepository McqQuestions { get; }
    public IFillTheBlankQuestionsRepsitory FillTheBlankQuestions { get; }
    public ITrueFalseRepository TrueFalse { get; }
    private readonly AppDbContext _db;
    
    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        ApplicationUser = new ApplicationUserRepository(_db);
        Documents = new DocumentRepository(_db);
        MatchingPairs = new MatchingPairsRepository(_db);
        McqOptions = new McqOptionsRepository(_db);
        MatchingQuestions = new MatchingQuestionsRepository(_db);
        McqQuestions = new McqQuestiosnsRepository(_db);
        FillTheBlankQuestions = new FillTheBlankRepository(_db);
        TrueFalse = new TrueFalseQuestionsRepository(_db);
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