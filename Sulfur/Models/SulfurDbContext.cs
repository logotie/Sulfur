using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Models
{
    public class SulfurDbContext : DbContext
    {
        //DbContext is primary class responsible for database operations
        public SulfurDbContext(DbContextOptions<SulfurDbContext> options) : base(options)
        {

        }

        //DbSet acts like a table in the database, collection of UrlPayload objects
        public DbSet<UrlPayload> UrlPayloads { get; set; }
    }
}
