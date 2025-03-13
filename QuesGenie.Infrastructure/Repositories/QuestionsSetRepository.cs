using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;
using QuesGenie.Infrastructure.Data;

namespace QuesGenie.Infrastructure.Repositories;

public class QuestionsSetRepository(AppDbContext db):Repository<QuestionsSets>(db),IQuestionSetRepository
{
    public async Task<(List<McqQuestions>, List<MatchingQuestions>, List<FillTheBlankQuestions>, List<TrueFalseQuestions>, string)> GetQuestionsByQuestionSetId(string questionSetId)
    {
        var questionSet = await db.QuestionsSets.
            Include(
                x => x.Questions)
            .ThenInclude(q => (q as McqQuestions).McqOptions)
            .Include(x => x.Questions)
            .ThenInclude(q => (q as MatchingQuestions).MatchingPairs)
            .Where(x => x.QuestionSetId == questionSetId)
            .FirstOrDefaultAsync();
        
        if(questionSet is null)
            throw new NotFoundException(nameof(questionSet), questionSetId);
        
        var mcqQuestions = questionSet.Questions.OfType<McqQuestions>().ToList();
        var fillTheBlankQuestions = questionSet.Questions.OfType<FillTheBlankQuestions>().ToList();
        var trueFalseQuestions = questionSet.Questions.OfType<TrueFalseQuestions>().ToList();
        var matchingQuestions = questionSet.Questions.OfType<MatchingQuestions>().ToList();
        
        return (mcqQuestions, matchingQuestions, fillTheBlankQuestions, trueFalseQuestions,questionSet.Status.ToString());
    }
}