using MediatR;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.HumanFeedback.Commands.EvaluateQuestion;

public class EvaluateQuestionCommandHanlder(IUnitOfWork unitOfWork):IRequestHandler<EvaluateQuestionCommand>
{
    public async Task Handle(EvaluateQuestionCommand request, CancellationToken cancellationToken)
    {
        foreach (var questionId in request.questionIds)
        {
            var question = await unitOfWork.Questions.GetOrDefalutAsync(x => x.QuestionId == questionId);
            if(question is null)
                throw new NotFoundException("Question", questionId);
            
            question.Evaluated = true;
        }
        await unitOfWork.SaveAsync();
    }
}