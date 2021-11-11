using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamAutomation.Application.Interfaces;
using ExamAutomation.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ExamAutomation.Web.Components
{
    public class QuestionViewComponent : ViewComponent
    {
        private readonly IQuestionService _questionService;

        public QuestionViewComponent(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int examId)
        {
            var relatedQuestions = _questionService.GetRelatedQuestions(examId);
            ViewData["ExamId"] = examId;
            return View("/Views/Exam/Components/Question/Default.cshtml",relatedQuestions);
        }
    }
}