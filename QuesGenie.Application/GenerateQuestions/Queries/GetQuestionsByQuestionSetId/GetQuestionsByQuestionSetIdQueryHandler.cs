using AutoMapper;
using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsByQuestionSetId;

public class GetQuestionsByQuestionSetIdQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper):
    IRequestHandler<GetQuestionsByQuestionSetIdQuery,GetQuestionSetDto>
{
    public async Task<GetQuestionSetDto> Handle(GetQuestionsByQuestionSetIdQuery request, CancellationToken cancellationToken)
    {
        var (mcqQuestions,
            matchingQuestions,
            fillTheBlankQuestions,
            trueFalseQuestions
            , status) = await unitOfWork.QuestionSet.GetQuestionsByQuestionSetId(request.questionSetId,
            cancellationToken);
        
        var questionSetDto = new GetQuestionSetDto();
        questionSetDto.QuestionSetId = request.questionSetId;
        questionSetDto.Status = status;
        questionSetDto.MatchingQuestions = mapper.Map<List<MatchingQuestionsDto>>(matchingQuestions);
        questionSetDto.McqQuestions = mapper.Map<List<McqQuestionsDto>>(mcqQuestions);
        questionSetDto.TrueFalseQuestions = mapper.Map<List<TrueFalseQuestionsDto>>(trueFalseQuestions);
        questionSetDto.FillTheBlanks = mapper.Map<List<FillTheBlankDto>>(fillTheBlankQuestions);
        return questionSetDto;
    }
}