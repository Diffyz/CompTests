using System;
using System.Data.Entity;

namespace DateBaseProject
{
    public class SimpleContext : DbContext
    {
        public SimpleContext() : base("authorization")
        { }

        public DbSet<User> users { get; set; }
    }
}