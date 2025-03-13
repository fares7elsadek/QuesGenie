using QuesGenie.Domain.Entities;

namespace QuesGenie.Domain.Repositories;

public interface IQuestionSetRepository:IRepository<QuestionsSets>
{
    Task<(List<McqQuestions>,List<MatchingQuestions>,List<FillTheBlankQuestions>,
        List<TrueFalseQuestions>,string)> GetQuestionsByQuestionSetId(string questionSetId);
}