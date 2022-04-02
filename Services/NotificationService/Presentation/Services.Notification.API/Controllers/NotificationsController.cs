using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Notification.Application.Repositories;
using Services.Notification.Domain.Dtos;
using Services.Notification.Domain.Mapping;
using SharedLibrary.ControllerBases;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : CustomBaseController
    {
        private readonly INotificationReadRepository _notificationReadRepository;
        private readonly INotificationWriteRepository _notificationWriteRepository;

        public NotificationsController(INotificationReadRepository notificationReadRepository, INotificationWriteRepository notificationWriteRepository)
        {
            _notificationReadRepository = notificationReadRepository;
            _notificationWriteRepository = notificationWriteRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Parameter is Empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var notification = await _notificationReadRepository.GetByIdAsync(id);
            if (notification != null)
                return CreateActionResultInstance(OperationResult<GetNotificationDto>.OkSuccessResult(ObjectMapper.Mapper.Map<GetNotificationDto>(notification)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could not found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
        }
        [HttpPost]
        public async Task<IActionResult> AddNotification(AddNotificationDto addNotificationDto)
        {
            if (!ModelState.IsValid)
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Model is not valid", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var addedEntity = await _notificationWriteRepository.AddAsync(ObjectMapper.Mapper.Map<Notification.Domain.Entities.Notication>(addNotificationDto));
            var save = await _notificationWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance(OperationResult<GetNotificationDto>.CreatedSuccessResult(ObjectMapper.Mapper.Map<GetNotificationDto>(addedEntity)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could not added", SharedLibrary.ResponseDtos.StatusCode.Error));
        }
        [HttpGet]
        [Route("GetNotificationListByCourseId/{CourseId}")]
        public IActionResult GetNotificationListByCourseId(string CourseId)
        {
            if (string.IsNullOrEmpty(CourseId))
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Parameter is empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var noticationList = _notificationReadRepository.GetWhere(i => i.CourseId == Guid.Parse(CourseId)).OrderByDescending(i => i.Priority);
            if (noticationList != null && noticationList.Count() > 0)
                return CreateActionResultInstance(OperationResult<List<GetNotificationDto>>.OkSuccessResult(ObjectMapper.Mapper.Map<List<GetNotificationDto>>(noticationList)));
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could Not found", SharedLibrary.ResponseDtos.StatusCode.NotFound));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveNotification(string id)
        {
            if (string.IsNullOrEmpty(id))
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Parameter is Empty", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            await _notificationWriteRepository.RemoveAsync(id);
            var save = await _notificationWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance(OperationResult<NoContent>.NoContentSuccessResult());
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could not deleted", SharedLibrary.ResponseDtos.StatusCode.Error));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            if (!ModelState.IsValid)
                return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Model is not valid", SharedLibrary.ResponseDtos.StatusCode.BadRequest));
            var update =  _notificationWriteRepository.Update(ObjectMapper.Mapper.Map<Domain.Entities.Notication>(updateNotificationDto));
            int save = 0;
            if (update)
                save = await _notificationWriteRepository.SaveAsync();
            if (save > 0)
                return CreateActionResultInstance(OperationResult<NoContent>.NoContentSuccessResult());
            return CreateActionResultInstance(OperationResult<NoContent>.CreateFailure("Could not Updated", SharedLibrary.ResponseDtos.StatusCode.Error));

        }

    }
}
