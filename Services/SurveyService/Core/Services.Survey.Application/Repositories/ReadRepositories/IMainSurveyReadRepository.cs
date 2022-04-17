using Services.Survey.Application.Repositories.BaseRepositories;
using Services.Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Application.Repositories.ReadRepositories
{
    public interface IMainSurveyReadRepository: IReadRepository<MainSurvey>
    {
    }
}
