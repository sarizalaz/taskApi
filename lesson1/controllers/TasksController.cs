using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lesson1.models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using System.Net.NetworkInformation;
using lesson1.Services;


namespace lesson1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _tasksService;

        public TasksController(ITaskService tasksService)
        {
            _tasksService = tasksService;
        }

        //get : api/Tasks
        [HttpGet]
        public ActionResult<IEnumerable<Tasks>> GetTasks()
        {
            return _tasksService.GetTasks();

        }
        [HttpGet("/{userId}")]

        public List<Tasks> GetByUser(int userId)
        {
            var task = _tasksService.GetByUser(userId);
            return task;
        }
        // get : api/Tasks/{id}
        [HttpGet("{status1}")]
        public ActionResult<List<Tasks>> GetTask(string status1)
        {
            var tasks = _tasksService.GetTasks(status1);
            return tasks;
        }


        [HttpPost]
        public bool AddTaskOne(Tasks t)
        {
            return _tasksService.AddTaskOne(t);
        }
        //post : api/Tasks/{updateTask}
        [HttpPut("{updateTask}")]
        public ActionResult<Tasks> UpdateTask(Tasks updateTask)
        {
            var tasks = _tasksService.UpdateTask(updateTask);

            //var task = tasks.FirstOrDefault(x => x.Id == updateTask.Id);
            //task.Status = updateTask.Status;

            return Ok(tasks);
        }

        //post : api/Tasks/{id

        [HttpDelete("{id}")]
        public ActionResult<Tasks> DeleteTask(int id)
        {
            _tasksService.DeleteTask(id);

            return Ok();
        }
        //[HttpPost]
        //public IActionResult Create([FromBody] AttachmentWithTask model)
        //{
        //    if (model == null || model.attachment == null || model.Tasks == null)
        //    {
        //        return BadRequest("Attachment and Task are required.");
        //    }

        //    bool success = _tasksService.Create(model);
        //    if (success)
        //    {
        //        return Ok("Transaction completed successfully.");
        //    }
        //    return StatusCode(500, "Failed to process transaction.");
        //}


    }  
}
