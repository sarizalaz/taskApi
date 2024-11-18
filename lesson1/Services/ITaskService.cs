using lesson1.models;
using Microsoft.AspNetCore.Mvc;

namespace lesson1.Services
{
    public interface ITaskService
    {
        List<Tasks> GetTasks(string status1);
        List<Tasks> AddTasks(Tasks newTask);
        public List<Tasks> UpdateTask(Tasks updateTask);
        public List<Tasks> DeleteTask(int id);
        public List<Tasks> GetTasks();
        public List<Tasks> GetByUser(int id);
        public string AddTaskOne(Tasks t);

    }
}
