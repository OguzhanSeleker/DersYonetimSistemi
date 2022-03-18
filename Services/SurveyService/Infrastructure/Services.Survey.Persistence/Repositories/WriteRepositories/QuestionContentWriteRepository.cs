using Services.Survey.Application.Repositories.WriteRepositories;
using Services.Survey.Domain.Entities;
using Services.Survey.Persistence.Contexts;
using Services.Survey.Persistence.Repositories.BaseRepositories;

namespace Services.Survey.Persistence.Repositories.WriteRepositories
{
    public class QuestionContentWriteRepository : WriteRepository<QuestionContent>, IQuestionContentWriteRepository
    {
        public QuestionContentWriteRepository(SurveyServiceDbContext context) : base(context)
        {
        }
    }
}
