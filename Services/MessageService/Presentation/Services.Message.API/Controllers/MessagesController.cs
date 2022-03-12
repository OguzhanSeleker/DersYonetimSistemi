using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Message.Application.Repositories;
using Services.Message.Domain.Dtos;
using Services.Message.Domain.Mapping;
using SharedLibrary.ControllerBases;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Message.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : CustomBaseController
    {
        readonly private IMessageReadRepository _messageReadRepository;
        readonly private IMessageWriteRepository _messageWriteRepository;

        public MessagesController(IMessageReadRepository messageReadRepository, IMessageWriteRepository messageWriteRepository)
        {
            _messageReadRepository = messageReadRepository;
            _messageWriteRepository = messageWriteRepository;
        }
        [HttpGet]
        [Route("[action]/{lessonId}")]
        public async Task<IActionResult> GetMessageListByLessonId(string lessonId)
        {
            if(string.IsNullOrEmpty(lessonId))
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter is empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            Guid guid = Guid.Empty;
            Guid.TryParse(lessonId, out guid);
            if (guid == Guid.Empty)
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter is not valid format", SharedLibrary.ResponseDtos.StatusCode.BadRequest));

            var entities =  _messageReadRepository.GetWhere(i => !i.Deleted && i.LessonId == guid);
            if (entities is not null && entities.Count() > 0)
                return CreateActionResultInstance(OperationResult<List<GetMessageDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetMessageDto>>(entities.OrderBy(i => i.CreatedDate))));
            return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Could not found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
        }
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetMessageListByUpperMessageId(string upperMessageId)
        {
            if (string.IsNullOrEmpty(upperMessageId))
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter is empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            Guid guid = Guid.Empty;
            Guid.TryParse(upperMessageId, out guid);
            if (guid == Guid.Empty)
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter is not valid format", SharedLibrary.ResponseDtos.StatusCode.BadRequest));

            var entities = _messageReadRepository.GetWhere(i => !i.Deleted && i.UpperMessageId.HasValue && i.UpperMessage.UpperMessageId.Value == guid);
            if (entities is not null && entities.Count() > 0)
                return CreateActionResultInstance(OperationResult<List<GetMessageDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetMessageDto>>(entities.OrderBy(i => i.CreatedDate))));
            return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Could not found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(AddMessageDto addMessageDto)
        {
            if (!ModelState.IsValid)
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Model is not valid", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var entity = await _messageWriteRepository.AddAsync(ObjectMapper.Mapper.Map<Domain.Entities.Message>(addMessageDto));
            var save = await _messageWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance<GetMessageDto>(OperationResult<GetMessageDto>.CreatedSuccessResult(ObjectMapper.Mapper.Map<GetMessageDto>(entity)));
            return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Could not add", SharedLibrary.ResponseDtos.StatusCode.Error));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(string id)
        {
            if (id == null)
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter is empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            Guid guid = Guid.Empty;
            Guid.TryParse(id, out guid);
            if(guid == Guid.Empty)
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter format is wrong", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var entity = await _messageReadRepository.GetByIdAsync(id);
            if(entity == null)
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Could not found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
            return CreateActionResultInstance<GetMessageDto>(OperationResult<GetMessageDto>.OkSuccessResult(ObjectMapper.Mapper.Map<GetMessageDto>(entity)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            if (string.IsNullOrEmpty(id))
                return CreateActionResultInstance<NoContent>(OperationResult<NoContent>.CreateFailure("Parameter is empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            await _messageWriteRepository.RemoveAsync(id);
            var res = await _messageWriteRepository.SaveAsync();
            if (res > 0)
                return CreateActionResultInstance(OperationResult<NoContent>.NoContentSuccessResult());
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("could not deleted", SharedLibrary.ResponseDtos.StatusCode.Error));

        }
    }
}
