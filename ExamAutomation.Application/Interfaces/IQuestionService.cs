using System.Collections.Generic;
using System.Linq;
using ExamAutomation.Domain.Interfaces;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.Interfaces
{
    public interface IQuestionService
    {
        List<Questions> GetRelatedQuestions(int examId);
    }
}