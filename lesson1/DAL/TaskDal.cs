using lesson1.models;
using lesson3.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Data.SqlClient;
using TasksApi.Services.Logger;


namespace lesson1.DAL
{
    public class TaskDal : ITaskDal
    {
        private readonly string _connectionString;
        private readonly ILoggerService _logger;
        private readonly TasksDBContext _context;

        public TaskDal(IConfiguration configuration, ILoggerService logger, TasksDBContext context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
            _context = context;
        }

        

   
        public List<Tasks> GetTasks()
        {
            _logger.Log("Create User start:");
            return _context.Tasks.ToList();
        }
        public List<Tasks> GetByUser(int id)
        {
            var task = _context.Tasks.Where(x => x.UserId == id);
            if (task == null)
                return new List<Tasks>();
            return task.ToList();
        }
        public bool AddTaskOne(Tasks t)
        {
            Project? project = _context.Project.Find(t.ProjectId);
            User? user = _context.User.Find(t.UserId);
            if (project != null && user != null)
            {
              
                _context.Tasks.Add(t);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Add(Tasks tasks)
        {
            Project? project = _context.Project.Find(tasks.ProjectId);
            User? user = _context.User.Find(tasks.UserId);
            if (project != null && user != null)
            {
                _logger.Log($"Create User start:{tasks.Priority}");
                _context.Tasks.Add(tasks);
                _context.SaveChanges();
                return true;
            }
            return false;

 
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
        //public bool ProcessTransaction(Attachment attachment, Tasks task)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        SqlTransaction transaction = connection.BeginTransaction();

        //        try
        //        {
        //            using (SqlCommand command1 = new SqlCommand("INSERT INTO Tasks (Priority, DueDate, Status, ProjectId, UserId) VALUES (@Priority, @DueDate, @Status, @ProjectId, @UserId)", connection, transaction))
        //            {
        //                command1.Parameters.AddWithValue("@Priority", task.Priority);
        //                command1.Parameters.AddWithValue("@DueDate", task.DueDate);
        //                command1.Parameters.AddWithValue("@Status", task.Status);
        //                command1.Parameters.AddWithValue("@ProjectId", task.ProjectId);

        //                command1.ExecuteNonQuery();
        //            }

        //            using (SqlCommand command2 = new SqlCommand("INSERT INTO Attachments (AttachPath, UploadDate) VALUES (@AttachPath, @UploadDate)", connection, transaction))
        //            {
        //                command2.Parameters.AddWithValue("@AttachPath", attachment.AttachPath);
        //                command2.Parameters.AddWithValue("@UploadDate", attachment.UploadDate);
        //                command2.ExecuteNonQuery();
        //            }

        //            transaction.Commit();
        //            Console.WriteLine("Transaction committed.");
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return false;
        //        }
        //    }
        //}
    }
}
