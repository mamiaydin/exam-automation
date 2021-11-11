using System.Collections.Generic;
using System.Linq;
using ExamAutomation.Domain.Interfaces;
using ExamAutomation.Domain.Models;
using ExamAutomation.Infra.Data.Context;

namespace ExamAutomation.Infra.Data.Repositories
{
    public class QuestionRepository :IQuestionRepository
    {
        private readonly AppDbContext _appDbContext;

        public QuestionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Questions> GetAll()
        {
            return _appDbContext.Questions;
            
        }
        
    }
}