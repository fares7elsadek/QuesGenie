using AutoMapper;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions.Profiles;

public class GenerateQuestionsTrueFalseProfile:Profile
{
    public GenerateQuestionsTrueFalseProfile()
    {
        CreateMap<TrueFalseQuestions, GenerateQuestionsTrueFalseDto>()
            .ForMember(x => x.pageRange, opt =>
            {
                opt.MapFrom(x => x.PageRange);
            }).ForMember(x => x.questionText, opt =>
            {
                opt.MapFrom(x => x.QuestionText);
            }).ForMember(x => x.answer, opt =>
            {
                opt.MapFrom(x => x.Answer);
            }).ForMember(x => x.context, opt =>
            {
                opt.MapFrom(x => x.Context);
            }).ReverseMap();
    }
}