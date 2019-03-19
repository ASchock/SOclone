using StackOverflow.DAL;
using StackOverflow.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StackOverflow.Controllers
{
    public class QuestionsController : Controller
    {
        private StackOverflowContext db = new StackOverflowContext();

        // GET: Questions
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

        // GET: Questions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            question.ViewCount += 1;
            await db.SaveChangesAsync();
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            CreateQuestionViewModel viewModel = new CreateQuestionViewModel()
            {
                Categories = db.Categories.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name })
            };
            return View(viewModel);
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateQuestionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Category selectedCategory = await db.Categories.SingleAsync(x => x.Id == viewModel.SelectedCategory);
                db.Questions.Add(new Question(viewModel.Title, viewModel.Text, selectedCategory));
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Questions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Text,Asked,ViewCount,AnswerCount,VoteCount")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Question question = await db.Questions.FindAsync(id);
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
