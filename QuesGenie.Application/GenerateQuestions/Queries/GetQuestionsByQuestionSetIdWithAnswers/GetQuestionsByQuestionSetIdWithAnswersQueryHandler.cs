using AutoMapper;
using MediatR;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsByQuestionSetIdWithAnswers;

public class GetQuestionsByQuestionSetIdWithAnswersQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper):
    IRequestHandler<GetQuestionsByQuestionSetIdWithAnswersQuery,GetQuestionSetAnswerDto>
{
    public async Task<GetQuestionSetAnswerDto> Handle(GetQuestionsByQuestionSetIdWithAnswersQuery request, CancellationToken cancellationToken)
    {
        var (mcqQuestions,
            matchingQuestions,
            fillTheBlankQuestions,
            trueFalseQuestions
            , status) = await unitOfWork.QuestionSet.GetQuestionsByQuestionSetId(request.questionSetId);
        
        var questionSetDto = new GetQuestionSetAnswerDto();
        questionSetDto.Status = status;
        questionSetDto.MatchingQuestions = mapper.Map<List<MatchingQuestionsAnswerDto>>(matchingQuestions);
        questionSetDto.McqQuestions = mapper.Map<List<McqQuestionsAnswerDto>>(mcqQuestions);
        questionSetDto.TrueFalseQuestions = mapper.Map<List<TrueFalseAnswerDto>>(trueFalseQuestions);
        questionSetDto.FillTheBlanks = mapper.Map<List<FillTheBlankAnswerDto>>(fillTheBlankQuestions);
        return questionSetDto;
    }
}