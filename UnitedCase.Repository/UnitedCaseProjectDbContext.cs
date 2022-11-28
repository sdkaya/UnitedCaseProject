using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Entity.Entities;

namespace UnitedCase.Repository
{
    public class UnitedCaseProjectDbContext : DbContext
    {
        public UnitedCaseProjectDbContext(DbContextOptions<UnitedCaseProjectDbContext> options)
            : base(options)
        {
        }
        public DbSet<MainNote> MainNotes { get; set; }
        public DbSet<ChildNote> ChildNotes { get; set; }


    }
}
