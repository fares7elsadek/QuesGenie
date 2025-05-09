using AutoMapper;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions.Profiles;

public class GenerateQuestionsFillTheBlankProfile: Profile
{
    public GenerateQuestionsFillTheBlankProfile()
    {
        CreateMap<FillTheBlankQuestions, GenerateQuestionsFillTheBlankDto>()
            .ForMember(x => x.answerText, opt =>
            {
                opt.MapFrom(x => x.AnswerText);
            }).ForMember(x => x.questionText, opt =>
            {
                opt.MapFrom(x => x.QuestionText);
            }).ForMember(x => x.answerText, opt =>
            {
                opt.MapFrom(x => x.AnswerText);
            }).ForMember(x => x.context, opt =>
            {
                opt.MapFrom(x => x.Context);
            }).ReverseMap();
    }
}
