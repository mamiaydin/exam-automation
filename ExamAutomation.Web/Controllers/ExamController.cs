using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamAutomation.Application.Interfaces;
using ExamAutomation.Application.ViewModels;
using ExamAutomation.Domain.Models;
using ExamAutomation.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamAutomation.Web.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
       private readonly AppDbContext _context;
       private readonly IExamService _examService;
       private readonly IQuestionService _questionService;

        public ExamController(AppDbContext context, IExamService examService, IQuestionService questionService)
        {
            _context = context;
            _examService = examService;
            _questionService = questionService;
        }

        // GET: Exam
        public async Task<IActionResult> Index()
        {
            var exams = _examService.GetAllExams();
            var examListViewModel = new List<ExamViewModel>();
            
            foreach (var exam in exams)
            {
                var questions = _questionService.GetRelatedQuestions(exam.Id);
                var examViewModel = new ExamViewModel
                {
                    Exam = exam,
                    Questions = questions
                };
                examListViewModel.Add(examViewModel);
            }
            var model = new ExamListViewModel
            {
                ExamViewModels = examListViewModel
            };

            return View(model);
        }

        // GET: exm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // GET: exm/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Exams exams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exams);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var exams = await _context.Exams.FindAsync(id);
            
            if (exams == null)
            {
                return NotFound();
            }
            return View(exams);
        }
        
        public async Task<IActionResult> EditExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var exams = await _context.Exams.FindAsync(id);
            
            if (exams == null)
            {
                return NotFound();
            }
            return View(exams);
        }
        
        

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Exams exams)
        {
            if (id != exams.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamsExists(exams.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exams);
        }
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exams = await _context.Exams.FindAsync(id);
            _context.Exams.Remove(exams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamsExists(int id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }
    }
}