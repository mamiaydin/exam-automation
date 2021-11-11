using System.Collections.Generic;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<Questions> GetAll();
    }
}