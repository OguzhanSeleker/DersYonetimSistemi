using Services.Survey.Application.Repositories.WriteRepositories;
using Services.Survey.Domain.Entities;
using Services.Survey.Persistence.Contexts;
using Services.Survey.Persistence.Repositories.BaseRepositories;

namespace Services.Survey.Persistence.Repositories.WriteRepositories
{
    public class QuestionWriteRepository : WriteRepository<Question>, IQuestionWriteRepository
    {
        public QuestionWriteRepository(SurveyServiceDbContext context) : base(context)
        {
        }
    }
}
