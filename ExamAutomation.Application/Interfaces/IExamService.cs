using ExamAutomation.Application.ViewModels;

namespace ExamAutomation.Application.Interfaces
{
    public interface IExamService
    {
        ExamListViewModel GetAllExams();
    }
}