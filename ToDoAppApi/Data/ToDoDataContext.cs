using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoAppApi.Models;

namespace ToDoAppApi.Data
{
    public class ToDoDataContext : DbContext
    {
        public ToDoDataContext(DbContextOptions<ToDoDataContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
