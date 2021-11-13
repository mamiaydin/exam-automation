using System.Collections.Generic;
using System.ComponentModel;

namespace ExamAutomation.Domain.Models
{
    public class Questions
    {
        public int Id { get; set; }
        [DisplayName("Question")]
        public string Question { get; set; }
        [DisplayName("A Option")]
        public string AnsA { get; set; }
        [DisplayName("B Option")]
        public string AnsB { get; set; }
        [DisplayName("C Option")]
        public string AnsC { get; set; }
        [DisplayName("D Option")]
        public string AnsD { get; set; }
        [DisplayName("True Answer")]
        public string Answer { get; set; }

        public int ExamsId { get; set; }

        public Exams Exams { get; set; }
    }
}