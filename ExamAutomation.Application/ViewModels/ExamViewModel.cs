using System.Collections.Generic;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.ViewModels
{
    public class ExamListViewModel
    {
        public IEnumerable<Exams> Exams { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
    }
}