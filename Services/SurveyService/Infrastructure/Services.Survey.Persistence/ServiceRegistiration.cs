using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Survey.Application.Repositories.ReadRepositories;
using Services.Survey.Application.Repositories.WriteRepositories;
using Services.Survey.Persistence.Repositories.ReadRepositories;
using Services.Survey.Persistence.Repositories.WriteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Survey.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Contexts.SurveyServiceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IAnswerReadRepository, AnswerReadRepository>();
            services.AddScoped<IAnswerWriteRepository, AnswerWriteRepository>();
            services.AddScoped<IMainSurveyReadRepository, MainSurveyReadRepository>();
            services.AddScoped<IMainSurveyWriteRepository, MainSurveyWriteRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();
            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionContentReadRepository, QuestionContentReadRepository>();
            services.AddScoped<IQuestionContentWriteRepository, QuestionContentWriteRepository>();
        }
    }
}
