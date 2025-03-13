using AutoMapper;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer.Profiles;

public class McqQuestionsAnswerProfile:Profile
{
    public McqQuestionsAnswerProfile()
    {
        CreateMap<McqQuestions, McqQuestionsAnswerDto>()
            .ForMember(x => x.McqOptions, opt =>
            {
                opt.MapFrom(x => x.McqOptions);
            });
    }
}