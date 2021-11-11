namespace ExamAutomation.Domain.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int ExamId { get; set; }
        
        public Exams Exams { get; set; }
    }
}