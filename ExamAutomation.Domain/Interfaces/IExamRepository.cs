using System.Collections.Generic;
using System.Threading.Tasks;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Domain.Interfaces
{
    public interface IExamRepository
    {
        IEnumerable<Exams> GetAll();
        Exams Get(int? id);

        void AddExamList(List<Exams> exams);
    }
}