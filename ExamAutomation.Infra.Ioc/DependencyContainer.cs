using ExamAutomation.Application.Interfaces;
using ExamAutomation.Application.Services;
using ExamAutomation.Domain.Interfaces;
using ExamAutomation.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExamAutomation.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IExamRepository, ExamRepository>();
            
            services.AddScoped<IQuestionService, QuestionService>();
            
        }
    }
}