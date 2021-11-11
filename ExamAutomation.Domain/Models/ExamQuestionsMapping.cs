using System.Collections.Generic;

namespace ExamAutomation.Domain.Models
{
    public class ExamQuestionsMapping
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public Exams Exam { get; set; }
        public virtual Questions Question {get; set; }
    }
}