using System.Collections.Generic;
using System.Linq;
using ExamAutomation.Application.Interfaces;
using ExamAutomation.Domain.Interfaces;
using ExamAutomation.Domain.Models;

namespace ExamAutomation.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<Questions> GetRelatedQuestions(int examId)
        {
            var questions = _questionRepository.GetAll().Where(x => x.ExamId == examId).ToList();
            return questions;
        }
    }
}