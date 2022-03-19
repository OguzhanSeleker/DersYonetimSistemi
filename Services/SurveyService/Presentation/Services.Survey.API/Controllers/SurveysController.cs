using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Survey.API.Filters;
using Services.Survey.Application.Repositories.ReadRepositories;
using Services.Survey.Application.Repositories.WriteRepositories;
using Services.Survey.Domain.Dtos;
using Services.Survey.Domain.Entities;
using Services.Survey.Domain.Mapping;
using Services.Survey.Persistence.Contexts;
using SharedLibrary.ControllerBases;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Survey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : CustomBaseController
    {
        private readonly SurveyServiceDbContext _context;
        private readonly IMainSurveyReadRepository _mainSurveyReadRepository;
        private readonly IMainSurveyWriteRepository _mainSurveyWriteRepository;
        private readonly IAnswerReadRepository _answerReadRepository;
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionContentReadRepository _questionContentReadRepository;
        private readonly IQuestionContentWriteRepository _questionContentWriteRepository;

        public SurveysController(SurveyServiceDbContext context, IMainSurveyReadRepository mainSurveyReadRepository, IMainSurveyWriteRepository mainSurveyWriteRepository, IAnswerReadRepository answerReadRepository, IAnswerWriteRepository answerWriteRepository, IQuestionReadRepository questionReadRepository, IQuestionWriteRepository questionWriteRepository, IQuestionContentReadRepository questionContentReadRepository, IQuestionContentWriteRepository questionContentWriteRepository)
        {
            _context = context;
            _mainSurveyReadRepository = mainSurveyReadRepository;
            _mainSurveyWriteRepository = mainSurveyWriteRepository;
            _answerReadRepository = answerReadRepository;
            _answerWriteRepository = answerWriteRepository;
            _questionReadRepository = questionReadRepository;
            _questionWriteRepository = questionWriteRepository;
            _questionContentReadRepository = questionContentReadRepository;
            _questionContentWriteRepository = questionContentWriteRepository;
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddMainSurvey([FromBody] AddSurveyDto addSurveyDto)
        {
            var entity = await _mainSurveyWriteRepository.AddAsync(ObjectMapper.Mapper.Map<MainSurvey>(addSurveyDto));
            var save = await _mainSurveyWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance(OperationResult<GetSurveyDto>.CreatedSuccessResult(ObjectMapper.Mapper.Map<GetSurveyDto>(entity)));
            else
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could Not Added", SharedLibrary.ResponseDtos.StatusCode.Error));
        }
        [HttpGet("[action]/lessonId")]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        public IActionResult GetMainSurveyListByLessonId(string lessonId)
        {
            var surveyList = _mainSurveyReadRepository.GetWhere(i => i.LessonId == Guid.Parse(lessonId), false).OrderBy(i => i.Active).ThenBy(i => i.CreatedDate);
            if (surveyList.Count() > 0)
                return CreateActionResultInstance(OperationResult<List<GetSurveyDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetSurveyDto>>(surveyList.ToList())));
            return CreateActionResultInstance(OperationResult<NoContent>.NoContentSuccessResult());
        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        [Route("[action]/id")]
        public async Task<IActionResult> GetMainSurveyById(string id)
        {
            var survey = await _mainSurveyReadRepository.GetByIdAsync(id, false);
            if (survey != null)
                return CreateActionResultInstance(OperationResult<GetSurveyDto>.OkSuccessResult(ObjectMapper.Mapper.Map<GetSurveyDto>(survey)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Not Found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
        }
        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddQuestion(AddQuestionDto addQuestionDto)
        {
            Question question = ObjectMapper.Mapper.Map<Question>(addQuestionDto);
            //List<QuestionContent> questionContents = ObjectMapper.Mapper.Map<List<QuestionContent>>(addQuestionDto.QuestionContents);
            question = await _questionWriteRepository.AddAsync(question);
            var save = await _questionWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance(OperationResult<NoContent>.CreatedSuccessResult());
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could Not Added", SharedLibrary.ResponseDtos.StatusCode.Error));
        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        [Route("[action]/surveyId")]
        public async Task<IActionResult> GetQuestionsBySurveyId(string surveyId)
        {
            var questions = _questionReadRepository.GetWhere(i => i.MainSurveyId == Guid.Parse(surveyId)).ToList();
            if (questions != null && questions.Count() > 0)
                return CreateActionResultInstance(OperationResult<List<GetQuestionDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetQuestionDto>>(questions)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Not Found", SharedLibrary.ResponseDtos.StatusCode.NotFound));

        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        [Route("[action]/id")]
        public async Task<IActionResult> GetQuestionById(string id)
        {
            var question = await _questionReadRepository.GetByIdAsync(id);
            if (question != null)
                return CreateActionResultInstance(OperationResult<GetQuestionDto>.OkSuccessResult(ObjectMapper.Mapper.Map<GetQuestionDto>(question)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Not Found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
        }
        [HttpGet]
        [ServiceFilter(typeof(ParameterFilterAttribute))]
        [Route("[action]/questionId")]
        public async Task<IActionResult> GetQuestionContentsByQuestionId(string questionId)
        {
            var questionContents = _questionContentReadRepository.GetWhere(i => i.QuestionId == Guid.Parse(questionId)).ToList();
            if(questionContents != null && questionContents.Count > 0)
                return CreateActionResultInstance(OperationResult<List<GetQuestionContentDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetQuestionContentDto>>(questionContents)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Not Found", SharedLibrary.ResponseDtos.StatusCode.NotFound));

        }
        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddAnswer(AddAnswerDto addAnswerDto)
        {
            var answer = ObjectMapper.Mapper.Map<Answer>(addAnswerDto);
            answer = await _answerWriteRepository.AddAsync(answer);
            var save = await _answerWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance(OperationResult<GetAnswerDto>.CreatedSuccessResult(ObjectMapper.Mapper.Map<GetAnswerDto>(answer)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could Not Added", SharedLibrary.ResponseDtos.StatusCode.Error));
        }
    }
}
