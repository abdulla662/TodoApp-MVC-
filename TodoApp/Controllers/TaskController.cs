using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TaskController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            var data = dbContext.Items;
            return View(data.ToList());
        }
        [HttpPost]
        public IActionResult SaveTaskData(TaskItem task)
        {
            if (task != null) {

                dbContext.Items.Add(task);
                dbContext.SaveChanges();
            }

            return RedirectToAction("index", "Task");
        }

        [HttpPost]
        public IActionResult Delete(int TaskId)
        {
            var task = dbContext.Items.FirstOrDefault(e => e.Id == TaskId);
            if (task != null)
            {
                dbContext.Items.Remove(task);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Task");

        }
        public IActionResult EditTaskView(int TaskId)
 {
     var task = dbContext.Items.FirstOrDefault(e => e.Id == TaskId);

     if (task != null) { 
     return View(task);
     }
     return RedirectToAction("error", "Home");

 }
        public IActionResult SaveEditedData(TaskItem task) {
            if (task != null) {
                dbContext.Items.Update(task);
                dbContext.SaveChanges();
                return RedirectToAction("index", "task");
            }

            return RedirectToAction("error", "Home");



        }
        [HttpPost]
        public IActionResult MarkCompleted(int TaskID)
        {
            var task = dbContext.Items.FirstOrDefault(e => e.Id == TaskID);
            if (task != null) {
                task.Status = !task.Status;
                dbContext.SaveChanges();
                return RedirectToAction("index", "Task");

            }
            return RedirectToAction("error", "Home");


        }
        [HttpGet]
        public IActionResult search(string keyword) {
            var data = dbContext.Items
              .Where(e => e.Title.Contains(keyword))
              .ToList();
            return View("Index", data.ToList());


        }


    }
}
