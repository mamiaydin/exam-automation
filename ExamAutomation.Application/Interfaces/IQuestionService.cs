using System.Collections.Generic;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.Interfaces
{
    public interface IQuestionService
    {
        List<Questions> GetRelatedQuestions(int examId);
    }
}