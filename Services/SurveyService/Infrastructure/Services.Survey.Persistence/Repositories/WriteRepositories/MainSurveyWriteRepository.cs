using Services.Survey.Application.Repositories.WriteRepositories;
using Services.Survey.Domain.Entities;
using Services.Survey.Persistence.Contexts;
using Services.Survey.Persistence.Repositories.BaseRepositories;

namespace Services.Survey.Persistence.Repositories.WriteRepositories
{
    public class MainSurveyWriteRepository : WriteRepository<MainSurvey>, IMainSurveyWriteRepository
    {
        public MainSurveyWriteRepository(SurveyServiceDbContext context) : base(context)
        {
        }
    }
}
