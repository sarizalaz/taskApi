using lesson1.models;
using lesson3.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using System.Threading.Tasks;


namespace lesson1.DAL
{
    public class TaskDal : ITaskDal
    {

        private readonly TasksDBContext _context;
        
        public TaskDal(TasksDBContext context)
        {
            _context = context;
        }

        public List<Tasks> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        public List<Tasks> GetByUser(int id)
        {
            var task = _context.Tasks.Where(x => x.UserId==id);
            if (task == null)
                return new List<Tasks>();
            return task.ToList();
        }
        public string AddTaskOne(Tasks t)
        {
            var users = _context.Users.ToList();
            var project = _context.project.ToList();
            foreach(var user in users)
            {
                if(user.Id==t.UserId)
                    foreach (var p in project)
                    {
                        if(p.Id== t.ProjectId)
                        {
                            _context.Add(t);
                            _context.SaveChanges();
                            return ("succesfull");
                        }
                       
                    }
                return ("no project exist");
            }
            return ("no user exist");
        }
        public void Add(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tasks? tasks = _context.Tasks.Find(id);

            if (tasks != null)
            {
                _context.Tasks.Remove(tasks);
                _context.SaveChanges();
            }
        }

        public Tasks GetById(int id)
        {
            Tasks? tasks = _context.Tasks.Find(id);
            return tasks;
        }

        public void Update(Tasks tasks)
        {
            _context.Tasks.Update(tasks);
            _context.SaveChanges();
        }

    }
}
