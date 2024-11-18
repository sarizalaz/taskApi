using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using lesson1.models;
using Microsoft.EntityFrameworkCore;

namespace lesson3.DAL
{
    public class TasksDBContext:DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Tasks> Users { get; set; }
        public DbSet<Tasks> project { get; set; }
    }
}
