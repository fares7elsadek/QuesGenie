using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class QuestionsSetRepository(AppDbContext db):Repository<QuestionsSets>(db),IQuestionSetRepository
{
    public async Task<(List<McqQuestions>, List<MatchingQuestions>, List<FillTheBlankQuestions>, List<TrueFalseQuestions>, string)> 
        GetQuestionsByQuestionSetId(string questionSetId, CancellationToken cancellationToken = default)
    {
        var questionSet = await db.QuestionsSets
            .Include(qs => qs.Questions)
            .AsNoTracking()
            .FirstOrDefaultAsync(qs => qs.QuestionSetId == questionSetId, cancellationToken);
    
        if (questionSet is null)
            throw new NotFoundException(nameof(QuestionsSets), questionSetId);

        
        var mcqQuestions = await db.McqQuestions
            .Where(q => q.QuestionSetId == questionSetId)
            .Include(q => q.McqOptions)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    
        var fillTheBlankQuestions = await db.FillTheBlank
            .Where(q => q.QuestionSetId == questionSetId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var trueFalseQuestions = await db.TrueFalseQuestions
            .Where(q => q.QuestionSetId == questionSetId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var matchingQuestions = await db.MatchingQuestions
            .Where(q => q.QuestionSetId == questionSetId)
            .Include(q => q.MatchingPairs)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return (mcqQuestions, matchingQuestions, fillTheBlankQuestions, trueFalseQuestions, questionSet.Status.ToString());
    }
}