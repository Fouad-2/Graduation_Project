using GradFinalProject.Models;
using GradFinalProject.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradFinalProject.Controllers
{
    public class CommentController : Controller
    {
        public IRepository<Comment> Comment { get; }
        public CommentController(IRepository<Comment> _Comment)
        {
            Comment = _Comment;
        }

        // GET: CommentController
        public ActionResult Index()
        {
            return View(Comment.View());
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View(Comment.Find(id));
        }

        // GET: CommentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment collection)
        {
            try
            {
                Comment.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Comment.Find(id));
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Comment collection)
        {
            try
            {
                Comment.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Comment.Find(id));
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Comment collection)
        {
            try
            {
                Comment.Delete(id, collection); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
