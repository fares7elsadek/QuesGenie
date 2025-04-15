using AutoMapper;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.GenerateQuestions.Dtos.GenerateQuestions.Profiles;

public class GenerateQuestionsMcqOptionsProfile:Profile
{
    public GenerateQuestionsMcqOptionsProfile()
    {
        CreateMap<McqOptions, GenerateQuestionsMcqOptionsDto>()
            .ForMember(opt => opt.optionText , c =>
            {
                c.MapFrom(x => x.OptionText);
            }).ForMember(opt => opt.isCorrectAnswer , c =>
            {
                c.MapFrom(x => x.IsCorrectAnswer);
            }).ReverseMap();
    }
}