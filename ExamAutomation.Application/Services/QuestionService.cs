using System.Collections.Generic;
using System.Linq;
using ExamAutomation.Application.Interfaces;
using ExamAutomation.Domain.Models;
using ExamAutomation.Infra.Data.Context;

namespace ExamAutomation.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public List<Questions> GetRelatedQuestions(int examId)
        {
           var relatedQuestions = _context.Questions.Where(x=>x.ExamsId == examId).ToList();
           return relatedQuestions;
        }
    }
}