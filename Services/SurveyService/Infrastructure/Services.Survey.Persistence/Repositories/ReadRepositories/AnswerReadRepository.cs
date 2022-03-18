using Services.Survey.Application.Repositories.ReadRepositories;
using Services.Survey.Domain.Entities;
using Services.Survey.Persistence.Contexts;
using Services.Survey.Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Persistence.Repositories.ReadRepositories
{
    public class AnswerReadRepository : ReadRepository<Answer>, IAnswerReadRepository
    {
        public AnswerReadRepository(SurveyServiceDbContext context) : base(context)
        {
        }
    }
}
