using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamAutomation.Application.Interfaces;
using ExamAutomation.Application.ViewModels;
using ExamAutomation.Domain.Models;
using ExamAutomation.Infra.Data.Context;
using ExamAutomation.Web.Models;
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



        // GET: exm/Create
        public  IActionResult Create()
        {
             _examService.GetDataFromWired();
             return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> SolveExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var model = _examService.GetExam(id);
            
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
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
            _questionService.DeleteRelatedQuestions(id);
            
            var exams = await _context.Exams.FindAsync(id);
            _context.Exams.Remove(exams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        
        [HttpPost]
        [Route("Exam/Result")]
        public JsonResult AjaxPost(AxajPostModel formData)
        {
            var relatedQuestions =
                _questionService.GetRelatedQuestions(formData.ExamId).OrderBy(x => x.Question).ToList();
            var relatedQuestionsAnswers = relatedQuestions.Select(x => x.Answer).ToList();
            
            return Json(new { Ans1 = relatedQuestionsAnswers[0] , Ans2 = relatedQuestionsAnswers[1], Ans3 = relatedQuestionsAnswers[2], Ans4 = relatedQuestionsAnswers[3]});
        }
    }
}