using Services.Homework.Application.Services.BaseRepository;
using Services.Homework.Domain.Dtos;
using Services.Homework.Domain.Entities;
using SharedLibrary.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Application.Services
{
    public interface IHomeworkMetadataService : IRepository<HomeworkMetadata>
    {
    }
}
