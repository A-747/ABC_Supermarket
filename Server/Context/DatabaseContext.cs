using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Supermarket.Shared.Models;


namespace ABC_Supermarket.Server.Context
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext(DbContextOptions options) : base(options) { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<ItemDetails> Item { get; set; }
    }
}
