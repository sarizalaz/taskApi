using lesson1.models;
using Microsoft.AspNetCore.Mvc;

namespace lesson1.DAL
{
    public interface ITaskDal
    {
        List<Tasks> GetTasks();
        //void SaveTasks(List<Tasks> tasks);
        public void Add(Tasks tasks);
       
        public void Delete(int id);
         public Tasks GetById(int id);
         public void Update(Tasks tasks);
        public List<Tasks> GetByUser(int id);
        public string AddTaskOne(Tasks t);
    }
}
