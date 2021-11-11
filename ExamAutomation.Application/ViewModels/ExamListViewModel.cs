using System.Collections.Generic;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.ViewModels
{
    public class ExamListViewModel
    {
        public IEnumerable<ExamViewModel> ExamViewModels { get; set; }
    }
}