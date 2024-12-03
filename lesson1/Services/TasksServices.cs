using lesson1.DAL;
using lesson1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lesson1.Services
{
    public class TasksServices : ITaskService
    {
        private readonly ITaskDal _taskDal;
        public TasksServices(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
        public List<Tasks> AddTasks(Tasks newTask)
        {
            //var t = _taskDal.GetTasks();
            //Tasks task = new Tasks();
            //task.Id = t.Count + 1;
            //task.Priority = newTask.Priority;
            //task.DueDate = newTask.DueDate;
            //task.Status = newTask.Status;
            //t.Add(task);
            _taskDal.Add(newTask);
            return new List<Tasks>(); 
        }

        public List<Tasks> GetTasks(string status1)
        {
            var tasks = _taskDal.GetTasks();
            List<Tasks> task = tasks.Where(x => x.Status.Contains(status1)).ToList();
            if (task == null)
                return new List<Tasks>();
            return task;
        }

        public List<Tasks> UpdateTask(Tasks updateTask)
        {
            //var tasks = _taskDal.GetTasks();
            //var task = tasks.FirstOrDefault(x => x.Id == updateTask.Id);
            //task.Status = updateTask.Status;
            _taskDal.Update(updateTask);
            return new List<Tasks>();
        }

        public List<Tasks> DeleteTask(int id)
        {
            //var tasks = _taskDal.GetTasks();
            //tasks.Remove(tasks.FirstOrDefault(x => x.Id == id));
            _taskDal.Delete(id);
            return new List<Tasks>();
        }

        public List<Tasks> GetTasks()
        {
            var tasks = _taskDal.GetTasks();
            return tasks;
        }
        public List<Tasks> GetByUser(int id)
        {
            var task = _taskDal.GetByUser(id);
            return task;
        }
        public bool AddTaskOne(Tasks t)

        {
            return _taskDal.AddTaskOne(t);
        }
        //public bool Create(AttachmentWithTask model)
        //{
        //    return _taskDal.ProcessTransaction(model.Attachments, model.Tasks);
        //}
    }
}
