using System.Collections.Generic;

namespace ExamAutomation.Domain.Models
{
    public class Exams
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }

    }
    

    
}