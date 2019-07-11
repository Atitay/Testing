using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Testing.Models;

namespace Testing.DAL
{
    public class TestingDbContext : DbContext
    {
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionExam> QuestionExams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=Testing;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

    }
    
}
