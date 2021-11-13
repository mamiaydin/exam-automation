using System.Collections.Generic;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.Interfaces
{
    public interface IExamService
    {
        List<Exams> GetAllExams();
        Exams GetExam(int? examId);

        void GetDataFromWired();
    }
}