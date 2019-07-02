using Microsoft.EntityFrameworkCore;
using System;


namespace Testing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



    }

}
