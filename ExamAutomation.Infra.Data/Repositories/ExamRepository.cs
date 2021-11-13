using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamAutomation.Domain.Interfaces;
using ExamAutomation.Domain.Models;
using ExamAutomation.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ExamAutomation.Infra.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Exams> GetAll()
        {
            return _appDbContext.Exams;
        }

        public Exams Get(int? id)
        {
            return _appDbContext.Exams
                .First(m => m.Id == id);
        }

        public async void AddExamList(List<Exams> exams)
        {
            foreach (var exam in exams)
            {
                _appDbContext.Add(exam);
            }
            await _appDbContext.SaveChangesAsync();
        }
        
    }
}