using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sulfur.Models.Db
{
    public interface IDbContext
    {
        DbSet<UrlPayload> UrlPayloads { get; set; }
    }
}
