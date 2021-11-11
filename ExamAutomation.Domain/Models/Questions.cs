using System.Collections.Generic;
using System.ComponentModel;

namespace ExamAutomation.Domain.Models
{
    public class Questions
    {
        public int Id { get; set; }
        [DisplayName("Soru")]
        public string Question { get; set; }
        [DisplayName("A Şıkkı")]
        public string AnsA { get; set; }
        [DisplayName("B Şıkkı")]
        public string AnsB { get; set; }
        [DisplayName("C Şıkkı")]
        public string AnsC { get; set; }
        [DisplayName("D Şıkkı")]
        public string AnsD { get; set; }
        [DisplayName("Doğru Cevap")]
        public string Answer { get; set; }

        public int ExamsId { get; set; }
    }
}