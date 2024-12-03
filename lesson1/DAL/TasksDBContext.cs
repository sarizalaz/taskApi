using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using lesson1.models;
using Microsoft.EntityFrameworkCore;



namespace lesson3.DAL
{
    public class TasksDBContext:DbContext
    {
        public TasksDBContext()
        {

        }

        public TasksDBContext(DbContextOptions<TasksDBContext> options)
            : base(options)
        {

        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Logger> Logger { get; set; }
        //public virtual DbSet<lesson1.models.Attachments> Attachments { get; set; }
    }
   

        
    }

