using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]
    public class ExamController : Controller
    {
        private readonly TestingDbContext _db;
        protected Guid CurrentUserId => Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public ExamController(TestingDbContext db)
        {
            _db = db;
        }

        public IActionResult Detail(Guid id) => View(_db.UserExams.First(a => a.ExamId == id));
        public IActionResult QuestionAnswer(Guid id)
        { 
            var _questAnswer = _db.QuestionExams.Where(a => a.QuestionExamId == id).ToList();

            foreach (var _questAns in _questAnswer)
            {
                _questAnswer.ForEach(e =>
                {
                    if (e.ExamId == _questAns.ExamId)
                    {
                        _db.SaveChanges();
                    }

                });
                return View(_questAns);
            }
            return View(_questAnswer);
        }


        [HttpGet]
        public IActionResult Test(Guid id)
        {
            var _UserExams = _db.UserExamQuestions.Where(a => a.UserExam.ExamId == id).ToList();


            foreach (var _userExam in _UserExams)
            {
                _UserExams.ForEach(u =>
                {
                    if (u.UserExamQuestionId == _userExam.UserExamQuestionId)
                    {
                        _userExam.UserExam.StartExam();
                        _userExam.UserExam.UpdateScore();
                        _db.SaveChanges();

                    }

                });
                return View(_userExam);
            }

            return View(_UserExams);
        }

        [HttpGet]
        public object GetExamQuestion(DataSourceLoadOptions loadOptions, Guid id)
        {
            return DataSourceLoader.Load(_db.QuestionExams.Where(m => m.ExamId == id), loadOptions);
        }

        [HttpGet]
        public object GetChoice(DataSourceLoadOptions loadOptions, Guid id)
        {
            return DataSourceLoader.Load(_db.Choices.Where(u => u.QuestionId == id), loadOptions);
        }


        [HttpPost, ActionName("Test")]
        public IActionResult TestPost(Guid id, Guid questionAnswer, Guid QuestionId)
        {

            var _questionAnswer = _db.UserExamQuestions.Where(a => a.UserExam.ExamId == id).ToList();

            foreach (var _questAns in _questionAnswer)
            {
                if (_questAns.QuestionId == QuestionId)
                {

                    _questAns.SelectChoiceId = questionAnswer;
                }

                _questAns.VerifyAnswer();

            }

            _db.SaveChanges();

            return RedirectToAction("Test", new { id = id });
        }


        [HttpPost, ActionName("Detail")]
        public IActionResult DetailPost(Guid id, string examQuestion)
        {

            var _questionAnswer = _db.UserExamQuestions.Where(a => a.UserExam.ExamId == id).ToList();


            return RedirectToAction("Detail", new { id = id });
        }

    }
}