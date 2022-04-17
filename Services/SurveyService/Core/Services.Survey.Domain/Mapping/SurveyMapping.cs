using AutoMapper;
using Services.Survey.Domain.Dtos;
using Services.Survey.Domain.Entities;

namespace Services.Survey.Domain.Mapping
{
    public class SurveyMapping : Profile
    {
        public SurveyMapping()
        {
            CreateMap<MainSurvey, AddSurveyDto>().ReverseMap();
            CreateMap<MainSurvey, GetSurveyDto>().ReverseMap();
            CreateMap<Question, AddQuestionDto>().ReverseMap();
            CreateMap<Question, GetQuestionDto>().ReverseMap();
            CreateMap<QuestionContent, AddQuestionContentDto>().ReverseMap();
            CreateMap<QuestionContent, GetQuestionContentDto>().ReverseMap();
            CreateMap<Answer, AddAnswerDto>().ReverseMap();
            CreateMap<Answer, GetAnswerDto>().ReverseMap();
            CreateMap<AnswerType, GetAnswerTypeDto>().ReverseMap();


        }
    }
}