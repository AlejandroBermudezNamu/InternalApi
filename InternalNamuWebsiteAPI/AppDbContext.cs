using InternalNamuWebsiteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalNamuWebsiteAPI.Context
{
    public class AppDbContext: DbContext
    {

            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public DbSet<User> User { get; set; }

    }
}
