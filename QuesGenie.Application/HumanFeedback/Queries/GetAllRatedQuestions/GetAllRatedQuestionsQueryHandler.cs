using MediatR;
using QuesGenie.Application.HumanFeedback.Queries.Dtos;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.HumanFeedback.Queries.GetAllRatedQuestions;

public class GetAllRatedQuestionsQueryHandler(IUnitOfWork unitOfWork): IRequestHandler<GetAllRatedQuestionsQuery,List<HumandFeedbackDto>>
{
    public async Task<List<HumandFeedbackDto>> Handle(GetAllRatedQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await unitOfWork.Questions
            .GetAllWithConditionAsync(x => x.HumanRate.HasValue && !x.Evaluated);

        return questions
            .Select(x => new HumandFeedbackDto(x.QuestionId, x.QuestionText, x.Context, x.HumanRate!.Value)).ToList();
    }
}