using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Models
{
    public class SulfurContext : DbContext
    {
        //DbContext is primary class responsible for database operations
        public SulfurContext(DbContextOptions<SulfurContext> options) : base(options)
        {

        }

        //DbSet acts like a table in the database, collection of UrlPayload objects
        public DbSet<UrlPayload> UrlPayloads { get; set; }
    }
}
