using System.Collections.Generic;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.ViewModels
{
    public class ExamViewModel
    {
        public Exams Exam { get; set; }
        public List<Questions> Questions { get; set; }
    }
}