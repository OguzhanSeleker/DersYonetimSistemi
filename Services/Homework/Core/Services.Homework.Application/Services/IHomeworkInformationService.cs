using Services.Homework.Application.Services.BaseRepository;
using Services.Homework.Application.Dtos;
using Services.Homework.Domain.Entities;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Services
{
    public interface IHomeworkInformationService : IRepository<HomeworkInformation>
    {
        Task<HomeworkInformation> GetByCourseId(string courseId);
    }
}
