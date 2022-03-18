using Services.Survey.Application.Repositories.WriteRepositories;
using Services.Survey.Domain.Entities;
using Services.Survey.Persistence.Contexts;
using Services.Survey.Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Persistence.Repositories.WriteRepositories
{
    public class AnswerWriteRepository : WriteRepository<Answer>, IAnswerWriteRepository
    {
        public AnswerWriteRepository(SurveyServiceDbContext context) : base(context)
        {
        }
    }
}
