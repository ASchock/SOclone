using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StackOverflow.DAL;
using StackOverflow.Models;

namespace StackOverflow.Controllers
{
    public class AnswersController : Controller
    {
        private StackOverflowContext db = new StackOverflowContext();

         // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddAnswerViewModel answer)
        {
            if (ModelState.IsValid)
            {
                Question question = await db.Questions.SingleAsync(x => x.Id == answer.QuestionId);
                question.Answers.Add(new Answer(answer.Text));
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Questions", new { id = answer.QuestionId });
            }

            return View(answer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
