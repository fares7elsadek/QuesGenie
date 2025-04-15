using AutoMapper;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions.Profiles;

public class GenerateQuestionsMcqProfile:Profile
{
    public GenerateQuestionsMcqProfile()
    {
        CreateMap<McqQuestions, GenerateQuestionMcqQuestionsDto>()
            .ForMember(x => x.mcqOptions, opt =>
            {
                opt.MapFrom(x => x.McqOptions);
            }).ForMember(x => x.questionText, opt =>
            {
                opt.MapFrom(x => x.QuestionText);
            }).ForMember(x => x.pageRange, opt =>
            {
                opt.MapFrom(x => x.PageRange);
            }).ReverseMap();
    }
}