using Microsoft.EntityFrameworkCore;
using System;

namespace lab_9
{
    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int EditionYear { get; set; }
    }

    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class AppContet : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DATASOURCE=D:\database\data.db");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
