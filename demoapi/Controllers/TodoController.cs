using System.Collections.Generic;
using System.Linq;
using demoapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {
        private readonly TodoContext _context;
        public TodoController (TodoContext context) {
            _context = context;

            if (_context.TodoItems.Count () == 0) {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add (new TodoItem { Name = "Item1" });
                _context.SaveChanges ();
            }
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll () {
            return _context.TodoItems.ToList ();
        }

        [HttpGet ("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById (long id) {
            var item = _context.TodoItems.Find (id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }
        // [HttpPost]
        // public  ActionResult<ResponseData> ValidateLogin(string id, string name){
        //     var request_ob = _res.ValidateLogin(id,name);
        //     if (request_ob == null) {
        //         return NotFound ();
        //     }
        //     return request_ob;
        // }
        [HttpPost]
        public ActionResult<RequestData> PostTest(RequestData model)
        {
            return model;
        }
    }
}