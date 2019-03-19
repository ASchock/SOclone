using StackOverflow.DAL;
using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        private StackOverflowContext db = new StackOverflowContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Questions.Select(x => new QuestionSummaryViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                CategoryName = x.Category.Name,
                VoteCount = x.VoteCount,
                AnswerCount = x.Answers.Count(),
                ViewCount = x.ViewCount,
                Asked = x.Asked
            }).ToListAsync());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}