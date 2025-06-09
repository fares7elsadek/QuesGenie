using MediatR;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.HumanFeedback.Commands.SubmitFeedback;

public class SubmitFeedbackCommandHanlder
    (IUnitOfWork unitOfWork):IRequestHandler<SubmitFeedbackCommand>
{
    public async Task Handle(SubmitFeedbackCommand request, CancellationToken cancellationToken)
    {
        var questionId = request.questionId;
        var rate = request.rate;
        
        var question = await unitOfWork.Questions.GetOrDefalutAsync(x => x.QuestionId == questionId);
        if(question == null)
            throw new NotFoundException(nameof(question), questionId);
        
        question.HumanRate = rate;
        await unitOfWork.SaveAsync();
    }
}